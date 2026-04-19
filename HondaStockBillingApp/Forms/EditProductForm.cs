using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class EditProductForm : Form
    {
        private int productId;

        public EditProductForm(int id)
        {
            InitializeComponent();
            txtCode.ReadOnly = true;   
            productId = id;
            LoadProductData();
        }

        private void LoadProductData()
        {
            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM products WHERE ID = @id";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtCode.Text = reader["ProductCode"].ToString();
                            txtName.Text = reader["ProductName"].ToString();
                            numQty.Value = Convert.ToInt32(reader["Qty"]);
                            numMinQty.Value = Convert.ToInt32(reader["MinQty"]);
                            numPurchase.Value = Convert.ToDecimal(reader["PurchasePrice"]);
                            numSale.Value = Convert.ToDecimal(reader["SalePrice"]);
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim().ToUpper();
            string name = txtName.Text.Trim();

            // 🔹 Validate Product Code
            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("⚠ Product code cannot be empty.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return;
            }
            if (code.Length > 20)
            {
                MessageBox.Show("⚠ Product code is too long (max 20 chars).", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return;
            }

            // 🔹 Validate Product Name
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("⚠ Product name cannot be empty.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (name.Length > 100)
            {
                MessageBox.Show("⚠ Product name is too long (max 100 chars).", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            // 🔹 Validate numeric values
            if (numQty.Value < 0)
            {
                MessageBox.Show("⚠ Quantity cannot be negative.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numQty.Focus();
                return;
            }

            if (numMinQty.Value < 0)
            {
                MessageBox.Show("⚠ Minimum quantity cannot be negative.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numMinQty.Focus();
                return;
            }

            if (numPurchase.Value <= 0)
            {
                MessageBox.Show("⚠ Purchase price must be greater than 0.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPurchase.Focus();
                return;
            }

            if (numSale.Value <= 0)
            {
                MessageBox.Show("⚠ Sale price must be greater than 0.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSale.Focus();
                return;
            }

            if (numSale.Value < numPurchase.Value)
            {
                DialogResult result = MessageBox.Show(
                    "⚠ Sale price is lower than purchase price. Are you sure?",
                    "Validation Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (result == DialogResult.No) return;
            }

            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();

                // 🔹 Check duplicate ProductCode (ignore current product ID)
                string checkSql = "SELECT COUNT(*) FROM products WHERE ProductCode=@code AND ID<>@id";
                using (var checkCmd = new SqliteCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@code", code);
                    checkCmd.Parameters.AddWithValue("@id", productId);

                    long exists = (long)checkCmd.ExecuteScalar();
                    if (exists > 0)
                    {
                        MessageBox.Show("⚠ A product with this code already exists. Please use a different code.",
                                        "Duplicate Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCode.Focus();
                        return;
                    }
                }

                // 🔹 Update if validation passes
                string query = @"UPDATE products 
                                 SET ProductCode=@code, ProductName=@name, 
                                     Qty=@qty, MinQty=@minQty, 
                                     PurchasePrice=@purchase, SalePrice=@sale
                                 WHERE ID=@id";

                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@qty", (int)numQty.Value);
                    cmd.Parameters.AddWithValue("@minQty", (int)numMinQty.Value);
                    cmd.Parameters.AddWithValue("@purchase", (double)numPurchase.Value);
                    cmd.Parameters.AddWithValue("@sale", (double)numSale.Value);
                    cmd.Parameters.AddWithValue("@id", productId);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("✅ Product updated successfully!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnSave.PerformClick();
                return true; // prevent "ding" sound
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
    }
using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class AddProductForm : Form
    {
        public bool ProductAdded { get; private set; } = false;

        public AddProductForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim().ToUpper();
            string name = txtName.Text.Trim();

            // 🔹 Validate required fields
            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("⚠ Product Code is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("⚠ Product Name is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            // 🔹 Validate Qty and MinQty
            if (numQty.Value < 0)
            {
                MessageBox.Show("⚠ Quantity cannot be negative!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numQty.Focus();
                return;
            }

            if (numMinQty.Value < 0)
            {
                MessageBox.Show("⚠ Minimum Quantity cannot be negative!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numMinQty.Focus();
                return;
            }

            // 🔹 Validate Prices
            if (numPurchase.Value < 0 || numSale.Value < 0)
            {
                MessageBox.Show("⚠ Prices cannot be negative!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔹 Profitability Check
            if (numSale.Value < numPurchase.Value)
            {
                MessageBox.Show("⚠ Sale Price cannot be less than Purchase Price!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSale.Focus();
                return;
            }

            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();

                // ✅ Check for duplicate ProductCode
                string checkQuery = "SELECT COUNT(*) FROM products WHERE ProductCode = @code";
                using (var checkCmd = new SqliteCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@code", code);
                    long count = (long)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("⚠ A product with this code already exists!", "Duplicate ProductCode",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCode.Focus();
                        return;
                    }
                }

                // ✅ Insert product
                string query = @"INSERT INTO products (ProductCode, ProductName, Qty, MinQty, PurchasePrice, SalePrice)
                         VALUES (@code, @name, @qty, @minQty, @purchase, @sale)";

                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@qty", (int)numQty.Value);
                    cmd.Parameters.AddWithValue("@minQty", (int)numMinQty.Value);
                    cmd.Parameters.AddWithValue("@purchase", (double)numPurchase.Value);
                    cmd.Parameters.AddWithValue("@sale", (double)numSale.Value);

                    cmd.ExecuteNonQuery();
                }
            }

            ProductAdded = true;
            MessageBox.Show("✅ Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

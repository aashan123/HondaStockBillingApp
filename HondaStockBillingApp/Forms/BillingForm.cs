using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class BillingForm : Form
    {
        private DataTable cartTable;
        private string InvoiceNumber;

        public BillingForm()
        {
            InitializeComponent();
            InitializeCartTable();
            LoadProducts();
            txtPaid.Clear();
            txtDiscount.Clear();
            dgvCart.CellValueChanged += dgvCart_CellValueChanged;
            dgvCart.CurrentCellDirtyStateChanged += dgvCart_CurrentCellDirtyStateChanged;
            this.dgvProducts.KeyDown += dgvProducts_KeyDown;
            this.dgvCart.KeyDown += dgvCart_KeyDown;
            txtDiscount.KeyPress += txtDiscount_KeyPress;
            this.dgvProducts.CellDoubleClick += dgvProducts_CellDoubleClick;


            GenerateInvoiceNumber();
        }

        private void InitializeCartTable()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("No", typeof(int));      // row number
            cartTable.Columns.Add("Code", typeof(string));
            cartTable.Columns.Add("Name", typeof(string));
            cartTable.Columns.Add("Qty", typeof(int));
            cartTable.Columns.Add("Price", typeof(decimal));
            cartTable.Columns.Add("Total", typeof(decimal)); // qty × price

            dgvCart.DataSource = cartTable;

            // make columns editable / read-only
            dgvCart.Columns["No"].ReadOnly = true;
            dgvCart.Columns["Code"].ReadOnly = true;
            dgvCart.Columns["Name"].ReadOnly = true;
            dgvCart.Columns["Price"].ReadOnly = true;
            dgvCart.Columns["Total"].ReadOnly = true;
            dgvCart.Columns["Qty"].ReadOnly = false; // only qty can be changed

            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        // 🔍 Search box focus
        private void txtSearchProduct_GotFocus(object sender, EventArgs e)
        {
            if (txtSearchProduct.Text == "🔍 Search Product...")
            {
                txtSearchProduct.Text = "";
                txtSearchProduct.ForeColor = Color.Black;
            }
        }

        private void txtSearchProduct_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchProduct.Text))
            {
                txtSearchProduct.Text = "🔍 Search Product...";
                txtSearchProduct.ForeColor = Color.Gray;
            }
        }


        private void txtSearchProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AddSelectedProduct();
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                // move focus to product grid
                if (dgvProducts.Rows.Count > 0)
                {
                    dgvProducts.Focus();
                }
            }
        }


        private void AddSelectedProduct()
        {
            if (dgvProducts.Rows.Count == 0)
            {
                MessageBox.Show("⚠ No product found.");
                return;
            }

            DataGridViewRow selectedRow = dgvProducts.CurrentRow ?? dgvProducts.Rows[0];

            string code = selectedRow.Cells["code"].Value.ToString();
            string name = selectedRow.Cells["name"].Value.ToString();
            decimal price = Convert.ToDecimal(selectedRow.Cells["price"].Value);
            int stockQty = Convert.ToInt32(selectedRow.Cells["Qty"].Value); // from products table

            // check if product already in cart
            DataRow existing = null;
            foreach (DataRow row in cartTable.Rows)
            {
                if (row["Code"].ToString() == code)
                {
                    existing = row;
                    break;
                }
            }

            if (existing != null)
            {
                int newQty = Convert.ToInt32(existing["qty"]) + 1;

                if (newQty > stockQty)
                {
                    MessageBox.Show($"❌ Stock not available for {name}. Only {stockQty} left.");
                    return;
                }

                existing["Qty"] = newQty;
                existing["Total"] = newQty * Convert.ToDecimal(existing["price"]);
            }
            else
            {
                if (stockQty < 1)
                {
                    MessageBox.Show($"❌ {name} is out of stock.");
                    return;
                }

                int nextNo = cartTable.Rows.Count + 1;
                cartTable.Rows.Add(nextNo, code, name, 1, price, price);
            }

            UpdateTotals();
        }





        // ➕ Add Product Button
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddSelectedProduct();
        }


        // 💵 Discount change
        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

            UpdateTotals();
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        // 🔄 Update totals
        private void UpdateTotals()
        {
            decimal total = 0;

            foreach (DataRow row in cartTable.Rows)
            {
                int qty = 0;
                decimal price = 0;

                if (row["Qty"] != DBNull.Value && !string.IsNullOrWhiteSpace(row["Qty"].ToString()))
                    int.TryParse(row["Qty"].ToString(), out qty);           // <-- updated

                if (row["Price"] != DBNull.Value && !string.IsNullOrWhiteSpace(row["Price"].ToString()))
                    decimal.TryParse(row["Price"].ToString(), out price);  // <-- updated

                total += qty * price;
            }

            lblTotal.Text = $"{total}";

            decimal discount = 0, paid = 0;
            decimal.TryParse(txtDiscount.Text, out discount);

            if (!string.IsNullOrWhiteSpace(txtPaid.Text))
            {
                decimal.TryParse(txtPaid.Text, out paid);
            }

            decimal netTotal = total - discount;
            decimal change = paid - netTotal;
            label3.Text = $"{netTotal}";

            lblReturn.Text = string.IsNullOrWhiteSpace(txtPaid.Text) ? "Return: Rs 0" : $"Return: Rs {change:N2}";
        }


        // 🔍 Search products
        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchProduct.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText) || searchText == "🔍 Search Product...")
            {
                LoadProducts();
            }
            else
            {
                LoadProducts(searchText);
            }
        }

        // 💾 Save Bill

        private void btnSaveBill_Click(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty, add products before saving.");
                return;
            }

            decimal paid1 = 0;
            if (string.IsNullOrWhiteSpace(txtPaid.Text))
            {
                MessageBox.Show("❌ Please enter the Paid amount.");
                txtPaid.Focus();
                return;
            }

            if (!decimal.TryParse(txtPaid.Text, out paid1) || paid1 < 0)
            {
                MessageBox.Show("❌ Paid amount must be 0 or more.");
                txtPaid.Focus();
                return;
            }


            string customerName = txtCustomerName.Text.Trim();
            if (string.IsNullOrEmpty(customerName))
                customerName = "Walk-in Customer";

            decimal discount = 0, paid = 0, grandTotal = 0;

            // ✅ Calculate totals & check stock
            foreach (DataRow row in cartTable.Rows)
            {
                string code = Convert.ToString(row["Code"]);
                string name = Convert.ToString(row["Name"]);

                // ✅ Safe parse for Qty
                int cartQty = 1; // default
                if (row["Qty"] == DBNull.Value || string.IsNullOrWhiteSpace(Convert.ToString(row["Qty"])) ||
                    !int.TryParse(Convert.ToString(row["Qty"]), out cartQty) || cartQty <= 0)
                {
                    cartQty = 1;
                    row["Qty"] = 1; // <-- also fix it in grid instantly
                }

                // ✅ Safe parse for Price
                decimal price = 0;
                if (row["Price"] == DBNull.Value || !decimal.TryParse(Convert.ToString(row["Price"]), out price))
                    price = 0;

                decimal total = cartQty * price;
                row["Total"] = total;
                grandTotal += total;

                // 🔍 Check stock availability
                using (var checkConn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    checkConn.Open();

                    string checkStock = "SELECT Qty, ProductName FROM products WHERE ProductCode=@code";
                    using (var cmd = new SqliteCommand(checkStock, checkConn))
                    {
                        cmd.Parameters.AddWithValue("@code", code);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int stockQty = reader.GetInt32(0);
                                string pname = reader.GetString(1);

                                if (cartQty > stockQty)
                                {
                                    MessageBox.Show(
                                        $"❌ Not enough stock for {pname}. " +
                                        $"Available: {stockQty}, Requested: {cartQty}"
                                    );
                                    return; // ❌ stop saving
                                }
                            }
                            else
                            {
                                MessageBox.Show($"❌ Product {code} not found in stock!");
                                return; // ❌ stop saving
                            }
                        }
                    }
                }
            }


            decimal.TryParse(txtDiscount.Text, out discount);
            decimal.TryParse(txtPaid.Text, out paid);

            decimal netTotal = grandTotal - discount;

            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();

                    using (var tx = conn.BeginTransaction())
                    {
                        // ✅ Insert into sales
                        string insertSale = @"INSERT INTO sales 
                    (customer_name, sale_date, total, discount, paid) 
                    VALUES (@c, @d, @t, @disc, @p);
                    SELECT last_insert_rowid();";

                        long saleId;
                        using (var cmd = new SqliteCommand(insertSale, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@c", customerName);
                            cmd.Parameters.AddWithValue("@d", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                            cmd.Parameters.AddWithValue("@t", netTotal);   // ✅ save net total
                            cmd.Parameters.AddWithValue("@disc", discount);
                            cmd.Parameters.AddWithValue("@p", paid);

                            saleId = (long)cmd.ExecuteScalar();
                        }

                        // ✅ Insert items & deduct stock
                        foreach (DataRow row in cartTable.Rows)
                        {

                            decimal purchasePrice = 0;
                            using (var cmdProd = new SqliteCommand(
                                "SELECT PurchasePrice FROM products WHERE ProductCode=@code", conn, tx))
                            {
                                cmdProd.Parameters.AddWithValue("@code", row["code"]);
                                var result = cmdProd.ExecuteScalar();
                                purchasePrice = result != null ? Convert.ToDecimal(result) : 0;
                            }

                            // 2️⃣ Insert into sale_items with purchase price
                            string insertItem = @"INSERT INTO sale_items 
        (sale_id, product_code, product_name, qty, price, purchase_price) 
        VALUES (@sid, @code, @name, @qty, @price, @purchase)";
                            using (var cmd = new SqliteCommand(insertItem, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@sid", saleId);
                                cmd.Parameters.AddWithValue("@code", row["code"]);
                                cmd.Parameters.AddWithValue("@name", row["name"]);
                                cmd.Parameters.AddWithValue("@qty", row["qty"]);
                                cmd.Parameters.AddWithValue("@price", row["price"]);
                                cmd.Parameters.AddWithValue("@purchase", purchasePrice);
                                cmd.ExecuteNonQuery();
                            }



                            // ✅ Deduct stock
                            string updateStock = "UPDATE products SET Qty = Qty - @sold WHERE ProductCode = @code";
                            using (var cmd = new SqliteCommand(updateStock, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@sold", row["qty"]);
                                cmd.Parameters.AddWithValue("@code", row["code"]);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving bill: " + ex.Message);
            }

            ShowInvoicePreviewAfterSave(customerName, discount, paid, grandTotal);

            // ✅ Clear cart and reset fields after saving bill
            cartTable.Clear();
            txtCustomerName.Clear();
            txtDiscount.Clear();
            txtPaid.Clear();
            lblTotal.Text = "Total: 0";
            lblReturn.Text = "Return: Rs 0";
            txtSearchProduct.Text = "🔍 Search Product...";
            txtSearchProduct.ForeColor = Color.Gray;
            LoadProducts(); // reload stock



        }

        private void GenerateInvoiceNumber()
        {
            Random random = new Random();
            int year = DateTime.Now.Year;
            int randomNumber = random.Next(100000, 999999); // 6-digit random number
            InvoiceNumber = $"HON-{year}-{randomNumber}";
        }


        // Load products into grid
        private void LoadProducts(string filter = "")
        {
            try
            {
                using (var connection = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT  
                    ProductCode AS Code, 
                    ProductName AS Name, 
                    Qty,
                    SalePrice AS Price 
                FROM products";

                    if (!string.IsNullOrWhiteSpace(filter))
                        query += " WHERE ProductName LIKE @filter OR ProductCode LIKE @filter";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(filter))
                            command.Parameters.AddWithValue("@filter", "%" + filter + "%");

                        using (var reader = command.ExecuteReader())
                        {
                            var table = new DataTable();
                            table.Load(reader);
                            dgvProducts.DataSource = table;

                            // ✅ auto-select first row if exists
                            if (dgvProducts.Rows.Count > 0)
                            {
                                dgvProducts.ClearSelection();
                                dgvProducts.Rows[0].Selected = true;
                                dgvProducts.CurrentCell = dgvProducts.Rows[0].Cells[0];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error loading products: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            cartTable.Clear();
            txtCustomerName.Clear();
            txtDiscount.Clear();
            txtPaid.Clear();
            lblTotal.Text = "0";
            lblReturn.Text = "Return: Rs 0";
            txtSearchProduct.Text = "🔍 Search Product...";
            txtSearchProduct.ForeColor = Color.Gray;
            LoadProducts(); // reload stock
        }

        private void dgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCart.Columns[e.ColumnIndex].Name == "Qty")
            {
                DataRow row = ((DataRowView)dgvCart.Rows[e.RowIndex].DataBoundItem).Row;

                int qty = 0;
                int.TryParse(row["Qty"].ToString(), out qty);
                decimal price = Convert.ToDecimal(row["Price"]);
                row["Total"] = qty * price;

                UpdateTotals();
            }
        }


        private void dgvCart_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCart.IsCurrentCellDirty)
            {
                dgvCart.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // stop default "go to next row"
                AddSelectedProduct();       // directly add product
            }
        }

        private void lblCustomerName_Click(object sender, EventArgs e)
        {

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvCart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            // Commit any pending edit so DataBoundItem is up-to-date
            if (dgvCart.IsCurrentCellInEditMode)
            {
                dgvCart.EndEdit();
                dgvCart.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

            // If user selected full rows, delete those; otherwise delete the current row
            var rowsToDelete = new System.Collections.Generic.List<DataRowView>();

            if (dgvCart.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow gvRow in dgvCart.SelectedRows)
                {
                    var drv = gvRow.DataBoundItem as DataRowView;
                    if (drv != null && !rowsToDelete.Contains(drv))
                        rowsToDelete.Add(drv);
                }
            }
            else if (dgvCart.CurrentRow != null)
            {
                var drv = dgvCart.CurrentRow.DataBoundItem as DataRowView;
                if (drv != null)
                    rowsToDelete.Add(drv);
            }

            // Delete the DataRows (work on a copy to avoid modifying collection while iterating)
            foreach (var drv in rowsToDelete)
            {
                try
                {
                    drv.Row.Delete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting row: " + ex.Message);
                }
            }

            // Re-number the "No" column so row numbers remain sequential
            int rn = 1;
            foreach (DataRow r in cartTable.Rows)
            {
                // only update non-deleted rows
                if (r.RowState != DataRowState.Deleted)
                    r["No"] = rn++;
            }

            UpdateTotals();

            // prevent default handling (which might do something else)
            e.Handled = true;
            e.SuppressKeyPress = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty, add products before preview.");
                return;
            }

            string customerName = txtCustomerName.Text.Trim();
            if (string.IsNullOrEmpty(customerName))
                customerName = "Walk-in Customer";

            decimal discount = 0, paid = 0, grandTotal = 0, returnAmount = 0;

            foreach (DataRow row in cartTable.Rows)
            {
                int qty = Convert.ToInt32(row["Qty"]);
                decimal price = Convert.ToDecimal(row["Price"]);
                grandTotal += qty * price;
            }

            decimal.TryParse(txtDiscount.Text, out discount);
            decimal.TryParse(txtPaid.Text, out paid);

            decimal netTotal = grandTotal - discount;
            returnAmount = paid - netTotal;

            // ✅ Just open invoice form without saving to DB
            InvoiceForm invoiceForm = new InvoiceForm
            {
                CustomerName = customerName,
                SaleDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                Discount = discount,
                GrandTotal = netTotal,
                Paid = paid,
                ReturnAmount = returnAmount,
                CartItems = cartTable.Copy()
            };
            invoiceForm.ShowDialog();
            this.Show();
        }
        // 📄 One unified function for invoice preview (handles Return & Due)
        private void ShowInvoicePreviewAfterSave(
            string customerName,
            decimal discount,
            decimal paid,
            decimal grandTotal)
        {
            decimal netTotal = grandTotal - discount;
            decimal balance = paid - netTotal;  // positive = return, negative = due


            InvoicePrinter printer = new InvoicePrinter();
            printer.PrepareAndPreview(
                InvoiceNumber,
                customerName,
                DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                cartTable.Copy(),
                grandTotal,    // subtotal before discount
                discount,
                netTotal,      // final total after discount
                paid,
                balance   // keep for compatibility
            );
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (Backspace, Delete etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Allow only digits and decimal point
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // block
            }

            // Prevent multiple decimal points
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new BillingForm().Show();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {


        }
        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // make sure it's not header row
            {
                AddSelectedProduct();
            }
        }

        private void BillingForm_Load(object sender, EventArgs e)
        {

        }
    }

}

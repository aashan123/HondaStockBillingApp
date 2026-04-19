using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class StockForm : Form
    {
        private System.Windows.Forms.Timer searchTimer;
        private int pageSize = 30;        // 🔹 per page records
        private int currentPage = 0;      // 🔹 current page index (0 = first)
        private int totalRecords = 0;     // 🔹 total records count (for info)
        public StockForm()
        {
            InitializeComponent();
            dgvProducts.Sorted += (s, e) => HighlightLowStock();
            //this.WindowState = FormWindowState.Maximized;
            //dgvProducts.CellMouseEnter += dgvProducts_CellMouseEnter;
            dgvProducts.CellPainting += dgvProducts_CellPainting;
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 400; // 0.4 seconds after last key press
            searchTimer.Tick += SearchTimer_Tick;

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                searchTimer.Stop();
                LoadProducts(); // instantly show all
            }
        }
        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop(); // stop timer to prevent multiple triggers
            string search = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(search) || txtSearch.ForeColor == Color.Gray)
                LoadProducts();       // show all products
            else
                LoadProducts(search); // search results
        }

        private void dgvProducts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 🎯 Custom DELETE button
                if (dgvProducts.Columns[e.ColumnIndex].Name == "DeleteButton")
                {
                    e.PaintBackground(e.CellBounds, true);

                    Color backColor = Color.FromArgb(239, 68, 68); // red
                    if (dgvProducts.CurrentCell != null &&
                        dgvProducts.CurrentCell.RowIndex == e.RowIndex &&
                        dgvProducts.CurrentCell.ColumnIndex == e.ColumnIndex)
                    {
                        backColor = Color.FromArgb(200, 30, 30); // darker red on hover/click
                    }

                    using (Brush brush = new SolidBrush(backColor))
                        e.Graphics.FillRectangle(brush, e.CellBounds);

                    TextRenderer.DrawText(
                        e.Graphics,
                        "🗑️ Delete",
                        new Font("Segoe UI", 9F, FontStyle.Bold),
                        e.CellBounds,
                        Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );

                    e.Handled = true;
                }

                // 🎯 Custom EDIT button
                else if (dgvProducts.Columns[e.ColumnIndex].Name == "EditButton")
                {
                    e.PaintBackground(e.CellBounds, true);

                    Color backColor = Color.DarkBlue; // blue
                    if (dgvProducts.CurrentCell != null &&
                        dgvProducts.CurrentCell.RowIndex == e.RowIndex &&
                        dgvProducts.CurrentCell.ColumnIndex == e.ColumnIndex)
                    {
                        backColor = Color.Black; // darker blue on hover/click
                    }

                    using (Brush brush = new SolidBrush(backColor))
                        e.Graphics.FillRectangle(brush, e.CellBounds);

                    TextRenderer.DrawText(
                        e.Graphics,
                        "✏️ Edit",
                        new Font("Segoe UI", 9F, FontStyle.Bold),
                        e.CellBounds,
                        Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );

                    e.Handled = true;
                }
            }
        }



        private void LoadProducts(string search = "")
        {
            try
            {
                // ✅ Suspend layout and updates (huge speed gain on DataGridView)
                dgvProducts.SuspendLayout();

                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();

                    // ✅ Efficient SELECT (no formatting, formatting done in .NET)
                    string query = @"SELECT 
                                ID, 
                                ProductCode, 
                                ProductName, 
                                Qty, 
                                MinQty, 
                                PurchasePrice, 
                                SalePrice,
                                (Qty * PurchasePrice) AS TotalPurchaseValue
                             FROM products";

                    string whereClause = "";
                    if (!string.IsNullOrWhiteSpace(search))
                        whereClause = " WHERE ProductCode LIKE @search OR ProductName LIKE @search";

                    int offset = currentPage * pageSize;
                    query += whereClause + $" LIMIT {pageSize} OFFSET {offset}";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(search))
                            cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                        var dt = new DataTable();
                        using (var reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                        {
                            dt.Load(reader);
                        }

                        // ✅ Bind once (no full rebuild)
                        dgvProducts.DataSource = dt;

                        // ✅ Only setup columns once
                        if (dgvProducts.Columns["EditButton"] == null)
                        {
                            var editButton = new DataGridViewButtonColumn
                            {
                                Name = "EditButton",
                                HeaderText = "Edit",
                                Text = "✏ Edit",
                                UseColumnTextForButtonValue = true,
                                Width = 70,
                                Frozen = true
                            };
                            dgvProducts.Columns.Add(editButton);
                        }

                        if (dgvProducts.Columns["DeleteButton"] == null)
                        {
                            var deleteButton = new DataGridViewButtonColumn
                            {
                                Name = "DeleteButton",
                                HeaderText = "Delete",
                                Text = "🗑 Delete",
                                UseColumnTextForButtonValue = true,
                                Width = 70,
                                Frozen = true
                            };
                            dgvProducts.Columns.Add(deleteButton);
                        }

                        // ✅ Format numeric columns once
                        if (dgvProducts.Columns["TotalPurchaseValue"] != null)
                        {
                            dgvProducts.Columns["TotalPurchaseValue"].DefaultCellStyle.Alignment =
                                DataGridViewContentAlignment.MiddleCenter;
                            dgvProducts.Columns["TotalPurchaseValue"].DefaultCellStyle.Format = "N2";
                            dgvProducts.Columns["TotalPurchaseValue"].HeaderText = "Total (Rs)";
                        }

                        dgvProducts.Columns["EditButton"].DisplayIndex = 9;
                        dgvProducts.Columns["DeleteButton"].DisplayIndex = 9;

                        // ✅ Disable autosize on every load (major speed killer)
                        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                        // ✅ Highlight low stock
                        HighlightLowStock();
                    }

                    // ✅ Update pagination info (fast COUNT)
                    using (var countCmd = new SqliteCommand("SELECT COUNT(*) FROM products" + whereClause, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(search))
                            countCmd.Parameters.AddWithValue("@search", "%" + search + "%");

                        totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());
                    }

                    lblPage.Text = $"Page: {currentPage + 1} / {Math.Ceiling(totalRecords / (double)pageSize)}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // ✅ Resume layout for smooth UI refresh
                dgvProducts.ResumeLayout();
            }
        }








        private void HighlightLowStock()
        {
            bool lowStock = false;

            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (row.Cells["Qty"].Value != null && row.Cells["MinQty"].Value != null)
                {
                    int qty = Convert.ToInt32(row.Cells["Qty"].Value);
                    int minQty = Convert.ToInt32(row.Cells["MinQty"].Value);

                    if (qty < minQty)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightPink;
                        lowStock = true;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    }
                }
            }

            if (lowStock)
            {
                lblWarning.Text = "⚠ Low Stock Detected";
                lblWarning.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblWarning.Text = "✅ All Stock OK";
                lblWarning.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            txtSearch.Text = "🔍 Search products...";
            txtSearch.ForeColor = Color.Gray;

            // 🔹 Attach events like BillingForm
            txtSearch.GotFocus += txtSearch_GotFocus;
            txtSearch.LostFocus += txtSearch_LostFocus;

            LoadProducts();
            dgvProducts.ClearSelection(); // optional: no row pre-selected
        }

        private void txtSearch_GotFocus(object sender, EventArgs e)
        {
            if (txtSearch.Text == "🔍 Search products...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "🔍 Search products...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // If placeholder text, ignore
            if (txtSearch.ForeColor == Color.Gray || txtSearch.Text == "🔍 Search products...")
                return;

            string search = txtSearch.Text.Trim();

            try
            {
                if (string.IsNullOrWhiteSpace(search))
                    LoadProducts();       // show all products
                else
                    LoadProducts(search); // filter products
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error loading products: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            currentPage = 0;
            LoadProducts(txtSearch.Text.Trim());
            
            searchTimer.Stop();
            searchTimer.Start();
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text.Trim()); // ✅ manual search
        }

        private void lblWarning_Click(object sender, EventArgs e)
        {
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddProductForm())
            {
                addForm.ShowDialog();

                if (addForm.ProductAdded)
                {
                    LoadProducts(); // refresh grid after adding
                }
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // ignore header clicks

            var column = dgvProducts.Columns[e.ColumnIndex];
            if (column == null) return;

            // Ensure row has a valid ID
            if (dgvProducts.Rows[e.RowIndex].Cells["ID"].Value == null) return;
            int id = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["ID"].Value);

            // ✅ Detect Edit button by Name
            if (column.Name == "EditButton")
            {
                using (EditProductForm editForm = new EditProductForm(id))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadProducts(); // refresh after edit
                    }
                }
            }
            // ✅ Detect Delete button by Name
            else if (column.Name == "DeleteButton")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this product?",
                                              "Confirm Delete",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM products WHERE ID = @id";
                        using (var cmd = new SqliteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    LoadProducts(); // refresh after delete
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTotalPurchaseValue_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((currentPage + 1) * pageSize < totalRecords)
            {
                currentPage++;

                string searchText = (txtSearch.Text == "🔍 Search products...") ? "" : txtSearch.Text.Trim();
                LoadProducts(searchText);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;

                string searchText = (txtSearch.Text == "🔍 Search products...") ? "" : txtSearch.Text.Trim();
                LoadProducts(searchText);
            }
        }
    }
}

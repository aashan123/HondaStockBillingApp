using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class StockManagmentForm : Form
    {
        private DataTable stockTable;


        private int pageSize = 60;        // 🔹 per page records
        private int currentPage = 0;      // 🔹 current page index (0 = first)
        private int totalRecords = 0;     // 🔹 total records count (for info)

        public StockManagmentForm()
        {
            InitializeComponent();

            // 🔍 Live search + events
            txtSearch.TextChanged += TxtSearch_TextChanged;
            chkBelowMin.CheckedChanged += chkBelowMin_CheckedChanged;
            dgvAllStock.CellContentClick += dgvAllStock_CellContentClick;
            dgvAllStock.Sorted += dgvAllStock_Sorted;
            dgvAllStock.EnableHeadersVisualStyles = false;
        }

        private void AllStockReportForm_Load(object sender, EventArgs e)
        {
            LoadAllStock();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            currentPage = 0;
            LoadAllStock();
        }

        private void chkBelowMin_CheckedChanged(object sender, EventArgs e)
        {
            currentPage = 0;
            LoadAllStock();
        }

        private void dgvAllStock_Sorted(object sender, EventArgs e)
        {
            UpdateSummaryTotals(stockTable);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddProductForm())
            {

                addForm.ShowDialog();

                if (addForm.ProductAdded)
                {
                    LoadAllStock(); // refresh grid after adding
                }
            }
        }

        // 🔹 Load Stock List
        private void LoadAllStock()
        {
            string search = txtSearch.Text.Trim();
            bool onlyBelowMin = chkBelowMin.Checked;

            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();

                // 🔹 Build WHERE clause safely
                List<string> conditions = new List<string>();
                if (!string.IsNullOrWhiteSpace(search))
                    conditions.Add("(ProductCode LIKE @search OR ProductName LIKE @search)");
                if (onlyBelowMin)
                    conditions.Add("Qty < MinQty");

                string whereClause = conditions.Count > 0
                    ? " WHERE " + string.Join(" AND ", conditions)
                    : "";

                // 🔹 Main Query with pagination
                string query = $@"
            SELECT 
                ID,
                ProductCode,
                ProductName,
                Qty,
                MinQty,
                PurchasePrice,
                SalePrice,
                ROUND((Qty * PurchasePrice), 2) AS TotalPurchaseValue
            FROM products
            {whereClause}
            LIMIT {pageSize} OFFSET {currentPage * pageSize};";

                using (var cmd = new SqliteCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(search))
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        stockTable = new DataTable();
                        stockTable.Load(reader);
                        dgvAllStock.DataSource = stockTable;
                    }
                }

                // ✅ Add Edit/Delete Buttons (only once)
                if (!dgvAllStock.Columns.Contains("Edit"))
                {
                    DataGridViewButtonColumn editCol = new DataGridViewButtonColumn
                    {
                        Name = "Edit",
                        HeaderText = "",
                        Text = "✏️ Edit",
                        UseColumnTextForButtonValue = true,
                        Width = 60
                    };
                    dgvAllStock.Columns.Add(editCol);
                }

                if (!dgvAllStock.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteCol = new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        HeaderText = "",
                        Text = "🗑 Delete",
                        UseColumnTextForButtonValue = true,
                        Width = 70
                    };
                    dgvAllStock.Columns.Add(deleteCol);
                }

                StyleDataGrid();
                UpdateSummaryTotals(stockTable);
                HighlightLowStock();

                // ✅ Record Count for pagination (use same WHERE)
                string countQuery = "SELECT COUNT(*) FROM products " + whereClause;
                using (var countCmd = new SqliteCommand(countQuery, conn))
                {
                    if (!string.IsNullOrWhiteSpace(search))
                        countCmd.Parameters.AddWithValue("@search", "%" + search + "%");

                    totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());
                }

                lblpageno.Text = $"Page: {currentPage + 1} / {Math.Ceiling(totalRecords / (double)pageSize)}";
            }
            foreach (DataGridViewColumn col in dgvAllStock.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        // ✅ Grid Styling
        private void StyleDataGrid()
        {
            dgvAllStock.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvAllStock.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAllStock.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dgvAllStock.EnableHeadersVisualStyles = false;
            dgvAllStock.RowHeadersVisible = false;
            dgvAllStock.AllowUserToAddRows = false;
            dgvAllStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvAllStock.Columns.Contains("Edit"))
            {
                dgvAllStock.Columns["Edit"].DefaultCellStyle.BackColor = Color.LightYellow;
                dgvAllStock.Columns["Edit"].DefaultCellStyle.SelectionBackColor = Color.Khaki;
            }

            if (dgvAllStock.Columns.Contains("Delete"))
            {
                dgvAllStock.Columns["Delete"].DefaultCellStyle.BackColor = Color.MistyRose;
                dgvAllStock.Columns["Delete"].DefaultCellStyle.SelectionBackColor = Color.LightCoral;
            }

            dgvAllStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ✅ Update Summary Totals
        private void UpdateSummaryTotals(DataTable dt)
        {
            int itemCount = dt.Rows.Count;
            int lowStockCount = 0;

            foreach (DataRow r in dt.Rows)
            {
                if (int.TryParse(r["Qty"]?.ToString(), out int qty) &&
                    int.TryParse(r["MinQty"]?.ToString(), out int minQty))
                {
                    if (qty < minQty) lowStockCount++;
                }
            }

            lblTotalItems.Text = $"📦 Items: {itemCount} (⚠ {lowStockCount} below min)";
            lblTotalItems.ForeColor = lowStockCount > 0 ? Color.Red : Color.Black;
        }

        // ✅ Highlight Low Stock Rows
        private void HighlightLowStock()
        {
            bool lowStockFound = false;

            foreach (DataGridViewRow row in dgvAllStock.Rows)
            {
                if (row.Cells["Qty"].Value != null && row.Cells["MinQty"].Value != null)
                {
                    if (int.TryParse(row.Cells["Qty"].Value.ToString(), out int qty) &&
                        int.TryParse(row.Cells["MinQty"].Value.ToString(), out int minQty))
                    {
                        if (qty < minQty)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightPink;
                            row.DefaultCellStyle.SelectionBackColor = Color.LightPink;
                            lowStockFound = true;
                        }

                    }
                }
            }

            if (lowStockFound)
            {
                lblWarning.Text = "⚠ Low Stock Detected";
                lblWarning.ForeColor = Color.Red;
            }
            else
            {
                lblWarning.Text = "✅ All Stock OK";
                lblWarning.ForeColor = Color.Green;
            }
        }

        // ✅ Handle Edit/Delete Button Clicks
        private void dgvAllStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var grid = dgvAllStock;
            string column = grid.Columns[e.ColumnIndex].Name;

            int productId = Convert.ToInt32(grid.Rows[e.RowIndex].Cells["ID"].Value);

            if (column == "Edit")
            {
                EditProductForm editForm = new EditProductForm(productId);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAllStock(); // refresh grid
                }
            }
            else if (column == "Delete")
            {
                var result = MessageBox.Show("Are you sure you want to delete this product?",
                                             "Confirm Delete",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM products WHERE ID=@id";
                        using (var cmd = new SqliteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", productId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("🗑 Product deleted successfully.", "Deleted",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllStock();
                }
            }
        }





        private void dgvAllStock_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if ((currentPage + 1) * pageSize < totalRecords)
            {
                currentPage++;

                LoadAllStock();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;

                LoadAllStock();
            }
        }
    }
}

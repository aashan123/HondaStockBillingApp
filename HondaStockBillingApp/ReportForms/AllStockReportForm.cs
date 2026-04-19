using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class AllStockReportForm : Form
    {
        private DataTable stockTable;

        public AllStockReportForm()
        {
            InitializeComponent();

            // Attach live search event
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void AllStockReportForm_Load(object sender, EventArgs e)
        {
            LoadAllStock();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadAllStock();
        }

        private void chkBelowMin_CheckedChanged(object sender, EventArgs e)
        {
            LoadAllStock();
        }

        private void dgvAllStock_Sorted(object sender, EventArgs e)
        {
            UpdateSummaryTotals(stockTable);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string summary = GetSummaryText();
            ExportHelper.ExportToExcel(dgvAllStock, "Honda Stock Report", summary, "AllStockReport.xlsx");
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            string summary = GetSummaryText();
            ExportHelper.ExportToPdf(dgvAllStock, "Honda Stock Report", summary, "AllStockReport.pdf");
        }

        private void LoadAllStock()
        {
            string search = txtSearch.Text.Trim();
            bool onlyBelowMin = chkBelowMin.Checked;

            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        ProductCode,
                        ProductName,
                        Qty,
                        MinQty,
                        printf('%.2f', PurchasePrice) AS PurchasePrice,
                        printf('%.2f', SalePrice) AS SalePrice,
                        printf('%.2f', Qty * PurchasePrice) AS TotalPurchaseValue,
                        printf('%.2f', Qty * SalePrice) AS PotentialRevenue
                    FROM products
                    WHERE 1=1";

                if (!string.IsNullOrEmpty(search))
                    query += " AND (ProductCode LIKE @search OR ProductName LIKE @search)";
                if (onlyBelowMin)
                    query += " AND Qty < MinQty";

                using (var cmd = new SqliteCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(search))
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        stockTable = new DataTable();
                        stockTable.Load(reader);
                        dgvAllStock.DataSource = stockTable;
                        UpdateSummaryTotals(stockTable);
                    }
                }
            }

            StyleDataGrid();
        }

        private void StyleDataGrid()
        {
            dgvAllStock.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvAllStock.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAllStock.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvAllStock.EnableHeadersVisualStyles = false;
        }

        private void UpdateSummaryTotals(DataTable dt)
        {
            int itemCount = dt.Rows.Count;
            decimal totalStockValue = 0m;
            decimal totalPotentialRevenue = 0m;
            int lowStockCount = 0;

            foreach (DataRow r in dt.Rows)
            {
                if (decimal.TryParse(r["TotalPurchaseValue"]?.ToString() ?? "0", out decimal tp))
                    totalStockValue += tp;
                if (decimal.TryParse(r["PotentialRevenue"]?.ToString() ?? "0", out decimal pr))
                    totalPotentialRevenue += pr;

                if (int.TryParse(r["Qty"]?.ToString(), out int qty) &&
                    int.TryParse(r["MinQty"]?.ToString(), out int minQty))
                {
                    if (qty < minQty) lowStockCount++;
                }
            }

            lblTotalItems.Text = $"📦 Items: {itemCount} (⚠ {lowStockCount} below min)";
            lblTotalStockValue.Text = $"💰 Stock Value (Cost): Rs {totalStockValue:N2}";
            lblTotalPotentialRevenue.Text = $"📈 Potential Revenue: Rs {totalPotentialRevenue:N2}";

            lblTotalItems.ForeColor = lowStockCount > 0 ? Color.Red : Color.Black;
        }

        private string GetSummaryText()
        {
            return $"{lblTotalItems.Text} | {lblTotalStockValue.Text} | {lblTotalPotentialRevenue.Text}";
        }
    }
}

using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class ProductReportForm : Form
    {
        private DataTable reportTable;

        public ProductReportForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        // ---------- Event Handlers (wired in Designer) ----------
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            LoadReport(dateFromPicker.Value.Date, dateToPicker.Value.Date);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            var d = DateTime.Today;
            dateFromPicker.Value = d;
            dateToPicker.Value = d;
            LoadReport(d, d);
        }

        private void btnYesterday_Click(object sender, EventArgs e)
        {
            var d = DateTime.Today.AddDays(-1);
            dateFromPicker.Value = d;
            dateToPicker.Value = d;
            LoadReport(d, d);
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            var start = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1);
            var end = start.AddDays(6);
            dateFromPicker.Value = start;
            dateToPicker.Value = end;
            LoadReport(start, end);
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            var start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var end = start.AddMonths(1).AddDays(-1);
            dateFromPicker.Value = start;
            dateToPicker.Value = end;
            LoadReport(start, end);
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            ExportToPdf();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        // ---------- Backend: Load report ----------
        private void LoadReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();

                    string sql = @"
WITH item_lines AS (
    SELECT 
        si.sale_id,
        si.product_code,
        si.product_name,
        SUM(si.qty) AS qty,
        SUM(si.qty * si.price) AS line_gross,
        SUM(si.qty * si.purchase_price) AS line_cost,
        SUM(si.qty * (si.price - si.purchase_price)) AS line_profit
    FROM sale_items si
    GROUP BY si.sale_id, si.product_code, si.product_name
),
sale_gross AS (
    SELECT 
        s.id AS sale_id,
        IFNULL(SUM(il.line_gross), 0) AS sale_gross,
        s.discount
    FROM sales s
    LEFT JOIN item_lines il ON s.id = il.sale_id
    WHERE date(s.sale_date) BETWEEN date(@from) AND date(@to)
    GROUP BY s.id, s.discount
),
alloc AS (
    SELECT
        il.product_code   AS Code,
        il.product_name   AS Product,
        il.qty,
        il.line_gross,
        il.line_cost,
        il.line_profit,
        sg.sale_gross,
        sg.discount,
        CASE 
            WHEN sg.sale_gross > 0 
            THEN (il.line_gross * sg.discount) / sg.sale_gross 
            ELSE 0 
        END AS allocated_discount,
        il.line_profit - CASE 
            WHEN sg.sale_gross > 0 
            THEN (il.line_gross * sg.discount) / sg.sale_gross 
            ELSE 0 
        END AS net_profit_line
    FROM item_lines il
    JOIN sale_gross sg ON il.sale_id = sg.sale_id
)
SELECT 
    Code,
    Product,
    SUM(qty) AS [Total Qty],
    SUM(line_gross) AS [Gross Sales],
    SUM(line_cost) AS [Total Cost],
    SUM(allocated_discount) AS [Discount],
    SUM(net_profit_line) AS [Net Profit]
FROM alloc
GROUP BY Code, Product
ORDER BY SUM(qty) DESC;
";

                    using (var cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@from", fromDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@to", toDate.ToString("yyyy-MM-dd"));

                        using (var reader = cmd.ExecuteReader())
                        {
                            reportTable = new DataTable();
                            reportTable.Load(reader);

                            dgvProducts.Columns.Clear();
                            dgvProducts.AutoGenerateColumns = true;
                            dgvProducts.DataSource = reportTable;
                            if (dgvProducts.Columns.Contains("Discount"))
                            {
                                dgvProducts.Columns["Discount"].Visible = false;
                            }

                            // ✅ Format numeric columns to 2 decimal places
                            foreach (DataGridViewColumn col in dgvProducts.Columns)
                            {
                                if (col.Name == "Gross Sales" || col.Name == "Total Cost" ||
                                    col.Name == "Discount" || col.Name == "Net Profit")
                                {
                                    col.DefaultCellStyle.Format = "N2"; // 2 decimal places
                                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                }
                                else if (col.Name == "Total Qty")
                                {
                                    col.DefaultCellStyle.Format = "N0"; // no decimal for quantity
                                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                }
                            }
                        }
                    }

                    // ✅ Update summary after loading
                    UpdateSummary();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product report: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // ---------- Summary Calculator ----------
        private void UpdateSummary()
        {
            if (reportTable == null || reportTable.Rows.Count == 0)
            {
                lblSummary.Text = "Summary: No data found.";
                return;
            }

            var view = reportTable.DefaultView;
            if (view.Count == 0)
            {
                lblSummary.Text = "Summary: No data matches filter.";
                return;
            }

            double totalQty = 0, totalGross = 0, totalDiscount = 0, totalProfit = 0;

            foreach (DataRowView row in view)
            {
                totalQty += Convert.ToDouble(row["Total Qty"]);
                totalGross += Convert.ToDouble(row["Gross Sales"]);
                totalDiscount += Convert.ToDouble(row["Discount"]);
                totalProfit += Convert.ToDouble(row["Net Profit"]);
            }

            lblSummary.Text =
                $"Summary: Qty Sold = {totalQty:N0} | Gross Sales = Rs {totalGross:N2} | " +
                $"Discount = Rs {totalDiscount:N2} | Net Profit = Rs {totalProfit:N2}";
        }

        // ---------- Filter ----------
        private void ApplyFilter()
        {
            if (reportTable == null) return;

            string filterText = txtSearch.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(filterText))
                reportTable.DefaultView.RowFilter = "";
            else
                reportTable.DefaultView.RowFilter =
                    $"[Product] LIKE '%{filterText}%' OR [Code] LIKE '%{filterText}%'";

            // ✅ recalc summary after filtering
            UpdateSummary();
        }

        // ---------- Export wrappers ----------
        private void ExportToExcel()
        {
            ExportHelper.ExportToExcel(dgvProducts, "Honda Product Report", lblSummary.Text, "ProductReport.xlsx");
        }

        private void ExportToPdf()
        {
            ExportHelper.ExportToPdf(dgvProducts,"Honda Product Report", lblSummary.Text, "ProductReport.pdf");
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }
    }
}

using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class SalesReportForm : Form
    {
        public SalesReportForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // ✅ Open fullscreen, but still resizable
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            LoadReport(dateFromPicker.Value.Date, dateToPicker.Value.Date);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dateFromPicker.Value = DateTime.Today;
            dateToPicker.Value = DateTime.Today;
            LoadReport(DateTime.Today, DateTime.Today);
        }

        private void btnYesterday_Click(object sender, EventArgs e)
        {
            var yesterday = DateTime.Today.AddDays(-1);
            dateFromPicker.Value = yesterday;
            dateToPicker.Value = yesterday;
            LoadReport(yesterday, yesterday);
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1); // Monday
            var endOfWeek = startOfWeek.AddDays(6);
            dateFromPicker.Value = startOfWeek;
            dateToPicker.Value = endOfWeek;
            LoadReport(startOfWeek, endOfWeek);
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            var startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            dateFromPicker.Value = startOfMonth;
            dateToPicker.Value = endOfMonth;
            LoadReport(startOfMonth, endOfMonth);
        }

        private void LoadReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();

              string sql = @"
    SELECT 
        id AS SaleID,
        date(sale_date) AS Date,
        customer_name AS Customer,
        total AS Total,
        paid AS Paid,
        (CASE 
            WHEN total > paid THEN (total - paid) 
            ELSE 0 
         END) AS Unpaid
    FROM sales
    WHERE date(sale_date) BETWEEN date(@from) AND date(@to)
    ORDER BY datetime(sale_date);
";




                    using (var cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@from", fromDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@to", toDate.ToString("yyyy-MM-dd"));

                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            // ✅ Fix: clear columns before binding
                            dgvSales.Columns.Clear();
                            dgvSales.AutoGenerateColumns = true;
                            dgvSales.DataSource = dt;
                        }
                    }

                    // ✅ Summary with Profit
                    string summarySql = @"
                        SELECT 
                            IFNULL(SUM(s.total),0) AS total_sales,
                            IFNULL(SUM(s.paid),0) AS total_paid,
                            IFNULL(SUM(CASE WHEN s.total - s.paid > 0 THEN (s.total - s.paid) ELSE 0 END),0) AS total_unpaid,
                            IFNULL(SUM(CASE WHEN s.total - s.paid < 0 THEN -(s.total - s.paid) ELSE 0 END),0) AS total_overpaid,
                            IFNULL(SUM(
                                (SELECT IFNULL(SUM(si.qty * (si.price - si.purchase_price)),0)
                                 FROM sale_items si 
                                 WHERE si.sale_id = s.id) - s.discount
                            ),0) AS net_profit
                        FROM sales s
                        WHERE date(s.sale_date) BETWEEN date(@from) AND date(@to);
                    ";

                    using (var cmd = new SqliteCommand(summarySql, conn))
                    {
                        cmd.Parameters.AddWithValue("@from", fromDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@to", toDate.ToString("yyyy-MM-dd"));

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                double total = reader.GetDouble(0);
                                double paid = reader.GetDouble(1);
                                double unpaid = reader.GetDouble(2);
                                double overpaid = reader.GetDouble(3);
                                double profit = reader.GetDouble(4);

                                UpdateSummary(
                                    $"Total Sales = Rs {total:N2}   |   " +
                                    $"Total Paid = Rs {paid:N2}   |   " +
                                    $"Unpaid = Rs {unpaid:N2}   |   " +
                                    $"Net Profit = Rs {profit:N2}"
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales report: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportHelper.ExportToExcel(dgvSales, "Honda Sales Report", lblSummary.Text);
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            ExportHelper.ExportToPdf(dgvSales, "Honda Sales Report", lblSummary.Text);
        }
    }
}

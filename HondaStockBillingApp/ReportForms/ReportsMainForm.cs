using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class ReportsMainForm : Form
    {
        public ReportsMainForm()
        {
            InitializeComponent();
            LoadTodayDashboard();
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadTodayDashboard()
        {
            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    string sql = @"
SELECT
    COUNT(s.id) AS bills_count,
    IFNULL(SUM(s.total), 0) AS gross_sales,
    IFNULL(SUM(s.paid), 0) AS total_paid,
    IFNULL(SUM(s.discount), 0) AS total_discount,
    IFNULL(SUM(CASE WHEN s.total - s.paid > 0 THEN (s.total - s.paid) ELSE 0 END), 0) AS total_unpaid,
    IFNULL(SUM(CASE WHEN s.total - s.paid < 0 THEN -(s.total - s.paid) ELSE 0 END), 0) AS total_overpaid,
    IFNULL(SUM(s.item_profit - s.discount), 0) AS net_profit
FROM (
    SELECT
        s.id,
        s.total,
        s.paid,
        s.discount,
        IFNULL(SUM(si.qty * (si.price - si.purchase_price)), 0) AS item_profit
    FROM sales s
    LEFT JOIN sale_items si ON s.id = si.sale_id
    WHERE date(s.sale_date) = date('now', 'localtime')
    GROUP BY s.id, s.total, s.paid, s.discount
) AS s;
";
                    using (var cmd = new SqliteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTodayBills.Text = $"Bills: {reader.GetInt32(0)}";
                            lblTodaySales.Text = $"Today Sales: Rs {reader.GetDouble(1):N2}";
                            lblTodayPaid.Text = $"Paid: Rs {reader.GetDouble(2):N2}";
                            lblTodayUnpaid.Text = $"Unpaid: Rs {reader.GetDouble(4):N2}";
                            lblTodayNetProfit.Text = $"Net Profit: Rs {reader.GetDouble(6):N2}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void lblHondaTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnAllStock_Click(object sender, EventArgs e)
        {
            
            SetActiveButton(btnAllStock);
            var form = new AllStockReportForm();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(form);
            form.Show();
        }

        private void ReportsMainForm_Load(object sender, EventArgs e)
        {

        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnDashboard);
            LoadTodayDashboard(); // already implemented
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnSalesReport);
            var form = new SalesReportForm();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(form);
            form.Show();
        }

        private void btnProductReport_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnProductReport);

            var form = new ProductReportForm();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(form);
            form.Show();
        }

        private void btnMinStock_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnMinStock);

            var form = new MinimumStockReportForm();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(form);
            form.Show();
        }
    }
    }

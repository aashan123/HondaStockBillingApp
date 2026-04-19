using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class RestoreBillsForm : Form
    {
        private DataGridView dgvBills;
        private Button btnRestore;
        private Button btnRefresh;
        private Button btnClose;
        private Panel headerPanel;
        private Label titleLabel;
        private PictureBox logoBox;
        private Panel buttonPanel;
        private Label instructionLabel;

        // Honda Brand Colors
        private readonly Color HondaRed = Color.FromArgb(204, 0, 0);      // #CC0000
        private readonly Color HondaSilver = Color.FromArgb(169, 169, 169); // #A9A9A9
        private readonly Color HondaDarkGray = Color.FromArgb(51, 51, 51);  // #333333
        private readonly Color HondaLightGray = Color.FromArgb(245, 245, 245); // #F5F5F5

        public RestoreBillsForm()
        {
            InitializeComponent();
            LoadLastBills();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.Text = "Honda Stock - Restore Bills";
            this.Size = new Size(900, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = HondaLightGray;
            this.MinimumSize = new Size(800, 600);
            this.Icon = SystemIcons.Application;

            // Header Panel
            headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = HondaRed,
                Padding = new Padding(20, 10, 20, 10)
            };

            // Logo placeholder (you can replace with actual Honda logo)
            logoBox = new PictureBox
            {
                Size = new Size(60, 60),
                Location = new Point(20, 10),
                BackColor = Color.White,
                SizeMode = PictureBoxSizeMode.CenterImage
            };
            // Add Honda "H" text as placeholder
            logoBox.Paint += (s, e) => {
                using (var font = new Font("Arial", 24, FontStyle.Bold))
                using (var brush = new SolidBrush(HondaRed))
                {
                    var text = "H";
                    var textSize = e.Graphics.MeasureString(text, font);
                    var x = (logoBox.Width - textSize.Width) / 2;
                    var y = (logoBox.Height - textSize.Height) / 2;
                    e.Graphics.DrawString(text, font, brush, x, y);
                }
            };

            // Title Label
            titleLabel = new Label
            {
                Text = "RESTORE BILLS",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(100, 25),
                BackColor = Color.Transparent
            };

            headerPanel.Controls.Add(logoBox);
            headerPanel.Controls.Add(titleLabel);

            // Instruction Label
            instructionLabel = new Label
            {
                Text = "Select a bill from the list below to restore it and update stock quantities",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = HondaDarkGray,
                AutoSize = true,
                Location = new Point(30, 100),
                BackColor = Color.Transparent
            };

            // DataGridView
            dgvBills = new DataGridView
            {
                Location = new Point(30, 130),
                Size = new Size(840, 380),
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D,
                GridColor = Color.Black,
                CellBorderStyle = DataGridViewCellBorderStyle.Single,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = HondaDarkGray,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    SelectionBackColor = HondaDarkGray,
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.White,
                    ForeColor = HondaDarkGray,
                    Font = new Font("Segoe UI", 11),
                    SelectionBackColor = Color.FromArgb(255, 230, 230), // Light red
                    SelectionForeColor = HondaDarkGray,
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                },
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = HondaLightGray,
                    ForeColor = HondaDarkGray,
                    Font = new Font("Segoe UI", 11),
                    SelectionBackColor = Color.FromArgb(255, 230, 230),
                    SelectionForeColor = HondaDarkGray,
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                },
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeight = 45,
                RowTemplate = { Height = 40 }
            };

            // Button Panel
            buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 80,
                BackColor = HondaLightGray,
                Padding = new Padding(30, 15, 30, 15)
            };

            // Restore Button
            btnRestore = CreateStyledButton("🔄 RESTORE SELECTED BILL", HondaRed, Color.White);
            btnRestore.Location = new Point(30, 15);
            btnRestore.Size = new Size(200, 45);
            btnRestore.Click += BtnRestore_Click;

            // Refresh Button
            btnRefresh = CreateStyledButton("🔄 REFRESH", HondaSilver, Color.White);
            btnRefresh.Location = new Point(250, 15);
            btnRefresh.Size = new Size(120, 45);
            btnRefresh.Click += BtnRefresh_Click;

            // Close Button
            btnClose = CreateStyledButton("✖ CLOSE", HondaDarkGray, Color.White);
            btnClose.Location = new Point(750, 15);
            btnClose.Size = new Size(120, 45);
            btnClose.Click += (s, e) => this.Close();

            buttonPanel.Controls.Add(btnRestore);
            buttonPanel.Controls.Add(btnRefresh);
            buttonPanel.Controls.Add(btnClose);

            // Add controls to form
            this.Controls.Add(dgvBills);
            this.Controls.Add(instructionLabel);
            this.Controls.Add(buttonPanel);
            this.Controls.Add(headerPanel);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Button CreateStyledButton(string text, Color backColor, Color foreColor)
        {
            var button = new Button
            {
                Text = text,
                BackColor = backColor,
                ForeColor = foreColor,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };

            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = ControlPaint.Light(backColor, 0.1f);
            button.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(backColor, 0.1f);

            // Add hover effects
            button.MouseEnter += (s, e) => {
                button.BackColor = ControlPaint.Light(backColor, 0.2f);
            };
            button.MouseLeave += (s, e) => {
                button.BackColor = backColor;
            };

            return button;
        }

        private void LoadLastBills()
        {
            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();

                    using (var pragma = conn.CreateCommand())
                    {
                        pragma.CommandText = "PRAGMA foreign_keys = ON;";
                        pragma.ExecuteNonQuery();
                    }

                    string query = @"SELECT 
                                      id as 'Bill ID', 
                                      customer_name as 'Customer Name', 
                                      total as 'Total Amount', 
                                      sale_date as 'Sale Date' 
                                    FROM sales 
                                    ORDER BY id DESC 
                                    LIMIT 20";

                    using (var cmd = new SqliteCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dgvBills.DataSource = dt;

                        // Format columns after binding
                        if (dgvBills.Columns.Count > 0)
                        {
                            dgvBills.Columns["Bill ID"].Width = 80;
                            dgvBills.Columns["Customer Name"].Width = 200;
                            dgvBills.Columns["Total Amount"].Width = 120;
                            dgvBills.Columns["Sale Date"].Width = 150;

                            // Format currency column with center alignment
                            // Format currency column as Rs
                            if (dgvBills.Columns["Total Amount"] != null)
                            {
                                dgvBills.Columns["Total Amount"].DefaultCellStyle.Format = "N2"; // just numbers with 2 decimals
                                dgvBills.Columns["Total Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dgvBills.Columns["Total Amount"].DefaultCellStyle.ForeColor = Color.DarkGreen;

                                // Add Rs prefix manually via CellFormatting event
                                dgvBills.CellFormatting += (s, e) =>
                                {
                                    if (dgvBills.Columns[e.ColumnIndex].Name == "Total Amount" && e.Value != null)
                                    {
                                        if (decimal.TryParse(e.Value.ToString(), out decimal val))
                                        {
                                            e.Value = "Rs. " + val.ToString("N2", CultureInfo.InvariantCulture);
                                            e.FormattingApplied = true;
                                        }
                                    }
                                };
                            }


                            // Format date column with center alignment
                            if (dgvBills.Columns["Sale Date"] != null)
                            {
                                dgvBills.Columns["Sale Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error loading bills: " + ex.Message);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadLastBills();
            ShowSuccessMessage("Bills list refreshed successfully!");
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            if (dgvBills.SelectedRows.Count == 0)
            {
                ShowWarningMessage("Please select a bill to restore.");
                return;
            }

            int saleId = Convert.ToInt32(dgvBills.SelectedRows[0].Cells["Bill ID"].Value);
            string customerName = dgvBills.SelectedRows[0].Cells["Customer Name"].Value?.ToString() ?? "Unknown";
            decimal totalAmount = Convert.ToDecimal(dgvBills.SelectedRows[0].Cells["Total Amount"].Value);

            var confirmResult = MessageBox.Show(
                $"Are you sure you want to restore this bill?\n\n" +
                $"Customer: {customerName}\n" +
                $"Amount: {totalAmount:C2}\n" +
                $"Bill ID: {saleId}\n\n" +
                $"This will restore the stock quantities and delete the bill record.",
                "Confirm Restore",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                RestoreBill(saleId);
                LoadLastBills(); // refresh list
            }
        }

        private void RestoreBill(int saleId)
        {
            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();

                    // ✅ Enable foreign keys
                    using (var pragma = conn.CreateCommand())
                    {
                        pragma.CommandText = "PRAGMA foreign_keys = ON;";
                        pragma.ExecuteNonQuery();
                    }

                    using (var tx = conn.BeginTransaction())
                    {
                        // 1. Get items of this bill
                        string getItems = "SELECT product_code, qty FROM sale_items WHERE sale_id = @sid";
                        using (var cmd = new SqliteCommand(getItems, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@sid", saleId);
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string code = reader.GetString(0);
                                    int qty = reader.GetInt32(1);

                                    // 2. Restore stock
                                    string restoreStock = "UPDATE products SET Qty = Qty + @q WHERE ProductCode = @c";
                                    using (var updateCmd = new SqliteCommand(restoreStock, conn, tx))
                                    {
                                        updateCmd.Parameters.AddWithValue("@q", qty);
                                        updateCmd.Parameters.AddWithValue("@c", code);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        // 3. Delete sale (cascade will delete sale_items)
                        string deleteSale = "DELETE FROM sales WHERE id = @sid";
                        using (var cmd = new SqliteCommand(deleteSale, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@sid", saleId);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                }

                ShowSuccessMessage("Bill restored successfully! Stock quantities have been updated.");
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error restoring bill: " + ex.Message);
            }
        }

        private void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowWarningMessage(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Adjust DataGridView size on form resize
            if (dgvBills != null)
            {
                dgvBills.Size = new Size(this.ClientSize.Width - 60, this.ClientSize.Height - 290);
            }

            // Adjust button positions
            if (btnClose != null)
            {
                btnClose.Location = new Point(this.ClientSize.Width - 150, 15);
            }
        }
    }
}
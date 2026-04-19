using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Design;
using OfficeOpenXml; // ✅ Need EPPlus NuGet
using iTextSharp.text; // ✅ Need iTextSharp NuGet
using iTextSharp.text.pdf;

namespace HondaStockBillingApp
{
    public partial class MinimumStockReportForm : Form
    {
        public MinimumStockReportForm()
        {
            InitializeComponent();
            dgvMinimumStock.AllowUserToDeleteRows = true;
            dgvMinimumStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMinimumStock.MultiSelect = true;
            dgvMinimumStock.KeyDown += DgvMinimumStock_KeyDown;

        }

        private void MinimumStockReportForm_Load(object sender, EventArgs e)
        {
            LoadMinimumStock();
        }

        private void LoadMinimumStock()
        {
            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ProductCode, ProductName, Qty, MinQty, PurchasePrice 
                           FROM products
                           WHERE Qty < MinQty";

                    using (var cmd = new SqliteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);

                        // Add editable OrderQty column if not exists
                        if (!dt.Columns.Contains("OrderQty"))
                            dt.Columns.Add("OrderQty", typeof(int));

                        foreach (DataRow row in dt.Rows)
                        {
                            int qty = Convert.ToInt32(row["Qty"]);
                            int minQty = Convert.ToInt32(row["MinQty"]);
                            row["OrderQty"] = minQty - qty; // default suggestion
                        }

                        dgvMinimumStock.DataSource = dt;

                        // ✅ Allow editing
                        dgvMinimumStock.ReadOnly = false;

                        // Mark all columns except OrderQty as readonly
                        foreach (DataGridViewColumn col in dgvMinimumStock.Columns)
                        {
                            if (col.Name != "OrderQty")
                                col.ReadOnly = true;
                        }

                        // Highlight OrderQty column
                        dgvMinimumStock.Columns["OrderQty"].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                        dgvMinimumStock.Columns["OrderQty"].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading minimum stock: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // 📑 Export PDF (full grid)
        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (dgvMinimumStock.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Export PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                FileName = "MinimumStockReport.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    Paragraph title = new Paragraph("Minimum Stock Report");
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);
                    doc.Add(new Paragraph("\nDate: " + DateTime.Now.ToString("dd/MM/yyyy")));
                    doc.Add(new Paragraph("\n"));

                    PdfPTable table = new PdfPTable(dgvMinimumStock.Columns.Count);
                    table.WidthPercentage = 100;

                    // Headers
                    foreach (DataGridViewColumn col in dgvMinimumStock.Columns)
                    {
                        PdfPCell cell = new PdfPCell(
            new Phrase(col.HeaderText, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD))
        );
                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);
                    }

                    // Data
                    foreach (DataGridViewRow row in dgvMinimumStock.Rows)
                    {
                        if (row.IsNewRow) continue;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(cell.Value?.ToString() ?? "");
                        }
                    }

                    doc.Add(table);
                    doc.Close();

                    MessageBox.Show("PDF Exported Successfully!", "Export PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting PDF: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 📊 Export Excel
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvMinimumStock.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = "MinimumStockReport.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var wb = new ClosedXML.Excel.XLWorkbook())
                    {
                        DataTable dt = new DataTable();
                        foreach (DataGridViewColumn col in dgvMinimumStock.Columns)
                            dt.Columns.Add(col.HeaderText);

                        foreach (DataGridViewRow row in dgvMinimumStock.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                var newRow = dt.NewRow();
                                for (int i = 0; i < dgvMinimumStock.Columns.Count; i++)
                                    newRow[i] = row.Cells[i].Value ?? DBNull.Value;
                                dt.Rows.Add(newRow);
                            }
                        }

                        var ws = wb.Worksheets.Add("Minimum Stock");
                        ws.Cell(1, 1).InsertTable(dt, "StockData", true);
                        ws.Columns().AdjustToContents();

                        wb.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("✅ Excel Exported Successfully!", "Export Excel",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting Excel: " + ex.Message, "Export Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 📦 Export Purchase Order (only ProductCode, ProductName, OrderQty)
        private void btnExportOrderPdf_Click(object sender, EventArgs e)
        {
            if (dgvMinimumStock.Rows.Count == 0)
            {
                MessageBox.Show("No items to export.", "Export Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                FileName = "PurchaseOrder.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    var titleFont = FontFactory.GetFont("Calbri", 16, iTextSharp.text.Font.BOLD);
                    Paragraph title = new Paragraph("Honda Purchase Order List", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);
                    doc.Add(new Paragraph("\nDate: " + DateTime.Now.ToString("dd/MM/yyyy")));
                    doc.Add(new Paragraph("\n"));

                    // 🔹 Table with 5 columns (extra "Amount")
                    PdfPTable table = new PdfPTable(5);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 8, 20, 32, 20, 20 });

                    // Headers
                    string[] headers = { "No#", "Product Code", "Product Name", "Order Qty", "Amount" };
                    foreach (var header in headers)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(header, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)));
                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);
                    }

                    int serial = 1;
                    decimal grandTotal = 0;

                    foreach (DataGridViewRow row in dgvMinimumStock.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int orderQty = Convert.ToInt32(row.Cells["OrderQty"].Value ?? 0);
                        decimal purchasePrice = Convert.ToDecimal(row.Cells["PurchasePrice"].Value ?? 0);
                        decimal amount = orderQty * purchasePrice;

                        table.AddCell(serial.ToString());
                        table.AddCell(row.Cells["ProductCode"].Value?.ToString());
                        table.AddCell(row.Cells["ProductName"].Value?.ToString());
                        table.AddCell(orderQty.ToString());
                        table.AddCell(amount.ToString("N2"));

                        grandTotal += amount;
                        serial++;
                    }

                    doc.Add(table);

                    // 🔹 Add Total
                    Paragraph total = new Paragraph("\nEstimated Bill: " + grandTotal.ToString("N2"),
                        FontFactory.GetFont("Calbri", 13, iTextSharp.text.Font.BOLD));
                    total.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(total);

                    doc.Close();

                    MessageBox.Show("Purchase Order exported successfully!", "Export PDF",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting Order PDF: " + ex.Message, "Export Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvMinimumStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true; // 🔹 Prevent DataGridView's default delete

                if (dgvMinimumStock.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvMinimumStock.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            string productName = row.Cells["ProductName"].Value?.ToString();

                            DialogResult result = MessageBox.Show(
                                $"Are you sure you want to remove \"{productName}\" from the order?",
                                "Confirm Delete",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning
                            );

                            if (result == DialogResult.Yes)
                            {
                                dgvMinimumStock.Rows.Remove(row);
                            }
                        }
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMinimumStock();
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }
    }

}

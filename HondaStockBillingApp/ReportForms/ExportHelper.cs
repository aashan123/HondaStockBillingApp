using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public static class ExportHelper
    {
        // ✅ Export to Excel (your working code)
        public static void ExportToExcel(DataGridView dgv,string reportName, string summaryText, string fileName = "SalesReport.xlsx")
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Excel Workbook|*.xlsx",
                    FileName = fileName
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var wb = new XLWorkbook())
                        {
                            DataTable dt = new DataTable();
                            foreach (DataGridViewColumn col in dgv.Columns)
                                dt.Columns.Add(col.HeaderText);

                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    var newRow = dt.NewRow();
                                    for (int i = 0; i < dgv.Columns.Count; i++)
                                        newRow[i] = row.Cells[i].Value ?? DBNull.Value;
                                    dt.Rows.Add(newRow);
                                }
                            }

                            var ws = wb.Worksheets.Add(reportName);
                            ws.Cell(1, 1).InsertTable(dt, "SalesData", true);

                            int lastRow = ws.LastRowUsed().RowNumber() + 2;
                            ws.Cell(lastRow, 2).Value = summaryText;
                            ws.Range(lastRow, 1, lastRow, 2).Style.Font.Bold = true;

                            ws.Columns().AdjustToContents();

                            wb.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("✅ Excel file exported successfully!",
                            "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error exporting to Excel: " + ex.Message,
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Export to PDF
        public static void ExportToPdf(DataGridView dgv, string reportName, string summaryText, string fileName = "SalesReport.pdf")
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "PDF files|*.pdf",
                    FileName = fileName
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();

                            // Title
                            Font titleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
                            Paragraph title = new Paragraph(reportName, titleFont);
                            title.Alignment = Element.ALIGN_CENTER;
                            pdfDoc.Add(title);

                            pdfDoc.Add(new Paragraph("\n"));

                            // Table
                            PdfPTable pdfTable = new PdfPTable(dgv.Columns.Count);
                            pdfTable.WidthPercentage = 100;

                            // Header
                            foreach (DataGridViewColumn column in dgv.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText))
                                {
                                    BackgroundColor = BaseColor.LIGHT_GRAY
                                };
                                pdfTable.AddCell(cell);
                            }

                            // Data
                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        pdfTable.AddCell(cell.Value?.ToString() ?? "");
                                    }
                                }
                            }

                            pdfDoc.Add(pdfTable);

                            pdfDoc.Add(new Paragraph("\n"));

                            // Summary
                            Font summaryFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                            Paragraph summary = new Paragraph("📊 " + summaryText, summaryFont);
                            summary.Alignment = Element.ALIGN_LEFT;
                            pdfDoc.Add(summary);

                            pdfDoc.Close();
                            stream.Close();
                        }

                        MessageBox.Show("✅ PDF file exported successfully!",
                            "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error exporting to PDF: " + ex.Message,
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public class InvoicePrinter : IDisposable
    {
        // --- Data ---
        public string InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public string SaleDate { get; set; }
        public DataTable CartItems { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Paid { get; set; }
        public decimal ReturnAmount { get; set; }

        private readonly PrintDocument printDoc;

        // ✅ Fonts declared ONCE (used in both measure + print)
        private readonly Font headingFont = new Font("Calibri", 12, FontStyle.Bold);
        private readonly Font subHeadingFont = new Font("Calibri", 8, FontStyle.Regular);
        private readonly Font labelFont = new Font("Calibri", 8, FontStyle.Bold);
        private readonly Font valueFont = new Font("Calibri", 8, FontStyle.Regular);
        private readonly Font tableHeaderFont = new Font("Calibri", 8, FontStyle.Bold);
        private readonly Font tableBodyFont = new Font("Calibri", 7, FontStyle.Regular);

        public InvoicePrinter()
        {
            printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;
        }

        // ✅ Show preview directly
        public void ShowPreview()
        {
            CustomPrintPreviewForm preview = new CustomPrintPreviewForm(printDoc);
            preview.ShowDialog();
        }

        public void PrepareAndPreview(
            string invoiceNumber,
            string customerName,
            string saleDate,
            DataTable cartItems,
            decimal subTotal,
            decimal discount,
            decimal grandTotal,
            decimal paid,
            decimal returnAmount)
        {
            InvoiceNumber = invoiceNumber;
            CustomerName = customerName;
            SaleDate = saleDate;
            CartItems = cartItems;
            SubTotal = subTotal;
            Discount = discount;
            GrandTotal = grandTotal;
            Paid = paid;
            ReturnAmount = returnAmount;

            // ✅ Fixed width for 80mm thermal printers (≈72mm printable area)
            int pageWidthHundredths = 283; // 2.83 inches × 100

            // ✅ Small safe margins
            var margins = new Margins(5, 25, 3, 3);
            printDoc.DefaultPageSettings.Margins = margins;

            // --- Measure content height ---
            int finalHeightHundredths;
            using (var bmp = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(bmp))
            {
                float dpiX = g.DpiX;
                float dpiY = g.DpiY;

                float pageWidthInches = pageWidthHundredths / 100f;
                float pageWidthPixels = pageWidthInches * dpiX;
                float leftMarginPixels = margins.Left / 100f * dpiX;
                float rightMarginPixels = margins.Right / 100f * dpiX;
                float usableWidthPixels = pageWidthPixels - leftMarginPixels - rightMarginPixels;

                float y = 10f;

                // Header
                y += g.MeasureString("THE BEST HONDA GOJRA", headingFont).Height + 3;
                y += g.MeasureString("Sargodha Gujrat Road Gojra", subHeadingFont).Height + 1;
                y += g.MeasureString("0340-0222766", subHeadingFont).Height + 8;

                // Invoice meta
                y += valueFont.Height + 3;
                y += valueFont.Height + 3;
                y += valueFont.Height + 8;

                // Table header
                y += tableHeaderFont.Height + 5;

                float noWidth = 18f;
                float codeWidth = 95f;
                float nameWidth = usableWidthPixels - noWidth - codeWidth - 35f - 40f - 50f;

                if (CartItems != null && CartItems.Rows.Count > 0)
                {
                    foreach (DataRow row in CartItems.Rows)
                    {
                        StringFormat sf = new StringFormat
                        {
                            Alignment = StringAlignment.Near,
                            LineAlignment = StringAlignment.Near,
                            Trimming = StringTrimming.Word,
                            FormatFlags = StringFormatFlags.LineLimit
                        };

                        string code = row["code"]?.ToString() ?? "";
                        SizeF codeSize = g.MeasureString(code, tableBodyFont, (int)codeWidth, sf);

                        string itemName = row["name"]?.ToString() ?? "";
                        SizeF nameSize = g.MeasureString(itemName, tableBodyFont, (int)nameWidth, sf);

                        float rowHeight = Math.Max(codeSize.Height, nameSize.Height);
                        rowHeight = Math.Max(rowHeight, tableBodyFont.Height);
                        y += rowHeight + 3;
                    }
                }

                y += 10;
                y += valueFont.Height + 3;
                y += valueFont.Height + 3;
                y += valueFont.Height + 3;
                y += valueFont.Height + 3;
                if (ReturnAmount != 0) y += valueFont.Height + 3;

                finalHeightHundredths = (int)Math.Ceiling(y / dpiY * 100f);
            }

            // ✅ Apply corrected page size
            printDoc.DefaultPageSettings.PaperSize =
                new PaperSize("Receipt80", pageWidthHundredths, finalHeightHundredths);

            CustomPrintPreviewForm previewForm = new CustomPrintPreviewForm(printDoc);
            previewForm.ShowDialog();
        }

        // ✅ Print directly
        public void PrintDirect()
        {
            PrintDialog dialog = new PrintDialog
            {
                Document = printDoc,
                AllowSomePages = true,
                AllowSelection = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.PrinterSettings.Copies = 1;
                printDoc.Print();
            }
        }

        // 🔹 Draw page
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                float leftMargin = e.MarginBounds.Left;
                float usableWidth = e.MarginBounds.Width;
                float y = 10;

                // Header
                SizeF shopNameSize = e.Graphics.MeasureString("THE BEST HONDA GOJRA", headingFont);
                e.Graphics.DrawString("THE BEST HONDA GOJRA", headingFont, Brushes.Black,
                    (usableWidth - shopNameSize.Width) / 2 + leftMargin, y);
                y += shopNameSize.Height + 3;

                SizeF sub1Size = e.Graphics.MeasureString("Sargodha Gujrat Road Gojra", subHeadingFont);
                e.Graphics.DrawString("Sargodha Gujrat Road Gojra", subHeadingFont, Brushes.Black,
                    (usableWidth - sub1Size.Width) / 2 + leftMargin, y);
                y += sub1Size.Height + 1;

                SizeF sub2Size = e.Graphics.MeasureString("0340-0222766", subHeadingFont);
                e.Graphics.DrawString("0340-0222766", subHeadingFont, Brushes.Black,
                    (usableWidth - sub2Size.Width) / 2 + leftMargin, y);
                y += sub2Size.Height + 5;

                e.Graphics.DrawLine(Pens.Black, leftMargin, y, leftMargin + usableWidth, y);
                y += 3;

                float labelX1 = leftMargin;
                float valueX1 = leftMargin + 55;

                e.Graphics.DrawString("Invoice:", labelFont, Brushes.Black, labelX1, y);
                e.Graphics.DrawString(InvoiceNumber, valueFont, Brushes.Black, valueX1 + 3, y);
                y += valueFont.Height + 3;

                e.Graphics.DrawString("Customer:", labelFont, Brushes.Black, labelX1, y);
                string customerText = CustomerName ?? "Walk-in Customer";
                e.Graphics.DrawString(customerText, valueFont, Brushes.Black, valueX1 + 3, y);
                y += valueFont.Height + 3;

                e.Graphics.DrawString("Date:", labelFont, Brushes.Black, labelX1, y);
                e.Graphics.DrawString(SaleDate ?? DateTime.Now.ToString("dd/MM/yyyy"),
                    valueFont, Brushes.Black, valueX1 + 3, y);
                y += valueFont.Height + 5;

                e.Graphics.DrawLine(Pens.Black, leftMargin, y, leftMargin + usableWidth, y);
                y += 3;

                // ✅ Table layout (fixed alignment for Qty, Price, Total)
                float noX = leftMargin;
                float noWidth = 18f;

                float codeX = noX + noWidth + 3f;
                float codeWidth = 60f;

                float nameX = codeX + codeWidth + 3f;
                float nameWidth = 80f;

                float qtyX = nameX + nameWidth + 5f;
                float qtyWidth = 20f;

                float priceX = qtyX + qtyWidth + 5f;
                float priceWidth = 30f;

                float totalX = priceX + priceWidth + 5f;
                float totalWidth = 40f;

                e.Graphics.DrawString("No", tableHeaderFont, Brushes.Black, noX, y);
                e.Graphics.DrawString("Code", tableHeaderFont, Brushes.Black, codeX, y);
                e.Graphics.DrawString("Item", tableHeaderFont, Brushes.Black, nameX, y);
                e.Graphics.DrawString("Qty", tableHeaderFont, Brushes.Black, qtyX, y);
                e.Graphics.DrawString("Price", tableHeaderFont, Brushes.Black, priceX, y);
                e.Graphics.DrawString("Total", tableHeaderFont, Brushes.Black, totalX, y);

                y += tableHeaderFont.Height + 3;
                e.Graphics.DrawLine(Pens.Black, leftMargin, y, leftMargin + usableWidth, y);
                y += 2;

                if (CartItems != null && CartItems.Rows.Count > 0)
                {
                    int serialNo = 1;
                    foreach (DataRow row in CartItems.Rows)
                    {
                        decimal qty = Convert.ToDecimal(row["qty"] ?? 0);
                        decimal price = Convert.ToDecimal(row["price"] ?? 0);
                        decimal lineTotal = qty * price;

                        e.Graphics.DrawString(serialNo.ToString(), tableBodyFont, Brushes.Black, noX, y);

                        StringFormat sf = new StringFormat
                        {
                            Alignment = StringAlignment.Near,
                            LineAlignment = StringAlignment.Near,
                            Trimming = StringTrimming.Word,
                            FormatFlags = StringFormatFlags.LineLimit
                        };

                        string code = row["code"]?.ToString() ?? "";
                        RectangleF codeRect = new RectangleF(codeX, y, codeWidth, tableBodyFont.Height * 2);
                        e.Graphics.DrawString(code, tableBodyFont, Brushes.Black, codeRect, sf);
                        SizeF codeSize = e.Graphics.MeasureString(code, tableBodyFont, (int)codeWidth, sf);

                        string itemName = row["name"]?.ToString() ?? "";
                        RectangleF nameRect = new RectangleF(nameX, y, nameWidth, tableBodyFont.Height * 4);
                        e.Graphics.DrawString(itemName, tableBodyFont, Brushes.Black, nameRect, sf);
                        SizeF nameSize = e.Graphics.MeasureString(itemName, tableBodyFont, (int)nameWidth, sf);

                        float rowHeight = Math.Max(codeSize.Height, nameSize.Height);
                        rowHeight = Math.Max(rowHeight, tableBodyFont.Height);

                        StringFormat rightAlign = new StringFormat { Alignment = StringAlignment.Far };

                        e.Graphics.DrawString(qty.ToString("0"), tableBodyFont, Brushes.Black,
                            qtyX + qtyWidth-3, y, rightAlign);
                        e.Graphics.DrawString(price.ToString("0"), tableBodyFont, Brushes.Black,
                            priceX + priceWidth-4, y, rightAlign);
                        e.Graphics.DrawString(lineTotal.ToString("0"), tableBodyFont, Brushes.Black,
                            totalX + totalWidth-10, y, rightAlign);

                        y += rowHeight + 3;
                        serialNo++;
                    }
                }

                y += 5;
                e.Graphics.DrawLine(Pens.Black, leftMargin, y, leftMargin + usableWidth, y);
                y += 5;

                // ✅ Summary block (unchanged except alignment fix applied earlier)
                float summaryStartX = leftMargin + usableWidth * 0.40f;
                float valueX = leftMargin + usableWidth - 25f;
                StringFormat rightAlignSummary = new StringFormat { Alignment = StringAlignment.Far };

                e.Graphics.DrawString("Sub Total:", labelFont, Brushes.Black, summaryStartX, y);
                e.Graphics.DrawString(SubTotal.ToString("0"), valueFont, Brushes.Black, valueX, y, rightAlignSummary);
                y += valueFont.Height + 3;

                e.Graphics.DrawString("Discount:", labelFont, Brushes.Black, summaryStartX, y);
                e.Graphics.DrawString(Discount.ToString("0"), valueFont, Brushes.Black, valueX, y, rightAlignSummary);
                y += valueFont.Height + 3;

                e.Graphics.DrawString("Grand Total:", labelFont, Brushes.Black, summaryStartX, y);
                e.Graphics.DrawString(GrandTotal.ToString("0"), valueFont, Brushes.Black, valueX, y, rightAlignSummary);
                y += valueFont.Height + 3;

                e.Graphics.DrawString("Paid:", labelFont, Brushes.Black, summaryStartX, y);
                e.Graphics.DrawString(Paid.ToString("0"), valueFont, Brushes.Black, valueX, y, rightAlignSummary);
                y += valueFont.Height + 3;

                if (ReturnAmount != 0)
                {
                    string balanceLabel = ReturnAmount > 0 ? "Return:" : "Due:";
                    decimal balanceValue = Math.Abs(ReturnAmount);

                    e.Graphics.DrawString(balanceLabel, labelFont, Brushes.Black, summaryStartX, y);
                    e.Graphics.DrawString(balanceValue.ToString("0"), valueFont, Brushes.Black, valueX, y, rightAlignSummary);
                    y += valueFont.Height + 3;
                }

                y += 5;
                e.Graphics.DrawLine(Pens.Black, leftMargin, y, leftMargin + usableWidth, y);
                y += 8;

                string footer = "Thank you for your business!";
                SizeF footerSize = e.Graphics.MeasureString(footer, subHeadingFont);
                float footerX = (usableWidth - footerSize.Width) / 2 + leftMargin;
                e.Graphics.DrawString(footer, subHeadingFont, Brushes.Black, footerX, y);

                y += footerSize.Height + 5;
                e.Graphics.DrawLine(Pens.Black, leftMargin, y, leftMargin + usableWidth, y);
                y += 10;

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during printing: {ex.Message}", "Print Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void Dispose()
        {
            headingFont.Dispose();
            subHeadingFont.Dispose();
            labelFont.Dispose();
            valueFont.Dispose();
            tableHeaderFont.Dispose();
            tableBodyFont.Dispose();
            printDoc.Dispose();
        }
    }
}

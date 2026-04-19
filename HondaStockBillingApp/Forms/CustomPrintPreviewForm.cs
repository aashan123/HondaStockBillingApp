using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class CustomPrintPreviewForm : Form
    {
        private PrintPreviewControl previewControl;
        private PrintDocument printDoc;
        private Button btnPrint;

        public CustomPrintPreviewForm(PrintDocument doc)
        {
            InitializeComponent();
            this.printDoc = doc;
            InitializeCustomUI();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
        }

        private void InitializeCustomUI()
        {
            this.Text = "Print Preview";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;

            // ✅ Preview control
            previewControl = new PrintPreviewControl
            {
                Document = printDoc,
                Dock = DockStyle.Fill,
                Zoom = 1.0,
                BackColor = Color.White
            };

            // ✅ Print button
            btnPrint = new Button
            {
                Text = "Print",
                BackColor = Color.Maroon,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Width = 80,
                Height = 30,
                Left = 10,
                Top = 10
            };
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.Click += BtnPrint_Click;

            // ✅ Top panel
            Panel topPanel = new Panel
            {
                Height = 50,
                Dock = DockStyle.Top,
                BackColor = Color.WhiteSmoke
            };
            topPanel.Controls.Add(btnPrint);

            this.Controls.Add(previewControl);
            this.Controls.Add(topPanel);

            // ✅ Enable shortcuts
            this.KeyPreview = true;
            this.KeyDown += CustomPrintPreviewForm_KeyDown;

            // ✅ Mouse wheel zoom with Ctrl
            previewControl.MouseWheel += PreviewControl_MouseWheel;
        }

        // 🔹 Handle Print button
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog dialog = new PrintDialog
                {
                    Document = printDoc,
                    AllowSomePages = true,
                    AllowSelection = true
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.PrinterSettings.Copies = 1; // always 1 copy now
                    printDoc.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing: {ex.Message}", "Print Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Ctrl + Mouse Wheel zoom
        private void PreviewControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (e.Delta > 0 && previewControl.Zoom < 5.0)
                {
                    previewControl.Zoom += 0.1;
                }
                else if (e.Delta < 0 && previewControl.Zoom > 0.2)
                {
                    previewControl.Zoom -= 0.1;
                }
            }
        }

        // 🔹 Keyboard shortcuts
        private void CustomPrintPreviewForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl+P = Print
            if (e.Control && e.KeyCode == Keys.P)
            {
                BtnPrint_Click(sender, EventArgs.Empty);
                e.Handled = true;
            }
            // Ctrl+Plus = Zoom In
            if (e.Control && e.KeyCode == Keys.Add)
            {
                if (previewControl.Zoom < 5.0)
                    previewControl.Zoom += 0.1;
                e.Handled = true;
            }
            // Ctrl+Minus = Zoom Out
            if (e.Control && e.KeyCode == Keys.Subtract)
            {
                if (previewControl.Zoom > 0.2)
                    previewControl.Zoom -= 0.1;
                e.Handled = true;
            }
        }
    }
}

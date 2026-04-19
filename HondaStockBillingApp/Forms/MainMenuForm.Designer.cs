namespace HondaStockBillingApp
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnBilling;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button restoreBill;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.btnStock = new System.Windows.Forms.Button();
            this.btnBilling = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.restoreBill = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStock
            // 
            this.btnStock.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.ForeColor = System.Drawing.Color.White;
            this.btnStock.Location = new System.Drawing.Point(44, 127);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(336, 87);
            this.btnStock.TabIndex = 0;
            this.btnStock.Text = "📦 Stock Management";
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnBilling
            // 
            this.btnBilling.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBilling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnBilling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBilling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBilling.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilling.ForeColor = System.Drawing.Color.White;
            this.btnBilling.Location = new System.Drawing.Point(418, 127);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(336, 87);
            this.btnBilling.TabIndex = 1;
            this.btnBilling.Text = "💰 Billing";
            this.btnBilling.UseVisualStyleBackColor = false;
            this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);
            // 
            // btnReports
            // 
            this.btnReports.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(44, 238);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(336, 87);
            this.btnReports.TabIndex = 2;
            this.btnReports.Text = "📊 Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(418, 348);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(336, 87);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 100);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(120, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(560, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "🏍️ The Best Honda Admin Panel";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // restoreBill
            // 
            this.restoreBill.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.restoreBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.restoreBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.restoreBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restoreBill.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.restoreBill.ForeColor = System.Drawing.Color.White;
            this.restoreBill.Location = new System.Drawing.Point(418, 238);
            this.restoreBill.Name = "restoreBill";
            this.restoreBill.Size = new System.Drawing.Size(336, 87);
            this.restoreBill.TabIndex = 5;
            this.restoreBill.Text = "🔄 Restore Bill";
            this.restoreBill.UseVisualStyleBackColor = false;
            this.restoreBill.Click += new System.EventHandler(this.restoreBill_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(44, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(336, 87);
            this.button1.TabIndex = 6;
            this.button1.Text = "🔒 Change Password";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(172, 459);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(469, 57);
            this.button2.TabIndex = 7;
            this.button2.Text = "💾 Backup";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // MainMenuForm
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.restoreBill);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.btnBilling);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnLogout);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Honda Admin Panel";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        // Add this method to handle advanced styling that the designer can't handle
        private void MainMenuForm_Load(object sender, System.EventArgs e)
        {
            // Configure advanced button properties that the designer can't handle
            ConfigureButtonEffects(btnStock, System.Drawing.Color.FromArgb(220, 20, 20), System.Drawing.Color.FromArgb(180, 0, 0));
            ConfigureButtonEffects(btnBilling, System.Drawing.Color.FromArgb(220, 20, 20), System.Drawing.Color.FromArgb(180, 0, 0));
            ConfigureButtonEffects(btnReports, System.Drawing.Color.FromArgb(190, 190, 190), System.Drawing.Color.FromArgb(140, 140, 140));
            ConfigureButtonEffects(btnLogout, System.Drawing.Color.FromArgb(80, 80, 80), System.Drawing.Color.FromArgb(30, 30, 30));
        }

        private void ConfigureButtonEffects(System.Windows.Forms.Button button, System.Drawing.Color hoverColor, System.Drawing.Color pressColor)
        {
            // Set advanced flat appearance properties
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = hoverColor;
            button.FlatAppearance.MouseDownBackColor = pressColor;

            // Add hover effects
            var originalColor = button.BackColor;
            var originalFont = button.Font;

            button.MouseEnter += (s, e) => {
                button.Font = new System.Drawing.Font(button.Font.FontFamily, button.Font.Size + 1, button.Font.Style);
            };

            button.MouseLeave += (s, e) => {
                button.Font = originalFont;
            };
        }

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
using System.Drawing;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    partial class ReportsMainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel topBrandPanel;

        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnSalesReport;
        private System.Windows.Forms.Button btnProductReport;
        private System.Windows.Forms.Button btnMinStock;
        private System.Windows.Forms.Button btnAllStock;

        private System.Windows.Forms.Label lblHondaTitle;
        private System.Windows.Forms.Label lblTodaySales;
        private System.Windows.Forms.Label lblTodayBills;
        private System.Windows.Forms.Label lblTodayPaid;
        private System.Windows.Forms.Label lblTodayUnpaid;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsMainForm));
            this.topBrandPanel = new System.Windows.Forms.Panel();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.btnAllStock = new System.Windows.Forms.Button();
            this.btnMinStock = new System.Windows.Forms.Button();
            this.btnProductReport = new System.Windows.Forms.Button();
            this.btnSalesReport = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTodayNetProfit = new System.Windows.Forms.Label();
            this.lblTodayUnpaid = new System.Windows.Forms.Label();
            this.lblTodayPaid = new System.Windows.Forms.Label();
            this.lblTodayBills = new System.Windows.Forms.Label();
            this.lblTodaySales = new System.Windows.Forms.Label();
            this.lblHondaTitle = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.sidePanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBrandPanel
            // 
            this.topBrandPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.topBrandPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBrandPanel.Location = new System.Drawing.Point(0, 0);
            this.topBrandPanel.Name = "topBrandPanel";
            this.topBrandPanel.Size = new System.Drawing.Size(1200, 5);
            this.topBrandPanel.TabIndex = 0;
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.sidePanel.Controls.Add(this.btnAllStock);
            this.sidePanel.Controls.Add(this.btnMinStock);
            this.sidePanel.Controls.Add(this.btnProductReport);
            this.sidePanel.Controls.Add(this.btnSalesReport);
            this.sidePanel.Controls.Add(this.btnDashboard);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 5);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.sidePanel.Size = new System.Drawing.Size(240, 695);
            this.sidePanel.TabIndex = 1;
            // 
            // btnAllStock
            // 
            this.btnAllStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.btnAllStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAllStock.FlatAppearance.BorderSize = 0;
            this.btnAllStock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllStock.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnAllStock.ForeColor = System.Drawing.Color.White;
            this.btnAllStock.Location = new System.Drawing.Point(0, 240);
            this.btnAllStock.Name = "btnAllStock";
            this.btnAllStock.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnAllStock.Size = new System.Drawing.Size(240, 55);
            this.btnAllStock.TabIndex = 4;
            this.btnAllStock.Text = "📋  All Stock";
            this.btnAllStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllStock.UseVisualStyleBackColor = false;
            this.btnAllStock.Click += new System.EventHandler(this.btnAllStock_Click);
            // 
            // btnMinStock
            // 
            this.btnMinStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.btnMinStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMinStock.FlatAppearance.BorderSize = 0;
            this.btnMinStock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMinStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMinStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinStock.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnMinStock.ForeColor = System.Drawing.Color.White;
            this.btnMinStock.Location = new System.Drawing.Point(0, 185);
            this.btnMinStock.Name = "btnMinStock";
            this.btnMinStock.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnMinStock.Size = new System.Drawing.Size(240, 55);
            this.btnMinStock.TabIndex = 3;
            this.btnMinStock.Text = "⚠️  Order Stock";
            this.btnMinStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMinStock.UseVisualStyleBackColor = false;
            this.btnMinStock.Click += new System.EventHandler(this.btnMinStock_Click);
            // 
            // btnProductReport
            // 
            this.btnProductReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.btnProductReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductReport.FlatAppearance.BorderSize = 0;
            this.btnProductReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnProductReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnProductReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductReport.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnProductReport.ForeColor = System.Drawing.Color.White;
            this.btnProductReport.Location = new System.Drawing.Point(0, 130);
            this.btnProductReport.Name = "btnProductReport";
            this.btnProductReport.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnProductReport.Size = new System.Drawing.Size(240, 55);
            this.btnProductReport.TabIndex = 2;
            this.btnProductReport.Text = "📦  Product Report";
            this.btnProductReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductReport.UseVisualStyleBackColor = false;
            this.btnProductReport.Click += new System.EventHandler(this.btnProductReport_Click);
            // 
            // btnSalesReport
            // 
            this.btnSalesReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.btnSalesReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalesReport.FlatAppearance.BorderSize = 0;
            this.btnSalesReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSalesReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSalesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesReport.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesReport.ForeColor = System.Drawing.Color.White;
            this.btnSalesReport.Location = new System.Drawing.Point(0, 75);
            this.btnSalesReport.Name = "btnSalesReport";
            this.btnSalesReport.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnSalesReport.Size = new System.Drawing.Size(240, 55);
            this.btnSalesReport.TabIndex = 1;
            this.btnSalesReport.Text = "📈  Sales Report";
            this.btnSalesReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesReport.UseVisualStyleBackColor = false;
            this.btnSalesReport.Click += new System.EventHandler(this.btnSalesReport_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 20);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(240, 55);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "📊  Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.headerPanel.Controls.Add(this.lblTodayNetProfit);
            this.headerPanel.Controls.Add(this.lblTodayUnpaid);
            this.headerPanel.Controls.Add(this.lblTodayPaid);
            this.headerPanel.Controls.Add(this.lblTodayBills);
            this.headerPanel.Controls.Add(this.lblTodaySales);
            this.headerPanel.Controls.Add(this.lblHondaTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(240, 5);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.headerPanel.Size = new System.Drawing.Size(960, 138);
            this.headerPanel.TabIndex = 2;
            // 
            // lblTodayNetProfit
            // 
            this.lblTodayNetProfit.AutoSize = true;
            this.lblTodayNetProfit.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayNetProfit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTodayNetProfit.Location = new System.Drawing.Point(632, 90);
            this.lblTodayNetProfit.Name = "lblTodayNetProfit";
            this.lblTodayNetProfit.Size = new System.Drawing.Size(89, 23);
            this.lblTodayNetProfit.TabIndex = 5;
            this.lblTodayNetProfit.Text = "Profit: ₨0";
            // 
            // lblTodayUnpaid
            // 
            this.lblTodayUnpaid.AutoSize = true;
            this.lblTodayUnpaid.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayUnpaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTodayUnpaid.Location = new System.Drawing.Point(424, 90);
            this.lblTodayUnpaid.Name = "lblTodayUnpaid";
            this.lblTodayUnpaid.Size = new System.Drawing.Size(100, 23);
            this.lblTodayUnpaid.TabIndex = 4;
            this.lblTodayUnpaid.Text = "Unpaid: ₨0";
            // 
            // lblTodayPaid
            // 
            this.lblTodayPaid.AutoSize = true;
            this.lblTodayPaid.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayPaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblTodayPaid.Location = new System.Drawing.Point(211, 90);
            this.lblTodayPaid.Name = "lblTodayPaid";
            this.lblTodayPaid.Size = new System.Drawing.Size(78, 23);
            this.lblTodayPaid.TabIndex = 3;
            this.lblTodayPaid.Text = "Paid: ₨0";
            // 
            // lblTodayBills
            // 
            this.lblTodayBills.AutoSize = true;
            this.lblTodayBills.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayBills.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblTodayBills.Location = new System.Drawing.Point(20, 90);
            this.lblTodayBills.Name = "lblTodayBills";
            this.lblTodayBills.Size = new System.Drawing.Size(105, 23);
            this.lblTodayBills.TabIndex = 2;
            this.lblTodayBills.Text = "Total Bills: 0";
            // 
            // lblTodaySales
            // 
            this.lblTodaySales.AutoSize = true;
            this.lblTodaySales.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodaySales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.lblTodaySales.Location = new System.Drawing.Point(20, 45);
            this.lblTodaySales.Name = "lblTodaySales";
            this.lblTodaySales.Size = new System.Drawing.Size(162, 26);
            this.lblTodaySales.TabIndex = 1;
            this.lblTodaySales.Text = "Today\'s Sales: ₨0";
            // 
            // lblHondaTitle
            // 
            this.lblHondaTitle.AutoSize = true;
            this.lblHondaTitle.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHondaTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHondaTitle.Location = new System.Drawing.Point(338, 20);
            this.lblHondaTitle.Name = "lblHondaTitle";
            this.lblHondaTitle.Size = new System.Drawing.Size(249, 39);
            this.lblHondaTitle.TabIndex = 0;
            this.lblHondaTitle.Text = "THE BEST HONDA";
            this.lblHondaTitle.Click += new System.EventHandler(this.lblHondaTitle_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(240, 143);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(960, 557);
            this.mainPanel.TabIndex = 3;
            // 
            // ReportsMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.topBrandPanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "ReportsMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports Dashboard";
            this.Load += new System.EventHandler(this.ReportsMainForm_Load);
            this.sidePanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Optional: Add method to set active button state
        private void SetActiveButton(Button activeButton)
        {
            // Reset all buttons to default state
            Button[] buttons = { btnDashboard, btnSalesReport, btnProductReport, btnMinStock, btnAllStock };

            foreach (Button btn in buttons)
            {
                btn.BackColor = Color.FromArgb(35, 31, 32); // Honda Black
                btn.ForeColor = Color.White;
            }

            // Set active button appearance
            activeButton.BackColor = Color.FromArgb(204, 0, 0); // Honda Red
            activeButton.ForeColor = Color.White;
        }

        private Label lblTodayNetProfit;
    }
}
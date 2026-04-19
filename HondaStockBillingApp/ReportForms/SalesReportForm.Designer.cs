using System.Drawing;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    partial class SalesReportForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel topBrandPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel filtersPanel;
        private System.Windows.Forms.Panel contentPanel;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dateFromPicker;
        private System.Windows.Forms.DateTimePicker dateToPicker;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Button btnExportExcel;

        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Panel summaryPanel;

        private System.Windows.Forms.GroupBox grpQuickFilters;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btnYesterday;
        private System.Windows.Forms.Button btnWeekly;
        private System.Windows.Forms.Button btnMonthly;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesReportForm));
            this.topBrandPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.filtersPanel = new System.Windows.Forms.Panel();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.grpQuickFilters = new System.Windows.Forms.GroupBox();
            this.btnMonthly = new System.Windows.Forms.Button();
            this.btnWeekly = new System.Windows.Forms.Button();
            this.btnYesterday = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dateToPicker = new System.Windows.Forms.DateTimePicker();
            this.dateFromPicker = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.summaryPanel = new System.Windows.Forms.Panel();
            this.lblSummary = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            this.filtersPanel.SuspendLayout();
            this.grpQuickFilters.SuspendLayout();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.summaryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBrandPanel
            // 
            this.topBrandPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.topBrandPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBrandPanel.Location = new System.Drawing.Point(0, 0);
            this.topBrandPanel.Name = "topBrandPanel";
            this.topBrandPanel.Size = new System.Drawing.Size(1031, 5);
            this.topBrandPanel.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.ForeColor = System.Drawing.Color.White;
            this.headerPanel.Location = new System.Drawing.Point(0, 5);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(30, 15, 30, 15);
            this.headerPanel.Size = new System.Drawing.Size(1031, 87);
            this.headerPanel.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(397, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(310, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📈 Sales Report";
            // 
            // filtersPanel
            // 
            this.filtersPanel.BackColor = System.Drawing.Color.White;
            this.filtersPanel.Controls.Add(this.btnExportExcel);
            this.filtersPanel.Controls.Add(this.btnExportPDF);
            this.filtersPanel.Controls.Add(this.grpQuickFilters);
            this.filtersPanel.Controls.Add(this.btnGenerate);
            this.filtersPanel.Controls.Add(this.dateToPicker);
            this.filtersPanel.Controls.Add(this.dateFromPicker);
            this.filtersPanel.Controls.Add(this.lblToDate);
            this.filtersPanel.Controls.Add(this.lblFromDate);
            this.filtersPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filtersPanel.Location = new System.Drawing.Point(0, 92);
            this.filtersPanel.Name = "filtersPanel";
            this.filtersPanel.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.filtersPanel.Size = new System.Drawing.Size(1031, 100);
            this.filtersPanel.TabIndex = 2;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(630, 36);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(100, 35);
            this.btnExportExcel.TabIndex = 6;
            this.btnExportExcel.Text = "📊 Export Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.btnExportPDF.FlatAppearance.BorderSize = 0;
            this.btnExportPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPDF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportPDF.Location = new System.Drawing.Point(510, 36);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(100, 35);
            this.btnExportPDF.TabIndex = 5;
            this.btnExportPDF.Text = "📄 Export PDF";
            this.btnExportPDF.UseVisualStyleBackColor = false;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // grpQuickFilters
            // 
            this.grpQuickFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpQuickFilters.Controls.Add(this.btnMonthly);
            this.grpQuickFilters.Controls.Add(this.btnWeekly);
            this.grpQuickFilters.Controls.Add(this.btnYesterday);
            this.grpQuickFilters.Controls.Add(this.btnToday);
            this.grpQuickFilters.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpQuickFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.grpQuickFilters.Location = new System.Drawing.Point(750, 15);
            this.grpQuickFilters.Name = "grpQuickFilters";
            this.grpQuickFilters.Size = new System.Drawing.Size(251, 79);
            this.grpQuickFilters.TabIndex = 7;
            this.grpQuickFilters.TabStop = false;
            this.grpQuickFilters.Text = "Quick Filters";
            // 
            // btnMonthly
            // 
            this.btnMonthly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnMonthly.FlatAppearance.BorderSize = 0;
            this.btnMonthly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonthly.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonthly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.btnMonthly.Location = new System.Drawing.Point(6, 48);
            this.btnMonthly.Name = "btnMonthly";
            this.btnMonthly.Size = new System.Drawing.Size(75, 25);
            this.btnMonthly.TabIndex = 3;
            this.btnMonthly.Text = "This Month";
            this.btnMonthly.UseVisualStyleBackColor = false;
            this.btnMonthly.Click += new System.EventHandler(this.btnMonthly_Click);
            // 
            // btnWeekly
            // 
            this.btnWeekly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnWeekly.FlatAppearance.BorderSize = 0;
            this.btnWeekly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeekly.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeekly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.btnWeekly.Location = new System.Drawing.Point(144, 14);
            this.btnWeekly.Name = "btnWeekly";
            this.btnWeekly.Size = new System.Drawing.Size(70, 25);
            this.btnWeekly.TabIndex = 2;
            this.btnWeekly.Text = "This Week";
            this.btnWeekly.UseVisualStyleBackColor = false;
            this.btnWeekly.Click += new System.EventHandler(this.btnWeekly_Click);
            // 
            // btnYesterday
            // 
            this.btnYesterday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnYesterday.FlatAppearance.BorderSize = 0;
            this.btnYesterday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYesterday.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYesterday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.btnYesterday.Location = new System.Drawing.Point(64, 14);
            this.btnYesterday.Name = "btnYesterday";
            this.btnYesterday.Size = new System.Drawing.Size(65, 25);
            this.btnYesterday.TabIndex = 1;
            this.btnYesterday.Text = "Yesterday";
            this.btnYesterday.UseVisualStyleBackColor = false;
            this.btnYesterday.Click += new System.EventHandler(this.btnYesterday_Click);
            // 
            // btnToday
            // 
            this.btnToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnToday.FlatAppearance.BorderSize = 0;
            this.btnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToday.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.btnToday.Location = new System.Drawing.Point(6, 14);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(50, 25);
            this.btnToday.TabIndex = 0;
            this.btnToday.Text = "Today";
            this.btnToday.UseVisualStyleBackColor = false;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(370, 36);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(120, 35);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "🔍 Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dateToPicker
            // 
            this.dateToPicker.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dateToPicker.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateToPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateToPicker.Location = new System.Drawing.Point(200, 42);
            this.dateToPicker.Name = "dateToPicker";
            this.dateToPicker.Size = new System.Drawing.Size(140, 25);
            this.dateToPicker.TabIndex = 3;
            // 
            // dateFromPicker
            // 
            this.dateFromPicker.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dateFromPicker.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFromPicker.Location = new System.Drawing.Point(30, 42);
            this.dateFromPicker.Name = "dateFromPicker";
            this.dateFromPicker.Size = new System.Drawing.Size(140, 25);
            this.dateFromPicker.TabIndex = 1;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblToDate.Location = new System.Drawing.Point(200, 20);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(59, 19);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "To Date:";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblFromDate.Location = new System.Drawing.Point(30, 20);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(77, 19);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "From Date:";
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.dgvSales);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 192);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(30, 20, 30, 0);
            this.contentPanel.Size = new System.Drawing.Size(1031, 333);
            this.contentPanel.TabIndex = 3;
            // 
            // dgvSales
            // 
            this.dgvSales.AllowUserToAddRows = false;
            this.dgvSales.AllowUserToDeleteRows = false;
            this.dgvSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSales.BackgroundColor = System.Drawing.Color.White;
            this.dgvSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSales.ColumnHeadersHeight = 40;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSales.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSales.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSales.EnableHeadersVisualStyles = false;
            this.dgvSales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvSales.Location = new System.Drawing.Point(30, 20);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSales.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSales.RowHeadersVisible = false;
            this.dgvSales.RowTemplate.Height = 35;
            this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSales.Size = new System.Drawing.Size(971, 313);
            this.dgvSales.TabIndex = 0;
            // 
            // summaryPanel
            // 
            this.summaryPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.summaryPanel.Controls.Add(this.lblSummary);
            this.summaryPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.summaryPanel.Location = new System.Drawing.Point(0, 525);
            this.summaryPanel.Name = "summaryPanel";
            this.summaryPanel.Padding = new System.Windows.Forms.Padding(30, 15, 30, 15);
            this.summaryPanel.Size = new System.Drawing.Size(1031, 75);
            this.summaryPanel.TabIndex = 4;
            // 
            // lblSummary
            // 
            this.lblSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.lblSummary.Location = new System.Drawing.Point(30, 15);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(971, 45);
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text = "📊 Summary: Select date range and click Generate to view sales report";
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SalesReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1031, 600);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.summaryPanel);
            this.Controls.Add(this.filtersPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.topBrandPanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "SalesReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Report";
            this.headerPanel.ResumeLayout(false);
            this.filtersPanel.ResumeLayout(false);
            this.filtersPanel.PerformLayout();
            this.grpQuickFilters.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.summaryPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // Helper method to set active quick filter button
        private void SetActiveQuickFilter(Button activeButton)
        {
            Button[] quickButtons = { btnToday, btnYesterday, btnWeekly, btnMonthly };

            foreach (Button btn in quickButtons)
            {
                btn.BackColor = Color.FromArgb(230, 230, 230); // Honda Accent
                btn.ForeColor = Color.FromArgb(35, 31, 32);    // Honda Black
            }

            activeButton.BackColor = Color.FromArgb(204, 0, 0); // Honda Red
            activeButton.ForeColor = Color.White;
        }

        // Method to update summary with Honda styling
        private void UpdateSummary(string summaryText)
        {
            lblSummary.Text = $"📊 Summary: {summaryText}";
        }
    }
}
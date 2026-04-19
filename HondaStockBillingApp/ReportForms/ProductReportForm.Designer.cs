using System.Drawing;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    partial class ProductReportForm
    {
        private readonly System.Collections.Generic.Dictionary<Button, Color> originalButtonColors
    = new System.Collections.Generic.Dictionary<Button, Color>();
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DateTimePicker dateFromPicker;
        private System.Windows.Forms.DateTimePicker dateToPicker;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btnYesterday;
        private System.Windows.Forms.Button btnWeekly;
        private System.Windows.Forms.Button btnMonthly;
        private System.Windows.Forms.Button btnExportPdf;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Panel pnlQuickFilters;
        private System.Windows.Forms.Label lblQuickFilters;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductReportForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.pnlQuickFilters = new System.Windows.Forms.Panel();
            this.btnMonthly = new System.Windows.Forms.Button();
            this.btnWeekly = new System.Windows.Forms.Button();
            this.btnYesterday = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.lblQuickFilters = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnExportPdf = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dateToPicker = new System.Windows.Forms.DateTimePicker();
            this.dateFromPicker = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.lblSummary = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.pnlQuickFilters.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlHeader.Controls.Add(this.pnlTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 62);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1200, 62);
            this.pnlTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(511, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📦 Product Report";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.White;
            this.pnlControls.Controls.Add(this.lblToDate);
            this.pnlControls.Controls.Add(this.lblFromDate);
            this.pnlControls.Controls.Add(this.pnlQuickFilters);
            this.pnlControls.Controls.Add(this.btnExportExcel);
            this.pnlControls.Controls.Add(this.btnExportPdf);
            this.pnlControls.Controls.Add(this.btnGenerate);
            this.pnlControls.Controls.Add(this.dateToPicker);
            this.pnlControls.Controls.Add(this.dateFromPicker);
            this.pnlControls.Controls.Add(this.lblDateTo);
            this.pnlControls.Controls.Add(this.lblDateFrom);
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(1200, 107);
            this.pnlControls.TabIndex = 1;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblToDate.Location = new System.Drawing.Point(182, 15);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(59, 19);
            this.lblToDate.TabIndex = 10;
            this.lblToDate.Text = "To Date:";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblFromDate.Location = new System.Drawing.Point(12, 15);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(77, 19);
            this.lblFromDate.TabIndex = 9;
            this.lblFromDate.Text = "From Date:";
            // 
            // pnlQuickFilters
            // 
            this.pnlQuickFilters.BackColor = System.Drawing.Color.White;
            this.pnlQuickFilters.Controls.Add(this.btnMonthly);
            this.pnlQuickFilters.Controls.Add(this.btnWeekly);
            this.pnlQuickFilters.Controls.Add(this.btnYesterday);
            this.pnlQuickFilters.Controls.Add(this.btnToday);
            this.pnlQuickFilters.Controls.Add(this.lblQuickFilters);
            this.pnlQuickFilters.Location = new System.Drawing.Point(701, 10);
            this.pnlQuickFilters.Name = "pnlQuickFilters";
            this.pnlQuickFilters.Size = new System.Drawing.Size(420, 70);
            this.pnlQuickFilters.TabIndex = 8;
            // 
            // btnMonthly
            // 
            this.btnMonthly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnMonthly.FlatAppearance.BorderSize = 0;
            this.btnMonthly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonthly.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMonthly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMonthly.Location = new System.Drawing.Point(285, 25);
            this.btnMonthly.Name = "btnMonthly";
            this.btnMonthly.Size = new System.Drawing.Size(90, 30);
            this.btnMonthly.TabIndex = 4;
            this.btnMonthly.Text = "This Month";
            this.btnMonthly.UseVisualStyleBackColor = false;
            this.btnMonthly.Click += new System.EventHandler(this.btnMonthly_Click);
            this.btnMonthly.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnMonthly.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // btnWeekly
            // 
            this.btnWeekly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnWeekly.FlatAppearance.BorderSize = 0;
            this.btnWeekly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeekly.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnWeekly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnWeekly.Location = new System.Drawing.Point(195, 25);
            this.btnWeekly.Name = "btnWeekly";
            this.btnWeekly.Size = new System.Drawing.Size(80, 30);
            this.btnWeekly.TabIndex = 3;
            this.btnWeekly.Text = "This Week";
            this.btnWeekly.UseVisualStyleBackColor = false;
            this.btnWeekly.Click += new System.EventHandler(this.btnWeekly_Click);
            this.btnWeekly.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnWeekly.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // btnYesterday
            // 
            this.btnYesterday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnYesterday.FlatAppearance.BorderSize = 0;
            this.btnYesterday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYesterday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnYesterday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnYesterday.Location = new System.Drawing.Point(105, 25);
            this.btnYesterday.Name = "btnYesterday";
            this.btnYesterday.Size = new System.Drawing.Size(80, 30);
            this.btnYesterday.TabIndex = 2;
            this.btnYesterday.Text = "Yesterday";
            this.btnYesterday.UseVisualStyleBackColor = false;
            this.btnYesterday.Click += new System.EventHandler(this.btnYesterday_Click);
            this.btnYesterday.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnYesterday.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // btnToday
            // 
            this.btnToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnToday.FlatAppearance.BorderSize = 0;
            this.btnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnToday.Location = new System.Drawing.Point(15, 25);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(80, 30);
            this.btnToday.TabIndex = 1;
            this.btnToday.Text = "Today";
            this.btnToday.UseVisualStyleBackColor = false;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            this.btnToday.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnToday.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // lblQuickFilters
            // 
            this.lblQuickFilters.AutoSize = true;
            this.lblQuickFilters.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblQuickFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblQuickFilters.Location = new System.Drawing.Point(10, 5);
            this.lblQuickFilters.Name = "lblQuickFilters";
            this.lblQuickFilters.Size = new System.Drawing.Size(76, 15);
            this.lblQuickFilters.TabIndex = 0;
            this.lblQuickFilters.Text = "Quick Filters";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(568, 34);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(117, 46);
            this.btnExportExcel.TabIndex = 6;
            this.btnExportExcel.Text = "📊 Export Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            this.btnExportExcel.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnExportExcel.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnExportPdf.FlatAppearance.BorderSize = 0;
            this.btnExportPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportPdf.Location = new System.Drawing.Point(452, 34);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(110, 46);
            this.btnExportPdf.TabIndex = 5;
            this.btnExportPdf.Text = "📄 Export PDF";
            this.btnExportPdf.UseVisualStyleBackColor = false;
            this.btnExportPdf.Click += new System.EventHandler(this.btnExportPdf_Click);
            this.btnExportPdf.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnExportPdf.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(346, 35);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(100, 45);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            this.btnGenerate.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnGenerate.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // dateToPicker
            // 
            this.dateToPicker.CustomFormat = "dd/MM/yyyy";
            this.dateToPicker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateToPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateToPicker.Location = new System.Drawing.Point(180, 40);
            this.dateToPicker.Name = "dateToPicker";
            this.dateToPicker.Size = new System.Drawing.Size(150, 25);
            this.dateToPicker.TabIndex = 3;
            // 
            // dateFromPicker
            // 
            this.dateFromPicker.CustomFormat = "dd/MM/yyyy";
            this.dateFromPicker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateFromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFromPicker.Location = new System.Drawing.Point(12, 40);
            this.dateFromPicker.Name = "dateFromPicker";
            this.dateFromPicker.Size = new System.Drawing.Size(150, 25);
            this.dateFromPicker.TabIndex = 2;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDateTo.ForeColor = System.Drawing.Color.White;
            this.lblDateTo.Location = new System.Drawing.Point(200, 15);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(64, 19);
            this.lblDateTo.TabIndex = 1;
            this.lblDateTo.Text = "To Date:";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDateFrom.ForeColor = System.Drawing.Color.White;
            this.lblDateFrom.Location = new System.Drawing.Point(30, 15);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(83, 19);
            this.lblDateFrom.TabIndex = 0;
            this.lblDateFrom.Text = "From Date:";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.pnlControls);
            this.pnlMain.Controls.Add(this.txtSearch);
            this.pnlMain.Controls.Add(this.lblSearch);
            this.pnlMain.Controls.Add(this.dgvProducts);
            this.pnlMain.Controls.Add(this.lblSummary);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 62);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(1200, 538);
            this.pnlMain.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(55, 132);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 25);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblSearch.Location = new System.Drawing.Point(12, 110);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(54, 19);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToResizeRows = false;
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducts.ColumnHeadersHeight = 40;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProducts.EnableHeadersVisualStyles = false;
            this.dgvProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dgvProducts.Location = new System.Drawing.Point(25, 163);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.RowTemplate.Height = 35;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(1150, 286);
            this.dgvProducts.TabIndex = 2;
            // 
            // lblSummary
            // 
            this.lblSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSummary.ForeColor = System.Drawing.Color.White;
            this.lblSummary.Location = new System.Drawing.Point(23, 467);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.lblSummary.Size = new System.Drawing.Size(1150, 40);
            this.lblSummary.TabIndex = 3;
            this.lblSummary.Text = "📊 Summary: Select date range and click Generate to view sales report";
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProductReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "ProductReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.pnlQuickFilters.ResumeLayout(false);
            this.pnlQuickFilters.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitializeOriginalButtonColors()
        {
            // Quick filter buttons
            originalButtonColors[btnToday] = btnToday.BackColor;
            originalButtonColors[btnYesterday] = btnYesterday.BackColor;
            originalButtonColors[btnWeekly] = btnWeekly.BackColor;
            originalButtonColors[btnMonthly] = btnMonthly.BackColor;

            // Generate / Export buttons
            originalButtonColors[btnGenerate] = btnGenerate.BackColor;
            originalButtonColors[btnExportPdf] = btnExportPdf.BackColor;
            originalButtonColors[btnExportExcel] = btnExportExcel.BackColor;
        }

        // Updated hover methods:
        private void Button_MouseEnter(object sender, System.EventArgs e)
        {
            if (sender is Button btn && originalButtonColors.ContainsKey(btn))
            {
                btn.BackColor = ControlPaint.Dark(originalButtonColors[btn], 0.1f);
            }
        }

        private void Button_MouseLeave(object sender, System.EventArgs e)
        {
            if (sender is Button btn && originalButtonColors.ContainsKey(btn))
            {
                btn.BackColor = originalButtonColors[btn];
            }
        }

        private Label lblToDate;
        private Label lblFromDate;
    }
}
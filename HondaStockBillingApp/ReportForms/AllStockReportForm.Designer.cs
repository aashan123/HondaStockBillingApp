namespace HondaStockBillingApp
{
    partial class AllStockReportForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox chkBelowMin;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnExportPdf;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridView dgvAllStock;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Label lblTotalStockValue;
        private System.Windows.Forms.Label lblTotalPotentialRevenue;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllStockReportForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.chkBelowMin = new System.Windows.Forms.CheckBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnExportPdf = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.dgvAllStock = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.lblTotalStockValue = new System.Windows.Forms.Label();
            this.lblTotalPotentialRevenue = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllStock)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1094, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(14, 22);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(239, 32);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "📦 All Stock Report";
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControls.Controls.Add(this.lblSearch);
            this.pnlControls.Controls.Add(this.txtSearch);
            this.pnlControls.Controls.Add(this.chkBelowMin);
            this.pnlControls.Controls.Add(this.pnlButtons);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Location = new System.Drawing.Point(0, 70);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlControls.Size = new System.Drawing.Size(1094, 65);
            this.pnlControls.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSearch.Location = new System.Drawing.Point(15, 8);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(94, 15);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "🔍 Search Item:";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(15, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(210, 25);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // chkBelowMin
            // 
            this.chkBelowMin.AutoSize = true;
            this.chkBelowMin.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBelowMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkBelowMin.Location = new System.Drawing.Point(325, 29);
            this.chkBelowMin.Name = "chkBelowMin";
            this.chkBelowMin.Size = new System.Drawing.Size(160, 19);
            this.chkBelowMin.TabIndex = 2;
            this.chkBelowMin.Text = "⚠️ Show Only Below Min";
            this.chkBelowMin.UseVisualStyleBackColor = true;
            this.chkBelowMin.CheckedChanged += new System.EventHandler(this.chkBelowMin_CheckedChanged);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnExportPdf);
            this.pnlButtons.Controls.Add(this.btnExportExcel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtons.Location = new System.Drawing.Point(626, 10);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(451, 43);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.btnExportPdf.FlatAppearance.BorderSize = 0;
            this.btnExportPdf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.btnExportPdf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.btnExportPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportPdf.Location = new System.Drawing.Point(12, 5);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(120, 35);
            this.btnExportPdf.TabIndex = 1;
            this.btnExportPdf.Text = "📑 Export PDF";
            this.btnExportPdf.UseVisualStyleBackColor = false;
            this.btnExportPdf.Click += new System.EventHandler(this.btnExportPdf_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(74)))));
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(54)))));
            this.btnExportExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(94)))));
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(138, 6);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(120, 35);
            this.btnExportExcel.TabIndex = 2;
            this.btnExportExcel.Text = "📊 Export Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // dgvAllStock
            // 
            this.dgvAllStock.AllowUserToAddRows = false;
            this.dgvAllStock.AllowUserToDeleteRows = false;
            this.dgvAllStock.AllowUserToResizeColumns = false;
            this.dgvAllStock.AllowUserToResizeRows = false;
            this.dgvAllStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAllStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAllStock.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAllStock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAllStock.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllStock.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllStock.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAllStock.EnableHeadersVisualStyles = false;
            this.dgvAllStock.GridColor = System.Drawing.Color.White;
            this.dgvAllStock.Location = new System.Drawing.Point(20, 150);
            this.dgvAllStock.MultiSelect = false;
            this.dgvAllStock.Name = "dgvAllStock";
            this.dgvAllStock.ReadOnly = true;
            this.dgvAllStock.RowHeadersVisible = false;
            this.dgvAllStock.RowTemplate.Height = 35;
            this.dgvAllStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllStock.Size = new System.Drawing.Size(1058, 301);
            this.dgvAllStock.TabIndex = 2;
            this.dgvAllStock.Sorted += new System.EventHandler(this.dgvAllStock_Sorted);

            // 
            // pnlFooter
            // 
            this.pnlFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.lblTotalItems);
            this.pnlFooter.Controls.Add(this.lblTotalStockValue);
            this.pnlFooter.Controls.Add(this.lblTotalPotentialRevenue);
            this.pnlFooter.Location = new System.Drawing.Point(16, 466);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlFooter.Size = new System.Drawing.Size(1062, 48);
            this.pnlFooter.TabIndex = 3;
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTotalItems.Location = new System.Drawing.Point(15, 15);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(92, 20);
            this.lblTotalItems.TabIndex = 0;
            this.lblTotalItems.Text = "📦 Items: 0";
            // 
            // lblTotalStockValue
            // 
            this.lblTotalStockValue.AutoSize = true;
            this.lblTotalStockValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalStockValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(74)))));
            this.lblTotalStockValue.Location = new System.Drawing.Point(305, 15);
            this.lblTotalStockValue.Name = "lblTotalStockValue";
            this.lblTotalStockValue.Size = new System.Drawing.Size(210, 20);
            this.lblTotalStockValue.TabIndex = 1;
            this.lblTotalStockValue.Text = "💰 Total Stock Value: Rs 0.00";
            // 
            // lblTotalPotentialRevenue
            // 
            this.lblTotalPotentialRevenue.AutoSize = true;
            this.lblTotalPotentialRevenue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalPotentialRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.lblTotalPotentialRevenue.Location = new System.Drawing.Point(677, 15);
            this.lblTotalPotentialRevenue.Name = "lblTotalPotentialRevenue";
            this.lblTotalPotentialRevenue.Size = new System.Drawing.Size(260, 20);
            this.lblTotalPotentialRevenue.TabIndex = 2;
            this.lblTotalPotentialRevenue.Text = "📈 Total Potential Revenue: Rs 0.00";
            // 
            // AllStockReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1094, 600);
            this.Controls.Add(this.dgvAllStock);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "AllStockReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Stock Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AllStockReportForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllStock)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Additional event handler for refresh button
        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            LoadAllStock();
        }

        // Additional event handler for search text changed
        private void txtSearch_TextChanged(object sender, System.EventArgs e)
        {
            // Add search functionality here
            // Filter the DataGridView based on search text
        }
    }
}
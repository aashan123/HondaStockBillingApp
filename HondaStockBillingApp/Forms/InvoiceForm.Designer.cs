using System;

namespace HondaStockBillingApp
{
    partial class InvoiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblShopName = new System.Windows.Forms.Label();
            this.pnlCustomerInfo = new System.Windows.Forms.Panel();
            this.lblCustomerHeader = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dgvInvoice = new System.Windows.Forms.DataGridView();
            this.lblReturn = new System.Windows.Forms.Label();
            this.lblPaid = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblSummaryHeader = new System.Windows.Forms.Label();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlCustomerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.pnlSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlHeader.Controls.Add(this.lblShopName);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblShopName
            // 
            this.lblShopName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblShopName.AutoSize = true;
            this.lblShopName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblShopName.ForeColor = System.Drawing.Color.White;
            this.lblShopName.Location = new System.Drawing.Point(307, 9);
            this.lblShopName.Name = "lblShopName";
            this.lblShopName.Size = new System.Drawing.Size(358, 37);
            this.lblShopName.TabIndex = 0;
            this.lblShopName.Text = "HONDA INVOICE PREVIEW";
            this.lblShopName.Click += new System.EventHandler(this.lblShopName_Click);
            // 
            // pnlCustomerInfo
            // 
            this.pnlCustomerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCustomerInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlCustomerInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCustomerInfo.Controls.Add(this.lblCustomerHeader);
            this.pnlCustomerInfo.Controls.Add(this.lblCustomer);
            this.pnlCustomerInfo.Controls.Add(this.lblDate);
            this.pnlCustomerInfo.Location = new System.Drawing.Point(30, 66);
            this.pnlCustomerInfo.Name = "pnlCustomerInfo";
            this.pnlCustomerInfo.Size = new System.Drawing.Size(840, 69);
            this.pnlCustomerInfo.TabIndex = 1;
            // 
            // lblCustomerHeader
            // 
            this.lblCustomerHeader.AutoSize = true;
            this.lblCustomerHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCustomerHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCustomerHeader.Location = new System.Drawing.Point(15, 10);
            this.lblCustomerHeader.Name = "lblCustomerHeader";
            this.lblCustomerHeader.Size = new System.Drawing.Size(141, 21);
            this.lblCustomerHeader.TabIndex = 0;
            this.lblCustomerHeader.Text = "INVOICE DETAILS";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCustomer.Location = new System.Drawing.Point(15, 35);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(82, 19);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "Customer: -";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDate.Location = new System.Drawing.Point(300, 35);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(51, 19);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date: -";
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.AllowUserToAddRows = false;
            this.dgvInvoice.AllowUserToDeleteRows = false;
            this.dgvInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoice.BackgroundColor = System.Drawing.Color.White;
            this.dgvInvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoice.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInvoice.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dgvInvoice.Location = new System.Drawing.Point(30, 141);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.ReadOnly = true;
            this.dgvInvoice.RowHeadersVisible = false;
            this.dgvInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoice.Size = new System.Drawing.Size(840, 257);
            this.dgvInvoice.TabIndex = 2;
            // 
            // lblReturn
            // 
            this.lblReturn.AutoSize = true;
            this.lblReturn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.lblReturn.Location = new System.Drawing.Point(15, 135);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(69, 19);
            this.lblReturn.TabIndex = 5;
            this.lblReturn.Text = "Return: 0";
            // 
            // lblPaid
            // 
            this.lblPaid.AutoSize = true;
            this.lblPaid.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaid.Location = new System.Drawing.Point(15, 115);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(50, 19);
            this.lblPaid.TabIndex = 4;
            this.lblPaid.Text = "Paid: 0";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(15, 90);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(115, 21);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Grand Total: 0";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDiscount.Location = new System.Drawing.Point(15, 65);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(78, 19);
            this.lblDiscount.TabIndex = 2;
            this.lblDiscount.Text = "Discount: 0";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubTotal.Location = new System.Drawing.Point(15, 40);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(80, 19);
            this.lblSubTotal.TabIndex = 1;
            this.lblSubTotal.Text = "Sub Total: 0";
            // 
            // lblSummaryHeader
            // 
            this.lblSummaryHeader.AutoSize = true;
            this.lblSummaryHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSummaryHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSummaryHeader.Location = new System.Drawing.Point(15, 10);
            this.lblSummaryHeader.Name = "lblSummaryHeader";
            this.lblSummaryHeader.Size = new System.Drawing.Size(92, 21);
            this.lblSummaryHeader.TabIndex = 0;
            this.lblSummaryHeader.Text = "SUMMARY";
            // 
            // pnlSummary
            // 
            this.pnlSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummary.Controls.Add(this.lblSummaryHeader);
            this.pnlSummary.Controls.Add(this.lblSubTotal);
            this.pnlSummary.Controls.Add(this.lblDiscount);
            this.pnlSummary.Controls.Add(this.lblTotal);
            this.pnlSummary.Controls.Add(this.lblPaid);
            this.pnlSummary.Controls.Add(this.lblReturn);
            this.pnlSummary.Location = new System.Drawing.Point(580, 413);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(290, 160);
            this.pnlSummary.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(780, 606);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // InvoiceForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 685);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.dgvInvoice);
            this.Controls.Add(this.pnlCustomerInfo);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InvoiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Honda Invoice Preview";
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCustomerInfo.ResumeLayout(false);
            this.pnlCustomerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblShopName;
        private System.Windows.Forms.Panel pnlCustomerInfo;
        private System.Windows.Forms.Label lblCustomerHeader;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DataGridView dgvInvoice;
        private System.Windows.Forms.Label lblReturn;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblSummaryHeader;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Button btnClose;
    }
}
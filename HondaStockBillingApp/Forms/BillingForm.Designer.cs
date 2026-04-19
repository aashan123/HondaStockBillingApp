using System.Windows.Forms;
using System.Drawing;

namespace HondaStockBillingApp
{
    partial class BillingForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSaveBill;
        private System.Windows.Forms.Button btnCancel;

        // New controls
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Label lblReturn;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;

        // Enhanced UI elements
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlProductSearch;
        private System.Windows.Forms.Panel pnlBilling;
        private System.Windows.Forms.Panel pnlActions;

        // Additional UI enhancements

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillingForm));
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSaveBill = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblPaid = new System.Windows.Forms.Label();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.lblReturn = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lablGtotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlProductSearch = new System.Windows.Forms.Panel();
            this.pnlBilling = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlProductSearch.SuspendLayout();
            this.pnlBilling.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchProduct.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearchProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.txtSearchProduct.Location = new System.Drawing.Point(25, 18);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(320, 29);
            this.txtSearchProduct.TabIndex = 0;
            this.txtSearchProduct.Paint += new System.Windows.Forms.PaintEventHandler(this.txtSearchProduct_Paint);
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.txtSearchProduct_TextChanged);
            this.txtSearchProduct.GotFocus += new System.EventHandler(this.txtSearchProduct_GotFocus);
            this.txtSearchProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchProduct_KeyDown);
            this.txtSearchProduct.LostFocus += new System.EventHandler(this.txtSearchProduct_LostFocus);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnAddProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddProduct.FlatAppearance.BorderSize = 0;
            this.btnAddProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.btnAddProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddProduct.Location = new System.Drawing.Point(365, 12);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(130, 38);
            this.btnAddProduct.TabIndex = 1;
            this.btnAddProduct.Text = "🛒 Add to Cart";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            this.btnAddProduct.Paint += new System.Windows.Forms.PaintEventHandler(this.btnAddProduct_Paint);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToResizeColumns = false;
            this.dgvProducts.AllowUserToResizeRows = false;
            this.dgvProducts.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProducts.EnableHeadersVisualStyles = false;
            this.dgvProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.dgvProducts.Location = new System.Drawing.Point(25, 131);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.RowTemplate.Height = 35;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(710, 150);
            this.dgvProducts.TabIndex = 2;
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToResizeColumns = false;
            this.dgvCart.AllowUserToResizeRows = false;
            this.dgvCart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCart.EnableHeadersVisualStyles = false;
            this.dgvCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.dgvCart.Location = new System.Drawing.Point(24, 293);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvCart.RowTemplate.Height = 35;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(470, 320);
            this.dgvCart.TabIndex = 3;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(120, 98);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 28);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Rs 0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSaveBill
            // 
            this.btnSaveBill.BackColor = System.Drawing.Color.Black;
            this.btnSaveBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveBill.FlatAppearance.BorderSize = 0;
            this.btnSaveBill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(136)))), ((int)(((byte)(56)))));
            this.btnSaveBill.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnSaveBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveBill.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaveBill.ForeColor = System.Drawing.Color.White;
            this.btnSaveBill.Location = new System.Drawing.Point(440, 10);
            this.btnSaveBill.Name = "btnSaveBill";
            this.btnSaveBill.Size = new System.Drawing.Size(140, 42);
            this.btnSaveBill.TabIndex = 12;
            this.btnSaveBill.Text = "💾 Save & Print";
            this.btnSaveBill.UseVisualStyleBackColor = false;
            this.btnSaveBill.Click += new System.EventHandler(this.btnSaveBill_Click);
            this.btnSaveBill.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSaveBill_Paint);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(590, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 42);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "🗑️ Clear Cart";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.Paint += new System.Windows.Forms.PaintEventHandler(this.btnCancel_Paint);
            // 
            // lblDiscount
            // 
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.ForeColor = System.Drawing.Color.Black;
            this.lblDiscount.Location = new System.Drawing.Point(15, 138);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(90, 25);
            this.lblDiscount.TabIndex = 7;
            this.lblDiscount.Text = "Discount:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDiscount.Location = new System.Drawing.Point(120, 135);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(100, 29);
            this.txtDiscount.TabIndex = 8;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.Paint += new System.Windows.Forms.PaintEventHandler(this.txtDiscount_Paint);
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // lblPaid
            // 
            this.lblPaid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPaid.ForeColor = System.Drawing.Color.Black;
            this.lblPaid.Location = new System.Drawing.Point(15, 198);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(50, 25);
            this.lblPaid.TabIndex = 9;
            this.lblPaid.Text = "Paid:";
            // 
            // txtPaid
            // 
            this.txtPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaid.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPaid.Location = new System.Drawing.Point(120, 195);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(100, 29);
            this.txtPaid.TabIndex = 10;
            this.txtPaid.Text = "0";
            this.txtPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPaid.Paint += new System.Windows.Forms.PaintEventHandler(this.txtPaid_Paint);
            this.txtPaid.TextChanged += new System.EventHandler(this.txtPaid_TextChanged);
            // 
            // lblReturn
            // 
            this.lblReturn.BackColor = System.Drawing.Color.White;
            this.lblReturn.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturn.ForeColor = System.Drawing.Color.Black;
            this.lblReturn.Location = new System.Drawing.Point(15, 246);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(205, 35);
            this.lblReturn.TabIndex = 11;
            this.lblReturn.Text = "💰 Return: Rs 0";
            this.lblReturn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerName.Location = new System.Drawing.Point(20, 15);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(138, 25);
            this.lblCustomerName.TabIndex = 20;
            this.lblCustomerName.Text = "👤 Customer:";
            this.lblCustomerName.Click += new System.EventHandler(this.lblCustomerName_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerName.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.txtCustomerName.Location = new System.Drawing.Point(174, 15);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(222, 30);
            this.txtCustomerName.TabIndex = 21;
            this.txtCustomerName.Paint += new System.Windows.Forms.PaintEventHandler(this.txtCustomerName_Paint);
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(179)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(290, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 42);
            this.button1.TabIndex = 22;
            this.button1.Text = "👁️ Preview Bill";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.Paint += new System.Windows.Forms.PaintEventHandler(this.button1_Paint);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Sub Total:";
            // 
            // lablGtotal
            // 
            this.lablGtotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lablGtotal.ForeColor = System.Drawing.Color.Black;
            this.lablGtotal.Location = new System.Drawing.Point(14, 167);
            this.lablGtotal.Name = "lablGtotal";
            this.lablGtotal.Size = new System.Drawing.Size(100, 25);
            this.lablGtotal.TabIndex = 25;
            this.lablGtotal.Text = "Grand Total:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(120, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 28);
            this.label3.TabIndex = 24;
            this.label3.Text = "Rs 0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.pnlHeader.Controls.Add(this.button2);
            this.pnlHeader.Controls.Add(this.lblCustomerName);
            this.pnlHeader.Controls.Add(this.txtCustomerName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.pnlHeader.Size = new System.Drawing.Size(750, 60);
            this.pnlHeader.TabIndex = 26;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.button2.Location = new System.Drawing.Point(615, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 36);
            this.button2.TabIndex = 22;
            this.button2.Text = "➕ New Bill";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.Paint += new System.Windows.Forms.PaintEventHandler(this.button2_Paint);
            // 
            // pnlProductSearch
            // 
            this.pnlProductSearch.BackColor = System.Drawing.Color.White;
            this.pnlProductSearch.Controls.Add(this.txtSearchProduct);
            this.pnlProductSearch.Controls.Add(this.btnAddProduct);
            this.pnlProductSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProductSearch.Location = new System.Drawing.Point(0, 60);
            this.pnlProductSearch.Name = "pnlProductSearch";
            this.pnlProductSearch.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlProductSearch.Size = new System.Drawing.Size(750, 65);
            this.pnlProductSearch.TabIndex = 27;
            this.pnlProductSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlProductSearch_Paint);
            // 
            // pnlBilling
            // 
            this.pnlBilling.BackColor = System.Drawing.Color.White;
            this.pnlBilling.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBilling.Controls.Add(this.label2);
            this.pnlBilling.Controls.Add(this.lblDiscount);
            this.pnlBilling.Controls.Add(this.txtDiscount);
            this.pnlBilling.Controls.Add(this.label1);
            this.pnlBilling.Controls.Add(this.lblTotal);
            this.pnlBilling.Controls.Add(this.lablGtotal);
            this.pnlBilling.Controls.Add(this.label3);
            this.pnlBilling.Controls.Add(this.lblPaid);
            this.pnlBilling.Controls.Add(this.txtPaid);
            this.pnlBilling.Controls.Add(this.lblReturn);
            this.pnlBilling.Location = new System.Drawing.Point(500, 293);
            this.pnlBilling.Name = "pnlBilling";
            this.pnlBilling.Padding = new System.Windows.Forms.Padding(15);
            this.pnlBilling.Size = new System.Drawing.Size(235, 320);
            this.pnlBilling.TabIndex = 28;
            this.pnlBilling.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBilling_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 42);
            this.label2.TabIndex = 26;
            this.label2.Text = "Bill Info";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlActions.Controls.Add(this.button1);
            this.pnlActions.Controls.Add(this.btnSaveBill);
            this.pnlActions.Controls.Add(this.btnCancel);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(0, 627);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.pnlActions.Size = new System.Drawing.Size(750, 65);
            this.pnlActions.TabIndex = 29;
            this.pnlActions.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlActions_Paint);
            // 
            // BillingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(750, 692);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlBilling);
            this.Controls.Add(this.pnlProductSearch);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.dgvCart);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BillingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🏍️ Honda Stock - Billing ";
            this.Load += new System.EventHandler(this.BillingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlProductSearch.ResumeLayout(false);
            this.pnlProductSearch.PerformLayout();
            this.pnlBilling.ResumeLayout(false);
            this.pnlBilling.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // Custom Paint Methods for Enhanced UI Effects

        // Header gradient effect
        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                panel.ClientRectangle,
                System.Drawing.Color.FromArgb(220, 53, 69),
                System.Drawing.Color.FromArgb(185, 28, 28),
                45F))
            {
                e.Graphics.FillRectangle(brush, panel.ClientRectangle);
            }
        }

        // Rounded corners for buttons
        private void btnSaveBill_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int cornerRadius = 8;

            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(btn.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(btn.Width - cornerRadius, btn.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, btn.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();

            btn.Region = new System.Drawing.Region(path);
        }

        private void btnCancel_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int cornerRadius = 8;

            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(btn.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(btn.Width - cornerRadius, btn.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, btn.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();

            btn.Region = new System.Drawing.Region(path);
        }

        private void btnAddProduct_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int cornerRadius = 8;

            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(btn.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(btn.Width - cornerRadius, btn.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, btn.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();

            btn.Region = new System.Drawing.Region(path);
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int cornerRadius = 8;

            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(btn.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(btn.Width - cornerRadius, btn.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, btn.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();

            btn.Region = new System.Drawing.Region(path);
        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int cornerRadius = 8;

            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(btn.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(btn.Width - cornerRadius, btn.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, btn.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();

            btn.Region = new System.Drawing.Region(path);
        }

        // TextBox custom borders
        private void txtSearchProduct_Paint(object sender, PaintEventArgs e)
        {
            TextBox txt = sender as TextBox;
            using (Pen pen = new Pen(System.Drawing.Color.FromArgb(206, 212, 218), 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, txt.Width - 1, txt.Height - 1);
            }
        }

        private void txtCustomerName_Paint(object sender, PaintEventArgs e)
        {
            TextBox txt = sender as TextBox;
            using (Pen pen = new Pen(System.Drawing.Color.White, 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, txt.Width - 1, txt.Height - 1);
            }
        }

        private void txtDiscount_Paint(object sender, PaintEventArgs e)
        {
            TextBox txt = sender as TextBox;
            using (Pen pen = new Pen(System.Drawing.Color.FromArgb(206, 212, 218), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, txt.Width - 1, txt.Height - 1);
            }
        }

        private void txtPaid_Paint(object sender, PaintEventArgs e)
        {
            TextBox txt = sender as TextBox;
            using (Pen pen = new Pen(System.Drawing.Color.FromArgb(206, 212, 218), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, txt.Width - 1, txt.Height - 1);
            }
        }

        // Panel shadows and effects
        private void pnlBilling_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;

            // Draw subtle shadow
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                int cornerRadius = 12;
                path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(panel.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(panel.Width - cornerRadius, panel.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(0, panel.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                path.CloseAllFigures();

                panel.Region = new System.Drawing.Region(path);
            }

            // Draw border
            using (Pen pen = new Pen(System.Drawing.Color.FromArgb(233, 236, 239), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        private void pnlProductSearch_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            using (Pen pen = new Pen(System.Drawing.Color.FromArgb(233, 236, 239), 1))
            {
                e.Graphics.DrawLine(pen, 0, panel.Height - 1, panel.Width, panel.Height - 1);
            }
        }

        private void pnlActions_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            using (Pen pen = new Pen(System.Drawing.Color.FromArgb(233, 236, 239), 1))
            {
                e.Graphics.DrawLine(pen, 0, 0, panel.Width, 0);
            }
        }

        private Button button1;
        private Label label1;
        private Label lablGtotal;
        private Label label3;
        private Button button2;
        private Label label2;
    }
}
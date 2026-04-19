namespace HondaStockBillingApp
{
    using System.Drawing;
    partial class AddProductForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.NumericUpDown numMinQty;
        private System.Windows.Forms.NumericUpDown numPurchase;
        private System.Windows.Forms.NumericUpDown numSale;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        // ✅ Labels (declared separately so Designer can parse)
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblMinQty;
        private System.Windows.Forms.Label lblPurchase;
        private System.Windows.Forms.Label lblSale;

        /// <summary>
        /// Clean up resources.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProductForm));
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.numMinQty = new System.Windows.Forms.NumericUpDown();
            this.numPurchase = new System.Windows.Forms.NumericUpDown();
            this.numSale = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblMinQty = new System.Windows.Forms.Label();
            this.lblPurchase = new System.Windows.Forms.Label();
            this.lblSale = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSale)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(129, 26);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(172, 20);
            this.txtCode.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(129, 61);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(172, 20);
            this.txtName.TabIndex = 3;
            // 
            // numQty
            // 
            this.numQty.Location = new System.Drawing.Point(129, 95);
            this.numQty.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numQty.Name = "numQty";
            this.numQty.Size = new System.Drawing.Size(103, 20);
            this.numQty.TabIndex = 5;
            // 
            // numMinQty
            // 
            this.numMinQty.Location = new System.Drawing.Point(129, 130);
            this.numMinQty.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMinQty.Name = "numMinQty";
            this.numMinQty.Size = new System.Drawing.Size(103, 20);
            this.numMinQty.TabIndex = 7;
            // 
            // numPurchase
            // 
            this.numPurchase.DecimalPlaces = 2;
            this.numPurchase.Location = new System.Drawing.Point(129, 165);
            this.numPurchase.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPurchase.Name = "numPurchase";
            this.numPurchase.Size = new System.Drawing.Size(103, 20);
            this.numPurchase.TabIndex = 9;
            // 
            // numSale
            // 
            this.numSale.DecimalPlaces = 2;
            this.numSale.Location = new System.Drawing.Point(129, 199);
            this.numSale.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSale.Name = "numSale";
            this.numSale.Size = new System.Drawing.Size(103, 20);
            this.numSale.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(69, 243);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(189, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 30);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(26, 26);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(75, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Product Code:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(26, 61);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(78, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Product Name:";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(26, 95);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(49, 13);
            this.lblQty.TabIndex = 4;
            this.lblQty.Text = "Quantity:";
            // 
            // lblMinQty
            // 
            this.lblMinQty.AutoSize = true;
            this.lblMinQty.Location = new System.Drawing.Point(26, 130);
            this.lblMinQty.Name = "lblMinQty";
            this.lblMinQty.Size = new System.Drawing.Size(46, 13);
            this.lblMinQty.TabIndex = 6;
            this.lblMinQty.Text = "Min Qty:";
            // 
            // lblPurchase
            // 
            this.lblPurchase.AutoSize = true;
            this.lblPurchase.Location = new System.Drawing.Point(26, 165);
            this.lblPurchase.Name = "lblPurchase";
            this.lblPurchase.Size = new System.Drawing.Size(82, 13);
            this.lblPurchase.TabIndex = 8;
            this.lblPurchase.Text = "Purchase Price:";
            // 
            // lblSale
            // 
            this.lblSale.AutoSize = true;
            this.lblSale.Location = new System.Drawing.Point(26, 199);
            this.lblSale.Name = "lblSale";
            this.lblSale.Size = new System.Drawing.Size(58, 13);
            this.lblSale.TabIndex = 10;
            this.lblSale.Text = "Sale Price:";
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 303);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.numQty);
            this.Controls.Add(this.lblMinQty);
            this.Controls.Add(this.numMinQty);
            this.Controls.Add(this.lblPurchase);
            this.Controls.Add(this.numPurchase);
            this.Controls.Add(this.lblSale);
            this.Controls.Add(this.numSale);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Product";
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

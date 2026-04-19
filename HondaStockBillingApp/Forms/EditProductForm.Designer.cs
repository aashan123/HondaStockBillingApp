using System.Windows.Forms;

namespace HondaStockBillingApp
{
    partial class EditProductForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblCode;
        private Label lblName;
        private Label lblQty;
        private Label lblMinQty;
        private Label lblPurchase;
        private Label lblSale;

        private TextBox txtCode;
        private TextBox txtName;
        private NumericUpDown numQty;
        private NumericUpDown numMinQty;
        private NumericUpDown numPurchase;
        private NumericUpDown numSale;

        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblMinQty = new System.Windows.Forms.Label();
            this.lblPurchase = new System.Windows.Forms.Label();
            this.lblSale = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.numMinQty = new System.Windows.Forms.NumericUpDown();
            this.numPurchase = new System.Windows.Forms.NumericUpDown();
            this.numSale = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSale)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(20, 20);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(100, 23);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Product Code:";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(20, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Product Name:";
            // 
            // lblQty
            // 
            this.lblQty.Location = new System.Drawing.Point(20, 100);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(100, 23);
            this.lblQty.TabIndex = 2;
            this.lblQty.Text = "Quantity:";
            // 
            // lblMinQty
            // 
            this.lblMinQty.Location = new System.Drawing.Point(20, 140);
            this.lblMinQty.Name = "lblMinQty";
            this.lblMinQty.Size = new System.Drawing.Size(100, 23);
            this.lblMinQty.TabIndex = 3;
            this.lblMinQty.Text = "Minimum Qty:";
            // 
            // lblPurchase
            // 
            this.lblPurchase.Location = new System.Drawing.Point(20, 180);
            this.lblPurchase.Name = "lblPurchase";
            this.lblPurchase.Size = new System.Drawing.Size(100, 23);
            this.lblPurchase.TabIndex = 4;
            this.lblPurchase.Text = "Purchase Price:";
            // 
            // lblSale
            // 
            this.lblSale.Location = new System.Drawing.Point(20, 220);
            this.lblSale.Name = "lblSale";
            this.lblSale.Size = new System.Drawing.Size(100, 23);
            this.lblSale.TabIndex = 5;
            this.lblSale.Text = "Sale Price:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(150, 20);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(200, 20);
            this.txtCode.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(150, 60);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 7;
            // 
            // numQty
            // 
            this.numQty.Location = new System.Drawing.Point(150, 100);
            this.numQty.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numQty.Name = "numQty";
            this.numQty.Size = new System.Drawing.Size(120, 20);
            this.numQty.TabIndex = 8;
            // 
            // numMinQty
            // 
            this.numMinQty.Location = new System.Drawing.Point(150, 140);
            this.numMinQty.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMinQty.Name = "numMinQty";
            this.numMinQty.Size = new System.Drawing.Size(120, 20);
            this.numMinQty.TabIndex = 9;
            // 
            // numPurchase
            // 
            this.numPurchase.DecimalPlaces = 2;
            this.numPurchase.Location = new System.Drawing.Point(150, 180);
            this.numPurchase.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPurchase.Name = "numPurchase";
            this.numPurchase.Size = new System.Drawing.Size(120, 20);
            this.numPurchase.TabIndex = 10;
            // 
            // numSale
            // 
            this.numSale.DecimalPlaces = 2;
            this.numSale.Location = new System.Drawing.Point(150, 220);
            this.numSale.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSale.Name = "numSale";
            this.numSale.Size = new System.Drawing.Size(120, 20);
            this.numSale.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(150, 270);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "💾 Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(250, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "❌ Cancel";
            // 
            // EditProductForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 330);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.lblMinQty);
            this.Controls.Add(this.lblPurchase);
            this.Controls.Add(this.lblSale);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.numQty);
            this.Controls.Add(this.numMinQty);
            this.Controls.Add(this.numPurchase);
            this.Controls.Add(this.numSale);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EditProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Product";
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

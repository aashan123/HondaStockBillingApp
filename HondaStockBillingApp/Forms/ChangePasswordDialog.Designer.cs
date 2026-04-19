namespace HondaStockBillingApp
{
    partial class ChangePasswordDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblNew = new System.Windows.Forms.Label();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbUsers
            // 
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.Font = new System.Drawing.Font("Calibri", 11F);
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(167, 21);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(189, 26);
            this.cmbUsers.TabIndex = 0;
            // 
            // txtNew
            // 
            this.txtNew.Font = new System.Drawing.Font("Calibri", 11F);
            this.txtNew.Location = new System.Drawing.Point(167, 63);
            this.txtNew.Name = "txtNew";
            this.txtNew.PasswordChar = '●';
            this.txtNew.Size = new System.Drawing.Size(189, 25);
            this.txtNew.TabIndex = 1;
            // 
            // txtConfirm
            // 
            this.txtConfirm.Font = new System.Drawing.Font("Calibri", 11F);
            this.txtConfirm.Location = new System.Drawing.Point(167, 100);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '●';
            this.txtConfirm.Size = new System.Drawing.Size(189, 25);
            this.txtConfirm.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(34, 24);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(82, 18);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Select User:";
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.lblNew.Location = new System.Drawing.Point(34, 63);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(103, 18);
            this.lblNew.TabIndex = 4;
            this.lblNew.Text = "New Password:";
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.lblConfirm.Location = new System.Drawing.Point(25, 103);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(123, 18);
            this.lblConfirm.TabIndex = 5;
            this.lblConfirm.Text = "Confirm Password:";
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnChange.FlatAppearance.BorderSize = 0;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.btnChange.ForeColor = System.Drawing.Color.White;
            this.btnChange.Location = new System.Drawing.Point(154, 139);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(90, 28);
            this.btnChange.TabIndex = 3;
            this.btnChange.Text = "🔒 Change";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(253, 139);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "✖ Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ChangePasswordDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(386, 191);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.cmbUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "🔒 Change User Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

using System;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
           
            InitializeComponent();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("👉 Stock Management Screen will open here");
            new StockManagmentForm().Show();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            new BillingForm().Show();   // Cashier also comes here directly
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
          
            new ReportsMainForm().Show();
        }
        private void restoreBill_Click(object sender, EventArgs e)
        {

            RestoreBillsForm restoreForm = new RestoreBillsForm();
            restoreForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var dlg = new ChangePasswordDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            BackupRestoreForm backupForm = new BackupRestoreForm();
            backupForm.Show();

        }
    }
}

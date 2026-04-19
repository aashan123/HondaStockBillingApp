using System;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class SplashScreen : Form
    {
        Timer timer = new Timer();

        public SplashScreen()
        {
            InitializeComponent();

            // Setup timer for 3 seconds
            timer.Interval = 3000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            //DatabaseHelper.TestConnection();
            //MainMenuForm mainMenuForm = new MainMenuForm();
            //mainMenuForm.Show();
            LoginForm login = new LoginForm();
            login.Show();
            //DatabaseHelper.TestConnection();


            //InvoiceForm invoiceForm = new InvoiceForm();
            //invoiceForm.Show();

            //ReportsMainForm reportsMainForm = new ReportsMainForm();
            //reportsMainForm.Show();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

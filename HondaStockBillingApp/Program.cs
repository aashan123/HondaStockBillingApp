using System;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // ✅ Make sure database exists in AppData before app starts
            DatabaseHelper.EnsureDatabase();

            // (Optional) — test connection during development
            // DatabaseHelper.TestConnection();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ✅ Start with SplashScreen (or MainForm directly if you prefer)
            Application.Run(new MainMenuForm());
        }
    }
}

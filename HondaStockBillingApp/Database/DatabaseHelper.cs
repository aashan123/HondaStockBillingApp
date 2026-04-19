using Microsoft.Data.Sqlite;
using System;
using System.IO;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public class DatabaseHelper
    {
        private static readonly string appDataFolder =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HondaStockBillingApp");

        private static readonly string dbFileName = "stock.db";
        private static readonly string dbPath = Path.Combine(appDataFolder, dbFileName);

        private static readonly string sourceDbPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dbFileName);

        public static string ConnectionString => $"Data Source={dbPath};";

         public static string LoggedInUsername { get; set; }

     
        public static void EnsureDatabase()
        {
            try
            {
                if (!Directory.Exists(appDataFolder))
                    Directory.CreateDirectory(appDataFolder);

                if (!File.Exists(dbPath) && File.Exists(sourceDbPath))
                {
                    File.Copy(sourceDbPath, dbPath, overwrite: false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error preparing database: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void TestConnection()
        {
            try
            {
                EnsureDatabase();
                using (var connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    MessageBox.Show("✅ Connected to DB!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB Error: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

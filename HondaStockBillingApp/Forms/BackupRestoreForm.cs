using System;
using System.IO;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class BackupRestoreForm : Form
    {
        public BackupRestoreForm()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string defaultFileName = $"stock_backup_{timestamp}.db";

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "SQLite Database (*.db)|*.db",
                    FileName = defaultFileName,
                    Title = "Save Database Backup",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string dbPath = DatabaseHelper.ConnectionString
                        .Replace("Data Source=", "")
                        .Replace(";", "");

                    File.Copy(dbPath, sfd.FileName, overwrite: true);

                    MessageBox.Show("✅ Backup created successfully!",
                        "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Database file is in use. Please close any open connections and try again.",
                    "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Backup error: " + ex.Message,
                    "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Filter = "SQLite Database (*.db)|*.db",
                    Title = "Select Backup to Restore"
                };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string dbPath = DatabaseHelper.ConnectionString
                        .Replace("Data Source=", "")
                        .Replace(";", "");

                    var confirm = MessageBox.Show(
                        $"⚠️ This will replace current database:Continue?",
                        "Confirm Restore",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        // Ensure no file lock
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        File.Copy(ofd.FileName, dbPath, overwrite: true);

                        MessageBox.Show("✅ Database restored successfully!\nPlease restart the app.",
                            "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Application.Restart();
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Database file is in use. Please close any open connections and try again.",
                    "Restore Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Restore error: " + ex.Message,
                    "Restore Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BackupRestoreForm_Load(object sender, EventArgs e)
        {

        }
    }
}

using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class ChangePasswordDialog : Form
    {
        public ChangePasswordDialog()
        {
            InitializeComponent();
            this.AcceptButton = btnChange;
            this.CancelButton = btnCancel;

            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                cmbUsers.Items.Clear();

                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT username FROM users ORDER BY username;";
                    using (var cmd = new SqliteCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbUsers.Items.Add(reader.GetString(0));
                        }
                    }
                }

                if (cmbUsers.Items.Count > 0)
                    cmbUsers.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string selectedUser = cmbUsers.SelectedItem?.ToString();
            string newPass = txtNew.Text.Trim();
            string confirm = txtConfirm.Text.Trim();

            if (string.IsNullOrEmpty(selectedUser) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirm)
            {
                MessageBox.Show("New password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();

                    // Directly update password (admin reset, no current password check)
                    string queryUpdate = "UPDATE users SET password=@newPass WHERE username=@u";
                    using (var cmd = new SqliteCommand(queryUpdate, conn))
                    {
                        cmd.Parameters.AddWithValue("@newPass", newPass);
                        cmd.Parameters.AddWithValue("@u", selectedUser);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Password updated successfully for user: " + selectedUser,
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No user updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

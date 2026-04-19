using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();

                    string query = "SELECT role FROM users WHERE username=@u AND password=@p";
                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);

                        var role = cmd.ExecuteScalar()?.ToString();

                        if (string.IsNullOrEmpty(role))
                        {
                            MessageBox.Show("Invalid username or password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // ✅ Store logged-in username and role globally
                        DatabaseHelper.LoggedInUsername = username;
                        //DatabaseHelper.LoggedInRole = role; // optional, for role-based logic in other forms

                        // Redirect based on role
                        this.Hide();
                        if (role == "admin")
                        {
                            new MainMenuForm().Show(); // open Admin menu
                        }
                        else if (role == "cashier")
                        {
                            new BillingForm().Show(); // open Billing directly
                        }
                        else
                        {
                            MessageBox.Show("Unknown role: " + role, "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Optional label click logic
        }
    }
}

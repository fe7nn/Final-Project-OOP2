using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Final_Project_OOP2
{
    public partial class VotingSytem : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb");

        public VotingSytem()
        {
            InitializeComponent();
            panelLogin.Visible = true;
            panelRegister.Visible = false;

            this.VisibleChanged += new EventHandler(VotingSytem_VisibleChanged);
        }

        private void VotingSytem_VisibleChanged(object? sender, EventArgs e)
        {
            if (this.Visible)
            {
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (!txtUsername.MaskFull)
            {
                MessageBox.Show("Please enter the complete ID in the format: ##-####-###");
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter your password.");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                // UPDATED: Changed [ElectionStar] to [ElectionStart] to match your screenshot
                string query = "SELECT [UserRole], [Username], [StudentName], [YearLevel], [Course], [ElectionTitle] FROM [Users] WHERE [Username] = ? AND [Password] = ?";

                OleDbCommand cmd = new OleDbCommand(query, conn);

                // Access requires parameters in the exact order of the '?' in the query
                cmd.Parameters.AddWithValue("@p1", txtUsername.Text); // For [Username]
                cmd.Parameters.AddWithValue("@p2", txtPassword.Text); // For [Password]
                 
                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string role = reader["UserRole"]?.ToString() ?? "voter";
                    string userID = reader["Username"]?.ToString() ?? "User";
                    string studentName = reader["StudentName"]?.ToString() ?? "Student";
                    string year = reader["YearLevel"]?.ToString() ?? "";
                    string course = reader["Course"]?.ToString() ?? "";
                    string studentElection = reader["ElectionTitle"].ToString();



                    MessageBox.Show($"Login Successful! Welcome, {studentName}.");

                    if (role.ToLower() == "admin")
                    {
                        AdminDashboard adminForm = new AdminDashboard(userID);
                        adminForm.RefreshAllData();
                        adminForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Now passing the correct data to your VoterDashboard
                        VoterDashboard vDash = new VoterDashboard(userID, studentName, year, course, studentElection);
                        vDash.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnSubmitRegistration_Click(object sender, EventArgs e)
        {
            if (!txtRegUser.MaskFull)
            {
                MessageBox.Show("Please enter the complete ID: ##-####-###");
                return;
            }

            if (!txtRegEmail.Text.Contains("@") || !txtRegEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email.");
                return;
            }

            if (string.IsNullOrEmpty(txtRegPass.Text))
            {
                MessageBox.Show("Please enter a password.");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                string query = "INSERT INTO [Users] ([Username], [Email], [Password], [UserRole]) VALUES (?, ?, ?, 'voter')";
                OleDbCommand cmd = new OleDbCommand(query, conn);

                cmd.Parameters.AddWithValue("?", txtRegUser.Text);
                cmd.Parameters.AddWithValue("?", txtRegEmail.Text.Trim());
                cmd.Parameters.AddWithValue("?", txtRegPass.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Registration Successful! You can now log in.");

                ClearRegistrationFields();
                panelRegister.Visible = false;
                panelLogin.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void ClearRegistrationFields()
        {
            txtRegUser.Clear();
            txtRegEmail.Clear();
            txtRegPass.Clear();
            txtRegUser.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
            panelRegister.Location = panelLogin.Location;
            panelRegister.Size = panelLogin.Size;
            panelRegister.Visible = true;
            panelRegister.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearRegistrationFields();
            panelRegister.Visible = false;
            panelLogin.Visible = true;
            panelLogin.BringToFront();
            txtUsername.Focus();
        }

        private void VotingSytem_Load(object sender, EventArgs e)
        {
        }
    }
}
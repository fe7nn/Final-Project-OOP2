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

                // --- STEP 1: CHECK THE ADMIN TABLE (Admins & Presidents) ---
                string adminQuery = "SELECT [UserRole], [Username], [StudentName], [AssignedOrg] FROM [Admin] WHERE [Username] = ? AND [Password] = ?";
                OleDbCommand adminCmd = new OleDbCommand(adminQuery, conn);
                adminCmd.Parameters.AddWithValue("@u", txtUsername.Text);
                adminCmd.Parameters.AddWithValue("@p", txtPassword.Text);

                OleDbDataReader adminReader = adminCmd.ExecuteReader();

                if (adminReader.Read())
                {
                    string role = adminReader["UserRole"]?.ToString().Trim() ?? "";
                    string userID = adminReader["Username"]?.ToString() ?? "";
                    string name = adminReader["StudentName"]?.ToString() ?? "";
                    string assignedOrg = adminReader["AssignedOrg"]?.ToString() ?? "";

                    if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"Access Granted: Welcome Adviser {name}.");
                        AdminDashboard adminForm = new AdminDashboard(userID);
                        adminForm.Show();
                        this.Hide();
                        return; // Stop here
                    }
                    else if (role.Equals("President", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"Access Granted: Welcome {assignedOrg} President {name}.");
                        OrgPresidentDashboard presDash = new OrgPresidentDashboard(userID, assignedOrg);
                        presDash.Show();
                        this.Hide();
                        return; // Stop here
                    }
                }
                adminReader.Close();

                // --- STEP 2: CHECK THE VOTERS TABLE (Students) ---
                // Assuming your Voters table has these columns based on your previous screen
                string voterQuery = "SELECT [Username], [StudentName], [YearLevel], [Course], [ElectionTitle] FROM [Voters] WHERE [Username] = ? AND [Password] = ?";
                OleDbCommand voterCmd = new OleDbCommand(voterQuery, conn);
                voterCmd.Parameters.AddWithValue("@u", txtUsername.Text);
                voterCmd.Parameters.AddWithValue("@p", txtPassword.Text);

                OleDbDataReader voterReader = voterCmd.ExecuteReader();

                if (voterReader.Read())
                {
                    string userID = voterReader["Username"]?.ToString() ?? "";
                    string name = voterReader["StudentName"]?.ToString() ?? "";
                    string year = voterReader["YearLevel"]?.ToString() ?? "";
                    string course = voterReader["Course"]?.ToString() ?? "";
                    string election = voterReader["ElectionTitle"]?.ToString() ?? "";

                    MessageBox.Show($"Login Successful! Welcome, {name}.");
                    VoterDashboard vDash = new VoterDashboard(userID, name, year, course, election);
                    vDash.Show();
                    this.Hide();
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
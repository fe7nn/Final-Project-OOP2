using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.Logging;
using System.Data.OleDb;

namespace Final_Project_OOP2
{
    public partial class VoterDashboard : Form
    {
        // GLOBAL CONNECTION STRING - Use this to ensure consistency
        string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;Mode=Share Deny None;";

        private string currentVoterID;
        private string loggedInStudentName;
        private DateTime electionStartTime;
        private DateTime electionEndTime;
        private string loggedInYear;
        private string loggedInCourse;
        private string currentElectionTitle;
        private System.Windows.Forms.Timer dashboardTimer;

        public VoterDashboard(string voterID, string StudentName, string year, string course, string electionTitle)
        {
            InitializeComponent();
            this.currentVoterID = voterID;
            this.loggedInStudentName = StudentName;
            this.loggedInYear = year;
            this.loggedInCourse = course;
            this.currentElectionTitle = electionTitle;
        }

        private void VoterDashboard_Load(object sender, EventArgs e)
        {
            pnlDashboard.BringToFront();
            lblWelcome.Text = $"Welcome, {loggedInStudentName}";

            // 1. ALWAYS check the database first to set the "Already Voted" flag
            CheckIfUserHasVoted();

            // 2. Load the schedule if a title exists
            if (!string.IsNullOrEmpty(currentElectionTitle))
            {
                LoadElectionSchedule();
                StartCountdown();
            }
            else
            {
                lblStatusLabel.Text = "No Election Assigned";
                if (btnVoteNow.Text != "Already Voted")
                {
                    btnVoteNow.Text = "Closed";
                    btnVoteNow.Enabled = false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblElectionTitle.Text = currentElectionTitle;

            if (btnVoteNow.Text == "Already Voted" || btnVoteNow.Text == "Voted")
            {
                btnVoteNow.Enabled = false;
                lblStatusLabel.Text = "VOTED";
                lblStatusLabel.BackColor = Color.Gray;
            }
            else
            {
                // This assumes your ElectionManager class is correctly handling logic
                lblStatusLabel.Text = ElectionManager.GetStatus();
                lblStatusLabel.BackColor = ElectionManager.GetStatusColor();
                btnVoteNow.Enabled = (ElectionManager.GetStatus() == "ACTIVE");
            }
        }

        private void CheckIfUserHasVoted()
        {
            // Clean up any existing locks
            OleDbConnection.ReleaseObjectPool();

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Using Username = ? to match your variable currentVoterID
                    string query = "SELECT HasVoted FROM Voters WHERE Username = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", this.currentVoterID);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result.ToString().Trim().Equals("Yes", StringComparison.OrdinalIgnoreCase))
                        {
                            btnVoteNow.Enabled = false;
                            btnVoteNow.Text = "Voted";
                            lblStatusLabel.Text = "Already Voted";
                        }
                        else
                        {
                            btnVoteNow.Text = "Vote Now!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking vote status: " + ex.Message);
                }
            }
        }

        private void LoadElectionSchedule()
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT StartDate, EndDate FROM Elections WHERE ElectionTitle = ?";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", currentElectionTitle);
                        OleDbDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            this.electionStartTime = Convert.ToDateTime(reader["StartDate"]);
                            this.electionEndTime = Convert.ToDateTime(reader["EndDate"]);

                            lblElectionTitle.Text = currentElectionTitle;
                            lblStartDate.Text = "Start: " + electionStartTime.ToString("MMM dd, yyyy hh:mm tt");
                            lblEndDate.Text = "End: " + electionEndTime.ToString("MMM dd, yyyy hh:mm tt");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading schedule: " + ex.Message);
                }
            }
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan remaining = electionEndTime - now;

            if (now < electionStartTime)
            {
                lblTimeRemaining.Text = "Not Started";
            }
            else if (remaining.TotalSeconds <= 0)
            {
                lblTimeRemaining.Text = "Election Closed";
                lblTimeRemaining.ForeColor = Color.Red;
            }
            else
            {
                lblTimeRemaining.Text = string.Format("{0:D2}d {1:D2}h {2:D2}m {3:D2}s",
                    remaining.Days, remaining.Hours, remaining.Minutes, remaining.Seconds);
            }
        }

        private void StartCountdown()
        {
            dashboardTimer = new System.Windows.Forms.Timer();
            dashboardTimer.Interval = 1000;
            dashboardTimer.Tick += countdownTimer_Tick;
            dashboardTimer.Start();
        }

        private void btnVoteNow_Click(object sender, EventArgs e)
        {
            // STOP THE TIMERS: This is the crucial fix for E_FAIL. 
            // It prevents the dashboard from asking for the DB while the Voting form is loading.
            if (dashboardTimer != null) dashboardTimer.Stop();

            // RELEASE THE DATABASE FILE
            OleDbConnection.ReleaseObjectPool();

            VotingForm vf = new VotingForm(currentVoterID, loggedInStudentName, loggedInYear, loggedInCourse, currentElectionTitle);

            this.Hide();
            vf.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e) => pnlDashboard.BringToFront();

        private void btnProfile_Click(object sender, EventArgs e)
        {
            pnlProfile.BringToFront();
            lblProfileFullName.Text = loggedInStudentName;
            lblYearLevel.Text = loggedInYear;
            lblCourse.Text = loggedInCourse;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (dashboardTimer != null) dashboardTimer.Stop();
                OleDbConnection.ReleaseObjectPool();

                Form loginForm = Application.OpenForms["VotingSytem"];
                if (loginForm != null)
                {
                    loginForm.Show();
                }
                else
                {
                    VotingSytem newLogin = new VotingSytem();
                    newLogin.Show();
                }
                this.Close();
            }
        }
    }
}
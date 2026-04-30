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
                // No election assigned to this voter at all
                lblElectionTitle.Text = "No Election Assigned";
                lblStartDate.Text = "";
                lblEndDate.Text = "";
                lblTimeRemaining.Text = "N/A";
                lblActiveElections.Text = "NO ELECTION";
                lblActiveElections.BackColor = Color.Gray;

                // Only disable if they haven't already voted
                if (btnVoteNow.Text != "Already Voted" && btnVoteNow.Text != "Voted")
                {
                    btnVoteNow.Text = "No Election";
                    btnVoteNow.Enabled = false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Guard: don't run if no election is assigned
            if (string.IsNullOrEmpty(currentElectionTitle)) return;

            lblElectionTitle.Text = currentElectionTitle;

            if (btnVoteNow.Text == "Already Voted" || btnVoteNow.Text == "Voted")
            {
                btnVoteNow.Enabled = false;
                lblActiveElections.Text = "VOTED";
                lblActiveElections.BackColor = Color.Gray;
                return;
            }

            DateTime now = DateTime.Now;

            if (now < electionStartTime)
            {
                lblActiveElections.Text = "UPCOMING";
                lblActiveElections.BackColor = Color.SteelBlue;
                btnVoteNow.Enabled = false;
                btnVoteNow.Text = "Not Yet Open";
            }
            else if (now >= electionStartTime && now <= electionEndTime)
            {
                lblActiveElections.Text = "ACTIVE";
                lblActiveElections.BackColor = Color.Green;

                // Don't re-enable if already voted
                if (btnVoteNow.Text != "Voted" && btnVoteNow.Text != "Already Voted")
                {
                    btnVoteNow.Enabled = true;
                    btnVoteNow.Text = "Vote Now!";
                }
            }
            else
            {
                lblActiveElections.Text = "CLOSED";
                lblActiveElections.BackColor = Color.Red;
                btnVoteNow.Enabled = false;
                btnVoteNow.Text = "Election Closed";
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
                            lblActiveElections.Text = "Already Voted";
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

                            // Dynamically set the "Active Elections" header label
                            DateTime now = DateTime.Now;
                            if (now < electionStartTime)
                            {
                                lblActiveElections.Text = "Upcoming Election";  // change to your label's name
                                lblActiveElections.Text = "UPCOMING";
                                lblActiveElections.BackColor = Color.SteelBlue;
                                btnVoteNow.Enabled = false;
                                btnVoteNow.Text = "Not Yet Open";
                            }
                            else if (now >= electionStartTime && now <= electionEndTime)
                            {
                                lblActiveElections.Text = "Active Election";
                                lblActiveElections.Text = "ACTIVE";
                                lblActiveElections.BackColor = Color.Green;
                            }
                            else
                            {
                                lblActiveElections.Text = "Completed Election";
                                lblActiveElections.Text = "CLOSED";
                                lblActiveElections.BackColor = Color.Red;
                                btnVoteNow.Enabled = false;
                                btnVoteNow.Text = "Election Closed";
                            }
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
                TimeSpan startsIn = electionStartTime - now;
                lblTimeRemaining.Text = string.Format("Starts in {0:D2}d {1:D2}h {2:D2}m {3:D2}s",
                    startsIn.Days, startsIn.Hours, startsIn.Minutes, startsIn.Seconds);
                lblTimeRemaining.ForeColor = Color.SteelBlue;
                btnVoteNow.Enabled = false;
                btnVoteNow.Text = "Not Yet Open";
            }
            else if (remaining.TotalSeconds <= 0)
            {
                lblTimeRemaining.Text = "Election Closed";
                lblTimeRemaining.ForeColor = Color.Red;
                btnVoteNow.Enabled = false;
                btnVoteNow.Text = "Election Closed";
                if (dashboardTimer != null) dashboardTimer.Stop(); // No need to keep ticking
            }
            else
            {
                lblTimeRemaining.Text = string.Format("{0:D2}d {1:D2}h {2:D2}m {3:D2}s",
                    remaining.Days, remaining.Hours, remaining.Minutes, remaining.Seconds);
                lblTimeRemaining.ForeColor = Color.Black;
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
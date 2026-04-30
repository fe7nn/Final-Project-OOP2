using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace Final_Project_OOP2
{
    public partial class VotingForm : Form
    {
        // GLOBAL CONNECTION STRING
        string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;Mode=Share Deny None;";

        private string currentVoterID;
        private string loggedInStudentName;
        private string currentElectionTitle;

        // Added fields to store constructor year/course values
        private string currentYear;
        private string currentCourse;

        public VotingForm(string voterID, string studentName, string year, string course, string electionTitle)
        {
            InitializeComponent();
            this.currentVoterID = voterID;
            this.loggedInStudentName = studentName;
            this.currentElectionTitle = electionTitle;
            this.currentYear = year;
            this.currentCourse = course;
        }

        private void VotingForm_Load(object sender, EventArgs e)
        {
            lblProfileFullName.Text = loggedInStudentName;

            // Use stored fields
            lblYearLevel.Text = currentYear;
            lblCourse.Text = currentCourse;

            lblElectionTitle.Text = currentElectionTitle;
            // Release any locks from the Dashboard
            OleDbConnection.ReleaseObjectPool();
            LoadComboBoxPositions();
        }

        private void LoadComboBoxPositions()
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // We wrap Position in brackets in case it's a reserved word
                    string sql = "SELECT DISTINCT [Position] FROM Candidates WHERE ElectionTitle = ?";
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.Parameters.AddWithValue("?", currentElectionTitle);

                    OleDbDataReader reader = cmd.ExecuteReader();
                    cmbPositions.Items.Clear();

                    while (reader.Read())
                    {
                        cmbPositions.Items.Add(reader["Position"].ToString());
                    }

                    if (cmbPositions.Items.Count > 0)
                    {
                        cmbPositions.SelectedIndex = 0; // This triggers the DGV load
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading positions: " + ex.Message);
                }
            }
        }

        private void cmbPositions_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbPositions.SelectedItem == null) return;

            string selectedPosition = cmbPositions.SelectedItem.ToString();
            OleDbConnection.ReleaseObjectPool();

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT FullName, Description, ImagePath FROM Candidates WHERE [Position] = ? AND ElectionTitle = ?";
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.Parameters.AddWithValue("?", selectedPosition);
                    cmd.Parameters.AddWithValue("?", currentElectionTitle);

                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Ensure ActualImage column is typed as Image
                    if (!dt.Columns.Contains("ActualImage"))
                        dt.Columns.Add("ActualImage", typeof(Image));

                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            string path = row["ImagePath"]?.ToString() ?? "";
                            if (!string.IsNullOrWhiteSpace(path) && System.IO.File.Exists(path))
                            {
                                // Load as Image (dispose handled by DataGridView)
                                row["ActualImage"] = Image.FromFile(path);
                            }
                            else
                            {
                                row["ActualImage"] = null;
                            }
                        }
                        catch
                        {
                            row["ActualImage"] = null;
                        }
                    }

                    // Keep designer layout: don't auto-generate columns
                    dgvCandidates.AutoGenerateColumns = false;
                    dgvCandidates.DataSource = dt;

                    // Robust mapping: find appropriate columns by Name or HeaderText and set DataPropertyName
                    // Image column
                    foreach (DataGridViewColumn col in dgvCandidates.Columns)
                    {
                        string header = (col.HeaderText ?? "").ToLower();
                        string name = (col.Name ?? "").ToLower();

                        if (col is DataGridViewImageColumn || name.Contains("image") || header.Contains("image") || header.Contains("photo") || name.Contains("photo"))
                        {
                            col.DataPropertyName = "ActualImage";
                            ((DataGridViewImageColumn)col).ImageLayout = DataGridViewImageCellLayout.Zoom;
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            col.Width = 100;
                        }
                        else if (name.Contains("name") || header.Contains("name") || header.Contains("full name"))
                        {
                            col.DataPropertyName = "FullName";
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        else if (name.Contains("desc") || header.Contains("desc") || header.Contains("description") || header.Contains("party"))
                        {
                            col.DataPropertyName = "Description";
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }

                    // --- ROW HEIGHT FIX ---
                    // Increased to 100 so the photo isn't crushed into an 'X'
                    dgvCandidates.RowTemplate.Height = 100;
                    foreach (DataGridViewRow row in dgvCandidates.Rows)
                    {
                        row.Height = 100;
                    }

                    dgvCandidates.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            pnlProfile.BringToFront();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pnlVoterArea.BringToFront();
        }

        private void dgvCandidates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvCandidates.Columns[e.ColumnIndex].Name == "colVote" || dgvCandidates.Columns[e.ColumnIndex].HeaderText == "Action")
            {
                string selectedCandidate = "";
                foreach (DataGridViewColumn col in dgvCandidates.Columns)
                {
                    if (col.DataPropertyName == "FullName")
                    {
                        selectedCandidate = dgvCandidates.Rows[e.RowIndex].Cells[col.Index].Value?.ToString() ?? "";
                        break;
                    }
                }

                if (cmbPositions.SelectedItem == null)
                {
                    MessageBox.Show("Please select a position before voting.",
                                    "No Position Selected",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                string selectedPosition = cmbPositions.SelectedItem.ToString();

                DialogResult result = MessageBox.Show($"Are you sure you want to vote for {selectedCandidate} as {selectedPosition}?",
                    "Confirm Vote", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    RecordVote(selectedCandidate, selectedPosition);
                }
            }
        }

        private void RecordVote(string candidate, string position)
        {
            if (HasAlreadyVotedForPosition(currentVoterID, position, currentElectionTitle))
            {
                MessageBox.Show($"You have already cast your vote for the position of {position}!",
                                "Duplicate Vote", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OleDbConnection.ReleaseObjectPool();
            string course = GetVoterCourse(currentVoterID);

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Votes (VoterID, CandidateName, [Position], ElectionTitle, VoteTimestamp, [Course]) " +
                                 "VALUES (?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", currentVoterID);
                        cmd.Parameters.AddWithValue("?", candidate);
                        cmd.Parameters.AddWithValue("?", position);
                        cmd.Parameters.AddWithValue("?", currentElectionTitle);
                        cmd.Parameters.AddWithValue("?", DateTime.Now.ToString());
                        cmd.Parameters.AddWithValue("?", course);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Vote cast successfully for {candidate}!");
                    }
                }
                catch (Exception ex) { MessageBox.Show("Vote Error: " + ex.Message); }
            }
        }

        private bool HasAlreadyVotedForPosition(string voterID, string position, string election)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Votes WHERE VoterID = ? AND [Position] = ? AND ElectionTitle = ?";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", voterID);
                        cmd.Parameters.AddWithValue("?", position);
                        cmd.Parameters.AddWithValue("?", election);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        private string GetVoterCourse(string id)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT Course FROM Voters WHERE Username = ?";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.AddWithValue("?", id);
                return cmd.ExecuteScalar()?.ToString() ?? "Unknown";
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            int totalPositions = GetTotalPositions();
            int userVotes = GetUserVoteCount();

            if (userVotes < totalPositions)
            {
                MessageBox.Show($"Incomplete Ballot! You have only voted for {userVotes} out of {totalPositions} positions.",
                                "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateVoterStatus();
            MessageBox.Show("Thank you for voting! Your session is now closed.", "Logged Out");

            this.Hide();
            VotingSytem newLogin = new VotingSytem();
            newLogin.Show();
        }

        private int GetTotalPositions()
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM (SELECT DISTINCT [Position] FROM Candidates WHERE ElectionTitle = ?)";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", currentElectionTitle);
                        return (int)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error counting positions: " + ex.Message);
                    return 0;
                }
            }
        }

        private int GetUserVoteCount()
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Votes WHERE VoterID = ? AND ElectionTitle = ?";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.AddWithValue("?", currentVoterID);
                cmd.Parameters.AddWithValue("?", currentElectionTitle);
                return (int)cmd.ExecuteScalar();
            }
        }

        private void UpdateVoterStatus()
        {
            if (string.IsNullOrEmpty(currentVoterID)) return;

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE [Voters] SET [HasVoted] = 'Yes' WHERE [Username] = ?";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", currentVoterID);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating status: " + ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
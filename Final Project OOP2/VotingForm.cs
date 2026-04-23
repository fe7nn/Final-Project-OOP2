using System;
using System.Data;
using System.Data.OleDb;
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

        public VotingForm(string voterID, string studentName, string year, string course, string electionTitle)
        {
            InitializeComponent();
            this.currentVoterID = voterID;
            this.loggedInStudentName = studentName;
            this.currentElectionTitle = electionTitle;
        }

        private void VotingForm_Load(object sender, EventArgs e)
        {
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

                    dt.Columns.Add("ActualImage", typeof(byte[]));

                    foreach (DataRow row in dt.Rows)
                    {
                        string path = row["ImagePath"].ToString();
                        if (System.IO.File.Exists(path))
                        {
                            row["ActualImage"] = System.IO.File.ReadAllBytes(path);
                        }
                    }

                    dgvCandidates.AutoGenerateColumns = false;
                    dgvCandidates.DataSource = dt;

                    // --- PHOTO FIX & COLUMN CENTERING ---
                    if (dgvCandidates.Columns.Contains("colImage"))
                    {
                        DataGridViewImageColumn imgCol = (DataGridViewImageColumn)dgvCandidates.Columns["colImage"];
                        imgCol.DataPropertyName = "ActualImage";
                        imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        imgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        imgCol.Width = 100;
                    }

                    // Center the Text for Name and Party
                    if (dgvCandidates.Columns.Contains("FullName"))
                    {
                        dgvCandidates.Columns["FullName"].DataPropertyName = "FullName";
                        dgvCandidates.Columns["FullName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    if (dgvCandidates.Columns.Contains("Description"))
                    {
                        dgvCandidates.Columns["Description"].DataPropertyName = "Description";
                        dgvCandidates.Columns["Description"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // --- ROW HEIGHT FIX ---
                    // Increased to 100 so the photo isn't crushed into an 'X'
                    dgvCandidates.RowTemplate.Height = 100;
                    foreach (DataGridViewRow row in dgvCandidates.Rows)
                    {
                        row.Height = 100;
                    }
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

            // Check if the click was on the "VOTE" column
            // Replace "colVote" with whatever the (Name) of your button column is
            if (dgvCandidates.Columns[e.ColumnIndex].Name == "colVote" || dgvCandidates.Columns[e.ColumnIndex].HeaderText == "Action")
            {
                // USE THE COLUMN INDEXES TO BE SAFE
                // If 'FullName' is the second column, use index [1]
                // If 'FullName' has a Designer Name like 'colName', use that.

                string selectedCandidate = "";

                // Safer way: search for the column that is mapped to "FullName"
                foreach (DataGridViewColumn col in dgvCandidates.Columns)
                {
                    if (col.DataPropertyName == "FullName")
                    {
                        selectedCandidate = dgvCandidates.Rows[e.RowIndex].Cells[col.Index].Value.ToString();
                        break;
                    }
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
                return; // Stop the method here
            }

            OleDbConnection.ReleaseObjectPool();
            string course = GetVoterCourse(currentVoterID); // Helper method to find the course

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Using [brackets] for Position and Course as they can be reserved words
                    string sql = "INSERT INTO Votes (VoterID, CandidateName, [Position], ElectionTitle, VoteTimestamp, [Course]) " +
                                 "VALUES (?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        // Order matters! Must match the '?' order in the SQL string
                        cmd.Parameters.AddWithValue("?", currentVoterID);
                        cmd.Parameters.AddWithValue("?", candidate);
                        cmd.Parameters.AddWithValue("?", position);
                        cmd.Parameters.AddWithValue("?", currentElectionTitle);

                        // For Access, sometimes sending the string version of the date is safer
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
                    // Count rows matching this student, this position, and this election
                    string sql = "SELECT COUNT(*) FROM Votes WHERE VoterID = ? AND [Position] = ? AND ElectionTitle = ?";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", voterID);
                        cmd.Parameters.AddWithValue("?", position);
                        cmd.Parameters.AddWithValue("?", election);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; // Returns true if they already voted
                    }
                }
                catch
                {
                    return false; // Default to false if there's a DB error
                }
            }
        }

        private string GetVoterCourse(string id)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT Course FROM Users WHERE Username = ?";
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

            // Success! Update their status and leave
            UpdateVoterStatus();
            MessageBox.Show("Thank you for voting! Your session is now closed.", "Logged Out");
            // 3. If they finished, mark them as 'HasVoted' in the database


            // 4. Proceed to Logout
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
                    // Access fix: Count the rows of a subquery that finds DISTINCT positions
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
                    // Table name is 'Users' and ID column is 'Username' based on your screenshot
                    string sql = "UPDATE [Users] SET [HasVoted] = 'Yes' WHERE [Username] = ?";

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

    

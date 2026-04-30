using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_OOP2
{
    public partial class OrgPresidentDashboard : Form
    {
        private string presID;
        private string myOrg;

        private string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";
        string selectedElection = ""; // This will be set when the dashboard loads and elections are pulled

        public OrgPresidentDashboard(string userID, string orgName)
        {
            InitializeComponent();
            this.presID = userID;
            this.myOrg = orgName;
        }

        private void OrgPresidentDashboard_Load(object sender, EventArgs e)
        {
            UpdateStatCards();

            LoadPositionsIntoComboBox();
            LoadOrgVoters();
            LoadAssignedElections();
            LoadCandidatesFromAccess();

            lblOrgTitle.Text = "Welcome, " + myOrg + " President!";

            pnlDashboard.Visible = true;
            pnlCandidate.Visible = false;
            pnlVoters.Visible = false;
            pnlResults.Visible = false;
            pnlAnalytics.Visible = false;
        }

        private void ShowPanel(Panel targetPanel)
        {
            pnlDashboard.Visible = (targetPanel == pnlDashboard);
            pnlCandidate.Visible = (targetPanel == pnlCandidate);
            pnlVoters.Visible = (targetPanel == pnlVoters);
            pnlResults.Visible = (targetPanel == pnlResults);
            pnlAnalytics.Visible = (targetPanel == pnlAnalytics);

            if (targetPanel.Visible) targetPanel.BringToFront();
        }

        private void DashButton_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlDashboard);
            UpdateStatCards();
            LoadVoterCounts();// Refresh the counts and leader on the home screen
        }

        private void VotersButton_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlVoters);
            LoadOrgVoters(); // Refresh the grid to show new registrations or vote statuses
        }

        private void CandidateButton_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlCandidate);
            // If you have a LoadCandidates() method, call it here
        }

        private void ResultsButton_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlResults);
            LoadElectionResults();// Optional: Refresh any simple results list here
        }

        private void AnalyticsButton_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlAnalytics);
            // Refresh the bar chart
            LoadOrgPresidentAnalytics();  // Refresh the pie chart
        }

        private void LoadVoterCounts()
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Filter count by the President's organization
                    string sql = "SELECT COUNT(*) FROM Voters WHERE ElectionTitle LIKE ?";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", myOrg + "%");
                        int count = (int)cmd.ExecuteScalar();
                        lblTotalVotersCount.Text = count.ToString();
                    }
                }
                catch (Exception ex) { /* Handle error */ }
            }
        }

        private void LoadOrgVoters()
        {
            // 1. Ensure your connection string is correct at the top of the file
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // 2. We change the query to use LIKE ? so it can match the partial name
                    string sql = "SELECT Username, Password, StudentName, YearLevel, HasVoted " + "FROM Voters WHERE ElectionTitle LIKE ?";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        // 3. Add the '%' wildcard so "ICPEP-SE" matches "ICPEP-SE CIT-U CHAPTER"
                        cmd.Parameters.AddWithValue("?", myOrg + "%");

                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // 4. Bind to your DataGridView
                        dgvVoters.DataSource = dt;
                        lblVNoVoters.Visible = (dt.Rows.Count == 0);
                        // 5. Hide the "No voters yet" message if data exists
                        lblTotalVotersCount.Text = dt.Rows.Count.ToString();
                        totalVotersValue.Text = dt.Rows.Count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading organization voters: " + ex.Message);
                }
            }
        }

        private void LoadAssignedElections()
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // This subquery pulls the real-time count from the Votes table
                    string query = @"SELECT e.ElectionTitle, e.Status, e.StartDate, e.EndDate, 
                            (SELECT COUNT(*) FROM Votes v WHERE v.ElectionTitle = e.ElectionTitle) AS VoteCount 
                            FROM Elections e WHERE e.ElectionTitle LIKE ?";

                    // FIX: Use 'query' here (not 'sql')
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Ensure myOrg matches the start of "ICPEP-SE CIT-U CHAPTER"
                        cmd.Parameters.AddWithValue("?", myOrg + "%");

                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Stop duplicate columns
                        dgvUpcomingElections.AutoGenerateColumns = false;
                        dgvUpcomingElections.DataSource = dt;

                        // Toggle "No upcoming elections" message
                        lblNoElections.Visible = (dt.Rows.Count == 0);

                        UpdateElectionStats(dt);
                    }
                }
                catch (Exception ex) { MessageBox.Show("Election Load Error: " + ex.Message); }
            }
        }

        private void LoadCandidates()
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Filter by the organization assigned to this President
                    string query = "SELECT CandidateName, Position, ElectionTitle, ImagePath FROM Candidates WHERE Organization = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", myOrg); // e.g., "ICPEP"

                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvCandidates.AutoGenerateColumns = false;

                        // Map your designer columns
                        dgvCandidates.Columns["colCName"].DataPropertyName = "CandidateName";
                        dgvCandidates.Columns["colCPosition"].DataPropertyName = "Position";
                        dgvCandidates.Columns["colCElection"].DataPropertyName = "ElectionTitle";

                        dgvCandidates.DataSource = dt;

                        // Hide the "No candidates yet" message if data exists
                        lblNoCandidates.Visible = (dt.Rows.Count == 0);
                    }
                }
                catch (Exception ex) { MessageBox.Show("Candidate Load Error: " + ex.Message); }
            }
        }

        private void UpdateElectionStats(DataTable dt)
        {
            int active = 0;
            int completed = 0;

            foreach (DataRow row in dt.Rows)
            {
                string status = row["Status"].ToString().ToLower();
                // Check your database for the exact word used (e.g., "Active" or "Ongoing")
                if (status == "active") active++;
                else if (status == "completed") completed++;
            }

            lblActiveCount.Text = active.ToString();
            lblCompletedCount.Text = completed.ToString();
        }


        private void UpdateStatCards()
        {
            // Use the variable passed from Login instead of a ComboBox
            string selected = this.myOrg;

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // 2. LATEST VOTE Timestamp
                    string sqlLatest = "SELECT TOP 1 VoteTimestamp FROM Votes WHERE ElectionTitle = ? ORDER BY VoteTimestamp DESC";
                    using (OleDbCommand cmd = new OleDbCommand(sqlLatest, conn))
                    {
                        cmd.Parameters.AddWithValue("?", selected);
                        object result = cmd.ExecuteScalar();
                        lblLatestVote.Text = (result != null) ? Convert.ToDateTime(result).ToString("hh:mm tt") : "N/A";
                    }

                    // 3. LEADING CANDIDATE
                    string sqlLeader = "SELECT TOP 1 CandidateName FROM Votes WHERE ElectionTitle = ? GROUP BY CandidateName ORDER BY COUNT(*) DESC";
                    using (OleDbCommand cmd = new OleDbCommand(sqlLeader, conn))
                    {
                        cmd.Parameters.AddWithValue("?", selected);
                        lblLeadingCandidate.Text = cmd.ExecuteScalar()?.ToString() ?? "No Leader";
                    }

                    // 4. TOTAL TURNOUT (Filtered by this Org)
                    // We need to compare "Voters in this Org" vs "Votes in this Org"
                    string sqlOrgVoters = "SELECT COUNT(*) FROM Voters WHERE [UserRole] = 'voter' AND [ElectionTitle] = ?";
                    int totalInOrg = 0;
                    using (OleDbCommand cmd = new OleDbCommand(sqlOrgVoters, conn))
                    {
                        cmd.Parameters.AddWithValue("?", selected);
                        totalInOrg = (int)cmd.ExecuteScalar();
                    }

                    string sqlVotedCount = "SELECT COUNT(DISTINCT [VoterID]) FROM Votes WHERE ElectionTitle = ?";
                    // Note: If Access doesn't support COUNT(DISTINCT), use: 
                    // "SELECT COUNT(*) FROM (SELECT DISTINCT [VoterID] FROM Votes WHERE ElectionTitle = ?)"
                    int totalVoted = 0;
                    using (OleDbCommand cmdVoted = new OleDbCommand("SELECT COUNT(*) FROM (SELECT DISTINCT [VoterID] FROM Votes WHERE ElectionTitle = ?)", conn))
                    {
                        cmdVoted.Parameters.AddWithValue("?", selected);
                        totalVoted = (int)cmdVoted.ExecuteScalar();
                    }

                    if (totalInOrg > 0)
                    {
                        double turnoutPercent = ((double)totalVoted / totalInOrg) * 100;
                        lblTurnout.Text = turnoutPercent.ToString("0.0") + "%";
                    }
                    else { lblTurnout.Text = "0%"; }
                }
                catch (Exception ex) { MessageBox.Show("Stat Card Error: " + ex.Message); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
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

        private void dgvVoters_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlCandidate_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dgvVoters.DataSource is DataTable dt)
            {
                DataView dv = dt.DefaultView;

                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    dv.RowFilter = "";
                    lblVNoVoters.Visible = false;
                }
                else
                {
                    // Sanitize the search text to prevent errors with single quotes
                    string searchText = txtSearch.Text.Replace("'", "''");

                    // UPDATED: Match the column names in your DataGridView
                    // If your SQL was: SELECT Username, StudentName, Password...
                    // Then use those exact names here:
                    dv.RowFilter = string.Format("Username LIKE '%{0}%' OR StudentName LIKE '%{0}%' OR Password LIKE '%{0}%' OR YearLevel LIKE '%{0}%'", searchText);

                    if (dv.Count == 0)
                    {
                        lblVNoVoters.Text = "No matching voters found.";
                        lblVNoVoters.Visible = true;
                    }
                    else
                    {
                        lblVNoVoters.Visible = false;
                    }
                }

                // Update the label to show the filtered count
                lblTotalVoters.Text = dv.Count.ToString();
            }
        }

        private void lblCompletedElections_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            using (AddCandidate popup = new AddCandidate())
            {
                // CRITICAL FIX: Pass the current organization to the popup
                // Make sure 'myOrg' is the variable holding the President's organization (e.g., "ICPEP")
                popup.CurrentOrg = this.myOrg;

                popup.ElectionList.Clear();
                popup.PositionList.Clear();

                // 1. Get elections from the President's Dashboard grid
                foreach (DataGridViewRow row in dgvUpcomingElections.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        popup.ElectionList.Add(row.Cells[0].Value.ToString());
                    }
                }

                // 2. Get positions from the 'Positions' table filtered by this organization
                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    try
                    {
                        conn.Open();
                        string posQuery = "SELECT PositionName FROM Positions WHERE Organization = ? ORDER BY PositionName ASC";
                        using (OleDbCommand cmd = new OleDbCommand(posQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("?", myOrg);
                            using (OleDbDataReader reader = cmd.ExecuteReader())
                            {
                                var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                                while (reader.Read())
                                {
                                    string raw = Convert.ToString(reader["PositionName"]);
                                    if (!string.IsNullOrWhiteSpace(raw))
                                    {
                                        string pos = raw.Trim();
                                        if (!seen.Contains(pos))
                                        {
                                            seen.Add(pos);
                                            popup.PositionList.Add(pos);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Database Error: " + ex.Message); }
                }

                // 3. SHOW THE POPUP
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the grid to show the newly added candidate
                    LoadCandidatesFromAccess();

                    // Check visibility of the "No candidates found" label
                    lblNoCandidates.Visible = (dgvCandidates.Rows.Count == 0);
                }
            }
        }
        private void LoadCandidatesFromAccess()
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Candidates WHERE Organization = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", myOrg);
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // 1. Create a new column in the DataTable to hold the actual Image object
                        dt.Columns.Add("ActualPhoto", typeof(Image));

                        // 2. Loop through each row and convert the path to an image
                        foreach (DataRow row in dt.Rows)
                        {
                            string path = row["ImagePath"].ToString();
                            if (!string.IsNullOrEmpty(path) && File.Exists(path))
                            {
                                row["ActualPhoto"] = Image.FromFile(path);
                            }
                            else
                            {
                                // Optional: row["ActualPhoto"] = MyDefaultImage; 
                            }
                        }

                        dgvCandidates.AutoGenerateColumns = false;

                        // 3. Map the Photo column to our NEW "ActualPhoto" column
                        dgvCandidates.Columns["colCPhoto"].DataPropertyName = "ActualPhoto";
                        dgvCandidates.Columns["colCName"].DataPropertyName = "FullName";
                        dgvCandidates.Columns["colCElection"].DataPropertyName = "ElectionTitle";
                        dgvCandidates.Columns["colCPosition"].DataPropertyName = "Position";
                        dgvCandidates.Columns["colCDesc"].DataPropertyName = "Description";

                        dgvCandidates.DataSource = dt;
                        lblNoCandidates.Visible = (dt.Rows.Count == 0);
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void CheckForCandidates()
        {
            lblNoCandidates.Visible = (dgvCandidates.Rows.Count == 0);
            if (lblNoCandidates.Visible) lblNoCandidates.BringToFront();
        }

        private void dgvCandidates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks on headers
            if (e.RowIndex < 0) return;

            // Only run if they click the Actions column
            if (dgvCandidates.Columns[e.ColumnIndex].Name == "colActions")
            {
                // Get the name of the candidate in the row that was clicked
                string candidateName = dgvCandidates.Rows[e.RowIndex].Cells["colCName"].Value?.ToString() ?? "";

                if (!string.IsNullOrEmpty(candidateName))
                {
                    // Confirm with the user
                    DialogResult result = MessageBox.Show($"Permanently delete {candidateName} from the database?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // 1. Delete from the Access File
                        DeleteCandidateByName(candidateName);

                        // 2. Refresh the Grid to show they are gone
                        LoadCandidatesFromAccess();

                        // 3. Update your "No Candidates" label visibility
                        CheckForCandidates();
                    }
                }
            }
        }

        private void LoadPositionsIntoComboBox()
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Fetch positions for this organization only
                    string sql = "SELECT PositionName FROM Positions WHERE Organization = ? ORDER BY PositionName ASC";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", myOrg);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            // Deduplicate and trim values (case-insensitive)
                            var positions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                            while (reader.Read())
                            {
                                string raw = Convert.ToString(reader["PositionName"]);
                                if (!string.IsNullOrWhiteSpace(raw))
                                {
                                    positions.Add(raw.Trim());
                                }
                            }

                            // Clear and add distinct, sorted positions
                            cmbPositionFilter.Items.Clear();
                            foreach (var pos in positions.OrderBy(p => p))
                            {
                                cmbPositionFilter.Items.Add(pos);
                            }

                            if (cmbPositionFilter.Items.Count > 0)
                            {
                                cmbPositionFilter.SelectedIndex = 0; // Select the first one by default
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading positions: " + ex.Message);
                }
            }
        }

        private void LoadElectionResults()
        {
            // Ensure an election is selected in your main dashboard grid
            if (dgvUpcomingElections.Rows.Count == 0) return;
            if (cmbPositionFilter.SelectedItem == null) return;

            // Prefer the selected row, otherwise fall back to the first row
            string activeElection = null;
            if (dgvUpcomingElections.SelectedRows.Count > 0)
            {
                activeElection = dgvUpcomingElections.SelectedRows[0].Cells[0].Value?.ToString();
            }
            if (string.IsNullOrWhiteSpace(activeElection) && dgvUpcomingElections.Rows.Count > 0)
            {
                activeElection = dgvUpcomingElections.Rows[0].Cells[0].Value?.ToString();
            }
            if (string.IsNullOrWhiteSpace(activeElection)) return;

            string selectedPos = cmbPositionFilter.SelectedItem.ToString();
            if (string.IsNullOrWhiteSpace(selectedPos)) return;

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Using [Position] in brackets because it is a reserved word in some SQL versions
                    string sql = "SELECT CandidateName, COUNT(*) AS TotalVotes " +
                                 "FROM Votes WHERE ElectionTitle = ? AND [Position] = ? " +
                                 "GROUP BY CandidateName ORDER BY COUNT(*) DESC";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", activeElection);
                        cmd.Parameters.AddWithValue("?", selectedPos);

                        DataTable dt = new DataTable();
                        new OleDbDataAdapter(cmd).Fill(dt);

                        dgvResults.DataSource = dt;

                        // Map DataPropertyName only if the designer columns exist
                        if (dgvResults.Columns["colResCandidate"] != null)
                            dgvResults.Columns["colResCandidate"].DataPropertyName = "CandidateName";
                        if (dgvResults.Columns["colResTotalVotes"] != null)
                            dgvResults.Columns["colResTotalVotes"].DataPropertyName = "TotalVotes";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Results Error: " + ex.Message);
                }
            }
        }

        private void DeleteCandidateByName(string name)
        {
            // Make sure this path is exactly where your database is located
            

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // We use the FullName column to find the row
                    string sql = "DELETE FROM Candidates WHERE [FullName] = ?";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", name);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        private void LoadOrgPresidentAnalytics()
        {
            // FIX: Define selectedElection from your dashboard grid
            if (dgvUpcomingElections.Rows.Count == 0 || dgvUpcomingElections.Rows[0].Cells[0].Value == null) return;
            string selectedElection = dgvUpcomingElections.Rows[0].Cells[0].Value.ToString();

            var series = chartAnalytics.Series[0];
            series.Points.Clear();

            // UI Configuration
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series.IsValueShownAsLabel = true;
            series.LegendText = "Votes";
            series["PointWidth"] = "0.6";
            series["DrawingStyle"] = "Cylinder";    // gives a rounded/3D look
            series["BarLabelStyle"] = "Center";     // centers the numeric label on the bar
            series.IsXValueIndexed = true;
            series.Color = System.Drawing.Color.Maroon; // Matches CIT-U theme

            chartAnalytics.Titles.Clear();
            chartAnalytics.Titles.Add("Top 5 Candidates in " + selectedElection);

            if (chartAnalytics.ChartAreas.Count > 0)
            {
                var area = chartAnalytics.ChartAreas[0];
                area.Area3DStyle.Enable3D = true; // Enables the look from your UI
                area.AxisX.Interval = 1; // Ensures every candidate name is shown
                area.AxisY.MajorGrid.Enabled = false;
            }

            
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Using CandidateName to match your confirmed DB schema
                    string sql = "SELECT TOP 5 CandidateName, COUNT(*) AS VoteCount " +
                                 "FROM Votes WHERE ElectionTitle = ? " +
                                 "GROUP BY CandidateName ORDER BY COUNT(*) DESC";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", selectedElection);
                        OleDbDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string name = reader["CandidateName"].ToString();
                            double votes = Convert.ToDouble(reader["VoteCount"]);

                            // Simplified point addition for reliability
                            int i = series.Points.AddXY(name, votes);
                            series.Points[i].Label = votes.ToString("0");
                        }
                    }

                    // Call the metric update while the connection is still open
                    UpdateMetricLabels(selectedElection, conn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Analytics Error: " + ex.Message);
                }
            }
        }

        private void UpdateMetricLabels(string election, OleDbConnection conn)
        {
            // Box 1: Leading Candidate
            string leadSql = "SELECT TOP 1 CandidateName FROM Votes WHERE ElectionTitle = ? " +
                             "GROUP BY CandidateName ORDER BY COUNT(*) DESC";
            using (OleDbCommand cmd = new OleDbCommand(leadSql, conn))
            {
                cmd.Parameters.AddWithValue("?", election);
                lblLeadingCandidate.Text = cmd.ExecuteScalar()?.ToString() ?? "N/A";
            }

            // Box 2: Total Turnout % (Fixed for Access SQL)
            // Access workaround for COUNT DISTINCT:
            string turnoutSql = "SELECT COUNT(*) FROM (SELECT DISTINCT VoterID FROM Votes WHERE ElectionTitle = ?)";
            using (OleDbCommand cmd = new OleDbCommand(turnoutSql, conn))
            {
                cmd.Parameters.AddWithValue("?", election);
                int votedCount = (int)cmd.ExecuteScalar();

                // This should eventually pull from your 'Voters' table count
                double totalVoters = 500.0;
                double percent = (votedCount / totalVoters) * 100;
                lblTurnout.Text = percent.ToString("0.0") + "%";
            }

            // Box 3: Latest Vote Timestamp
            string timeSql = "SELECT MAX(VoteTimestamp) FROM Votes WHERE ElectionTitle = ?";
            using (OleDbCommand cmd = new OleDbCommand(timeSql, conn))
            {
                cmd.Parameters.AddWithValue("?", election);
                object lastVote = cmd.ExecuteScalar();
                lblLatestVote.Text = lastVote != DBNull.Value ? lastVote.ToString() : "No votes yet";
            }
        }

        private void cmbPositionFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadElectionResults();
        }
    }
}
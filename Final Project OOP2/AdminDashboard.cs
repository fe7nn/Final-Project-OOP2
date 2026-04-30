using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final_Project_OOP2
{
    public partial class AdminDashboard : Form
    {
        private string adminID;
        private string currentElectionTitle = "";

        private string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";
        
        public AdminDashboard(string userID)
        {
            InitializeComponent();
            this.adminID = userID;

        }

        private void AdminDashboard_Load(object sender, EventArgs e) 
        {
            timer1.Start();


            // Initial Panel Visibility
            pnlDashboard.Visible = true;
            pnlCandidate.Visible = false;
            pnlPositions.Visible = false;
            pnlElection.Visible = false;
            pnlVoters.Visible = false;
            pnlResults.Visible = false;
            pnlAnalytics.Visible = false;

            // UI Cleanup for DataGrids
            dgvUpcomingElections.ReadOnly = true;
            dgvUpcomingElections.AllowUserToAddRows = false;
            dgvUpcomingElections.AllowUserToDeleteRows = false;
            dgvUpcomingElections.BorderStyle = BorderStyle.None;
            dgvUpcomingElections.RowHeadersVisible = false;
            dgvCandidates.AutoGenerateColumns = true;
            RefreshAllData();
            // Initial UI Refresh
            CheckForElections();
            CheckForCandidates();
            CheckForVoters();
            CheckForElections();
            UpdateDashboardCounters();
            LoadElectionList();
        }

        #region Navigation & Sidebar Events

        private void DashButton_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlDashboard);


        }

        private void ElectionButton_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlElection);

        }

        private void PositionsButton_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlPositions);
            CheckForPositions();
        }

        private void VotersButton_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlVoters);
            LoadVotersFromAccess();
            CheckForVoters();
        }

        private void CandidateButton_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlCandidate);
            LoadCandidatesFromAccess();
            CheckForCandidates();
        }

        private void ResultsButton_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlResults);
        }

        private void AnalyticsButton_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlAnalytics);
            
            UpdateStatCards();
            LoadCandidateBarChart();
            UpdateSubtitle();
        }

        private void ShowPanel(Panel targetPanel)
        {
            pnlDashboard.Visible = (targetPanel == pnlDashboard);
            pnlCandidate.Visible = (targetPanel == pnlCandidate);
            pnlPositions.Visible = (targetPanel == pnlPositions);
            pnlElection.Visible = (targetPanel == pnlElection);
            pnlVoters.Visible = (targetPanel == pnlVoters);
            pnlResults.Visible = (targetPanel == pnlResults);
            pnlAnalytics.Visible = (targetPanel == pnlAnalytics);
            targetPanel.BringToFront();
        }

        private void LogOut_Click(object sender, EventArgs e)
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

        #endregion

        #region Pop-up Form Launchers

        private void OpenCreateForm_Click(object sender, EventArgs e)
        {
            using (AddElection popup = new AddElection())
            {
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    // 1. Save to the database FIRST
                    SaveElectionToDatabase(popup.ElectionTitle, popup.FullStart, popup.FullEnd);

                    // 2. REFRESH the grid from the database
                    // This replaces the dgvElections.Rows.Add(...) lines that caused the crash
                    LoadElectionsFromAccess();

                    // 3. Update any counters on your dashboard
                    UpdateDashboardCounters();
                }
            }
        }

        // Add this helper method below
        private void SaveElectionToDatabase(string title, DateTime start, DateTime end)
        {
            
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Elections (ElectionTitle, StartDate, EndDate) VALUES (?, ?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", title);
                        cmd.Parameters.AddWithValue("?", start.ToString());
                        cmd.Parameters.AddWithValue("?", end.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error saving election: " + ex.Message); }
            }
        }

        private void addPositionOpenForm_Click(object sender, EventArgs e)
        {
            using (AddPosition popup = new AddPosition())
            {
                // 1. Pass the list of available elections to the popup
                foreach (DataGridViewRow r in dgvElections.Rows)
                {
                    // Using index 0 for Election Title
                    if (r.Cells[0].Value != null)
                        popup.ElectionList.Add(r.Cells[0].Value.ToString());
                }

                // 2. Show the popup
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    /* IMPORTANT: Do not use dgvPositions.Rows.Add() anymore.
                       Instead, reload the data from Access so the grid matches the database.
                    */
                    LoadPositionsFromAccess();

                    // This handles the "No positions yet" label visibility
                    CheckForPositions();
                }
            }
        }

        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            using (AddCandidate popup = new AddCandidate())
            {
                // 1. CLEAR AND RE-FILL THE LISTS FROM YOUR GRIDS
                popup.ElectionList.Clear();
                popup.PositionList.Clear();

                // Get fresh elections from dgvElections
                foreach (DataGridViewRow row in dgvElections.Rows)
                {
                    if (row.Cells[0].Value != null)
                        popup.ElectionList.Add(row.Cells[0].Value.ToString());
                }

                // Get fresh positions from dgvPositions
                foreach (DataGridViewRow row in dgvPositions.Rows)
                {
                    if (row.Cells[1].Value != null)
                        popup.PositionList.Add(row.Cells[1].Value.ToString());
                }

                // 2. SHOW THE POPUP
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    /* Instead of manually adding a row to the grid here, 
                       we call the database refresh. 
                       The 'AddCandidate' popup already saved the data to Access, 
                       so this will pull the new candidate into the grid automatically.
                    */
                    LoadCandidatesFromAccess();

                    // This checks if the grid is empty to show/hide the "No candidates" label
                    CheckForCandidates();
                }
            }
        }

        private void LoadPositionsFromAccess()
        {
            
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ElectionTitle, PositionName FROM Positions ORDER BY ElectionTitle ASC";
                    OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPositions.AutoGenerateColumns = false;
                    // Map these to the (Name) of your designer columns
                    dgvPositions.Columns[0].DataPropertyName = "ElectionTitle";
                    dgvPositions.Columns[1].DataPropertyName = "PositionName";

                    dgvPositions.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show("Error loading positions: " + ex.Message); }
            }
        }

        private void LoadElectionsFromAccess()
        {
            

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // SELECT from Elections table
                    string query = @"SELECT e.ElectionTitle, e.StartDate, e.EndDate, e.Status, 
                            (SELECT COUNT(*) FROM Votes v WHERE v.ElectionTitle = e.ElectionTitle) AS VoteCount 
                            FROM Elections e";

                    OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        DateTime start = Convert.ToDateTime(row["StartDate"]);
                        DateTime end = Convert.ToDateTime(row["EndDate"]);
                        DateTime now = DateTime.Now;

                        string currentStatus;
                        if (now < start) currentStatus = "Upcoming";
                        else if (now >= start && now <= end) currentStatus = "Active";
                        else currentStatus = "Completed";

                        row["Status"] = currentStatus;
                        // Sync the database
                        UpdateStatusInDatabase(row["ElectionTitle"].ToString(), currentStatus);
                    }

                    // --- UI FIXES START HERE ---

                    // 1. STOP DUPLICATE COLUMNS
                    // This MUST be set before DataSource
                    dgvElections.AutoGenerateColumns = false;
                    dgvUpcomingElections.AutoGenerateColumns = false;

                    // 2. BIND DATA
                    dgvUpcomingElections.DataSource = dt;
                    dgvElections.DataSource = dt;

                    // 3. UPDATE LABELS
                    UpdateDashboardCounters(dt);

                    // 4. HIDE MESSAGES IF DATA EXISTS
                    lblNoElectionsMsg.Visible = (dt.Rows.Count == 0);
                    lblNoElections.Visible = (dt.Rows.Count == 0);

                    // --- UI FIXES END HERE ---
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dashboard Load Error: " + ex.Message);
                }
            }
        }

        public void RefreshAllData()
        {
            LoadElectionsFromAccess();   // Reloads the Dashboard and Management grids
            LoadVotersFromAccess();      // Reloads the Voters grid
            LoadCandidatesFromAccess();  // Reloads the Candidates grid
            LoadPositionsFromAccess();   // Reloads the Positions grid
            LoadElectionTitles();        // Reloads the Results dropdown
            UpdateDashboardCounters();   // Updates your top status labels
        }

        private void DeleteElectionFromAccess(string title)
        {
            
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Delete from the Elections table where the title matches
                    string sql = "DELETE FROM Elections WHERE [ElectionTitle] = ?";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", title);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Delete Error: " + ex.Message);
                }
            }
        }

        private int GetTotalVotesForElection(string electionTitle)
        {
            
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Counts rows in 'Votes' where the 'ElectionTitle' matches
                    string sql = "SELECT COUNT(*) FROM Votes WHERE ElectionTitle = ?";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", electionTitle);
                        return (int)cmd.ExecuteScalar();
                    }
                }
                catch { return 0; }
            }
        }

        private void importVoters_Click(object sender, EventArgs e)
        {
            if (cmbElectionAssign.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an election to assign these voters to.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedElection = cmbElectionAssign.SelectedItem.ToString();

            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "CSV Files (*.csv)|*.csv|Excel Files (*.xlsx; *.xls)|*.xlsx;*.xls|All Files (*.*)|*.*" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID Number");
                dt.Columns.Add("Full Name");
                dt.Columns.Add("Email");
                dt.Columns.Add("Year");
                dt.Columns.Add("Course");
                dt.Columns.Add("Password");
                dt.Columns.Add("Status");


                string[] lines = System.IO.File.ReadAllLines(openFileDialog.FileName);
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(',');

                    if (data.Length >= 6)
                    {
                        // 2. Add the 8th item (selectedElection) to the row
                        dt.Rows.Add(data[0], data[1], data[2], data[3], data[4], data[5], data[6]);
                    }
                }

                dgvVoters.DataSource = dt;

                UpdateVoterCount();
                SaveVotersToAccess(dt, selectedElection);
            }
        }

        private void LoadElectionList()
        {
            // 1. Clear the ComboBox so we don't get duplicates if we call this twice
            cmbElectionAssign.Items.Clear();
            cmbElectionAssign.Items.Add("All"); // Add the default "Show Everyone" option

            // ... then load the rest from the database as you did before ...
            cmbElectionAssign.SelectedIndex = 0; // Default to "All"
            

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // 2. Select only the Title column from your Elections table
                    string sql = "SELECT [ElectionTitle] FROM Elections";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // 3. Add each election title to the ComboBox
                                cmbElectionAssign.Items.Add(reader["ElectionTitle"].ToString());
                            }
                        }
                    }

                    // 4. Select the first item by default so it's not blank
                    if (cmbElectionAssign.Items.Count > 0)
                    {
                        cmbElectionAssign.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading elections: " + ex.Message);
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
                    // Select the exact column names from your image_ff5c3e.png
                    string query = "SELECT [ImagePath], [FullName], [ElectionTitle], [Position], [Description] FROM Candidates";

                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvCandidates.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading candidates: " + ex.Message);
                }
            }
        }

        private void LoadVotersFromAccess()
        {
            

            // Get selection (SelectedItem or typed text)
            string selectedElection = (cmbElectionAssign.SelectedItem ?? cmbElectionAssign.Text)?.ToString().Trim();
            if (string.IsNullOrEmpty(selectedElection)) selectedElection = "All";

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Base query: select voters only
                    string query = "SELECT [Username] AS [ID Number], [StudentName] AS [Full Name], [Email], [YearLevel] AS [Year], [Course], [Password], [ElectionTitle] " +
                                   "FROM Voters WHERE UCase([UserRole]) = 'VOTER'";

                    // If a specific election is chosen, compare trimmed uppercase values to tolerate spacing/case
                    if (!string.Equals(selectedElection, "All", StringComparison.OrdinalIgnoreCase))
                    {
                        query += " AND UCase(Trim([ElectionTitle])) = UCase(Trim(?))";
                    }

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        if (!string.Equals(selectedElection, "All", StringComparison.OrdinalIgnoreCase))
                        {
                            cmd.Parameters.AddWithValue("?", selectedElection);
                        }

                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvVoters.DataSource = dt;
                        dgvVoters.Refresh();

                        string countString = dt.Rows.Count.ToString();

                        lblTotalVotersCount.Text = countString;

                        if (lblTotalVoters != null)
                            lblTotalVoters.Text = countString;

                        // ADDED: Update the dashboard value label
                        if (totalVotersValue != null)
                            totalVotersValue.Text = countString;

                        lblVNoVoters.Visible = (dt.Rows.Count == 0);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }


        private void SaveVotersToAccess(DataTable dt, string electionTitle)
        {
            

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    foreach (DataRow row in dt.Rows)
                    {
                        // ADDED: [ElectionTitle] and [HasVoted] to the columns
                        // Added a check to see if the username already exists to avoid duplicates
                        string checkSql = "SELECT COUNT(*) FROM Voters WHERE [Username] = ?";
                        using (OleDbCommand checkCmd = new OleDbCommand(checkSql, conn))
                        {
                            checkCmd.Parameters.AddWithValue("?", row["ID Number"].ToString());
                            int exists = (int)checkCmd.ExecuteScalar();

                            if (exists == 0)
                            {
                                string sql = "INSERT INTO Voters ([Username], [StudentName], [Email], [YearLevel], [Course], [Password], [ElectionTitle], [HasVoted], [UserRole]) " +
                             "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";

                                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                                {
                                    // 2. Make sure you have exactly 9 AddWithValue lines in this EXACT order:
                                    cmd.Parameters.AddWithValue("?", row["ID Number"].ToString()); // 1
                                    cmd.Parameters.AddWithValue("?", row["Full Name"].ToString());  // 2
                                    cmd.Parameters.AddWithValue("?", row["Email"].ToString());      // 3
                                    cmd.Parameters.AddWithValue("?", row["Year"].ToString());       // 4
                                    cmd.Parameters.AddWithValue("?", row["Course"].ToString());     // 5
                                    cmd.Parameters.AddWithValue("?", row["Password"].ToString());   // 6


                                    // Check if this is null or empty. If you haven't created an election yet, this will fail.
                                    string title = string.IsNullOrEmpty(ElectionManager.CurrentTitle) ? "No Election" : ElectionManager.CurrentTitle;
                                    cmd.Parameters.AddWithValue("?", electionTitle);                        // 7

                                    cmd.Parameters.AddWithValue("?", "No");                         // 8
                                    cmd.Parameters.AddWithValue("?", "voter");                      // 9

                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    MessageBox.Show("Voters imported and assigned to: " + electionTitle);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving voters: " + ex.Message);
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EditElection popup = new EditElection();
            popup.ShowDialog();
        }

        #endregion

        #region DataGridView Events & Logic

        private void dgvElections_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvElections.Columns[e.ColumnIndex].Name == "colEActions")
            {
                var cellBounds = dgvElections.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var relativeClickX = dgvElections.PointToClient(Cursor.Position).X - cellBounds.X;

                if (relativeClickX < cellBounds.Width / 2) // EDIT CLICK
                {
                    using (EditElection editPopup = new EditElection())
                    {
                        // 1. Get values from the DataGridView row
                        string title = dgvElections.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                        string startStr = dgvElections.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";
                        string endStr = dgvElections.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? "";

                        // 2. Use your custom method to push data into the popup form
                        editPopup.LoadElectionData(title, startStr, endStr);

                        if (editPopup.ShowDialog() == DialogResult.OK)
                        {
                            // 1. Get the original title as it exists in the database to use as a key
                            string originalTitle = dgvElections.Rows[e.RowIndex].Cells[0].Value?.ToString();

                            // 2. Perform the database update first
                            UpdateElectionInAccess(originalTitle, editPopup.ElectionTitle, editPopup.StartDate, editPopup.EndDate);

                            // 3. Update the DataGridView UI to reflect the changes
                            dgvElections.Rows[e.RowIndex].Cells[0].Value = editPopup.ElectionTitle;
                            dgvElections.Rows[e.RowIndex].Cells[2].Value = editPopup.StartDate.ToString("MM/dd/yyyy hh:mm tt");
                            dgvElections.Rows[e.RowIndex].Cells[3].Value = editPopup.EndDate.ToString("MM/dd/yyyy hh:mm tt");

                            // 4. Refresh the rest of the dashboard
                            UpdateDashboardCounters();
                            LoadElectionsFromAccess(); // Refresh the grid to ensure data sync
                        }
                    }
                }
                else // DELETE CLICK
                {
                    if (MessageBox.Show("Are you sure you want to delete this election?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        // 1. Get the title from the row before we delete it
                        string titleToDelete = dgvElections.Rows[e.RowIndex].Cells[0].Value?.ToString();

                        if (!string.IsNullOrEmpty(titleToDelete))
                        {
                            // 2. Delete it from the Access Database
                            DeleteElectionFromAccess(titleToDelete);

                            // 3. Remove it from the DataGridView UI
                            dgvElections.Rows.RemoveAt(e.RowIndex);

                            // 4. Update your counters and refresh the dashboard
                            UpdateDashboardCounters();
                            LoadElectionsFromAccess(); // Refresh the dashboard grid too!

                            MessageBox.Show("Election deleted successfully.");
                        }
                    }
                }
            }
        }

        private void UpdateElectionInAccess(string oldTitle, string newTitle, DateTime start, DateTime end)
        {
            

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Use brackets for reserved Access keywords [Start] and [End]
                    string sql = "UPDATE Elections SET ElectionTitle = ?, StartDate = ?, EndDate = ? WHERE ElectionTitle = ?";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", newTitle);
                        // Access expects the date format to be readable by the database
                        cmd.Parameters.AddWithValue("?", start.ToString("MM/dd/yyyy hh:mm tt"));
                        cmd.Parameters.AddWithValue("?", end.ToString("MM/dd/yyyy hh:mm tt"));
                        cmd.Parameters.AddWithValue("?", oldTitle);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Update Error: " + ex.Message);
                }
            }
        }


        private void DeleteCandidateVotes(string electionTitle, string candidateName)
        {
            
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // This removes every individual vote cast for this specific person
                    string sql = "DELETE FROM Votes WHERE ElectionTitle = ? AND CandidateName = ?";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", electionTitle);
                        cmd.Parameters.AddWithValue("?", candidateName);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting votes: " + ex.Message);
                }
            }
        }

        private void dgvPositions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPositions.Columns[e.ColumnIndex].Name == "colPActions")
            {
                var relativeMouseX = dgvPositions.PointToClient(Cursor.Position).X - dgvPositions.GetColumnDisplayRectangle(e.ColumnIndex, false).X;

                // Current Data from the row
                string currentElection = dgvPositions.Rows[e.RowIndex].Cells[0].Value.ToString();
                string currentPosition = dgvPositions.Rows[e.RowIndex].Cells[1].Value.ToString();

                if (relativeMouseX < dgvPositions.Columns[e.ColumnIndex].Width / 2) // Edit
                {
                    using (AddPosition editPop = new AddPosition())
                    {
                        foreach (DataGridViewRow r in dgvElections.Rows)
                        {
                            if (r.Cells[0].Value != null) editPop.ElectionList.Add(r.Cells[0].Value.ToString());
                        }

                        string currentOrg = dgvPositions.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";

                        // Pass all 3 values including organization
                        editPop.LoadPositionData(currentElection, currentPosition, currentOrg);

                        if (editPop.ShowDialog() == DialogResult.OK)
                        {
                            LoadPositionsFromAccess();
                        }
                    }
                }
                else // Delete Logic
                {
                    if (MessageBox.Show($"Are you sure you want to delete the '{currentPosition}' position for '{currentElection}'?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        

                        using (OleDbConnection conn = new OleDbConnection(connStr))
                        {
                            try
                            {
                                conn.Open();
                                // Delete matching record from the Positions table
                                string sql = "DELETE FROM Positions WHERE [ElectionTitle] = ? AND [PositionName] = ?";

                                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                                {
                                    cmd.Parameters.AddWithValue("?", currentElection);
                                    cmd.Parameters.AddWithValue("?", currentPosition);

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Position deleted from database.");
                                        // Refresh the UI
                                        LoadPositionsFromAccess();
                                        CheckForPositions();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error deleting from database: " + ex.Message);
                            }
                        }
                    }
                }
            }
        }

        private void dgvCandidates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks on headers
            if (e.RowIndex < 0) return;

            // Only run if they click the Actions column
            if (dgvCandidates.Columns[e.ColumnIndex].Name == "colActions")
            {
                // Get the name of the candidate in the row that was clicked
                string candidateName = dgvCandidates.Rows[e.RowIndex].Cells["colName"].Value?.ToString() ?? "";

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


        private void dgvPositions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > 0)
            {
                object currentValue = dgvPositions.Rows[e.RowIndex].Cells[0].Value;
                object previousValue = dgvPositions.Rows[e.RowIndex - 1].Cells[0].Value;

                if (currentValue != null && previousValue != null && currentValue.ToString() == previousValue.ToString())
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgvElections_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvElections.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                using (Brush backBrush = new SolidBrush(Color.FromArgb(220, 53, 69)))
                {
                    Rectangle btnRect = e.CellBounds;
                    btnRect.Inflate(-4, -4);
                    e.Graphics.FillRectangle(backBrush, btnRect);
                    TextRenderer.DrawText(e.Graphics, "Delete", e.CellStyle.Font, btnRect, Color.White, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                }
                e.Handled = true;
            }
        }

        #endregion

        #region Dashboard & Counters Logic

        private void UpdateDashboardCounters()
        {
            // Check if the grid has data, then pass that data to the main logic
            if (dgvElections.DataSource is DataTable dt)
            {
                UpdateDashboardCounters(dt);
            }
        }

        private void UpdateDashboardCounters(DataTable dt)
        {
            int active = 0;
            int completed = 0;

            foreach (DataRow row in dt.Rows)
            {
                // Use the Status column from your Elections table
                string status = row["Status"]?.ToString().Trim().ToUpper() ?? "";

                if (status == "ACTIVE") active++;
                else if (status == "COMPLETED") completed++;
            }

            lblActiveElectionsCount.Text = active.ToString();
            lblCompletedElectionsCount.Text = completed.ToString();

            // Toggle the "No elections" message
            lblNoElections.Visible = (dt.Rows.Count == 0); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool needsRefresh = false;
            DateTime now = DateTime.Now;

            foreach (DataGridViewRow row in dgvElections.Rows)
            {
                if (row.IsNewRow) continue;

                // Ensure these match your DataGridView column names
                if (row.Cells["colEStart"].Value == null || row.Cells["colEEnd"].Value == null) continue;

                DateTime start = DateTime.Parse(row.Cells["colEStart"].Value.ToString());
                DateTime end = DateTime.Parse(row.Cells["colEEnd"].Value.ToString());
                string currentStatus = row.Cells["colEStatus"].Value?.ToString();
                string electionTitle = row.Cells["colETitle"].Value?.ToString();
                string newStatus;

                if (now < start) newStatus = "Upcoming";
                else if (now >= start && now <= end) newStatus = "Active";
                else newStatus = "Completed";

                if (currentStatus != newStatus)
                {
                    row.Cells["colEStatus"].Value = newStatus;

                    // This pushes the "Active" status to the database
                    UpdateStatusInDatabase(electionTitle, newStatus);
                    needsRefresh = true;
                }
            }

            // This now calls the parameterless version we added in Step 1
            if (needsRefresh) UpdateDashboardCounters();
        }

        private void UpdateStatusInDatabase(string title, string status)
        {
            
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // This updates the 'Status' column in the Elections table
                    string sql = "UPDATE Elections SET [Status] = ? WHERE [ElectionTitle] = ?";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", status);
                        cmd.Parameters.AddWithValue("?", title);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) { /* Log error if needed */ }
            }
        }

        #endregion

        #region UI Visibility & Action Handlers

        private void CheckForElections()
        {
            bool hasData = dgvElections.Rows.Count > 0;
            lblNoElections.Visible = !hasData;
            lblNoElectionsMsg.Visible = !hasData;
            if (!hasData) lblNoElections.BringToFront();
        }

        private void CheckForVoters()
        {
            lblVNoVoters.Visible = (dgvVoters.Rows.Count == 0);
            if (lblVNoVoters.Visible) lblVNoVoters.BringToFront();
        }

        private void CheckForCandidates()
        {
            lblNoCandidates.Visible = (dgvCandidates.Rows.Count == 0);
            if (lblNoCandidates.Visible) lblNoCandidates.BringToFront();
        }

        private void CheckForPositions()
        {
            lblNoPositions.Visible = (dgvPositions.Rows.Count == 0);
            if (!dgvPositions.Visible) lblNoPositions.BringToFront();
        }

        private void deleteVoters_Click(object sender, EventArgs e)
        {
            // 1. Get the election currently selected in your filter/assign ComboBox
            // Make sure to use the correct name of your ComboBox (e.g., cmbFilterElection)
            string selectedElection = cmbElectionAssign.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrEmpty(selectedElection) || selectedElection == "All")
            {
                MessageBox.Show("Please select a specific election first to delete its voters.", "Selection Required");
                return;
            }

            // 2. Ask for confirmation including the name of the election
            DialogResult result = MessageBox.Show($"Are you sure you want to delete ALL voters assigned to '{selectedElection}'? This cannot be undone.",
                                                  "Confirm Mass Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                

                using (OleDbConnection accessConn = new OleDbConnection(connStr))
                {
                    try
                    {
                        accessConn.Open();

                        // 3. SQL to delete voters ONLY from the selected election
                        string deleteQuery = "DELETE FROM Voters WHERE [UserRole] = 'voter' AND [ElectionTitle] = ?";

                        using (OleDbCommand cmd = new OleDbCommand(deleteQuery, accessConn))
                        {
                            cmd.Parameters.AddWithValue("?", selectedElection);

                            int rowsDeleted = cmd.ExecuteNonQuery();

                            // 4. Refresh the UI


                            MessageBox.Show($"{rowsDeleted} voters from '{selectedElection}' have been deleted.", "Success");
                            LoadVotersFromAccess();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting voters: " + ex.Message);
                    }
                }
            }
        }

        private void HandleDeleteAction(int rowIndex)
        {
            if (MessageBox.Show("Delete this record?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dgvCandidates.Rows.RemoveAt(rowIndex);
                CheckForCandidates();
            }
        }

        #endregion

        #region Hover Effects

        private void DashButton_MouseEnter(object sender, EventArgs e) => DashButton.BackColor = Color.FromArgb(255, 215, 0);
        private void DashButton_MouseLeave(object sender, EventArgs e) => DashButton.BackColor = Color.Maroon;

        private void VotersButton_MouseHover(object sender, EventArgs e) => VotersButton.BackColor = Color.FromArgb(255, 215, 0);
        private void VotersButton_MouseLeave(object sender, EventArgs e) => VotersButton.BackColor = Color.Maroon;

        private void PositionsButton_MouseHover(object sender, EventArgs e) => PositionsButton.BackColor = Color.FromArgb(255, 215, 0);
        private void PositionsButton_MouseLeave(object sender, EventArgs e) => PositionsButton.BackColor = Color.Maroon;



        private void ElectionButton_MouseHover(object sender, EventArgs e) => ElectionButton.BackColor = Color.FromArgb(255, 215, 0);
        private void ElectionButton_MouseLeave(object sender, EventArgs e) => ElectionButton.BackColor = Color.Maroon;

        private void ResultsButton_MouseHover(object sender, EventArgs e) => ResultsButton.BackColor = Color.FromArgb(255, 215, 0);
        private void ResultsButton_MouseLeave(object sender, EventArgs e) => ResultsButton.BackColor = Color.Maroon;

        private void AnalyticsButton_MouseHover(object sender, EventArgs e) => AnalyticsButton.BackColor = Color.FromArgb(255, 215, 0);
        private void AnalyticsButton_MouseLeave(object sender, EventArgs e) => AnalyticsButton.BackColor = Color.Maroon;

        #endregion

        #region Unused Placeholders & Paint Events
        private void pnlDashboard_Paint(object sender, PaintEventArgs e) => CheckForElections();
        private void pnlElection_Paint(object sender, PaintEventArgs e) => CheckForElections();
        private void pnlVoters_Paint(object sender, PaintEventArgs e) => CheckForVoters();
        private void lblEnoelections_Click(object sender, EventArgs e) { }
        private void pnlMainContainer_Paint(object sender, PaintEventArgs e) { }
        private void lblDashboard_Click(object sender, EventArgs e) { }
        private void pnlPositions_Paint(object sender, PaintEventArgs e) { }
        private void pnlCandidate_Paint(object sender, PaintEventArgs e) { }
        private void dgvUpcomingElections_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        #endregion

        private void pnlResults_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlAnalytics_Paint(object sender, PaintEventArgs e)
        {

        }



        private void dgvVoters_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Check if the clicked cell is your "Delete" button column
            // Replace "Actions" with the actual name or index of your button column
            if (dgvVoters.Columns[e.ColumnIndex].Name == "colVActions" && e.RowIndex >= 0)
            {
                // 2. Get the ID Number (Username) from the row you clicked
                string studentID = dgvVoters.Rows[e.RowIndex].Cells["ID Number"].Value.ToString();

                DialogResult result = MessageBox.Show($"Are you sure you want to delete student {studentID}?",
                                                      "Confirm Delete", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    

                    using (OleDbConnection conn = new OleDbConnection(connStr))
                    {
                        try
                        {
                            conn.Open();
                            // 3. Delete from Access using the ID
                            string deleteQuery = "DELETE FROM Voters WHERE [Username] = @id";

                            using (OleDbCommand cmd = new OleDbCommand(deleteQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", studentID);
                                cmd.ExecuteNonQuery();
                            }

                            // 4. Remove the row from the DataGridView UI
                            dgvVoters.Rows.RemoveAt(e.RowIndex);

                            // 5. Update the total count label
                            int currentCount = int.Parse(lblTotalVoters.Text);
                            lblTotalVoters.Text = (currentCount - 1).ToString();

                            // 6. Show "No voters yet" if we just deleted the last one
                            UpdateVoterCount();

                            MessageBox.Show("Student deleted successfully.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting from database: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // 1. Get the data currently in the grid
            if (dgvVoters.DataSource is DataTable dt)
            {
                DataView dv = dt.DefaultView;

                // 2. Check if the search box is empty
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    // Reset the filter to show EVERYTHING
                    dv.RowFilter = "";

                    // UI Cleanup: Hide the "No results" message and show the original count
                    lblVNoVoters.Visible = false;
                }
                else
                {
                    string searchText = txtSearch.Text.Replace("'", "''");
                    // 3. Apply the filter (Searching by Full Name)
                    // The '%' signs allow the user to find "Juan" just by typing "Ju"
                    dv.RowFilter = string.Format("[ID Number] LIKE '%{0}%' OR [Full Name] LIKE '%{0}%' OR [Course] LIKE '%{0}%' OR [Year] LIKE '%{0}%' ", searchText);

                    // 4. Handle "No Results Found"
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

                // 5. Always update the total voters label to show the current filtered count
                lblTotalVoters.Text = dgvVoters.Rows.Count.ToString();
            }
        }

      


        private void UpdateVoterCount()
        {
            // Count the rows in the DataGridView
            int count = dgvVoters.Rows.Count;

            // Update the label text
            lblTotalVoters.Text = count.ToString();

            // Automatically handle the "No voters yet" label
            if (count > 0)
            {
                lblVNoVoters.Visible = false;
            }
            else
            {
                lblVNoVoters.Visible = true;
            }
        }

        private void dgvCandidates_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 1. Change "Photo" to whatever the (Name) of your image column is in the designer
            if (dgvCandidates.Columns[e.ColumnIndex].Name == "colPhoto" && e.Value != null)
            {
                try
                {
                    string path = e.Value.ToString();
                    if (System.IO.File.Exists(path))
                    {
                        // This converts the text path into an actual Image object
                        e.Value = Image.FromFile(path);
                    }
                }
                catch
                {
                    // If the file is broken, show nothing instead of crashing
                    e.Value = null;
                }
            }
        }

        private void dgvCandidates_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void LoadElectionResults()
        {
            if (string.IsNullOrEmpty(currentElectionTitle)) return;

            OleDbConnection.ReleaseObjectPool();
            
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // This query matches your confirmed Votes table
                    string sql = "SELECT [Position], CandidateName, COUNT(*) AS TotalVotes " +
                                 "FROM Votes WHERE ElectionTitle = ? " +
                                 "GROUP BY [Position], CandidateName " +
                                 "ORDER BY [Position] ASC, COUNT(*) DESC";

                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.Parameters.AddWithValue("?", currentElectionTitle);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    // Clear the grid before adding new data
                    dgvResults.Rows.Clear();

                    while (reader.Read())
                    {
                        // Matches your columns: Position | Candidate Name | Total Votes
                        dgvResults.Rows.Add(
                            reader["Position"].ToString(),
                            reader["CandidateName"].ToString(),
                            reader["TotalVotes"].ToString()
                        );
                    }

                    // Helpful check if no votes exist yet
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("No votes have been cast for " + currentElectionTitle);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Results Load Error: " + ex.Message);
                }
            }
        }


        private void cmbElectionFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbElectionFilter.SelectedItem != null)
            {
                // 1. Update the variable
                currentElectionTitle = cmbElectionFilter.SelectedItem.ToString();

                // 2. Refresh the DataGrid
                LoadElectionResults();

                // 3. (Optional) Force the grid to repaint
                dgvResults.Refresh();
            }
        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadElectionTitles()
        {
            
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Get unique election titles so there are no duplicates in the list
                    string query = "SELECT DISTINCT ElectionTitle FROM Candidates";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    cmbElectionFilter.Items.Clear();

                    while (reader.Read())
                    {
                        // Add each title to the ComboBox
                        cmbElectionFilter.Items.Add(reader["ElectionTitle"].ToString());
                    }

                    // Automatically select the first one if the list isn't empty
                    if (cmbElectionFilter.Items.Count > 0)
                    {
                        cmbElectionFilter.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ComboBox Load Error: " + ex.Message);
                }
            }
        }

        private void pnlDashboard_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void pnlElection_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void btnDeleteElection_Click(object sender, EventArgs e)
        {
            string selectedElection = cmbElectionFilter.Text;

            if (string.IsNullOrEmpty(selectedElection) || selectedElection == "--Select Election--")
            {
                MessageBox.Show("Please select an election to clear its results.");
                return;
            }

            var confirm = MessageBox.Show($"Clear all votes for '{selectedElection}'? The election itself will NOT be deleted.",
                                           "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                
                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    try
                    {
                        conn.Open();

                        // ONLY DELETE FROM VOTES TABLE
                        string sqlVotes = "DELETE FROM Votes WHERE ElectionTitle = ?";
                        using (OleDbCommand cmdVotes = new OleDbCommand(sqlVotes, conn))
                        {
                            cmdVotes.Parameters.AddWithValue("?", selectedElection);
                            cmdVotes.ExecuteNonQuery();
                        }

                        MessageBox.Show("Results cleared!");

                        // SYNC EVERYTHING WITHOUT DELETING THE ELECTION
                        dgvResults.Rows.Clear();      // Clears the Results grid
                                                      // This will now show "0" votes in the Dashboard/Management grids
                                                      // Updates status labels
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        

        private void UpdateStatCards()
        {
            string selected = cmbElectionFilter.Text;
            if (string.IsNullOrEmpty(selected) || selected == "--Select Election--") return;

            
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // 1. TOP COURSE (Added brackets to [Course] for safety)
                    

                    // 2. LATEST VOTE (Timestamp of the most recent vote)
                    string sqlLatest = "SELECT TOP 1 VoteTimestamp FROM Votes WHERE ElectionTitle = ? ORDER BY VoteTimestamp DESC";
                    using (OleDbCommand cmd = new OleDbCommand(sqlLatest, conn))
                    {
                        cmd.Parameters.AddWithValue("?", selected);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            DateTime latest = Convert.ToDateTime(result);
                            lblLatestVote.Text = latest.ToString("hh:mm tt");
                        }
                        else { lblLatestVote.Text = "N/A"; }
                    }


                    // 3. LEADING CANDIDATE (Simplified to ensure Jovan can be counted)
                    string sqlLeader = "SELECT TOP 1 CandidateName FROM Votes WHERE ElectionTitle = ? GROUP BY CandidateName ORDER BY COUNT(*) DESC";
                    using (OleDbCommand cmd = new OleDbCommand(sqlLeader, conn))
                    {
                        cmd.Parameters.AddWithValue("?", selected);
                        lblLeadingCandidate.Text = cmd.ExecuteScalar()?.ToString() ?? "No Leader";
                    }

                    // 4. TOTAL TURNOUT (Check if your table uses 'Voter' or another term)
                    string sqlTotalVoters = "SELECT COUNT(*) FROM Voters WHERE [UserRole] = 'Voter'";
                    int totalRegistered = 0;
                    using (OleDbCommand cmdReg = new OleDbCommand(sqlTotalVoters, conn))
                    {
                        totalRegistered = (int)cmdReg.ExecuteScalar();
                    }

                    // Count unique VoterIDs
                    string sqlVotedCount = "SELECT COUNT(*) FROM (SELECT DISTINCT [VoterID] FROM Votes WHERE ElectionTitle = ?)";
                    int totalVoted = 0;
                    using (OleDbCommand cmdVoted = new OleDbCommand(sqlVotedCount, conn))
                    {
                        cmdVoted.Parameters.AddWithValue("?", selected);
                        totalVoted = (int)cmdVoted.ExecuteScalar();
                    }

                    if (totalRegistered > 0)
                    {
                        double turnoutPercent = ((double)totalVoted / totalRegistered) * 100;
                        lblTurnout.Text = turnoutPercent.ToString("0.0") + "%";
                    }
                    else { lblTurnout.Text = "0%"; }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadCandidateBarChart()
        {
            string selectedElection = cmbElectionFilter.Text;

            var series = chartCandidateBar.Series[0];
            series.Points.Clear();

            // Use horizontal bars
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series.IsValueShownAsLabel = true;
            series.LegendText = "Votes";
            series["PointWidth"] = "0.6";
            series["DrawingStyle"] = "Cylinder";    // gives a rounded/3D look
            series["BarLabelStyle"] = "Center";     // centers the numeric label on the bar
            series.IsXValueIndexed = true; // categories are indexed

            chartCandidateBar.Titles.Clear();
            chartCandidateBar.Titles.Add("Showing the Top 5 Candidates with the most votes across all positions in " + selectedElection);

            // Configure chart area for horizontal layout and 3D appearance
            if (chartCandidateBar.ChartAreas.Count > 0)
            {
                var area = chartCandidateBar.ChartAreas[0];

                // Enable 3D for a look similar to your screenshot
                area.Area3DStyle.Enable3D = true;
                area.Area3DStyle.Inclination = 15;
                area.Area3DStyle.Rotation = 20;
                area.Area3DStyle.PointDepth = 40;
                area.Area3DStyle.IsClustered = true;
                area.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;

                // Y axis will show category labels (candidates) for a horizontal bar chart
                area.AxisY.Interval = 1;
                area.AxisY.LabelStyle.Angle = 0;
                area.AxisY.MajorGrid.Enabled = false;

                // X axis shows numeric values
                area.AxisX.MajorGrid.Enabled = true;
                area.AxisX.LabelStyle.Format = ""; // plain numbers
                area.RecalculateAxesScale();
            }

            
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT TOP 5 CandidateName, COUNT(*) AS VoteCount " +
                                 "FROM Votes WHERE ElectionTitle = ? " +
                                 "GROUP BY CandidateName ORDER BY COUNT(*) DESC";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", selectedElection);

                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // if no rows - clear and exit
                            if (dt.Rows.Count == 0)
                            {
                                series.Points.Clear();
                                chartCandidateBar.Invalidate();
                                return;
                            }

                            foreach (DataRow row in dt.Rows)
                            {
                                string name = row["CandidateName"].ToString();
                                double votes = 0;
                                double.TryParse(row["VoteCount"].ToString(), out votes);

                                var pt = new System.Windows.Forms.DataVisualization.Charting.DataPoint
                                {
                                    AxisLabel = name,
                                    YValues = new double[] { votes }
                                };

                                // optional: show value in label with no decimals
                                pt.Label = votes.ToString("0");
                                series.Points.Add(pt);
                            }

                            // Ensure axes rescale after points are added
                            if (chartCandidateBar.ChartAreas.Count > 0)
                                chartCandidateBar.ChartAreas[0].RecalculateAxesScale();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Bar Chart Error: " + ex.Message);
                }
            }
        }

        private void UpdateSubtitle()
        {
            string selected = cmbElectionFilter.Text;
            lblSubtitle.Text = $"Results for: {selected}";
            lblSubtitle1.Text = $"Data updated as of {DateTime.Now:hh:mm tt}";

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void cmbElectionAssign_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadVotersFromAccess();
        }

        private void cmbElectionAssign_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            LoadVotersFromAccess();
        }

        private void cmbElectionAssign_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}



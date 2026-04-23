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
            dgvCandidates.AutoGenerateColumns = false;

            // Initial UI Refresh
            CheckForElections();
            CheckForCandidates();
            CheckForVoters();
            CheckForElections();
            UpdateDashboardCounters();
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
            LoadAnalyticsChart();
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
                    ElectionManager.CurrentTitle = popup.ElectionTitle;
                    ElectionManager.StartDate = popup.FullStart;
                    ElectionManager.EndDate = popup.FullEnd;
                    ElectionManager.IsSetup = true;

                    string statusText = ElectionManager.GetStatus();

                    // 1. Update Grid UI
                    dgvElections.Rows.Add(popup.ElectionTitle, statusText,
                        popup.FullStart.ToString("MM/dd/yyyy hh:mm tt"),
                        popup.FullEnd.ToString("MM/dd/yyyy hh:mm tt"), "Edit | Delete");

                    // 2. NEW: Save to the database so it doesn't disappear on logout
                    SaveElectionToDatabase(popup.ElectionTitle, popup.FullStart, popup.FullEnd);

                    UpdateDashboardCounters();
                }
            }
        }

        // Add this helper method below
        private void SaveElectionToDatabase(string title, DateTime start, DateTime end)
        {
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";
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
                foreach (DataGridViewRow r in dgvElections.Rows)
                {
                    if (r.Cells[0].Value != null) popup.ElectionList.Add(r.Cells[0].Value.ToString());
                }

                if (popup.ShowDialog() == DialogResult.OK)
                {
                    dgvPositions.Rows.Add(popup.SelectedElection, popup.PositionName, "Edit | Delete");
                    dgvPositions.Sort(dgvPositions.Columns[0], ListSortDirection.Ascending);
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
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Assuming your table is named 'Positions'
                    string query = "SELECT DISTINCT [ElectionTitle], [Position] FROM Candidates";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    dgvPositions.Rows.Clear(); // Clear the DGV from your image

                    while (reader.Read())
                    {
                        // Matches your screenshot columns: Election | Positions | Actions
                        dgvPositions.Rows.Add(
                            reader["ElectionTitle"].ToString(),
                            reader["Position"].ToString(),
                            "Edit | Delete"
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Position Load Error: " + ex.Message);
                }
            }
        }

        private void LoadElectionsFromAccess()
        {
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // This is the magic part: the (SELECT COUNT(*)...) gets the real-time vote count
                    string query = @"SELECT e.ElectionTitle, e.StartDate, e.EndDate, 
                            (SELECT COUNT(*) FROM Votes v WHERE v.ElectionTitle = e.ElectionTitle) AS VoteCount 
                            FROM Elections e";

                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    dgvUpcomingElections.Rows.Clear();

                    while (reader.Read())
                    {
                        // 1. DEFINE the variables here (This fixes the "does not exist" errors)
                        string title = reader["ElectionTitle"].ToString();
                        string status = ""; // We will set this below
                        DateTime start = Convert.ToDateTime(reader["StartDate"]);
                        DateTime end = Convert.ToDateTime(reader["EndDate"]);
                        int voteCount = Convert.ToInt32(reader["VoteCount"]);

                        // 2. Determine the Status using your ElectionManager
                        ElectionManager.StartDate = start;
                        ElectionManager.EndDate = end;
                        status = ElectionManager.GetStatus();

                        // 3. NOW you can use them in your Rows.Add
                        dgvUpcomingElections.Rows.Add(title, status, start.ToString("MM/dd/yyyy hh:mm tt"), end.ToString("MM/dd/yyyy hh:mm tt"), voteCount);

                        dgvElections.Rows.Add(title, status, start.ToString("MM/dd/yyyy hh:mm tt"), end.ToString("MM/dd/yyyy hh:mm tt"), "Edit | Delete");
                    }

                    // Hide the "No elections" message if data exists
                    lblNoElectionsMsg.Visible = (dgvElections.Rows.Count == 0);
                    lblNoElections.Visible = (dgvUpcomingElections.Rows.Count == 0);
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
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";
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
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";
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
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "CSV Files|*.csv" };
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

                    if (data.Length >= 7)
                    {
                        dt.Rows.Add(data[0], data[1], data[2], data[3], data[4], data[5], data[6]);
                    }
                }

                dgvVoters.DataSource = dt;

                UpdateVoterCount();
                SaveVotersToAccess(dt);
            }
        }

        private void LoadCandidatesFromAccess()
        {
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";

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
            string accessConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";

            using (OleDbConnection conn = new OleDbConnection(accessConnString))
            {
                try
                {
                    conn.Open();
                    // Fetch all users who have the 'voter' role
                    string query = "SELECT [Username] AS [ID Number], [StudentName] AS [Full Name], [Email], [YearLevel] AS [Year], [Course], [Password], [UserRole] " +
                            "FROM Users WHERE [UserRole] = 'voter'";

                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind the data to your grid
                    dgvVoters.DataSource = dt;

                    // Handle the "No voters yet" label visibility
                    if (dt.Rows.Count > 0)
                    {
                        lblVNoVoters.Visible = false;
                        lblTotalVotersCount.Text = dt.Rows.Count.ToString();
                        totalVotersValue.Text = dt.Rows.Count.ToString();
                    }
                    else
                    {
                        lblVNoVoters.Visible = true;
                        lblTotalVotersCount.Text = "0";
                        totalVotersValue.Text = "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading voters: " + ex.Message);
                }
            }
        }


        private void SaveVotersToAccess(DataTable dt)
        {
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    foreach (DataRow row in dt.Rows)
                    {
                        // ADDED: [ElectionTitle] and [HasVoted] to the columns
                        // Added a check to see if the username already exists to avoid duplicates
                        string checkSql = "SELECT COUNT(*) FROM Users WHERE [Username] = ?";
                        using (OleDbCommand checkCmd = new OleDbCommand(checkSql, conn))
                        {
                            checkCmd.Parameters.AddWithValue("?", row["ID Number"].ToString());
                            int exists = (int)checkCmd.ExecuteScalar();

                            if (exists == 0)
                            {
                                string sql = "INSERT INTO Users ([Username], [StudentName], [Email], [YearLevel], [Course], [Password], [ElectionTitle], [HasVoted], [UserRole]) " + "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";

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
                                    cmd.Parameters.AddWithValue("?", title);                        // 7

                                    cmd.Parameters.AddWithValue("?", "No");                         // 8
                                    cmd.Parameters.AddWithValue("?", "voter");                      // 9

                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    MessageBox.Show("Voters imported and assigned to: " + ElectionManager.CurrentTitle);
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
                            // 3. Save the values BACK to the grid using the correct property names
                            dgvElections.Rows[e.RowIndex].Cells[0].Value = editPopup.ElectionTitle;
                            dgvElections.Rows[e.RowIndex].Cells[2].Value = editPopup.StartDate.ToString("MM/dd/yyyy hh:mm tt");
                            dgvElections.Rows[e.RowIndex].Cells[3].Value = editPopup.EndDate.ToString("MM/dd/yyyy hh:mm tt");

                            UpdateDashboardCounters();
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

        private void DeleteCandidateVotes(string electionTitle, string candidateName)
        {
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";
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

                if (relativeMouseX < dgvPositions.Columns[e.ColumnIndex].Width / 2) // Edit
                {
                    using (AddPosition editPop = new AddPosition())
                    {
                        string currentElection = dgvPositions.Rows[e.RowIndex].Cells[0].Value.ToString();
                        string currentPosition = dgvPositions.Rows[e.RowIndex].Cells[1].Value.ToString();

                        foreach (DataGridViewRow r in dgvElections.Rows)
                        {
                            if (r.Cells[0].Value != null) editPop.ElectionList.Add(r.Cells[0].Value.ToString());
                        }

                        editPop.LoadPositionData(currentElection, currentPosition);

                        if (editPop.ShowDialog() == DialogResult.OK)
                        {
                            dgvPositions.Rows[e.RowIndex].Cells[0].Value = editPop.SelectedElection;
                            dgvPositions.Rows[e.RowIndex].Cells[1].Value = editPop.PositionName;
                        }
                    }
                }
                else // Delete
                {
                    if (MessageBox.Show("Delete all positions for this election?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        dgvPositions.Rows.RemoveAt(e.RowIndex);
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
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";

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
            int active = 0;
            int completed = 0;

            foreach (DataGridViewRow row in dgvElections.Rows)
            {
                if (row.IsNewRow) continue;

                // .Trim() removes hidden spaces, .ToUpper() makes it all caps for easy comparison
                string status = row.Cells[1].Value?.ToString().Trim().ToUpper() ?? "";

                if (status == "ACTIVE")
                {
                    active++;
                }
                else if (status == "COMPLETED")
                {
                    completed++;
                }
            }

            // Now update your labels
            lblActiveElections.Text = active.ToString();
            lblCompletedElections.Text = completed.ToString();

            // Toggle the "No elections" message
            lblNoElections.Visible = (dgvUpcomingElections.Rows.Count == 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool needsRefresh = false;
            DateTime now = DateTime.Now;

            foreach (DataGridViewRow row in dgvElections.Rows)
            {
                if (row.Cells["colEStart"].Value == null || row.Cells["colEEnd"].Value == null) continue;

                DateTime start = DateTime.Parse(row.Cells["colEStart"].Value.ToString());
                DateTime end = DateTime.Parse(row.Cells["colEEnd"].Value.ToString());
                string currentStatus = row.Cells["colEStatus"].Value?.ToString();
                string newStatus;

                if (now < start) newStatus = "Upcoming";
                else if (now >= start && now <= end) newStatus = "Active";
                else newStatus = "Completed";

                if (currentStatus != newStatus)
                {
                    row.Cells["colEStatus"].Value = newStatus;
                    needsRefresh = true;
                }
            }

            if (needsRefresh) UpdateDashboardCounters();
        }

        private void UpdateActiveElectionsCount()
        {
            int activeCount = 0;
            DateTime now = DateTime.Now;

            foreach (DataGridViewRow row in dgvElections.Rows)
            {
                if (row.Cells[2].Value != null && row.Cells[3].Value != null)
                {
                    DateTime startDate = DateTime.Parse(row.Cells[2].Value.ToString());
                    DateTime endDate = DateTime.Parse(row.Cells[3].Value.ToString());

                    if (now >= startDate && now <= endDate) activeCount++;
                }
            }
            lblActiveElections.Text = activeCount.ToString();
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
            // 1. Ask for confirmation so you don't delete by accident!
            DialogResult result = MessageBox.Show("Are you sure you want to delete ALL voters from the system? This cannot be undone.",
                                                  "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string accessConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";

                using (OleDbConnection accessConn = new OleDbConnection(accessConnString))
                {
                    try
                    {
                        accessConn.Open();

                        // SQL to delete only users with the 'voter' role 
                        // (This keeps your Admin account safe!)
                        string deleteQuery = "DELETE FROM Users WHERE [UserRole] = 'voter'";

                        using (OleDbCommand cmd = new OleDbCommand(deleteQuery, accessConn))
                        {
                            int rowsDeleted = cmd.ExecuteNonQuery();

                            // 2. Clear the Grid in your WinForms UI
                            dgvVoters.DataSource = null;
                            dgvVoters.Rows.Clear();

                            // 3. Update the "Total Voters" label to 0
                            lblTotalVoters.Text = "0";

                            MessageBox.Show($"{rowsDeleted} voters have been deleted from the database.", "Success");
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

        private void CandidateButton_MouseHover(object sender, EventArgs e) => CandidateButton.BackColor = Color.FromArgb(255, 215, 0);
        private void CandidateButton_MouseLeave(object sender, EventArgs e) => CandidateButton.BackColor = Color.Maroon;

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
                    string accessConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";

                    using (OleDbConnection conn = new OleDbConnection(accessConnString))
                    {
                        try
                        {
                            conn.Open();
                            // 3. Delete from Access using the ID
                            string deleteQuery = "DELETE FROM Users WHERE [Username] = @id";

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
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb";
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
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb";
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
                string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";
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

        private void LoadAnalyticsChart()
        {
            string selectedElection = cmbElectionFilter.Text;

            // Clear existing data
            chartAnalytics.Series[0].Points.Clear();
            chartAnalytics.Titles.Clear();
            chartAnalytics.Titles.Add("Votes by Course: " + selectedElection);
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Query to group votes by course
                    string sql = "SELECT [Course], COUNT(*) as TotalVotes FROM Votes WHERE ElectionTitle = ? GROUP BY [Course]";

                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.Parameters.AddWithValue("?", selectedElection);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string course = reader["Course"].ToString();
                        int count = Convert.ToInt32(reader["TotalVotes"]);

                        // Add data point to the chart
                        chartAnalytics.Series[0].Points.AddXY(course, count);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chart Error: " + ex.Message);
                }
            }
        }

        private void UpdateStatCards()
        {
            string selected = cmbElectionFilter.Text;
            if (string.IsNullOrEmpty(selected) || selected == "--Select Election--") return;

            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // 1. TOP COURSE (Department with most votes)
                    string sqlTopCourse = "SELECT TOP 1 [Course] FROM Votes WHERE ElectionTitle = ? GROUP BY [Course] ORDER BY COUNT(*) DESC";
                    using (OleDbCommand cmd = new OleDbCommand(sqlTopCourse, conn))
                    {
                        cmd.Parameters.AddWithValue("?", selected);
                        lblTopCourse.Text = cmd.ExecuteScalar()?.ToString() ?? "None";
                    }

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

                    // 3. LEADING CANDIDATE (Candidate with highest vote count)
                    string sqlLeader = "SELECT TOP 1 CandidateName FROM Votes WHERE ElectionTitle = ? GROUP BY CandidateName ORDER BY COUNT(*) DESC";
                    using (OleDbCommand cmd = new OleDbCommand(sqlLeader, conn))
                    {
                        cmd.Parameters.AddWithValue("?", selected);
                        lblLeadingCandidate.Text = cmd.ExecuteScalar()?.ToString() ?? "No Leader";
                    }

                    // --- 4. TOTAL TURNOUT (NEW SECTION) ---
                    // Count total registered voters (Role='Voter' prevents counting Admin)
                    string sqlTotalVoters = "SELECT COUNT(*) FROM Users WHERE [Role] = 'Voter'";
                    int totalRegistered = 0;
                    using (OleDbCommand cmdReg = new OleDbCommand(sqlTotalVoters, conn))
                    {
                        totalRegistered = (int)cmdReg.ExecuteScalar();
                    }

                    // Count total unique voters who participated in this election
                    string sqlVotedCount = "SELECT COUNT(*) FROM (SELECT DISTINCT VoterID FROM Votes WHERE ElectionTitle = ?)";
                    int totalVoted = 0;
                    using (OleDbCommand cmdVoted = new OleDbCommand(sqlVotedCount, conn))
                    {
                        cmdVoted.Parameters.AddWithValue("?", selected);
                        totalVoted = (int)cmdVoted.ExecuteScalar();
                    }

                    // Calculate and display percentage
                    if (totalRegistered > 0)
                    {
                        double turnoutPercent = ((double)totalVoted / totalRegistered) * 100;
                        lblTurnout.Text = turnoutPercent.ToString("0.0") + "%";
                    }
                    else
                    {
                        lblTurnout.Text = "0%";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Stat Card Error: " + ex.Message);
                }
            }
        }

        private void LoadCandidateBarChart()
        {
            string selectedElection = cmbElectionFilter.Text;

            chartCandidateBar.Series[0].Points.Clear();
            chartCandidateBar.Titles.Clear();
            chartCandidateBar.Titles.Add("Top 5 Overall Candidates");
            chartCandidateBar.Series[0].LegendText = "Votes";
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Get the top 5 candidates by vote count
                    string sql = "SELECT TOP 5 CandidateName, COUNT(*) as VoteCount " +
                                 "FROM Votes WHERE ElectionTitle = ? " +
                                 "GROUP BY CandidateName ORDER BY COUNT(*) DESC";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", selectedElection);
                        OleDbDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            chartCandidateBar.Series[0].Points.AddXY(reader["CandidateName"].ToString(), reader["VoteCount"]);
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
            lblSubtitle.Text = $"Showing results for: {selected} | Data updated as of {DateTime.Now:hh:mm tt}";
        }

    }
}



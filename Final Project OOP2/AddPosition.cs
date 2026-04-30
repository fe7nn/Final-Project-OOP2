using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Final_Project_OOP2
{
    public partial class AddPosition : Form
    {
        public List<string> ElectionList = new List<string>();
        // 1. Properties to hold the data for the Dashboard to read
        string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";
        public string PositionName { get; set; }
        public string SelectedElection { get; set; }
        public string SelectedOrganization { get; set; }
        private bool isEditMode = false;
        private string originalElection;
        private string originalPosition;
        public AddPosition()
        {
            InitializeComponent();
        }

        private void LoadOrganizations()
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Pull unique organization names from the Admin table
                    string sql = "SELECT DISTINCT AssignedOrg FROM Admin WHERE AssignedOrg <> 'Global' ORDER BY AssignedOrg ASC";

                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    cmbOrgList.Items.Clear();

                    while (reader.Read())
                    {
                        // Ensure we don't add null values
                        string org = reader["AssignedOrg"].ToString();
                        if (!string.IsNullOrEmpty(org))
                        {
                            cmbOrgList.Items.Add(org);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // This catches the 0x80004005 error if the database path is wrong
                    MessageBox.Show("Error loading Organizations: " + ex.Message);
                }
            }
        }


        private void AddPosition_Load(object sender, EventArgs e)
        {
            // 1. Load the elections passed from the Dashboard
            cmbElectionTitle.Items.Clear();
            if (ElectionList != null && ElectionList.Count > 0)
            {
                foreach (string election in ElectionList)
                {
                    cmbElectionTitle.Items.Add(election);
                }

                if (cmbElectionTitle.SelectedIndex == -1)
                    cmbElectionTitle.SelectedIndex = 0;
            }

            // 2. NEW: Load Organizations from the Admin Table
            LoadOrganizations();

            // 3. Keep your existing AutoComplete logic
            txtPositionName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPositionName.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection positions = new AutoCompleteStringCollection();
            positions.AddRange(new string[]
            {
                "President", "Vice-President", "Secretary",
                "Treasurer", "Auditor", "Public Information Officer",
                "Protocol Officer", "1st Year Representative",
                "2nd Year Representative", "3rd Year Representative", "4th Year Representative"
            });

            txtPositionName.AutoCompleteCustomSource = positions;
        }

        // --- ADD THIS METHOD FOR THE EDITING PART ---
        public void LoadPositionData(string election, string position, string organization)
        {
            originalElection = election;
            originalPosition = position;
            isEditMode = true;

            cmbElectionTitle.SelectedItem = election;
            txtPositionName.Text = position;
            cmbOrgList.SelectedItem = organization;

            PoistionCreate.Text = "Update Position";
        }

        private void PoistionCreate_Click(object sender, EventArgs e)
        {
            if (cmbElectionTitle.SelectedItem == null ||
         string.IsNullOrWhiteSpace(txtPositionName.Text) ||
         cmbOrgList.SelectedItem == null)
            {
                MessageBox.Show("Please select an election, enter a position, and select an organization.");
                return;
            }

            this.SelectedElection = cmbElectionTitle.SelectedItem.ToString();
            this.PositionName = txtPositionName.Text;
            this.SelectedOrganization = cmbOrgList.SelectedItem.ToString();

            string sql;

            if (isEditMode)
            {
                // UPDATE the existing record using the originals in the WHERE clause
                sql = "UPDATE Positions SET [PositionName] = ?, [ElectionTitle] = ?, [Organization] = ? " +
                      "WHERE [PositionName] = ? AND [ElectionTitle] = ?";
            }
            else
            {
                // INSERT a brand new record
                sql = "INSERT INTO Positions ([PositionName], [ElectionTitle], [Organization]) VALUES (?, ?, ?)";
            }

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", this.PositionName);
                        cmd.Parameters.AddWithValue("?", this.SelectedElection);
                        cmd.Parameters.AddWithValue("?", this.SelectedOrganization);

                        if (isEditMode)
                        {
                            // Add the WHERE clause parameters
                            cmd.Parameters.AddWithValue("?", originalPosition);
                            cmd.Parameters.AddWithValue("?", originalElection);
                        }

                        cmd.ExecuteNonQuery();
                        MessageBox.Show(isEditMode ? "Position updated successfully!" : "Position saved successfully for " + this.SelectedOrganization);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Save Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbElectionTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbElectionTitle.SelectedItem == null) return;

            string electionTitle = cmbElectionTitle.SelectedItem.ToString().ToUpper();

            // Loop through all organizations and find the best match
            string bestMatch = null;
            int bestMatchLength = 0;

            foreach (var item in cmbOrgList.Items)
            {
                string org = item.ToString().ToUpper();

                // Check if the election title CONTAINS the org name
                if (electionTitle.Contains(org) && org.Length > bestMatchLength)
                {
                    bestMatch = item.ToString();
                    bestMatchLength = org.Length;
                }
            }

            // Auto-select if a match was found
            if (bestMatch != null)
            {
                cmbOrgList.SelectedItem = bestMatch;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Final_Project_OOP2
{
    public partial class AddCandidate : Form
    {
        // Data properties
        private string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";
        public string CandidateName { get; set; }
        public string Election { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public Image Photo { get; set; }
        public string PhotoPath { get; set; }

        // NEW: Property to hold the President's Organization (e.g., "ICPEP")
        public string CurrentOrg { get; set; }

        // properties to hold the lists from the dashboard
        public List<string> ElectionList { get; set; } = new List<string>();
        public List<string> PositionList { get; set; } = new List<string>();

        // Guard to avoid re-entrant calls while filling positions
        private bool _isLoadingPositions = false;

        public AddCandidate()
        {
            InitializeComponent();
        }

        // Use this method when EDITING an existing candidate
        public void LoadCandidateData(string path, string name, string election, string position, string desc, List<string> eList, List<string> pList)
        {
            txtName.Text = name;
            cmbElectionTitle.Text = election;
            cmbPosition.Text = position;
            txtDescription.Text = desc;

            // Fill the ComboBoxes
            cmbElectionTitle.Items.Clear();
            cmbPosition.Items.Clear();
            foreach (var item in eList) cmbElectionTitle.Items.Add(item);
            foreach (var item in pList) cmbPosition.Items.Add(item);

            this.PhotoPath = path;
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                lblFileName.Text = path;
                // Optional: pbPreview.Image = Image.FromFile(path);
            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (open.ShowDialog() == DialogResult.OK)
            {
                lblFileName.Text = open.FileName;
                // If you have a PictureBox for preview, load it here:
                // pbPreview.Image = Image.FromFile(open.FileName);
            }
        }

        private void btnSaveCandidate_Click(object sender, EventArgs e)
        {
            

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Count your '?' markers carefully (Total of 6)
                    string sql = "INSERT INTO Candidates ([ElectionTitle], [Position], [FullName], [Description], [ImagePath], [Organization]) " +
                                 "VALUES (?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        // Order MUST match the SQL statement above
                        cmd.Parameters.AddWithValue("@title", cmbElectionTitle.Text);
                        cmd.Parameters.AddWithValue("@pos", cmbPosition.Text);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@img", lblFileName.Text);

                        // CRITICAL: Ensure CurrentOrg is not null
                        cmd.Parameters.AddWithValue("@org", string.IsNullOrEmpty(CurrentOrg) ? "Unknown" : CurrentOrg);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Candidate successfully added!", "Success");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving candidate: " + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddCandidate_Load_1(object sender, EventArgs e)
        {
            // Unlock both to be safe
            cmbElectionTitle.DataSource = null;
            cmbPosition.DataSource = null;
            cmbElectionTitle.Items.Clear();
            cmbPosition.Items.Clear();

            // Bind Elections only
            if (ElectionList != null && ElectionList.Count > 0)
            {
                // Use a list for the DataSource
                cmbElectionTitle.DataSource = ElectionList.Distinct().ToList();
            }

            // Ensure the correct event handler is attached so selecting an election loads positions
            cmbElectionTitle.SelectedIndexChanged -= cmbElectionTitle_SelectedIndexChanged;
            cmbElectionTitle.SelectedIndexChanged += cmbElectionTitle_SelectedIndexChanged;

            // Instead of binding PositionList here, let the SelectedIndexChanged 
            // of the ElectionTitle handle it automatically.
            LoadPositionsForSelectedElection();

            if (!string.IsNullOrEmpty(Election)) cmbElectionTitle.Text = Election;
            if (!string.IsNullOrEmpty(Position)) cmbPosition.Text = Position;
        }

        private void LoadPositionsForSelectedElection()
        {
            if (_isLoadingPositions) return;

            if (cmbElectionTitle.SelectedItem == null) return;
            string selectedElection = cmbElectionTitle.SelectedItem.ToString();
            if (string.IsNullOrWhiteSpace(selectedElection)) return;

            _isLoadingPositions = true;

            

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Break the link to prevent the "DataSource" error
                    cmbPosition.DataSource = null;
                    cmbPosition.Items.Clear();

                    // SQL targets the Positions table
                    string sql = "SELECT [PositionName] FROM [Positions] WHERE [ElectionTitle] = ?";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", selectedElection);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string pos = reader["PositionName"]?.ToString() ?? "";
                                if (!string.IsNullOrEmpty(pos))
                                {
                                    cmbPosition.Items.Add(pos);
                                }
                            }
                        }
                    }

                    if (cmbPosition.Items.Count > 0) cmbPosition.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading filtered positions: " + ex.Message);
                }
                finally
                {
                    _isLoadingPositions = false;
                }
            }
        }

        // Ensure election selection triggers reload of positions
        private void cmbElectionTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPositionsForSelectedElection();
        }

        // Don't use this to load positions (Designer may still wire this). Keep it simple.
        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPosition.SelectedItem != null)
            {
                Position = cmbPosition.SelectedItem.ToString();
            }
        }
    }
}
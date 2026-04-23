using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Final_Project_OOP2
{
    public partial class AddCandidate : Form
    {
        // Data properties
        public string CandidateName { get; set; }
        public string Election { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public Image Photo { get; set; }
        public string PhotoPath { get; set; }


        // properties to hold the lists from the dashboard
        public List<string> ElectionList { get; set; } = new List<string>();
        public List<string> PositionList { get; set; } = new List<string>();

        public AddCandidate()
        {
            InitializeComponent();
        }


        // Use this method when EDITING an existing candidate
        public void LoadCandidateData(string path, string name, string election, string position, string desc, List<string> eList, List<string> pList)
        {
            // IMPORTANT: Replace 'txtName', 'cmbElection', etc. with YOUR control names
            txtName.Text = name;
            cmbElectionTitle.Text = election;
            cmbPosition.Text = position;
            txtDescription.Text = desc;

            // Fill the ComboBoxes using the list names from the parentheses (eList, pList)
            foreach (var item in eList) cmbElectionTitle.Items.Add(item);
            foreach (var item in pList) cmbPosition.Items.Add(item);

            // Keep the old path in case the user doesn't pick a new photo
            this.PhotoPath = path;
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (open.ShowDialog() == DialogResult.OK)
            {
                // Display the path in your label (lblPhotoPath)
                lblFileName.Text = open.FileName;

                // Optional: Show a preview if you have a PictureBox

            }
        }

        private void btnSaveCandidate_Click(object sender, EventArgs e)
        {
            string accessConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\OOP Final Project - TAMARES\VotingSystem.mdb;";

            using (OleDbConnection conn = new OleDbConnection(accessConnString))
            {
                try
                {
                    conn.Open();
                    // Use [] for all column names to be safe with Access
                    string sql = "INSERT INTO Candidates ([ElectionTitle], [Position], [FullName], [Description], [ImagePath]) " +
                                 "VALUES (?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", cmbElectionTitle.Text);
                        cmd.Parameters.AddWithValue("@pos", cmbPosition.Text);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@img", lblFileName.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Candidate successfully added to the election!", "Success");

                    // 1. Set DialogResult to OK so the Dashboard knows to refresh
                    this.DialogResult = DialogResult.OK;

                    // 2. Close the pop-up
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

        private void cmbElectionTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddCandidate_Load_1(object sender, EventArgs e)
        {
            // FORCE CLEAR THE OLD DATA
            cmbElectionTitle.DataSource = null;
            cmbPosition.DataSource = null;

            // RE-BIND THE NEW DATA
            if (ElectionList != null && ElectionList.Count > 0)
            {
                cmbElectionTitle.DataSource = ElectionList.Distinct().ToList();
            }

            if (PositionList != null && PositionList.Count > 0)
            {
                cmbPosition.DataSource = PositionList.Distinct().ToList();
            }

            // Restore text if we are editing
            if (!string.IsNullOrEmpty(Election)) cmbElectionTitl.Text = Election;
            if (!string.IsNullOrEmpty(Position)) cmbPosition.Text = Position;
        }

        private void cmbElectionTitle_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_OOP2
{
    public partial class AddCandidate : Form
    {
        public string CandidateName { get; set; }
        public string Election { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public Image Photo { get; set; }

        public AddCandidate()
        {
            InitializeComponent();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Photo = Image.FromFile(ofd.FileName);
                    lblFileName.Text = Path.GetFileName(ofd.FileName);
                }
            }
        }

        private void btnSaveCandidate_Click(object sender, EventArgs e)
        {
            // Fill the properties before closing
            CandidateName = cmbStudent.Text;
            Election = cmbElection.Text;
            Position = cmbPosition.Text;
            Description = txtDescription.Text;

            this.DialogResult = DialogResult.OK; // Tells the Dashboard "Yes, save it!"
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCandidate_Load(object sender, EventArgs e)
        {

        }
        public void LoadCandidateData(Image photo, string name, string election, string position, string desc)
        {
            this.Text = "Edit Candidate"; // Change the title of the window
            btnSaveCandidate.Text = "Update Candidate"; // Change the button text

            // Fill the inputs
            Photo = photo;
            cmbStudent.Text = name;
            cmbElection.Text = election;
            cmbPosition.Text = position;
            txtDescription.Text = desc;

            // If you have a label for the filename, update it
            lblFileName.Text = "Existing Photo";
        }
    }
}


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
    public partial class AddPosition : Form
    {
        public AddPosition()
        {
            InitializeComponent();
        }
        public string SelectedElection { get; set; }
        public string PositionName { get; set; }

        private void AddPosition_Load(object sender, EventArgs e)
        {
            // 1. Setup the behavior
            txtPositionName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPositionName.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // 2. Create the specific list for your project
            AutoCompleteStringCollection positions = new AutoCompleteStringCollection();
            positions.AddRange(new string[]
            {
                "President",
                "Vice President",
                "Secretary General",
                "Treasurer General",
                "Solicitor General",
                "Executive Auditor",
                "Cabinet Secretary",
                "1st Year Representative",
                "2nd Year Representative",
                "3rd Year Representative",
                "4th Year Representative"
            });

            // 3. Apply the list to your textbox
            txtPositionName.AutoCompleteCustomSource = positions;
        }

        private void PoistionCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPositionName.Text))
            {
                MessageBox.Show("Please enter a position name.");
                return;
            }

            // Add to dgvPositions
            // Columns: ID (Hidden), Position Name, Max Votes, Actions (Edit|Delete)
            dgvPositions.Rows.Add("", txtPositionName.Text, numMaxVotes.Value.ToString(), "Edit | Delete");

            // Clear the input for the next one
            txtPositionName.Clear();
            numMaxVotes.Value = 1;

            // Call your check method to hide the "No Positions Found" label
            CheckForPositions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

using System;
using System.Windows.Forms;

namespace Final_Project_OOP2
{
    public partial class AddElection : Form
    {
        // Properties used by the Dashboard to pass/read data
        public string? ElectionTitle { get; set; }
        public DateTime FullStart { get; set; } = DateTime.Now;
        public DateTime FullEnd { get; set; } = DateTime.Now.AddDays(1);

        public AddElection()
        {
            InitializeComponent();
        }

        private void AddElection_Load(object sender, EventArgs e)
        {
            // --- THIS PART WAS MISSING ---
            // When the form opens, put the property values into the UI controls
            txtElectionTitle.Text = ElectionTitle;

            // Set Date portion and Time portion for Start
            dtpStartDate.Value = FullStart;
            dtpStartTime.Value = FullStart;

            // Set Date portion and Time portion for End
            dtpEndDate.Value = FullEnd;
            dtpEndTime.Value = FullEnd;

            txtElectionTitle.Focus();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtElectionTitle.Text))
            {
                MessageBox.Show("Please enter an Election Title.");
                return;
            }

            // Combine the separate Date and Time pickers back into the single DateTime properties
            this.FullStart = dtpStartDate.Value.Date + dtpStartTime.Value.TimeOfDay;
            this.FullEnd = dtpEndDate.Value.Date + dtpEndTime.Value.TimeOfDay;

            if (FullEnd <= FullStart)
            {
                MessageBox.Show("End date/time must be after the start date/time.");
                return;
            }

            // Update the property so the Dashboard can read the final value
            this.ElectionTitle = txtElectionTitle.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Keep this method if you prefer calling it manually from the Dashboard
        public void LoadElectionData(string title, DateTime start, DateTime end)
        {
            this.ElectionTitle = title;
            this.FullStart = start;
            this.FullEnd = end;

            // Immediately update UI if the form is already open
            txtElectionTitle.Text = title;
            dtpStartDate.Value = start;
            dtpStartTime.Value = start;
            dtpEndDate.Value = end;
            dtpEndTime.Value = end;


        }
    }
}
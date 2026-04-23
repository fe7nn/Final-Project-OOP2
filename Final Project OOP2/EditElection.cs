using System;
using System.Windows.Forms;

namespace Final_Project_OOP2
{
    public partial class EditElection : Form
    {
        // Properties to hold the data so the Dashboard can read them back
        public string ElectionTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public EditElection()
        {
            InitializeComponent();
        }

        // --- NEW: This method fills the form with the current data from the Grid ---
        public void LoadElectionData(string title, string start, string end)
        {
            txtEditTitle.Text = title;

            // Convert the strings from the Grid back into DateTime values for your pickers
            if (DateTime.TryParse(start, out DateTime s))
            {
                dtpStartDate.Value = s.Date;
                dtpStartTime.Value = s;
            }
            if (DateTime.TryParse(end, out DateTime n))
            {
                dtpEndDate.Value = n.Date;
                dtpEndTime.Value = n;
            }
        }

        private void btnUpdateElection_Click(object sender, EventArgs e)
        {
            // 1. Basic Validation
            if (string.IsNullOrWhiteSpace(txtEditTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Combine Date and Time from your separate tools (Date + TimeOfDay)
            this.ElectionTitle = txtEditTitle.Text;
            this.StartDate = dtpStartDate.Value.Date + dtpStartTime.Value.TimeOfDay;
            this.EndDate = dtpEndDate.Value.Date + dtpEndTime.Value.TimeOfDay;

            // 3. Validation for logic
            if (EndDate <= StartDate)
            {
                MessageBox.Show("End date/time must be after the start date/time.", "Date Error");
                return;
            }

            // 4. Close with OK result
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void EditElection_Load(object sender, EventArgs e)
        {
            // Optional: Any initialization logic
        }
    }
}
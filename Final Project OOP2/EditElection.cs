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
    public partial class EditElection : Form
    {
        public string ElectionTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public EditElection()
        {
            InitializeComponent();
        }

        private void EditElection_Load(object sender, EventArgs e)
        {
           
        }

        private void btnUpdateElection_Click(object sender, EventArgs e)
        {
            // Basic Validation
            if (string.IsNullOrWhiteSpace(txtEditTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Combine Date and Time from the separate tools
            ElectionTitle = txtEditTitle.Text;
            StartDate = dtpStartDate.Value.Date + dtpStartTime.Value.TimeOfDay;
            EndDate = dtpEndDate.Value.Date + dtpEndTime.Value.TimeOfDay;

            MessageBox.Show("Election updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class AddElection : Form
    {
        public AddElection()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtElectionTitle.Text)) return;

            // Add to dgvElections
            // Columns: Election Title, Status, Actions
            dgvElections.Rows.Add(txtElectionTitle.Text, "Draft", "Edit | Delete");

            txtElectionTitle.Clear();
            CheckForElections();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddElection_Load(object sender, EventArgs e)
        {

        }
    }
}

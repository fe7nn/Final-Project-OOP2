using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_OOP2
{
    public partial class ImportVoters : Form
    {
        public DataTable ImportedData { get; private set; }
        public ImportVoters()
        {
            InitializeComponent();
            ImportedData = new DataTable();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("Please select a file first.");
                return;
            }

            // Connection string for .mdb
            string connString = $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={txtFilePath.Text};";

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                try
                {
                    conn.Open();
                    // Querying the columns you specified
                    string query = "SELECT [IDNumber], [FullName], [Year], [Course] FROM Voters";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);

                    ImportedData.Clear();
                    adapter.Fill(ImportedData);

                    MessageBox.Show($"{ImportedData.Rows.Count} voters found! Closing to update dashboard.", "Success");
                    this.DialogResult = DialogResult.OK; // Signals the Dashboard to proceed
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdImport.Filter = "MS Access Database (*.mdb)|*.mdb";
            if (ofdImport.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofdImport.FileName;
            }
        }

        private void btnCancelImport_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

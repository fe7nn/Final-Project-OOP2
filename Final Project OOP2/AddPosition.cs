using System;
using System.Windows.Forms;

namespace Final_Project_OOP2
{
    public partial class AddPosition : Form
    {
        public List<string> ElectionList = new List<string>();
        // 1. Properties to hold the data for the Dashboard to read
        public string? SelectedElection { get; set; }
        public string? PositionName { get; set; }

        public AddPosition()
        {
            InitializeComponent();
        }

        private void AddPosition_Load(object sender, EventArgs e)
        {
            // 1. Load the elections passed from the Dashboard into the ComboBox
            cmbElectionTitle.Items.Clear();
            if (ElectionList != null && ElectionList.Count > 0)
            {
                foreach (string election in ElectionList)
                {
                    cmbElectionTitle.Items.Add(election);
                }

                // Only auto-select if something isn't already selected (prevents overwriting Edit data)
                if (cmbElectionTitle.SelectedIndex == -1)
                    cmbElectionTitle.SelectedIndex = 0;
            }

            // Keep your existing AutoComplete logic
            txtPositionName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPositionName.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection positions = new AutoCompleteStringCollection();
            positions.AddRange(new string[]
            {
                "President", "Vice President", "Secretary General",
                "Treasurer General", "Solicitor General", "Executive Auditor",
                "Cabinet Secretary", "1st Year Representative",
                "2nd Year Representative", "3rd Year Representative", "4th Year Representative"
            });

            txtPositionName.AutoCompleteCustomSource = positions;
        }

        // --- ADD THIS METHOD FOR THE EDITING PART ---
        public void LoadPositionData(string election, string positions)
        {
            // This pre-fills the form when you click "Edit" in the Dashboard
            cmbElectionTitle.SelectedItem = election;

            // This puts all existing positions (President, VP, etc.) into the textbox
            txtPositionName.Text = positions;

            // Optional: Change the button text so you know you're editing
            PoistionCreate.Text = "Update Position";
        }

        private void PoistionCreate_Click(object sender, EventArgs e)
        {
            // --- ADDED: Validation for Election selection ---
            if (cmbElectionTitle.SelectedItem == null)
            {
                MessageBox.Show("Please select an election.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPositionName.Text))
            {
                MessageBox.Show("Please enter a position name.");
                return;
            }

            // --- ADDED: Capture the selected election ---
            this.SelectedElection = cmbElectionTitle.SelectedItem.ToString();

            // Just capture the name (Keep this)
            this.PositionName = txtPositionName.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
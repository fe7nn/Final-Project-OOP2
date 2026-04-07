namespace Final_Project_OOP2
{
    public partial class VoterDashboard : Form
    {
        private string currentVoterID;
        public VoterDashboard(string voterID)
        {
            InitializeComponent();
            this.currentVoterID = voterID;
        }

        private void VoterDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}

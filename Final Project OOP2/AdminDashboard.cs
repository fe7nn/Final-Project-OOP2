namespace Final_Project_OOP2
{
    public partial class AdminDashboard : Form
    {
        private string adminID;

        public AdminDashboard(string userID)
        {
            InitializeComponent();
            this.adminID = userID;
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            pnlDashboard.Visible = true;
            pnlCandidate.Visible = false;
            pnlPositions.Visible = false;
            pnlElection.Visible = false;
            pnlVoters.Visible = false;

            // UI Cleanup for DataGrid
            dgvUpcomingElections.BorderStyle = BorderStyle.None;
            dgvUpcomingElections.RowHeadersVisible = false;
        }

        #region Navigation & Sidebar Events

        private void DashButton_Click(object sender, EventArgs e)
        {
            pnlDashboard.Visible = true;
            pnlCandidate.Visible = false;
            pnlPositions.Visible = false;
            pnlElection.Visible = false;
            pnlVoters.Visible = false;
            pnlDashboard.BringToFront();
        }

        private void ElectionButton_Click(object sender, EventArgs e)
        {
            pnlElection.Visible = true;
            pnlCandidate.Visible = false;
            pnlDashboard.Visible = false;
            pnlPositions.Visible = false;
            pnlVoters.Visible = false;
            pnlElection.BringToFront();
        }

        private void PositionsButton_Click(object sender, EventArgs e)
        {
            pnlPositions.Visible = true;
            pnlCandidate.Visible = false;
            pnlElection.Visible = false;
            pnlDashboard.Visible = false;
            pnlVoters.Visible = false;
            pnlPositions.BringToFront();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form? loginForm = Application.OpenForms["VotingSytem"];
                if (loginForm != null)
                {
                    loginForm.Show();
                    this.Close();
                }
                else
                {
                    VotingSytem newLogin = new VotingSytem();
                    newLogin.Show();
                    this.Close();
                }
            }
        }

        #endregion

        #region Pop-up Form Launchers

        private void OpenCreateForm_Click(object sender, EventArgs e)
        {
            AddElection popup = new AddElection();
            DialogResult result = popup.ShowDialog();
        }

        private void addPositionOpenForm_Click(object sender, EventArgs e)
        {
            AddPosition popup = new AddPosition();
            DialogResult result = popup.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EditElection popup = new EditElection();
            DialogResult result = popup.ShowDialog();
        }

        #endregion

        #region Hover Effects

        private void DashButton_MouseEnter(object sender, EventArgs e) => DashButton.BackColor = Color.FromArgb(255, 215, 0);
        private void DashButton_MouseLeave(object sender, EventArgs e) => DashButton.BackColor = Color.Maroon;

        private void VotersButton_MouseHover(object sender, EventArgs e) => VotersButton.BackColor = Color.FromArgb(255, 215, 0);
        private void VotersButton_MouseLeave(object sender, EventArgs e) => VotersButton.BackColor = Color.Maroon;

        private void PositionsButton_MouseHover(object sender, EventArgs e) => PositionsButton.BackColor = Color.FromArgb(255, 215, 0);
        private void PositionsButton_MouseLeave(object sender, EventArgs e) => PositionsButton.BackColor = Color.Maroon;

        private void CandidateButton_MouseHover(object sender, EventArgs e) => CandidateButton.BackColor = Color.FromArgb(255, 215, 0);
        private void CandidateButton_MouseLeave(object sender, EventArgs e) => CandidateButton.BackColor = Color.Maroon;

        private void ElectionButton_MouseHover(object sender, EventArgs e) => ElectionButton.BackColor = Color.FromArgb(255, 215, 0);
        private void ElectionButton_MouseLeave(object sender, EventArgs e) => ElectionButton.BackColor = Color.Maroon;

        private void ResultsButton_MouseHover(object sender, EventArgs e) => ResultsButton.BackColor = Color.FromArgb(255, 215, 0);
        private void ResultsButton_MouseLeave(object sender, EventArgs e) => ResultsButton.BackColor = Color.Maroon;

        #endregion

        #region DataGridView Events (Delete & Custom Painting)

        private void dgvElections_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Match the column name used in the painting logic
            if (e.RowIndex >= 0 && dgvElections.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                if (MessageBox.Show("Are you sure you want to remove this election?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    dgvElections.Rows.RemoveAt(e.RowIndex);
                    CheckForElections(); // Refresh the "No Elections" label immediately
                }
            }
        }

        private void dgvElections_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Fix: Make sure it checks the same grid it's inside (dgvElections)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvElections.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                using (Brush backBrush = new SolidBrush(Color.FromArgb(220, 53, 69)))
                {
                    Rectangle btnRect = e.CellBounds;
                    btnRect.Inflate(-4, -4);
                    e.Graphics.FillRectangle(backBrush, btnRect);

                    TextRenderer.DrawText(e.Graphics, "Delete", e.CellStyle.Font, btnRect, Color.White,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                }
                e.Handled = true;
            }
        }

        #endregion

        #region UI Refresh Logic

        private void CheckForElections()
        {
            int emptyThreshold = dgvUpcomingElections.AllowUserToAddRows ? 1 : 0;
            if (dgvUpcomingElections.Rows.Count <= emptyThreshold)
            {
                lblNoElections.Visible = true;
                lblEnoelections.Visible = true;
                lblNoElections.BringToFront();
            }
            else
            {
                lblNoElections.Visible = false;
                lblEnoelections.Visible = false;
            }
        }

        private void CheckForVoters()
        {
            // If the grid is empty, show the "No voters yet" message
            if (dgvVoters.Rows.Count == 0)
            {
                lblVNoVoters.Visible = true;
                lblVNoVoters.BringToFront();
            }
            else
            {
                lblVNoVoters.Visible = false;
            }
        }

        private void pnlDashboard_Paint(object sender, PaintEventArgs e) => CheckForElections();
        private void pnlElection_Paint(object sender, PaintEventArgs e) => CheckForElections();
        private void pnlPositions_Paint(object sender, PaintEventArgs e) { }

        #endregion

        #region Unused UI Handlers & Placeholders

        private void lblEnoelections_Click(object sender, EventArgs e) { }
        private void VoteButton_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void pnlMainContainer_Paint(object sender, PaintEventArgs e) { }
        private void lblDashboard_Click(object sender, EventArgs e) { }

        #endregion

        private void pnlVoters_Paint(object sender, PaintEventArgs e)
        {
            CheckForVoters();
        }

        private void importVoters_Click(object sender, EventArgs e)
        {
            // 1. Create the popup instance
            using (ImportVoters popup = new ImportVoters())
            {
                // 2. Open the form and wait for the result
                DialogResult result = popup.ShowDialog();

                // 3. If the result is 'OK' (the user clicked Import in the other form)
                if (result == DialogResult.OK)
                {
                    // This is where you will put the code to refresh your DataGridView
                    // For now, we can show a test message
                    MessageBox.Show("Refreshing Voter List...", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // In Increment 2, we will call a function here to load 
                    // the data from your .mdb into the dgvVoters grid.
                    // LoadVotersFromDatabase(); 
                    CheckForVoters();
                }
            }
        }

        private void deleteVoters_Click(object sender, EventArgs e)
        {
            // 1. Check if there is even anything to delete
            if (dgvVoters.Rows.Count > 0)
            {
                // 2. High-level warning (since this clears the whole database list)
                DialogResult result = MessageBox.Show("Are you sure you want to PERMANENTLY delete the entire voter list?",
                    "Stop", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

                if (result == DialogResult.Yes)
                {
                    // 3. Clear the DataGridView
                    dgvVoters.Rows.Clear();

                    // 4. Reset your counter label (the big 0 in your top right card)
                    lblTotalVotersCount.Text = "0";

                    MessageBox.Show("All voter records have been cleared successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("The voter list is already empty.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void VotersButton_Click(object sender, EventArgs e)
        {
            pnlVoters.Visible = true;
            pnlCandidate.Visible = false;
            pnlPositions.Visible = false;
            pnlElection.Visible = false;
            pnlDashboard.Visible = false;
            pnlPositions.BringToFront();
        }

        private void dgvPositions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // --- DELETE ACTION ---
            if (dgvPositions.Columns[e.ColumnIndex].Name == "btnDeletePos")
            {
                if (MessageBox.Show("Are you sure you want to delete this position?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    dgvPositions.Rows.RemoveAt(e.RowIndex);
                }
            }

            // --- EDIT ACTION (Directly in Grid) ---
            if (dgvPositions.Columns[e.ColumnIndex].Name == "btnEditPos")
            {
                // This puts the cell into "Typing Mode" so you can change the name immediately
                dgvPositions.CurrentCell = dgvPositions.Rows[e.RowIndex].Cells[1]; // Focus the Position Name cell
                dgvPositions.BeginEdit(true);
            }
        }

        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            using (AddCandidate popup = new AddCandidate())
            {
                // Show the popup
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    // Pick up the data from the popup's properties and add to dgvCandidates
                    dgvCandidates.Rows.Add(
                        popup.Photo,
                        popup.CandidateName,
                        popup.Election,
                        popup.Position,
                        popup.Description
                    );

                    // Hide the "No candidates found" message if it was visible
                    CheckForCandidates();
                }
            }
        }

        private void pnlCandidate_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CandidateButton_Click(object sender, EventArgs e)
        {
            pnlCandidate.Visible = true;
            pnlVoters.Visible = false;
            pnlPositions.Visible = false;
            pnlElection.Visible = false;
            pnlDashboard.Visible = false;
            pnlCandidate.BringToFront();
        }

        private void CheckForCandidates()
        {
            // If the grid is empty (0 rows), show the message. Otherwise, hide it.
            if (dgvCandidates.Rows.Count == 0)
            {
                lblNoCandidates.Visible = true;
                lblNoCandidates.BringToFront(); // Ensures it's not hidden behind the grid
            }
            else
            {
                lblNoCandidates.Visible = false;
            }
        }

        private void dgvCandidates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvCandidates.Columns[e.ColumnIndex].Name == "colActions")
            {
                var relativeMouseX = dgvCandidates.PointToClient(Cursor.Position).X
                                     - dgvCandidates.GetColumnDisplayRectangle(e.ColumnIndex, false).X;

                // --- HANDLE EDIT (Left Side Click) ---
                if (relativeMouseX < dgvCandidates.Columns[e.ColumnIndex].Width / 2)
                {
                    using (AddCandidate editForm = new AddCandidate())
                    {
                        // 1. Get the current data from the row
                        Image currentPhoto = (Image)dgvCandidates.Rows[e.RowIndex].Cells["colPhoto"].Value;
                        string currentName = dgvCandidates.Rows[e.RowIndex].Cells["colName"].Value.ToString();
                        string currentElection = dgvCandidates.Rows[e.RowIndex].Cells["colCElection"].Value.ToString();
                        string currentPosition = dgvCandidates.Rows[e.RowIndex].Cells["colCPosition"].Value.ToString();
                        string currentDesc = dgvCandidates.Rows[e.RowIndex].Cells["colDescription"].Value.ToString();

                        // 2. Pass it to the form
                        editForm.LoadCandidateData(currentPhoto, currentName, currentElection, currentPosition, currentDesc);

                        // 3. If they click "Update"
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            // 4. Update the specific row with the new values
                            dgvCandidates.Rows[e.RowIndex].Cells["colPhoto"].Value = editForm.Photo;
                            dgvCandidates.Rows[e.RowIndex].Cells["colName"].Value = editForm.CandidateName;
                            dgvCandidates.Rows[e.RowIndex].Cells["colCElection"].Value = editForm.Election;
                            dgvCandidates.Rows[e.RowIndex].Cells["colCPosition"].Value = editForm.Position;
                            dgvCandidates.Rows[e.RowIndex].Cells["colDescription"].Value = editForm.Description;
                        }
                    }
                }
                // --- HANDLE DELETE (Right Side Click) ---
                else
                {
                    HandleDeleteAction(e.RowIndex);
                }
            }
        }

        private void HandleEditAction(int rowIndex)
        {
            MessageBox.Show("Editing " + dgvCandidates.Rows[rowIndex].Cells["colName"].Value);
        }

        private void HandleDeleteAction(int rowIndex)
        {
            if (MessageBox.Show("Delete this record?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dgvCandidates.Rows.RemoveAt(rowIndex);
                CheckForCandidates();
            }
        }
    }
}
namespace Final_Project_OOP2
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            pnlSidebar = new Panel();
            label1 = new Label();
            pictureBox3 = new PictureBox();
            LogOut = new Button();
            imageList1 = new ImageList(components);
            ResultsButton = new Button();
            ElectionButton = new Button();
            CandidateButton = new Button();
            PositionsButton = new Button();
            VotersButton = new Button();
            DashButton = new Button();
            pnlMainContainer = new Panel();
            pnlCandidate = new Panel();
            lblNoCandidates = new Label();
            dgvCandidates = new DataGridView();
            colPhoto = new DataGridViewImageColumn();
            colName = new DataGridViewTextBoxColumn();
            colCElection = new DataGridViewTextBoxColumn();
            colCPosition = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colActions = new DataGridViewButtonColumn();
            btnAddCandidate = new Button();
            label14 = new Label();
            label12 = new Label();
            pnlVoters = new Panel();
            lblVNoVoters = new Label();
            dgvVoters = new DataGridView();
            colIDNumber = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colYear = new DataGridViewTextBoxColumn();
            colCourse = new DataGridViewTextBoxColumn();
            colVstatus = new DataGridViewTextBoxColumn();
            colVActions = new DataGridViewButtonColumn();
            deleteVoters = new Button();
            imageList2 = new ImageList(components);
            importVoters = new Button();
            panel1 = new Panel();
            lblTotalVotersCount = new Label();
            label13 = new Label();
            label11 = new Label();
            label8 = new Label();
            pnlDashboard = new Panel();
            lblNoElections = new Label();
            dgvUpcomingElections = new DataGridView();
            colTitle = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colStart = new DataGridViewTextBoxColumn();
            colEnd = new DataGridViewTextBoxColumn();
            colTotalVotes = new DataGridViewTextBoxColumn();
            lblDashboard = new Label();
            label5 = new Label();
            panel2 = new Panel();
            totalVotersValue = new Label();
            label2 = new Label();
            panel3 = new Panel();
            activeElections = new Label();
            label3 = new Label();
            panel4 = new Panel();
            completedElection = new Label();
            label4 = new Label();
            pnlElection = new Panel();
            lblEnoelections = new Label();
            dgvElections = new DataGridView();
            colElecTitle = new DataGridViewTextBoxColumn();
            colElecStatus = new DataGridViewTextBoxColumn();
            colElecStart = new DataGridViewTextBoxColumn();
            coldElecEnd = new DataGridViewTextBoxColumn();
            colEActions = new DataGridViewButtonColumn();
            OpenCreateForm = new Button();
            btnUpdate = new Button();
            label7 = new Label();
            label6 = new Label();
            pnlPositions = new Panel();
            dgvPositions = new DataGridView();
            colElection = new DataGridViewTextBoxColumn();
            btnEditPos = new DataGridViewButtonColumn();
            btnDeletePos = new DataGridViewButtonColumn();
            colPos = new DataGridViewTextBoxColumn();
            addPositionOpenForm = new Button();
            label10 = new Label();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            pnlMainContainer.SuspendLayout();
            pnlCandidate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCandidates).BeginInit();
            pnlVoters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVoters).BeginInit();
            panel1.SuspendLayout();
            pnlDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUpcomingElections).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            pnlElection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvElections).BeginInit();
            pnlPositions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPositions).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.header1;
            pictureBox1.Location = new Point(-1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1560, 115);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.Maroon;
            pnlSidebar.Controls.Add(label1);
            pnlSidebar.Controls.Add(pictureBox3);
            pnlSidebar.Controls.Add(LogOut);
            pnlSidebar.Controls.Add(ResultsButton);
            pnlSidebar.Controls.Add(ElectionButton);
            pnlSidebar.Controls.Add(CandidateButton);
            pnlSidebar.Controls.Add(PositionsButton);
            pnlSidebar.Controls.Add(VotersButton);
            pnlSidebar.Controls.Add(DashButton);
            pnlSidebar.Location = new Point(-1, 112);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(247, 710);
            pnlSidebar.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(34, 130);
            label1.Name = "label1";
            label1.Size = new Size(168, 25);
            label1.TabIndex = 24;
            label1.Text = "Welcome, Admin!";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.admin1;
            pictureBox3.Location = new Point(55, 9);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(125, 118);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 23;
            pictureBox3.TabStop = false;
            // 
            // LogOut
            // 
            LogOut.BackColor = Color.Maroon;
            LogOut.FlatAppearance.BorderSize = 0;
            LogOut.FlatStyle = FlatStyle.Flat;
            LogOut.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LogOut.ForeColor = Color.White;
            LogOut.ImageAlign = ContentAlignment.MiddleLeft;
            LogOut.ImageKey = "logout.png";
            LogOut.ImageList = imageList1;
            LogOut.Location = new Point(77, 623);
            LogOut.Name = "LogOut";
            LogOut.Padding = new Padding(10, 0, 0, 0);
            LogOut.Size = new Size(85, 56);
            LogOut.TabIndex = 22;
            LogOut.TextAlign = ContentAlignment.MiddleLeft;
            LogOut.TextImageRelation = TextImageRelation.ImageBeforeText;
            LogOut.UseVisualStyleBackColor = false;
            LogOut.Click += LogOut_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "votes.png");
            imageList1.Images.SetKeyName(1, "position.png");
            imageList1.Images.SetKeyName(2, "election.png");
            imageList1.Images.SetKeyName(3, "logout.png");
            imageList1.Images.SetKeyName(4, "results.png");
            imageList1.Images.SetKeyName(5, "candidate.png");
            imageList1.Images.SetKeyName(6, "voters.png");
            imageList1.Images.SetKeyName(7, "dashboard.png");
            imageList1.Images.SetKeyName(8, "import.png");
            imageList1.Images.SetKeyName(9, "delete.png");
            // 
            // ResultsButton
            // 
            ResultsButton.BackColor = Color.Maroon;
            ResultsButton.FlatAppearance.BorderSize = 0;
            ResultsButton.FlatStyle = FlatStyle.Flat;
            ResultsButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ResultsButton.ForeColor = Color.White;
            ResultsButton.ImageAlign = ContentAlignment.MiddleLeft;
            ResultsButton.ImageKey = "results.png";
            ResultsButton.ImageList = imageList1;
            ResultsButton.Location = new Point(-3, 477);
            ResultsButton.Name = "ResultsButton";
            ResultsButton.Padding = new Padding(10, 0, 0, 0);
            ResultsButton.Size = new Size(247, 54);
            ResultsButton.TabIndex = 21;
            ResultsButton.Text = "          Results";
            ResultsButton.TextAlign = ContentAlignment.MiddleLeft;
            ResultsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            ResultsButton.UseVisualStyleBackColor = false;
            ResultsButton.MouseEnter += ResultsButton_MouseHover;
            ResultsButton.MouseLeave += ResultsButton_MouseLeave;
            ResultsButton.MouseHover += ResultsButton_MouseHover;
            // 
            // ElectionButton
            // 
            ElectionButton.BackColor = Color.Maroon;
            ElectionButton.FlatAppearance.BorderSize = 0;
            ElectionButton.FlatStyle = FlatStyle.Flat;
            ElectionButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ElectionButton.ForeColor = Color.White;
            ElectionButton.ImageAlign = ContentAlignment.MiddleLeft;
            ElectionButton.ImageKey = "election.png";
            ElectionButton.ImageList = imageList1;
            ElectionButton.Location = new Point(-3, 229);
            ElectionButton.Name = "ElectionButton";
            ElectionButton.Padding = new Padding(10, 0, 0, 0);
            ElectionButton.Size = new Size(247, 56);
            ElectionButton.TabIndex = 19;
            ElectionButton.Text = "          Elections";
            ElectionButton.TextAlign = ContentAlignment.MiddleLeft;
            ElectionButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            ElectionButton.UseVisualStyleBackColor = false;
            ElectionButton.Click += ElectionButton_Click;
            ElectionButton.MouseEnter += ElectionButton_MouseHover;
            ElectionButton.MouseLeave += ElectionButton_MouseLeave;
            ElectionButton.MouseHover += ElectionButton_MouseHover;
            // 
            // CandidateButton
            // 
            CandidateButton.BackColor = Color.Maroon;
            CandidateButton.FlatAppearance.BorderSize = 0;
            CandidateButton.FlatStyle = FlatStyle.Flat;
            CandidateButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CandidateButton.ForeColor = Color.White;
            CandidateButton.ImageAlign = ContentAlignment.MiddleLeft;
            CandidateButton.ImageKey = "candidate.png";
            CandidateButton.ImageList = imageList1;
            CandidateButton.Location = new Point(0, 415);
            CandidateButton.Name = "CandidateButton";
            CandidateButton.Padding = new Padding(10, 0, 0, 0);
            CandidateButton.Size = new Size(247, 56);
            CandidateButton.TabIndex = 17;
            CandidateButton.Text = "          Candidates";
            CandidateButton.TextAlign = ContentAlignment.MiddleLeft;
            CandidateButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            CandidateButton.UseVisualStyleBackColor = false;
            CandidateButton.Click += CandidateButton_Click;
            CandidateButton.MouseEnter += CandidateButton_MouseHover;
            CandidateButton.MouseLeave += CandidateButton_MouseLeave;
            CandidateButton.MouseHover += CandidateButton_MouseHover;
            // 
            // PositionsButton
            // 
            PositionsButton.BackColor = Color.Maroon;
            PositionsButton.FlatAppearance.BorderSize = 0;
            PositionsButton.FlatStyle = FlatStyle.Flat;
            PositionsButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PositionsButton.ForeColor = Color.White;
            PositionsButton.ImageKey = "position.png";
            PositionsButton.ImageList = imageList1;
            PositionsButton.Location = new Point(0, 353);
            PositionsButton.Name = "PositionsButton";
            PositionsButton.Size = new Size(247, 56);
            PositionsButton.TabIndex = 15;
            PositionsButton.Text = "          Positions";
            PositionsButton.TextAlign = ContentAlignment.MiddleLeft;
            PositionsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            PositionsButton.UseVisualStyleBackColor = false;
            PositionsButton.Click += PositionsButton_Click;
            PositionsButton.MouseEnter += PositionsButton_MouseHover;
            PositionsButton.MouseLeave += PositionsButton_MouseLeave;
            PositionsButton.MouseHover += PositionsButton_MouseHover;
            // 
            // VotersButton
            // 
            VotersButton.BackColor = Color.Maroon;
            VotersButton.FlatAppearance.BorderSize = 0;
            VotersButton.FlatStyle = FlatStyle.Flat;
            VotersButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            VotersButton.ForeColor = Color.White;
            VotersButton.ImageAlign = ContentAlignment.MiddleLeft;
            VotersButton.ImageKey = "voters.png";
            VotersButton.ImageList = imageList1;
            VotersButton.Location = new Point(-6, 291);
            VotersButton.Name = "VotersButton";
            VotersButton.Padding = new Padding(10, 0, 0, 0);
            VotersButton.Size = new Size(250, 56);
            VotersButton.TabIndex = 13;
            VotersButton.Text = "           Voters";
            VotersButton.TextAlign = ContentAlignment.MiddleLeft;
            VotersButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            VotersButton.UseVisualStyleBackColor = false;
            VotersButton.Click += VotersButton_Click;
            VotersButton.MouseEnter += VotersButton_MouseHover;
            VotersButton.MouseLeave += VotersButton_MouseLeave;
            VotersButton.MouseHover += VotersButton_MouseHover;
            // 
            // DashButton
            // 
            DashButton.BackColor = Color.Maroon;
            DashButton.FlatAppearance.BorderSize = 0;
            DashButton.FlatStyle = FlatStyle.Flat;
            DashButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DashButton.ForeColor = Color.White;
            DashButton.ImageAlign = ContentAlignment.MiddleLeft;
            DashButton.ImageKey = "dashboard.png";
            DashButton.ImageList = imageList1;
            DashButton.Location = new Point(-3, 167);
            DashButton.Name = "DashButton";
            DashButton.Padding = new Padding(10, 0, 0, 0);
            DashButton.Size = new Size(247, 56);
            DashButton.TabIndex = 12;
            DashButton.Text = "          Dashboard";
            DashButton.TextAlign = ContentAlignment.MiddleLeft;
            DashButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            DashButton.UseVisualStyleBackColor = false;
            DashButton.Click += DashButton_Click;
            DashButton.MouseEnter += DashButton_MouseEnter;
            DashButton.MouseLeave += DashButton_MouseLeave;
            // 
            // pnlMainContainer
            // 
            pnlMainContainer.BackgroundImage = Properties.Resources.panelbackground;
            pnlMainContainer.Controls.Add(pnlElection);
            pnlMainContainer.Controls.Add(pnlPositions);
            pnlMainContainer.Controls.Add(pnlCandidate);
            pnlMainContainer.Controls.Add(pnlVoters);
            pnlMainContainer.Controls.Add(pnlDashboard);
            pnlMainContainer.Location = new Point(0, 0);
            pnlMainContainer.Margin = new Padding(0);
            pnlMainContainer.Name = "pnlMainContainer";
            pnlMainContainer.Size = new Size(1557, 818);
            pnlMainContainer.TabIndex = 3;
            pnlMainContainer.Paint += pnlMainContainer_Paint;
            // 
            // pnlCandidate
            // 
            pnlCandidate.BackgroundImage = Properties.Resources.panelbackground;
            pnlCandidate.Controls.Add(lblNoCandidates);
            pnlCandidate.Controls.Add(dgvCandidates);
            pnlCandidate.Controls.Add(btnAddCandidate);
            pnlCandidate.Controls.Add(label14);
            pnlCandidate.Controls.Add(label12);
            pnlCandidate.Location = new Point(245, 115);
            pnlCandidate.Name = "pnlCandidate";
            pnlCandidate.Size = new Size(1312, 703);
            pnlCandidate.TabIndex = 25;
            pnlCandidate.Paint += pnlCandidate_Paint;
            // 
            // lblNoCandidates
            // 
            lblNoCandidates.AutoSize = true;
            lblNoCandidates.BackColor = Color.Maroon;
            lblNoCandidates.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoCandidates.ForeColor = Color.Black;
            lblNoCandidates.Location = new Point(515, 294);
            lblNoCandidates.Name = "lblNoCandidates";
            lblNoCandidates.Size = new Size(219, 30);
            lblNoCandidates.TabIndex = 33;
            lblNoCandidates.Text = "No candidates found.";
            // 
            // dgvCandidates
            // 
            dgvCandidates.AllowUserToAddRows = false;
            dgvCandidates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCandidates.BackgroundColor = Color.Maroon;
            dgvCandidates.BorderStyle = BorderStyle.None;
            dgvCandidates.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = Color.Gold;
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = Color.Maroon;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            dgvCandidates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dgvCandidates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCandidates.Columns.AddRange(new DataGridViewColumn[] { colPhoto, colName, colCElection, colCPosition, colDescription, colActions });
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = SystemColors.Window;
            dataGridViewCellStyle13.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle13.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            dgvCandidates.DefaultCellStyle = dataGridViewCellStyle13;
            dgvCandidates.EnableHeadersVisualStyles = false;
            dgvCandidates.GridColor = Color.DarkGray;
            dgvCandidates.Location = new Point(31, 216);
            dgvCandidates.Name = "dgvCandidates";
            dgvCandidates.ReadOnly = true;
            dgvCandidates.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = SystemColors.Control;
            dataGridViewCellStyle14.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle14.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            dgvCandidates.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dgvCandidates.RowHeadersVisible = false;
            dgvCandidates.RowTemplate.Height = 80;
            dgvCandidates.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvCandidates.Size = new Size(1250, 150);
            dgvCandidates.TabIndex = 32;
            dgvCandidates.CellContentClick += dgvCandidates_CellContentClick;
            // 
            // colPhoto
            // 
            colPhoto.HeaderText = "Photo";
            colPhoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPhoto.Name = "colPhoto";
            colPhoto.ReadOnly = true;
            // 
            // colName
            // 
            colName.HeaderText = "Name";
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colCElection
            // 
            colCElection.HeaderText = "Election";
            colCElection.Name = "colCElection";
            colCElection.ReadOnly = true;
            // 
            // colCPosition
            // 
            colCPosition.HeaderText = "Position";
            colCPosition.Name = "colCPosition";
            colCPosition.ReadOnly = true;
            // 
            // colDescription
            // 
            colDescription.HeaderText = "Description";
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;
            // 
            // colActions
            // 
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.Padding = new Padding(5);
            colActions.DefaultCellStyle = dataGridViewCellStyle12;
            colActions.HeaderText = "Actions";
            colActions.Name = "colActions";
            colActions.ReadOnly = true;
            colActions.Text = "Edit   |   Delete";
            colActions.UseColumnTextForButtonValue = true;
            // 
            // btnAddCandidate
            // 
            btnAddCandidate.BackColor = Color.Maroon;
            btnAddCandidate.BackgroundImageLayout = ImageLayout.None;
            btnAddCandidate.FlatAppearance.BorderSize = 0;
            btnAddCandidate.FlatStyle = FlatStyle.Flat;
            btnAddCandidate.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCandidate.ForeColor = Color.White;
            btnAddCandidate.Location = new Point(33, 117);
            btnAddCandidate.Name = "btnAddCandidate";
            btnAddCandidate.Size = new Size(223, 66);
            btnAddCandidate.TabIndex = 28;
            btnAddCandidate.Text = "+ Add Candidate";
            btnAddCandidate.UseVisualStyleBackColor = false;
            btnAddCandidate.Click += btnAddCandidate_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.Maroon;
            label14.Location = new Point(33, 78);
            label14.Name = "label14";
            label14.Size = new Size(296, 25);
            label14.TabIndex = 27;
            label14.Text = "Manage candidate for elections.";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Maroon;
            label12.Location = new Point(20, 16);
            label12.Name = "label12";
            label12.Size = new Size(572, 65);
            label12.TabIndex = 26;
            label12.Text = "Candidate Management";
            // 
            // pnlVoters
            // 
            pnlVoters.BackgroundImage = Properties.Resources.panelbackground;
            pnlVoters.Controls.Add(lblVNoVoters);
            pnlVoters.Controls.Add(dgvVoters);
            pnlVoters.Controls.Add(deleteVoters);
            pnlVoters.Controls.Add(importVoters);
            pnlVoters.Controls.Add(panel1);
            pnlVoters.Controls.Add(label11);
            pnlVoters.Controls.Add(label8);
            pnlVoters.Location = new Point(245, 115);
            pnlVoters.Name = "pnlVoters";
            pnlVoters.Size = new Size(1312, 703);
            pnlVoters.TabIndex = 30;
            pnlVoters.Paint += pnlVoters_Paint;
            // 
            // lblVNoVoters
            // 
            lblVNoVoters.AutoSize = true;
            lblVNoVoters.BackColor = Color.Maroon;
            lblVNoVoters.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVNoVoters.ForeColor = Color.Black;
            lblVNoVoters.Location = new Point(517, 294);
            lblVNoVoters.Name = "lblVNoVoters";
            lblVNoVoters.Size = new Size(149, 30);
            lblVNoVoters.TabIndex = 32;
            lblVNoVoters.Text = "No voters yet.";
            // 
            // dgvVoters
            // 
            dgvVoters.AllowUserToAddRows = false;
            dgvVoters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVoters.BackgroundColor = Color.Maroon;
            dgvVoters.BorderStyle = BorderStyle.None;
            dgvVoters.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = Color.Gold;
            dataGridViewCellStyle15.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle15.ForeColor = Color.Maroon;
            dataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            dgvVoters.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            dgvVoters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVoters.Columns.AddRange(new DataGridViewColumn[] { colIDNumber, colFullName, colYear, colCourse, colVstatus, colVActions });
            dgvVoters.EnableHeadersVisualStyles = false;
            dgvVoters.GridColor = Color.DarkGray;
            dgvVoters.Location = new Point(31, 226);
            dgvVoters.Name = "dgvVoters";
            dgvVoters.ReadOnly = true;
            dgvVoters.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvVoters.RowHeadersVisible = false;
            dgvVoters.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVoters.Size = new Size(1250, 150);
            dgvVoters.TabIndex = 31;
            // 
            // colIDNumber
            // 
            colIDNumber.HeaderText = "I.D Number";
            colIDNumber.Name = "colIDNumber";
            colIDNumber.ReadOnly = true;
            // 
            // colFullName
            // 
            colFullName.HeaderText = "Full Name";
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            // 
            // colYear
            // 
            colYear.HeaderText = "Year";
            colYear.Name = "colYear";
            colYear.ReadOnly = true;
            // 
            // colCourse
            // 
            colCourse.HeaderText = "Course";
            colCourse.Name = "colCourse";
            colCourse.ReadOnly = true;
            // 
            // colVstatus
            // 
            colVstatus.HeaderText = "Status";
            colVstatus.Name = "colVstatus";
            colVstatus.ReadOnly = true;
            // 
            // colVActions
            // 
            colVActions.HeaderText = "Actions";
            colVActions.Name = "colVActions";
            colVActions.ReadOnly = true;
            colVActions.Text = "Edit | Delete";
            colVActions.UseColumnTextForButtonValue = true;
            // 
            // deleteVoters
            // 
            deleteVoters.BackColor = Color.Maroon;
            deleteVoters.BackgroundImageLayout = ImageLayout.None;
            deleteVoters.FlatAppearance.BorderSize = 0;
            deleteVoters.FlatStyle = FlatStyle.Flat;
            deleteVoters.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteVoters.ForeColor = Color.Black;
            deleteVoters.ImageKey = "delete.png";
            deleteVoters.ImageList = imageList2;
            deleteVoters.Location = new Point(232, 117);
            deleteVoters.Name = "deleteVoters";
            deleteVoters.Size = new Size(181, 53);
            deleteVoters.TabIndex = 29;
            deleteVoters.Text = "Delete All Voters";
            deleteVoters.TextAlign = ContentAlignment.MiddleLeft;
            deleteVoters.TextImageRelation = TextImageRelation.ImageBeforeText;
            deleteVoters.UseVisualStyleBackColor = false;
            deleteVoters.Click += deleteVoters_Click;
            // 
            // imageList2
            // 
            imageList2.ColorDepth = ColorDepth.Depth32Bit;
            imageList2.ImageStream = (ImageListStreamer)resources.GetObject("imageList2.ImageStream");
            imageList2.TransparentColor = Color.Transparent;
            imageList2.Images.SetKeyName(0, "delete.png");
            imageList2.Images.SetKeyName(1, "import.png");
            // 
            // importVoters
            // 
            importVoters.BackColor = SystemColors.Desktop;
            importVoters.BackgroundImageLayout = ImageLayout.None;
            importVoters.FlatAppearance.BorderSize = 0;
            importVoters.FlatStyle = FlatStyle.Flat;
            importVoters.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            importVoters.ForeColor = Color.Black;
            importVoters.ImageKey = "import.png";
            importVoters.ImageList = imageList2;
            importVoters.Location = new Point(44, 117);
            importVoters.Name = "importVoters";
            importVoters.Size = new Size(157, 53);
            importVoters.TabIndex = 28;
            importVoters.Text = "Import Voters";
            importVoters.TextAlign = ContentAlignment.MiddleLeft;
            importVoters.TextImageRelation = TextImageRelation.ImageBeforeText;
            importVoters.UseVisualStyleBackColor = false;
            importVoters.Click += importVoters_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(lblTotalVotersCount);
            panel1.Controls.Add(label13);
            panel1.Location = new Point(987, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(294, 130);
            panel1.TabIndex = 27;
            // 
            // lblTotalVotersCount
            // 
            lblTotalVotersCount.AutoSize = true;
            lblTotalVotersCount.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            lblTotalVotersCount.ForeColor = Color.Maroon;
            lblTotalVotersCount.Location = new Point(14, 58);
            lblTotalVotersCount.Name = "lblTotalVotersCount";
            lblTotalVotersCount.RightToLeft = RightToLeft.Yes;
            lblTotalVotersCount.Size = new Size(40, 47);
            lblTotalVotersCount.TabIndex = 26;
            lblTotalVotersCount.Text = "0";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Maroon;
            label13.Location = new Point(3, 9);
            label13.Name = "label13";
            label13.Size = new Size(171, 37);
            label13.TabIndex = 25;
            label13.Text = "Total Voters";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Maroon;
            label11.Location = new Point(31, 78);
            label11.Name = "label11";
            label11.Size = new Size(721, 25);
            label11.TabIndex = 25;
            label11.Text = "Manage and import voters from an Access file (I.D Number, Name, Year, Course)";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Maroon;
            label8.Location = new Point(20, 16);
            label8.Name = "label8";
            label8.Size = new Size(485, 65);
            label8.TabIndex = 26;
            label8.Text = "Voters Management";
            // 
            // pnlDashboard
            // 
            pnlDashboard.BackColor = Color.Transparent;
            pnlDashboard.Controls.Add(lblNoElections);
            pnlDashboard.Controls.Add(dgvUpcomingElections);
            pnlDashboard.Controls.Add(lblDashboard);
            pnlDashboard.Controls.Add(label5);
            pnlDashboard.Controls.Add(panel2);
            pnlDashboard.Controls.Add(panel3);
            pnlDashboard.Controls.Add(panel4);
            pnlDashboard.Location = new Point(245, 115);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(1312, 703);
            pnlDashboard.TabIndex = 29;
            pnlDashboard.Paint += pnlDashboard_Paint;
            // 
            // lblNoElections
            // 
            lblNoElections.AutoSize = true;
            lblNoElections.BackColor = Color.Maroon;
            lblNoElections.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoElections.ForeColor = Color.Black;
            lblNoElections.Location = new Point(517, 412);
            lblNoElections.Name = "lblNoElections";
            lblNoElections.Size = new Size(240, 30);
            lblNoElections.TabIndex = 29;
            lblNoElections.Text = "No upcoming elections.";
            // 
            // dgvUpcomingElections
            // 
            dgvUpcomingElections.AllowUserToAddRows = false;
            dgvUpcomingElections.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUpcomingElections.BackgroundColor = Color.Maroon;
            dgvUpcomingElections.BorderStyle = BorderStyle.None;
            dgvUpcomingElections.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = Color.Gold;
            dataGridViewCellStyle16.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle16.ForeColor = Color.Maroon;
            dataGridViewCellStyle16.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.True;
            dgvUpcomingElections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            dgvUpcomingElections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUpcomingElections.Columns.AddRange(new DataGridViewColumn[] { colTitle, colStatus, colStart, colEnd, colTotalVotes });
            dgvUpcomingElections.EnableHeadersVisualStyles = false;
            dgvUpcomingElections.GridColor = Color.DarkGray;
            dgvUpcomingElections.Location = new Point(44, 327);
            dgvUpcomingElections.Name = "dgvUpcomingElections";
            dgvUpcomingElections.ReadOnly = true;
            dgvUpcomingElections.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUpcomingElections.RowHeadersVisible = false;
            dgvUpcomingElections.Size = new Size(1219, 150);
            dgvUpcomingElections.TabIndex = 28;
            // 
            // colTitle
            // 
            colTitle.HeaderText = "Title";
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colStart
            // 
            dataGridViewCellStyle17.Format = "G";
            dataGridViewCellStyle17.NullValue = null;
            colStart.DefaultCellStyle = dataGridViewCellStyle17;
            colStart.HeaderText = "Start Date";
            colStart.Name = "colStart";
            colStart.ReadOnly = true;
            // 
            // colEnd
            // 
            dataGridViewCellStyle18.Format = "G";
            dataGridViewCellStyle18.NullValue = null;
            colEnd.DefaultCellStyle = dataGridViewCellStyle18;
            colEnd.HeaderText = "End Date";
            colEnd.Name = "colEnd";
            colEnd.ReadOnly = true;
            // 
            // colTotalVotes
            // 
            colTotalVotes.HeaderText = "Total Votes";
            colTotalVotes.Name = "colTotalVotes";
            colTotalVotes.ReadOnly = true;
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.Transparent;
            lblDashboard.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = Color.Maroon;
            lblDashboard.Location = new Point(20, 16);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(273, 65);
            lblDashboard.TabIndex = 25;
            lblDashboard.Text = "Dashboard";
            lblDashboard.Click += lblDashboard_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Maroon;
            label5.Location = new Point(20, 276);
            label5.Name = "label5";
            label5.Size = new Size(208, 30);
            label5.TabIndex = 27;
            label5.Text = "Upcoming Elections";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(totalVotersValue);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(70, 106);
            panel2.Name = "panel2";
            panel2.Size = new Size(294, 130);
            panel2.TabIndex = 26;
            // 
            // totalVotersValue
            // 
            totalVotersValue.AutoSize = true;
            totalVotersValue.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            totalVotersValue.ForeColor = Color.Maroon;
            totalVotersValue.Location = new Point(14, 58);
            totalVotersValue.Name = "totalVotersValue";
            totalVotersValue.RightToLeft = RightToLeft.Yes;
            totalVotersValue.Size = new Size(40, 47);
            totalVotersValue.TabIndex = 26;
            totalVotersValue.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(3, 9);
            label2.Name = "label2";
            label2.Size = new Size(171, 37);
            label2.TabIndex = 25;
            label2.Text = "Total Voters";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(activeElections);
            panel3.Controls.Add(label3);
            panel3.ForeColor = Color.Maroon;
            panel3.Location = new Point(463, 106);
            panel3.Name = "panel3";
            panel3.Size = new Size(294, 130);
            panel3.TabIndex = 27;
            // 
            // activeElections
            // 
            activeElections.AutoSize = true;
            activeElections.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            activeElections.ForeColor = Color.Maroon;
            activeElections.Location = new Point(17, 58);
            activeElections.Name = "activeElections";
            activeElections.RightToLeft = RightToLeft.Yes;
            activeElections.Size = new Size(40, 47);
            activeElections.TabIndex = 27;
            activeElections.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            label3.ForeColor = Color.Maroon;
            label3.Location = new Point(3, 9);
            label3.Name = "label3";
            label3.Size = new Size(219, 37);
            label3.TabIndex = 26;
            label3.Text = "Active Elections";
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Controls.Add(completedElection);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(866, 106);
            panel4.Name = "panel4";
            panel4.Size = new Size(294, 130);
            panel4.TabIndex = 27;
            // 
            // completedElection
            // 
            completedElection.AutoSize = true;
            completedElection.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            completedElection.ForeColor = Color.Maroon;
            completedElection.Location = new Point(17, 58);
            completedElection.Name = "completedElection";
            completedElection.RightToLeft = RightToLeft.Yes;
            completedElection.Size = new Size(40, 47);
            completedElection.TabIndex = 28;
            completedElection.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            label4.ForeColor = Color.Maroon;
            label4.Location = new Point(3, 9);
            label4.Name = "label4";
            label4.Size = new Size(268, 37);
            label4.TabIndex = 27;
            label4.Text = "Completed Election";
            // 
            // pnlElection
            // 
            pnlElection.BackColor = Color.Transparent;
            pnlElection.Controls.Add(lblEnoelections);
            pnlElection.Controls.Add(dgvElections);
            pnlElection.Controls.Add(OpenCreateForm);
            pnlElection.Controls.Add(btnUpdate);
            pnlElection.Controls.Add(label7);
            pnlElection.Controls.Add(label6);
            pnlElection.Location = new Point(245, 115);
            pnlElection.Name = "pnlElection";
            pnlElection.Size = new Size(1312, 703);
            pnlElection.TabIndex = 30;
            pnlElection.Paint += pnlElection_Paint;
            // 
            // lblEnoelections
            // 
            lblEnoelections.AutoSize = true;
            lblEnoelections.BackColor = Color.Maroon;
            lblEnoelections.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEnoelections.ForeColor = Color.Black;
            lblEnoelections.Location = new Point(515, 302);
            lblEnoelections.Name = "lblEnoelections";
            lblEnoelections.Size = new Size(173, 30);
            lblEnoelections.TabIndex = 30;
            lblEnoelections.Text = "No elections yet.";
            lblEnoelections.Click += lblEnoelections_Click;
            // 
            // dgvElections
            // 
            dgvElections.AllowUserToAddRows = false;
            dgvElections.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvElections.BackgroundColor = Color.Maroon;
            dgvElections.BorderStyle = BorderStyle.None;
            dgvElections.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = Color.Gold;
            dataGridViewCellStyle19.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle19.ForeColor = Color.Maroon;
            dataGridViewCellStyle19.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
            dgvElections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dgvElections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvElections.Columns.AddRange(new DataGridViewColumn[] { colElecTitle, colElecStatus, colElecStart, coldElecEnd, colEActions });
            dgvElections.EnableHeadersVisualStyles = false;
            dgvElections.GridColor = Color.DarkGray;
            dgvElections.Location = new Point(31, 216);
            dgvElections.Name = "dgvElections";
            dgvElections.ReadOnly = true;
            dgvElections.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvElections.RowHeadersVisible = false;
            dgvElections.Size = new Size(1250, 150);
            dgvElections.TabIndex = 29;
            dgvElections.CellContentClick += dgvElections_CellContentClick;
            dgvElections.CellPainting += dgvElections_CellPainting;
            // 
            // colElecTitle
            // 
            colElecTitle.HeaderText = "Title";
            colElecTitle.Name = "colElecTitle";
            colElecTitle.ReadOnly = true;
            // 
            // colElecStatus
            // 
            colElecStatus.HeaderText = "Status";
            colElecStatus.Name = "colElecStatus";
            colElecStatus.ReadOnly = true;
            // 
            // colElecStart
            // 
            colElecStart.HeaderText = "Start";
            colElecStart.Name = "colElecStart";
            colElecStart.ReadOnly = true;
            // 
            // coldElecEnd
            // 
            coldElecEnd.HeaderText = "End";
            coldElecEnd.Name = "coldElecEnd";
            coldElecEnd.ReadOnly = true;
            // 
            // colEActions
            // 
            colEActions.HeaderText = "Actions";
            colEActions.Name = "colEActions";
            colEActions.ReadOnly = true;
            colEActions.Text = "Edit | Delete";
            colEActions.UseColumnTextForButtonValue = true;
            // 
            // OpenCreateForm
            // 
            OpenCreateForm.BackColor = Color.Maroon;
            OpenCreateForm.BackgroundImageLayout = ImageLayout.None;
            OpenCreateForm.FlatAppearance.BorderSize = 0;
            OpenCreateForm.FlatStyle = FlatStyle.Flat;
            OpenCreateForm.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OpenCreateForm.ForeColor = Color.White;
            OpenCreateForm.Location = new Point(44, 117);
            OpenCreateForm.Name = "OpenCreateForm";
            OpenCreateForm.Size = new Size(223, 66);
            OpenCreateForm.TabIndex = 27;
            OpenCreateForm.Text = "+ Create Election";
            OpenCreateForm.UseVisualStyleBackColor = false;
            OpenCreateForm.Click += OpenCreateForm_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Maroon;
            btnUpdate.BackgroundImageLayout = ImageLayout.None;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(1058, 104);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(223, 66);
            btnUpdate.TabIndex = 31;
            btnUpdate.Text = "Update Election";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Maroon;
            label7.Location = new Point(31, 81);
            label7.Name = "label7";
            label7.Size = new Size(328, 25);
            label7.TabIndex = 25;
            label7.Text = "Manage and create elections below.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Maroon;
            label6.Location = new Point(20, 16);
            label6.Name = "label6";
            label6.Size = new Size(522, 65);
            label6.TabIndex = 26;
            label6.Text = "Election Management";
            // 
            // pnlPositions
            // 
            pnlPositions.BackgroundImage = Properties.Resources.panelbackground;
            pnlPositions.Controls.Add(dgvPositions);
            pnlPositions.Controls.Add(addPositionOpenForm);
            pnlPositions.Controls.Add(label10);
            pnlPositions.Controls.Add(label9);
            pnlPositions.Location = new Point(245, 115);
            pnlPositions.Name = "pnlPositions";
            pnlPositions.Size = new Size(1312, 703);
            pnlPositions.TabIndex = 31;
            pnlPositions.Paint += pnlPositions_Paint;
            // 
            // dgvPositions
            // 
            dgvPositions.AllowUserToAddRows = false;
            dgvPositions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPositions.BackgroundColor = Color.Maroon;
            dgvPositions.BorderStyle = BorderStyle.None;
            dgvPositions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPositions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = Color.Gold;
            dataGridViewCellStyle20.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle20.ForeColor = Color.Maroon;
            dataGridViewCellStyle20.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = DataGridViewTriState.True;
            dgvPositions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            dgvPositions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPositions.Columns.AddRange(new DataGridViewColumn[] { colElection, btnEditPos, btnDeletePos, colPos });
            dgvPositions.EnableHeadersVisualStyles = false;
            dgvPositions.GridColor = Color.DarkGray;
            dgvPositions.Location = new Point(31, 216);
            dgvPositions.Name = "dgvPositions";
            dgvPositions.ReadOnly = true;
            dgvPositions.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPositions.RowHeadersVisible = false;
            dgvPositions.RowTemplate.Height = 40;
            dgvPositions.RowTemplate.ReadOnly = true;
            dgvPositions.Size = new Size(1219, 105);
            dgvPositions.TabIndex = 30;
            dgvPositions.CellContentClick += dgvPositions_CellContentClick;
            // 
            // colElection
            // 
            colElection.FillWeight = 150F;
            colElection.HeaderText = "Election";
            colElection.Name = "colElection";
            colElection.ReadOnly = true;
            // 
            // btnEditPos
            // 
            btnEditPos.HeaderText = "";
            btnEditPos.Name = "btnEditPos";
            btnEditPos.ReadOnly = true;
            btnEditPos.UseColumnTextForButtonValue = true;
            // 
            // btnDeletePos
            // 
            btnDeletePos.HeaderText = "";
            btnDeletePos.Name = "btnDeletePos";
            btnDeletePos.ReadOnly = true;
            btnDeletePos.UseColumnTextForButtonValue = true;
            // 
            // colPos
            // 
            colPos.HeaderText = "Positions";
            colPos.Name = "colPos";
            colPos.ReadOnly = true;
            // 
            // addPositionOpenForm
            // 
            addPositionOpenForm.BackColor = Color.Maroon;
            addPositionOpenForm.BackgroundImageLayout = ImageLayout.None;
            addPositionOpenForm.FlatAppearance.BorderSize = 0;
            addPositionOpenForm.FlatStyle = FlatStyle.Flat;
            addPositionOpenForm.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addPositionOpenForm.ForeColor = Color.White;
            addPositionOpenForm.Location = new Point(44, 117);
            addPositionOpenForm.Name = "addPositionOpenForm";
            addPositionOpenForm.Size = new Size(223, 66);
            addPositionOpenForm.TabIndex = 28;
            addPositionOpenForm.Text = "+ Add Position";
            addPositionOpenForm.UseVisualStyleBackColor = false;
            addPositionOpenForm.Click += addPositionOpenForm_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Maroon;
            label10.Location = new Point(31, 81);
            label10.Name = "label10";
            label10.Size = new Size(715, 25);
            label10.TabIndex = 25;
            label10.Text = "Manage election positions (President, Vice President, etc.) grouped by election.";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Maroon;
            label9.Location = new Point(20, 16);
            label9.Name = "label9";
            label9.Size = new Size(525, 65);
            label9.TabIndex = 27;
            label9.Text = "Position Management";
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1557, 818);
            Controls.Add(pictureBox1);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlMainContainer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminDashboard";
            Load += AdminDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            pnlMainContainer.ResumeLayout(false);
            pnlCandidate.ResumeLayout(false);
            pnlCandidate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCandidates).EndInit();
            pnlVoters.ResumeLayout(false);
            pnlVoters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVoters).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlDashboard.ResumeLayout(false);
            pnlDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUpcomingElections).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            pnlElection.ResumeLayout(false);
            pnlElection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvElections).EndInit();
            pnlPositions.ResumeLayout(false);
            pnlPositions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPositions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel pnlSidebar;
        private Button VotersButton;
        private Button DashButton;
        private Button ResultsButton;
        private Button ElectionButton;
        private Button CandidateButton;
        private Button PositionsButton;
        private Button LogOut;
        private ImageList imageList1;
        private PictureBox pictureBox3;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel pnlMainContainer;
        private TabControl tabControl2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Label lblDashboard;
        private Panel panel4;
        private Label label4;
        private Panel panel3;
        private Label label3;
        private Panel panel2;
        private Label totalVotersValue;
        private Label label2;
        private Label completedElection;
        private Label activeElections;
        private Label label5;
        private DataGridView dgvUpcomingElections;
        private Panel pnlDashboard;
        private Label lblNoElections;
        private Panel pnlElection;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colStart;
        private DataGridViewTextBoxColumn colEnd;
        private DataGridViewTextBoxColumn colTotalVotes;
        private Label label7;
        private Label label6;
        private Button OpenCreateForm;
        private Label lblEnoelections;
        private DataGridView dgvElections;
        private Panel pnlPositions;
        private Label label10;
        private Label label9;
        private Button addPositionOpenForm;
        private DataGridView dgvPositions;
        private DataGridViewTextBoxColumn colElection;
        private DataGridViewTextBoxColumn colPos;
        private Button btnUpdate;
        private Panel pnlVoters;
        private Label label11;
        private Label label8;
        private Button importVoters;
        private Panel panel1;
        private Label lblTotalVotersCount;
        private Label label13;
        private Button deleteVoters;
        private ImageList imageList2;
        private Label lblVNoVoters;
        private DataGridView dgvVoters;
        private DataGridViewButtonColumn btnEditPos;
        private DataGridViewButtonColumn btnDeletePos;
        private Panel pnlCandidate;
        private Button btnAddCandidate;
        private Label label14;
        private Label label12;
        private DataGridView dgvCandidates;
        private Label lblNoCandidates;
        private DataGridViewTextBoxColumn colIDNumber;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colYear;
        private DataGridViewTextBoxColumn colCourse;
        private DataGridViewTextBoxColumn colVstatus;
        private DataGridViewButtonColumn colVActions;
        private DataGridViewTextBoxColumn colElecTitle;
        private DataGridViewTextBoxColumn colElecStatus;
        private DataGridViewTextBoxColumn colElecStart;
        private DataGridViewTextBoxColumn coldElecEnd;
        private DataGridViewButtonColumn colEActions;
        private DataGridViewImageColumn colPhoto;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colCElection;
        private DataGridViewTextBoxColumn colCPosition;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewButtonColumn colActions;
    }
}
namespace Final_Project_OOP2
{
    partial class VotingForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VotingForm));
            mainPanel = new Panel();
            btnLogout = new Button();
            btnProfile = new Button();
            btnDashboard = new Button();
            pictureBox1 = new PictureBox();
            pnlProfile = new Panel();
            label6 = new Label();
            panel1 = new Panel();
            lblCourse = new Label();
            lblYearLevel = new Label();
            lblProfileFullName = new Label();
            label5 = new Label();
            label4 = new Label();
            pictureBox4 = new PictureBox();
            label2 = new Label();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pnlVoterArea = new Panel();
            label8 = new Label();
            cmbPositions = new ComboBox();
            dgvCandidates = new DataGridView();
            colImage = new DataGridViewImageColumn();
            colName = new DataGridViewTextBoxColumn();
            colParty = new DataGridViewTextBoxColumn();
            colVote = new DataGridViewButtonColumn();
            label7 = new Label();
            label3 = new Label();
            lblElectionTitle = new Label();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlProfile.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pnlVoterArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCandidates).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.Maroon;
            mainPanel.Controls.Add(btnLogout);
            mainPanel.Controls.Add(btnProfile);
            mainPanel.Controls.Add(btnDashboard);
            mainPanel.Location = new Point(-2, 88);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1560, 81);
            mainPanel.TabIndex = 5;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Maroon;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1437, 9);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(120, 67);
            btnLogout.TabIndex = 41;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.Maroon;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(145, 9);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(120, 67);
            btnProfile.TabIndex = 40;
            btnProfile.Text = "Profile";
            btnProfile.UseVisualStyleBackColor = false;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.Maroon;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(15, 9);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(124, 67);
            btnDashboard.TabIndex = 40;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.header1;
            pictureBox1.Location = new Point(-2, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1560, 92);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pnlProfile
            // 
            pnlProfile.BackgroundImage = Properties.Resources.panelbackground;
            pnlProfile.Controls.Add(label6);
            pnlProfile.Controls.Add(panel1);
            pnlProfile.Location = new Point(-2, 170);
            pnlProfile.Name = "pnlProfile";
            pnlProfile.Size = new Size(1560, 650);
            pnlProfile.TabIndex = 33;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DimGray;
            label6.ImageAlign = ContentAlignment.TopCenter;
            label6.ImageKey = "profile.png";
            label6.Location = new Point(441, 596);
            label6.Name = "label6";
            label6.Size = new Size(656, 30);
            label6.TabIndex = 36;
            label6.Text = "Need to Update your information? Contact your school administrator.";
            label6.TextAlign = ContentAlignment.BottomCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(lblCourse);
            panel1.Controls.Add(lblYearLevel);
            panel1.Controls.Add(lblProfileFullName);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(160, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1238, 593);
            panel1.TabIndex = 37;
            // 
            // lblCourse
            // 
            lblCourse.BackColor = Color.Transparent;
            lblCourse.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCourse.ForeColor = Color.Black;
            lblCourse.ImageAlign = ContentAlignment.TopCenter;
            lblCourse.ImageKey = "profile.png";
            lblCourse.Location = new Point(435, 450);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(339, 37);
            lblCourse.TabIndex = 35;
            lblCourse.Text = "TEST";
            lblCourse.TextAlign = ContentAlignment.BottomCenter;
            // 
            // lblYearLevel
            // 
            lblYearLevel.BackColor = Color.Transparent;
            lblYearLevel.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblYearLevel.ForeColor = Color.Black;
            lblYearLevel.ImageAlign = ContentAlignment.TopCenter;
            lblYearLevel.ImageKey = "profile.png";
            lblYearLevel.Location = new Point(435, 283);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(339, 37);
            lblYearLevel.TabIndex = 35;
            lblYearLevel.Text = "TEST";
            lblYearLevel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // lblProfileFullName
            // 
            lblProfileFullName.BackColor = Color.Transparent;
            lblProfileFullName.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfileFullName.ForeColor = Color.Black;
            lblProfileFullName.ImageAlign = ContentAlignment.TopCenter;
            lblProfileFullName.ImageKey = "profile.png";
            lblProfileFullName.Location = new Point(435, 153);
            lblProfileFullName.Name = "lblProfileFullName";
            lblProfileFullName.Size = new Size(339, 37);
            lblProfileFullName.TabIndex = 35;
            lblProfileFullName.Text = "TEST";
            lblProfileFullName.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DimGray;
            label5.ImageAlign = ContentAlignment.TopCenter;
            label5.ImageKey = "profile.png";
            label5.Location = new Point(552, 420);
            label5.Name = "label5";
            label5.Size = new Size(107, 30);
            label5.TabIndex = 33;
            label5.Text = "Program";
            label5.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DimGray;
            label4.ImageAlign = ContentAlignment.TopCenter;
            label4.ImageKey = "profile.png";
            label4.Location = new Point(550, 253);
            label4.Name = "label4";
            label4.Size = new Size(107, 30);
            label4.TabIndex = 33;
            label4.Text = "Year Level";
            label4.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.BackgroundImage = Properties.Resources.profile;
            pictureBox4.Image = Properties.Resources.folders;
            pictureBox4.Location = new Point(552, 352);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(107, 80);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 34;
            pictureBox4.TabStop = false;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DimGray;
            label2.ImageAlign = ContentAlignment.TopCenter;
            label2.ImageKey = "profile.png";
            label2.Location = new Point(552, 123);
            label2.Name = "label2";
            label2.Size = new Size(107, 30);
            label2.TabIndex = 33;
            label2.Text = "Full Name";
            label2.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImage = Properties.Resources.profile;
            pictureBox3.Image = Properties.Resources.graduationcap;
            pictureBox3.Location = new Point(552, 193);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(107, 80);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 34;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Maroon;
            label1.Location = new Point(3, 2);
            label1.Name = "label1";
            label1.Size = new Size(1235, 65);
            label1.TabIndex = 32;
            label1.Text = "STUDENT INFORMATION";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = Properties.Resources.profile;
            pictureBox2.Image = Properties.Resources.profile;
            pictureBox2.Location = new Point(552, 58);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(107, 80);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 34;
            pictureBox2.TabStop = false;
            // 
            // pnlVoterArea
            // 
            pnlVoterArea.AutoScroll = true;
            pnlVoterArea.BackgroundImage = Properties.Resources.panelbackground;
            pnlVoterArea.Controls.Add(label8);
            pnlVoterArea.Controls.Add(cmbPositions);
            pnlVoterArea.Controls.Add(dgvCandidates);
            pnlVoterArea.Controls.Add(label7);
            pnlVoterArea.Controls.Add(label3);
            pnlVoterArea.Controls.Add(lblElectionTitle);
            pnlVoterArea.Location = new Point(-2, 170);
            pnlVoterArea.Name = "pnlVoterArea";
            pnlVoterArea.Padding = new Padding(10);
            pnlVoterArea.Size = new Size(1560, 650);
            pnlVoterArea.TabIndex = 38;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Maroon;
            label8.Location = new Point(25, 123);
            label8.Name = "label8";
            label8.Size = new Size(225, 25);
            label8.TabIndex = 39;
            label8.Text = "Select a position to vote";
            // 
            // cmbPositions
            // 
            cmbPositions.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbPositions.FormattingEnabled = true;
            cmbPositions.Location = new Point(25, 153);
            cmbPositions.Name = "cmbPositions";
            cmbPositions.Size = new Size(329, 33);
            cmbPositions.TabIndex = 38;
            cmbPositions.SelectedIndexChanged += cmbPositions_SelectedIndexChanged_1;
            // 
            // dgvCandidates
            // 
            dgvCandidates.AllowUserToAddRows = false;
            dgvCandidates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCandidates.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCandidates.BackgroundColor = Color.Maroon;
            dgvCandidates.BorderStyle = BorderStyle.None;
            dgvCandidates.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCandidates.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Gold;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Maroon;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCandidates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCandidates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCandidates.Columns.AddRange(new DataGridViewColumn[] { colImage, colName, colParty, colVote });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvCandidates.DefaultCellStyle = dataGridViewCellStyle4;
            dgvCandidates.EnableHeadersVisualStyles = false;
            dgvCandidates.GridColor = Color.DarkGray;
            dgvCandidates.Location = new Point(25, 193);
            dgvCandidates.Name = "dgvCandidates";
            dgvCandidates.ReadOnly = true;
            dgvCandidates.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCandidates.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgvCandidates.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvCandidates.RowTemplate.Height = 50;
            dgvCandidates.RowTemplate.ReadOnly = true;
            dgvCandidates.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvCandidates.Size = new Size(1511, 433);
            dgvCandidates.TabIndex = 37;
            dgvCandidates.CellContentClick += dgvCandidates_CellContentClick;
            // 
            // colImage
            // 
            colImage.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colImage.Frozen = true;
            colImage.HeaderText = "Photo";
            colImage.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colImage.Name = "colImage";
            colImage.ReadOnly = true;
            colImage.Width = 370;
            // 
            // colName
            // 
            colName.DataPropertyName = "FullName";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colName.DefaultCellStyle = dataGridViewCellStyle2;
            colName.HeaderText = "Candidate Name";
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colParty
            // 
            colParty.DataPropertyName = "Description";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colParty.DefaultCellStyle = dataGridViewCellStyle3;
            colParty.HeaderText = "Party";
            colParty.Name = "colParty";
            colParty.ReadOnly = true;
            // 
            // colVote
            // 
            colVote.HeaderText = "Action";
            colVote.Name = "colVote";
            colVote.ReadOnly = true;
            colVote.Text = "VOTE";
            colVote.UseColumnTextForButtonValue = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.Location = new Point(741, 117);
            label7.Name = "label7";
            label7.Size = new Size(100, 21);
            label7.TabIndex = 36;
            label7.Text = "Vote Wisely!";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(583, 86);
            label3.Name = "label3";
            label3.Size = new Size(400, 25);
            label3.TabIndex = 35;
            label3.Text = "Please select one candidate for each position.";
            // 
            // lblElectionTitle
            // 
            lblElectionTitle.BackColor = Color.Maroon;
            lblElectionTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblElectionTitle.ForeColor = Color.White;
            lblElectionTitle.Location = new Point(176, 10);
            lblElectionTitle.Name = "lblElectionTitle";
            lblElectionTitle.Size = new Size(1238, 65);
            lblElectionTitle.TabIndex = 34;
            lblElectionTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VotingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1557, 818);
            Controls.Add(mainPanel);
            Controls.Add(pictureBox1);
            Controls.Add(pnlProfile);
            Controls.Add(pnlVoterArea);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "VotingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VotingForm";
            Load += VotingForm_Load;
            mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlProfile.ResumeLayout(false);
            pnlProfile.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnlVoterArea.ResumeLayout(false);
            pnlVoterArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCandidates).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Button btnLogout;
        private Button btnProfile;
        private Button btnDashboard;
        private PictureBox pictureBox1;
        private Panel pnlProfile;
        private Label label6;
        private Panel panel1;
        private Label lblCourse;
        private Label lblYearLevel;
        private Label lblProfileFullName;
        private Label label5;
        private Label label4;
        private PictureBox pictureBox4;
        private Label label2;
        private PictureBox pictureBox3;
        private Label label1;
        private PictureBox pictureBox2;
        private Panel pnlVoterArea;
        private Label label7;
        private Label label3;
        private Label lblElectionTitle;
        private ComboBox cmbPositions;
        private DataGridView dgvCandidates;
        private Label label8;
        private DataGridViewImageColumn colImage;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colParty;
        private DataGridViewButtonColumn colVote;
    }
}
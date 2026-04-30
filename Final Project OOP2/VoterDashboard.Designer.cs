namespace Final_Project_OOP2
{
    partial class VoterDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoterDashboard));
            pictureBox1 = new PictureBox();
            mainPanel = new Panel();
            btnLogout = new Button();
            btnProfile = new Button();
            btnDashboard = new Button();
            pnlDashboard = new Panel();
            panel2 = new Panel();
            btnVoteNow = new Button();
            lblEndDate = new Label();
            lblStartDate = new Label();
            label3 = new Label();
            lblActiveElections = new Label();
            lblWelcome = new Label();
            pnlElectionCard = new Panel();
            lblElectionTitle = new Label();
            pnlTimeContainer = new Panel();
            lblTimeRemaining = new Label();
            label232 = new Label();
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
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            mainPanel.SuspendLayout();
            pnlDashboard.SuspendLayout();
            panel2.SuspendLayout();
            pnlElectionCard.SuspendLayout();
            pnlTimeContainer.SuspendLayout();
            pnlProfile.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.header1;
            pictureBox1.Location = new Point(-3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1560, 92);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.Maroon;
            mainPanel.Controls.Add(btnLogout);
            mainPanel.Controls.Add(btnProfile);
            mainPanel.Controls.Add(btnDashboard);
            mainPanel.Location = new Point(-3, 89);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1560, 81);
            mainPanel.TabIndex = 2;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Maroon;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1428, 9);
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
            // pnlDashboard
            // 
            pnlDashboard.BackgroundImage = Properties.Resources.panelbackground;
            pnlDashboard.Controls.Add(panel2);
            pnlDashboard.Location = new Point(-3, 171);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(1560, 650);
            pnlDashboard.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(btnVoteNow);
            panel2.Controls.Add(lblEndDate);
            panel2.Controls.Add(lblStartDate);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lblActiveElections);
            panel2.Controls.Add(lblWelcome);
            panel2.Controls.Add(pnlElectionCard);
            panel2.Controls.Add(pnlTimeContainer);
            panel2.ImeMode = ImeMode.On;
            panel2.Location = new Point(160, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1238, 593);
            panel2.TabIndex = 31;
            // 
            // btnVoteNow
            // 
            btnVoteNow.BackColor = Color.Maroon;
            btnVoteNow.FlatAppearance.BorderSize = 0;
            btnVoteNow.FlatStyle = FlatStyle.Flat;
            btnVoteNow.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVoteNow.ForeColor = Color.White;
            btnVoteNow.Location = new Point(504, 453);
            btnVoteNow.Name = "btnVoteNow";
            btnVoteNow.Size = new Size(239, 69);
            btnVoteNow.TabIndex = 39;
            btnVoteNow.Text = "Vote Now!";
            btnVoteNow.UseVisualStyleBackColor = false;
            btnVoteNow.Click += btnVoteNow_Click;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.BackColor = Color.Transparent;
            lblEndDate.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndDate.ForeColor = Color.Black;
            lblEndDate.Location = new Point(461, 249);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(56, 30);
            lblEndDate.TabIndex = 35;
            lblEndDate.Text = "End:";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.BackColor = Color.Transparent;
            lblStartDate.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStartDate.ForeColor = Color.Black;
            lblStartDate.Location = new Point(461, 219);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(66, 30);
            lblStartDate.TabIndex = 35;
            lblStartDate.Text = "Start:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(51, 189);
            label3.Name = "label3";
            label3.Size = new Size(1156, 30);
            label3.TabIndex = 34;
            label3.Text = "Your vote is your voice — make it count! Support leaders who reflect your values and vision for a better community.";
            // 
            // lblActiveElections
            // 
            lblActiveElections.BackColor = Color.Transparent;
            lblActiveElections.Font = new Font("Segoe UI Semibold", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActiveElections.ForeColor = Color.Black;
            lblActiveElections.Location = new Point(51, 67);
            lblActiveElections.Name = "lblActiveElections";
            lblActiveElections.Size = new Size(1144, 47);
            lblActiveElections.TabIndex = 32;
            lblActiveElections.Text = "Active Elections";
            lblActiveElections.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.Maroon;
            lblWelcome.Location = new Point(0, 2);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(1238, 65);
            lblWelcome.TabIndex = 31;
            lblWelcome.Text = "TEST";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlElectionCard
            // 
            pnlElectionCard.BackColor = Color.Maroon;
            pnlElectionCard.Controls.Add(lblElectionTitle);
            pnlElectionCard.Location = new Point(51, 114);
            pnlElectionCard.Name = "pnlElectionCard";
            pnlElectionCard.Size = new Size(1144, 65);
            pnlElectionCard.TabIndex = 37;
            // 
            // lblElectionTitle
            // 
            lblElectionTitle.BackColor = Color.Maroon;
            lblElectionTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblElectionTitle.ForeColor = Color.White;
            lblElectionTitle.Location = new Point(-51, 0);
            lblElectionTitle.Name = "lblElectionTitle";
            lblElectionTitle.Size = new Size(1238, 65);
            lblElectionTitle.TabIndex = 33;
            lblElectionTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTimeContainer
            // 
            pnlTimeContainer.BackColor = Color.LightCoral;
            pnlTimeContainer.Controls.Add(lblTimeRemaining);
            pnlTimeContainer.Controls.Add(label232);
            pnlTimeContainer.Location = new Point(51, 282);
            pnlTimeContainer.Name = "pnlTimeContainer";
            pnlTimeContainer.Size = new Size(1144, 65);
            pnlTimeContainer.TabIndex = 38;
            // 
            // lblTimeRemaining
            // 
            lblTimeRemaining.AutoSize = true;
            lblTimeRemaining.BackColor = Color.LightCoral;
            lblTimeRemaining.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimeRemaining.ForeColor = Color.Maroon;
            lblTimeRemaining.Location = new Point(501, 17);
            lblTimeRemaining.Name = "lblTimeRemaining";
            lblTimeRemaining.Size = new Size(0, 30);
            lblTimeRemaining.TabIndex = 36;
            lblTimeRemaining.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label232
            // 
            label232.AutoSize = true;
            label232.BackColor = Color.LightCoral;
            label232.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label232.ForeColor = Color.Maroon;
            label232.Location = new Point(327, 17);
            label232.Name = "label232";
            label232.Size = new Size(178, 30);
            label232.TabIndex = 36;
            label232.Text = "Time Remaining:";
            label232.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlProfile
            // 
            pnlProfile.BackgroundImage = Properties.Resources.panelbackground;
            pnlProfile.Controls.Add(label6);
            pnlProfile.Controls.Add(panel1);
            pnlProfile.Location = new Point(-3, 171);
            pnlProfile.Name = "pnlProfile";
            pnlProfile.Size = new Size(1560, 650);
            pnlProfile.TabIndex = 32;
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
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // VoterDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.panelbackground;
            ClientSize = new Size(1557, 818);
            Controls.Add(mainPanel);
            Controls.Add(pictureBox1);
            Controls.Add(pnlDashboard);
            Controls.Add(pnlProfile);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "VoterDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VoterDashboard";
            Load += VoterDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            mainPanel.ResumeLayout(false);
            pnlDashboard.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlElectionCard.ResumeLayout(false);
            pnlTimeContainer.ResumeLayout(false);
            pnlTimeContainer.PerformLayout();
            pnlProfile.ResumeLayout(false);
            pnlProfile.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel mainPanel;
        private Panel pnlDashboard;
        private Button btnProfile;
        private Button btnDashboard;
        private Button btnLogout;
        private Panel pnlProfile;
        private Label label1;
        private Label label2;
        private Label lblYearLevel;
        private Label lblProfileFullName;
        private Label label4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Label label6;
        private Label lblCourse;
        private Label label5;
        private PictureBox pictureBox4;
        private Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private Panel panel2;
        private Button btnVoteNow;
        private Label lblEndDate;
        private Label lblStartDate;
        private Label label3;
        private Label lblActiveElections;
        private Label lblWelcome;
        private Panel pnlElectionCard;
        private Label lblElectionTitle;
        private Panel pnlTimeContainer;
        private Label lblTimeRemaining;
        private Label label232;
    }
}
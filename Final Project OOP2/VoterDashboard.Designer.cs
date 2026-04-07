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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoterDashboard));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panelVoters = new Panel();
            label1 = new Label();
            pictureBox3 = new PictureBox();
            LogOut = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelVoters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.header1;
            pictureBox1.Location = new Point(-3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1560, 115);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.wmremove_transformed;
            pictureBox2.Location = new Point(-3, 113);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1560, 701);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // panelVoters
            // 
            panelVoters.BackColor = Color.Maroon;
            panelVoters.Controls.Add(label1);
            panelVoters.Controls.Add(pictureBox3);
            panelVoters.Controls.Add(LogOut);
            panelVoters.Location = new Point(-3, 113);
            panelVoters.Name = "panelVoters";
            panelVoters.Size = new Size(247, 710);
            panelVoters.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(41, 130);
            label1.Name = "label1";
            label1.Size = new Size(158, 25);
            label1.TabIndex = 24;
            label1.Text = "Welcome, Voter!";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.votersprofile1;
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
            LogOut.Location = new Point(77, 623);
            LogOut.Name = "LogOut";
            LogOut.Padding = new Padding(10, 0, 0, 0);
            LogOut.Size = new Size(85, 56);
            LogOut.TabIndex = 22;
            LogOut.TextAlign = ContentAlignment.MiddleLeft;
            LogOut.TextImageRelation = TextImageRelation.ImageBeforeText;
            LogOut.UseVisualStyleBackColor = false;
            // 
            // VoterDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1557, 818);
            Controls.Add(panelVoters);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "VoterDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VoterDashboard";
            Load += VoterDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelVoters.ResumeLayout(false);
            panelVoters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panelVoters;
        private Label label1;
        private PictureBox pictureBox3;
        private Button LogOut;
    }
}
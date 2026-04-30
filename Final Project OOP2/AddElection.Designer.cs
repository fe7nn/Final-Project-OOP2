namespace Final_Project_OOP2
{
    partial class AddElection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddElection));
            panel1 = new Panel();
            button1 = new Button();
            Create = new Button();
            dtpEndDate = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            label9 = new Label();
            dtpStartDate = new DateTimePicker();
            label7 = new Label();
            label8 = new Label();
            label6 = new Label();
            txtElectionTitle = new TextBox();
            label5 = new Label();
            panel2 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.panelbackground;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(Create);
            panel1.Controls.Add(dtpEndDate);
            panel1.Controls.Add(dtpEndTime);
            panel1.Controls.Add(dtpStartTime);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(dtpStartDate);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtElectionTitle);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(638, 599);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonShadow;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(297, 523);
            button1.Name = "button1";
            button1.Size = new Size(117, 54);
            button1.TabIndex = 29;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Create
            // 
            Create.BackColor = Color.Maroon;
            Create.BackgroundImageLayout = ImageLayout.None;
            Create.FlatAppearance.BorderSize = 0;
            Create.FlatStyle = FlatStyle.Flat;
            Create.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Create.ForeColor = Color.White;
            Create.Location = new Point(440, 523);
            Create.Name = "Create";
            Create.Size = new Size(171, 54);
            Create.TabIndex = 28;
            Create.Text = "+ Create Election";
            Create.UseVisualStyleBackColor = false;
            Create.Click += Create_Click;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(24, 459);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(200, 29);
            dtpEndDate.TabIndex = 6;
            // 
            // dtpEndTime
            // 
            dtpEndTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(401, 459);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(200, 29);
            dtpEndTime.TabIndex = 6;
            // 
            // dtpStartTime
            // 
            dtpStartTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.Location = new Point(401, 359);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(200, 29);
            dtpStartTime.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Maroon;
            label9.Location = new Point(382, 420);
            label9.Name = "label9";
            label9.Size = new Size(99, 25);
            label9.TabIndex = 5;
            label9.Text = "End Time:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(24, 359);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 29);
            dtpStartDate.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Maroon;
            label7.Location = new Point(382, 320);
            label7.Name = "label7";
            label7.Size = new Size(109, 25);
            label7.TabIndex = 5;
            label7.Text = "Start Time:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Maroon;
            label8.Location = new Point(12, 420);
            label8.Name = "label8";
            label8.Size = new Size(97, 25);
            label8.TabIndex = 5;
            label8.Text = "End Date:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Maroon;
            label6.Location = new Point(12, 320);
            label6.Name = "label6";
            label6.Size = new Size(107, 25);
            label6.TabIndex = 5;
            label6.Text = "Start Date:";
            // 
            // txtElectionTitle
            // 
            txtElectionTitle.BorderStyle = BorderStyle.FixedSingle;
            txtElectionTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtElectionTitle.Location = new Point(24, 265);
            txtElectionTitle.Name = "txtElectionTitle";
            txtElectionTitle.Size = new Size(238, 33);
            txtElectionTitle.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Maroon;
            label5.Location = new Point(12, 230);
            label5.Name = "label5";
            label5.Size = new Size(169, 32);
            label5.TabIndex = 3;
            label5.Text = "Election Title:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Moccasin;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(38, 34);
            panel2.Name = "panel2";
            panel2.Size = new Size(525, 171);
            panel2.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.DimGray;
            label4.Location = new Point(31, 115);
            label4.Name = "label4";
            label4.Size = new Size(422, 21);
            label4.TabIndex = 2;
            label4.Text = "• Ensure the election duration is correct before saving.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(31, 85);
            label3.Name = "label3";
            label3.Size = new Size(398, 21);
            label3.TabIndex = 2;
            label3.Text = "• End Date/Time must be after the Start Date/Time.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(31, 55);
            label2.Name = "label2";
            label2.Size = new Size(310, 21);
            label2.TabIndex = 1;
            label2.Text = "• Start Date/Time must be in the future.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Maroon;
            label1.Location = new Point(13, 14);
            label1.Name = "label1";
            label1.Size = new Size(88, 32);
            label1.TabIndex = 0;
            label1.Text = "Guide:";
            // 
            // AddElection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(638, 599);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddElection";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Election";
            Load += AddElection_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpStartDate;
        private Label label7;
        private Label label8;
        private Label label6;
        private TextBox txtElectionTitle;
        private Label label5;
        private DateTimePicker dtpEndTime;
        private Label label9;
        private Button button1;
        private Button Create;
    }
}
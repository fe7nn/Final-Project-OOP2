namespace Final_Project_OOP2
{
    partial class AddCandidate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCandidate));
            panel1 = new Panel();
            cmbPosition = new ComboBox();
            cmbElectionTitle = new ComboBox();
            btnCancel = new Button();
            btnSaveCandidate = new Button();
            imageList1 = new ImageList(components);
            txtDescription = new RichTextBox();
            btnChooseFile = new Button();
            txtName = new TextBox();
            lblFileName = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.panelbackground;
            panel1.Controls.Add(cmbPosition);
            panel1.Controls.Add(cmbElectionTitle);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnSaveCandidate);
            panel1.Controls.Add(txtDescription);
            panel1.Controls.Add(btnChooseFile);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(lblFileName);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(480, 667);
            panel1.TabIndex = 0;
            // 
            // cmbPosition
            // 
            cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.FlatStyle = FlatStyle.Flat;
            cmbPosition.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Location = new Point(23, 135);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(430, 33);
            cmbPosition.TabIndex = 35;
            cmbPosition.SelectedIndexChanged += cmbPosition_SelectedIndexChanged;
            // 
            // cmbElectionTitle
            // 
            cmbElectionTitle.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbElectionTitle.FlatStyle = FlatStyle.Flat;
            cmbElectionTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbElectionTitle.FormattingEnabled = true;
            cmbElectionTitle.Location = new Point(23, 54);
            cmbElectionTitle.Name = "cmbElectionTitle";
            cmbElectionTitle.Size = new Size(430, 33);
            cmbElectionTitle.TabIndex = 35;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ButtonShadow;
            btnCancel.BackgroundImageLayout = ImageLayout.None;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(18, 576);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(117, 54);
            btnCancel.TabIndex = 34;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSaveCandidate
            // 
            btnSaveCandidate.BackColor = Color.Maroon;
            btnSaveCandidate.BackgroundImageLayout = ImageLayout.None;
            btnSaveCandidate.FlatAppearance.BorderSize = 0;
            btnSaveCandidate.FlatStyle = FlatStyle.Flat;
            btnSaveCandidate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveCandidate.ForeColor = Color.White;
            btnSaveCandidate.ImageAlign = ContentAlignment.MiddleLeft;
            btnSaveCandidate.ImageKey = "import.png";
            btnSaveCandidate.ImageList = imageList1;
            btnSaveCandidate.Location = new Point(237, 576);
            btnSaveCandidate.Name = "btnSaveCandidate";
            btnSaveCandidate.Size = new Size(216, 54);
            btnSaveCandidate.TabIndex = 33;
            btnSaveCandidate.Text = "   Add Candidate";
            btnSaveCandidate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSaveCandidate.UseVisualStyleBackColor = false;
            btnSaveCandidate.Click += btnSaveCandidate_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "import.png");
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(23, 307);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(430, 96);
            txtDescription.TabIndex = 32;
            txtDescription.Text = "";
            // 
            // btnChooseFile
            // 
            btnChooseFile.BackColor = Color.Maroon;
            btnChooseFile.BackgroundImageLayout = ImageLayout.None;
            btnChooseFile.FlatAppearance.BorderSize = 0;
            btnChooseFile.FlatStyle = FlatStyle.Flat;
            btnChooseFile.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChooseFile.ForeColor = Color.White;
            btnChooseFile.Location = new Point(18, 459);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(124, 35);
            btnChooseFile.TabIndex = 31;
            btnChooseFile.Text = "Choose File";
            btnChooseFile.UseVisualStyleBackColor = false;
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(23, 224);
            txtName.Name = "txtName";
            txtName.Size = new Size(430, 33);
            txtName.TabIndex = 7;
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.BackColor = Color.Transparent;
            lblFileName.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFileName.ForeColor = Color.Maroon;
            lblFileName.Location = new Point(15, 497);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(150, 25);
            lblFileName.TabIndex = 4;
            lblFileName.Text = "No file choosen";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Maroon;
            label4.Location = new Point(12, 424);
            label4.Name = "label4";
            label4.Size = new Size(82, 32);
            label4.TabIndex = 4;
            label4.Text = "Photo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Maroon;
            label3.Location = new Point(12, 272);
            label3.Name = "label3";
            label3.Size = new Size(153, 32);
            label3.TabIndex = 4;
            label3.Text = "Description:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(12, 189);
            label2.Name = "label2";
            label2.Size = new Size(210, 32);
            label2.TabIndex = 4;
            label2.Text = "Candidate Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Maroon;
            label1.Location = new Point(12, 100);
            label1.Name = "label1";
            label1.Size = new Size(114, 32);
            label1.TabIndex = 4;
            label1.Text = "Position:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Maroon;
            label5.Location = new Point(12, 19);
            label5.Name = "label5";
            label5.Size = new Size(169, 32);
            label5.TabIndex = 4;
            label5.Text = "Election Title:";
            // 
            // AddCandidate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 667);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddCandidate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Candidate";
            Load += AddCandidate_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label5;
        private Label label1;
        private Label label2;
        private TextBox cmbStudent;
        private Label label3;
        private Button btnChooseFile;
        private RichTextBox txtDescription;
        private Label lblFileName;
        private Label label4;
        private Button btnCancel;
        private Button btnSaveCandidate;
        private ImageList imageList1;
        private ComboBox cmbElectionTitl;
        private ComboBox cmbPosition;
        private ComboBox cmbElectionTitle;
        private TextBox txtName;
    }
}
namespace Final_Project_OOP2
{
    partial class AddPosition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPosition));
            panel1 = new Panel();
            button1 = new Button();
            txtPositionName = new TextBox();
            PoistionCreate = new Button();
            cmbOrgList = new ComboBox();
            cmbElectionTitle = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.panelbackground;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(txtPositionName);
            panel1.Controls.Add(PoistionCreate);
            panel1.Controls.Add(cmbOrgList);
            panel1.Controls.Add(cmbElectionTitle);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(408, 408);
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
            button1.Location = new Point(82, 342);
            button1.Name = "button1";
            button1.Size = new Size(117, 54);
            button1.TabIndex = 31;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtPositionName
            // 
            txtPositionName.AutoCompleteCustomSource.AddRange(new string[] { "President", "Vice President", "Secretary General", "Treasurer General", "Solicitor General", "Executive Auditor", "Cabinet Secretary", "1st Year Representative", "2nd Year Representative", "3rd Year Representative", "4th Year Representative" });
            txtPositionName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPositionName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPositionName.Location = new Point(22, 163);
            txtPositionName.Name = "txtPositionName";
            txtPositionName.Size = new Size(303, 33);
            txtPositionName.TabIndex = 6;
            // 
            // PoistionCreate
            // 
            PoistionCreate.BackColor = Color.Maroon;
            PoistionCreate.BackgroundImageLayout = ImageLayout.None;
            PoistionCreate.FlatAppearance.BorderSize = 0;
            PoistionCreate.FlatStyle = FlatStyle.Flat;
            PoistionCreate.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PoistionCreate.ForeColor = Color.White;
            PoistionCreate.Location = new Point(225, 342);
            PoistionCreate.Name = "PoistionCreate";
            PoistionCreate.Size = new Size(171, 54);
            PoistionCreate.TabIndex = 30;
            PoistionCreate.Text = "Save Position";
            PoistionCreate.UseVisualStyleBackColor = false;
            PoistionCreate.Click += PoistionCreate_Click;
            // 
            // cmbOrgList
            // 
            cmbOrgList.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrgList.FlatStyle = FlatStyle.Flat;
            cmbOrgList.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbOrgList.FormattingEnabled = true;
            cmbOrgList.Items.AddRange(new object[] { "test" });
            cmbOrgList.Location = new Point(22, 249);
            cmbOrgList.Name = "cmbOrgList";
            cmbOrgList.Size = new Size(303, 33);
            cmbOrgList.TabIndex = 5;
            // 
            // cmbElectionTitle
            // 
            cmbElectionTitle.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbElectionTitle.FlatStyle = FlatStyle.Flat;
            cmbElectionTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbElectionTitle.FormattingEnabled = true;
            cmbElectionTitle.Items.AddRange(new object[] { "test" });
            cmbElectionTitle.Location = new Point(22, 62);
            cmbElectionTitle.Name = "cmbElectionTitle";
            cmbElectionTitle.Size = new Size(303, 33);
            cmbElectionTitle.TabIndex = 5;
            cmbElectionTitle.SelectedIndexChanged += cmbElectionTitle_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Maroon;
            label1.Location = new Point(12, 116);
            label1.Name = "label1";
            label1.Size = new Size(188, 32);
            label1.TabIndex = 4;
            label1.Text = "Position Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(12, 214);
            label2.Name = "label2";
            label2.Size = new Size(181, 32);
            label2.TabIndex = 4;
            label2.Text = "Organizations:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Maroon;
            label5.Location = new Point(12, 27);
            label5.Name = "label5";
            label5.Size = new Size(169, 32);
            label5.TabIndex = 4;
            label5.Text = "Election Title:";
            // 
            // AddPosition
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 408);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddPosition";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Position";
            Load += AddPosition_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label5;
        private ComboBox cmbElectionTitle;
        private TextBox txtPositionName;
        private Label label1;
        private Button button1;
        private Button PoistionCreate;
        private ComboBox cmbOrgList;
        private Label label2;
    }
}
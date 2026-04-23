namespace Final_Project_OOP2
{
    partial class ImportVoters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportVoters));
            panel1 = new Panel();
            btnCancelImport = new Button();
            txtFilePath = new TextBox();
            btnImport = new Button();
            btnBrowse = new Button();
            label11 = new Label();
            ofdImport = new OpenFileDialog();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.panelbackground;
            panel1.Controls.Add(btnCancelImport);
            panel1.Controls.Add(txtFilePath);
            panel1.Controls.Add(btnImport);
            panel1.Controls.Add(btnBrowse);
            panel1.Controls.Add(label11);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(688, 261);
            panel1.TabIndex = 2;
            // 
            // btnCancelImport
            // 
            btnCancelImport.BackColor = SystemColors.ButtonShadow;
            btnCancelImport.BackgroundImageLayout = ImageLayout.None;
            btnCancelImport.FlatAppearance.BorderSize = 0;
            btnCancelImport.FlatStyle = FlatStyle.Flat;
            btnCancelImport.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelImport.ForeColor = Color.White;
            btnCancelImport.Location = new Point(14, 176);
            btnCancelImport.Name = "btnCancelImport";
            btnCancelImport.Size = new Size(117, 54);
            btnCancelImport.TabIndex = 32;
            btnCancelImport.Text = "Cancel";
            btnCancelImport.UseVisualStyleBackColor = false;
            btnCancelImport.Click += btnCancelImport_Click;
            // 
            // txtFilePath
            // 
            txtFilePath.BorderStyle = BorderStyle.None;
            txtFilePath.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFilePath.Location = new Point(14, 64);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(654, 26);
            txtFilePath.TabIndex = 31;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.Maroon;
            btnImport.BackgroundImageLayout = ImageLayout.None;
            btnImport.FlatAppearance.BorderSize = 0;
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImport.ForeColor = Color.White;
            btnImport.Location = new Point(478, 176);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(171, 54);
            btnImport.TabIndex = 30;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += btnImport_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.Maroon;
            btnBrowse.BackgroundImageLayout = ImageLayout.None;
            btnBrowse.FlatAppearance.BorderSize = 0;
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBrowse.ForeColor = Color.White;
            btnBrowse.Location = new Point(291, 176);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(171, 54);
            btnBrowse.TabIndex = 29;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Maroon;
            label11.Location = new Point(12, 22);
            label11.Name = "label11";
            label11.Size = new Size(632, 25);
            label11.TabIndex = 26;
            label11.Text = "Choose an Excel file to import voter data. Accepted forms: (.xlsx)|.xlsx";
            // 
            // ofdImport
            // 
            ofdImport.FileName = "openFileDialog1";
            ofdImport.Filter = "MS Access Files (.mdb)|.mdb";
            // 
            // ImportVoters
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 261);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ImportVoters";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Import Voters";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label11;
        private OpenFileDialog ofdImport;
        private Button btnBrowse;
        private Button btnImport;
        private TextBox txtFilePath;
        private Button btnCancelImport;
    }
}
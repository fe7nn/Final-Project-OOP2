namespace Final_Project_OOP2
{
    partial class VotingSytem
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VotingSytem));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panelLogin = new Panel();
            txtUsername = new MaskedTextBox();
            label11 = new Label();
            label10 = new Label();
            button2 = new Button();
            btnLogin = new Button();
            button1 = new Button();
            txtPassword = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelRegister = new Panel();
            button4 = new Button();
            txtRegUser = new MaskedTextBox();
            txtRegEmail = new TextBox();
            label9 = new Label();
            btnSubmitRegistration = new Button();
            button3 = new Button();
            txtRegPass = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            panelDashboard = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelLogin.SuspendLayout();
            panelRegister.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.header;
            pictureBox1.Location = new Point(-1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1618, 107);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.wmremove_transformed;
            pictureBox2.Location = new Point(-1, 103);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1618, 715);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // panelLogin
            // 
            panelLogin.Anchor = AnchorStyles.None;
            panelLogin.BackColor = Color.Maroon;
            panelLogin.Controls.Add(txtUsername);
            panelLogin.Controls.Add(label11);
            panelLogin.Controls.Add(label10);
            panelLogin.Controls.Add(button2);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(button1);
            panelLogin.Controls.Add(txtPassword);
            panelLogin.Controls.Add(label4);
            panelLogin.Controls.Add(label3);
            panelLogin.Controls.Add(label2);
            panelLogin.Controls.Add(label1);
            panelLogin.Location = new Point(424, 209);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(695, 432);
            panelLogin.TabIndex = 2;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.HidePromptOnLeave = true;
            txtUsername.Location = new Point(24, 109);
            txtUsername.Mask = "00-0000-000";
            txtUsername.Name = "txtUsername";
            txtUsername.PromptChar = ' ';
            txtUsername.Size = new Size(646, 33);
            txtUsername.TabIndex = 0;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Maroon;
            label11.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(14, 395);
            label11.Name = "label11";
            label11.Size = new Size(450, 17);
            label11.TabIndex = 10;
            label11.Text = "The apply button is only enabled during the official application period.";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Maroon;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(23, 319);
            label10.Name = "label10";
            label10.Size = new Size(274, 25);
            label10.TabIndex = 9;
            label10.Text = "For new enrolles, click APPLY.";
            // 
            // button2
            // 
            button2.BackColor = Color.Gold;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(24, 347);
            button2.Name = "button2";
            button2.Size = new Size(273, 45);
            button2.TabIndex = 8;
            button2.Text = "APPLY";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Gold;
            btnLogin.BackgroundImageLayout = ImageLayout.None;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(566, 313);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(104, 41);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // button1
            // 
            button1.BackColor = Color.Gold;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(24, 272);
            button1.Name = "button1";
            button1.Size = new Size(104, 41);
            button1.TabIndex = 6;
            button1.Text = "Clear Entries";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(24, 193);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(646, 33);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Maroon;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(14, 165);
            label4.Name = "label4";
            label4.Size = new Size(102, 25);
            label4.TabIndex = 4;
            label4.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Maroon;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(14, 81);
            label3.Name = "label3";
            label3.Size = new Size(106, 25);
            label3.TabIndex = 2;
            label3.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(14, 44);
            label2.Name = "label2";
            label2.Size = new Size(669, 20);
            label2.TabIndex = 1;
            label2.Text = "______________________________________________________________________________________________________________";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Maroon;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(242, 32);
            label1.TabIndex = 0;
            label1.Text = "User Authentication";
            // 
            // panelRegister
            // 
            panelRegister.Anchor = AnchorStyles.None;
            panelRegister.BackColor = Color.Maroon;
            panelRegister.Controls.Add(button4);
            panelRegister.Controls.Add(txtRegUser);
            panelRegister.Controls.Add(txtRegEmail);
            panelRegister.Controls.Add(label9);
            panelRegister.Controls.Add(btnSubmitRegistration);
            panelRegister.Controls.Add(button3);
            panelRegister.Controls.Add(txtRegPass);
            panelRegister.Controls.Add(label5);
            panelRegister.Controls.Add(label6);
            panelRegister.Controls.Add(label7);
            panelRegister.Controls.Add(label8);
            panelRegister.Location = new Point(1142, 256);
            panelRegister.Name = "panelRegister";
            panelRegister.Size = new Size(692, 432);
            panelRegister.TabIndex = 8;
            panelRegister.Visible = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Gold;
            button4.BackgroundImageLayout = ImageLayout.None;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(547, 7);
            button4.Name = "button4";
            button4.Size = new Size(136, 37);
            button4.TabIndex = 6;
            button4.Text = "Back to Login";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // txtRegUser
            // 
            txtRegUser.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRegUser.Location = new Point(24, 109);
            txtRegUser.Mask = "00-0000-000";
            txtRegUser.Name = "txtRegUser";
            txtRegUser.PromptChar = ' ';
            txtRegUser.Size = new Size(646, 33);
            txtRegUser.TabIndex = 1;
            // 
            // txtRegEmail
            // 
            txtRegEmail.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRegEmail.Location = new Point(24, 271);
            txtRegEmail.Name = "txtRegEmail";
            txtRegEmail.Size = new Size(646, 33);
            txtRegEmail.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Maroon;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(14, 243);
            label9.Name = "label9";
            label9.Size = new Size(64, 25);
            label9.TabIndex = 8;
            label9.Text = "Email:";
            // 
            // btnSubmitRegistration
            // 
            btnSubmitRegistration.BackColor = Color.Gold;
            btnSubmitRegistration.BackgroundImageLayout = ImageLayout.None;
            btnSubmitRegistration.FlatStyle = FlatStyle.Flat;
            btnSubmitRegistration.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSubmitRegistration.Location = new Point(566, 366);
            btnSubmitRegistration.Name = "btnSubmitRegistration";
            btnSubmitRegistration.Size = new Size(104, 41);
            btnSubmitRegistration.TabIndex = 4;
            btnSubmitRegistration.Text = "Submit";
            btnSubmitRegistration.UseVisualStyleBackColor = false;
            btnSubmitRegistration.Click += btnSubmitRegistration_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Gold;
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(14, 323);
            button3.Name = "button3";
            button3.Size = new Size(104, 41);
            button3.TabIndex = 5;
            button3.Text = "Clear Entries";
            button3.UseVisualStyleBackColor = false;
            // 
            // txtRegPass
            // 
            txtRegPass.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRegPass.Location = new Point(24, 193);
            txtRegPass.Name = "txtRegPass";
            txtRegPass.Size = new Size(646, 33);
            txtRegPass.TabIndex = 2;
            txtRegPass.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Maroon;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(14, 165);
            label5.Name = "label5";
            label5.Size = new Size(102, 25);
            label5.TabIndex = 4;
            label5.Text = "Password:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Maroon;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(14, 81);
            label6.Name = "label6";
            label6.Size = new Size(106, 25);
            label6.TabIndex = 2;
            label6.Text = "Username:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(14, 44);
            label7.Name = "label7";
            label7.Size = new Size(669, 20);
            label7.TabIndex = 1;
            label7.Text = "______________________________________________________________________________________________________________";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Maroon;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(14, 12);
            label8.Name = "label8";
            label8.Size = new Size(153, 32);
            label8.TabIndex = 0;
            label8.Text = "Registration";
            // 
            // panelDashboard
            // 
            panelDashboard.Location = new Point(1225, 253);
            panelDashboard.Name = "panelDashboard";
            panelDashboard.Size = new Size(200, 100);
            panelDashboard.TabIndex = 8;
            panelDashboard.Visible = false;
            // 
            // VotingSytem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Yellow;
            ClientSize = new Size(1557, 818);
            Controls.Add(panelRegister);
            Controls.Add(panelDashboard);
            Controls.Add(panelLogin);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VotingSytem";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CIT-U Voting System";
            Load += VotingSytem_Load;
            VisibleChanged += VotingSytem_VisibleChanged;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            panelRegister.ResumeLayout(false);
            panelRegister.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panelLogin;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button btnLogin;
        private Panel panelRegister;
        private TextBox txtRegEmail;
        private Label label9;
        private Button btnSubmitRegistration;
        private Button button3;
        private TextBox txtRegPass;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label11;
        private Label label10;
        private Button button2;
        private Panel panelDashboard;
        private MaskedTextBox txtUsername;
        private TextBox txtPassword;
        private MaskedTextBox txtRegUser;
        private Button button4;
    }
}

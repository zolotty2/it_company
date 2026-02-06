namespace it_company
{
    partial class FormLogin

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            PctrBox = new PictureBox();
            LoginPnl = new Panel();
            button1 = new Button();
            LoginBtn = new Button();
            PasswordTxt = new TextBox();
            LoginTxt = new TextBox();
            PasswordLbl = new Label();
            EmailLbl = new Label();
            ((System.ComponentModel.ISupportInitialize)PctrBox).BeginInit();
            LoginPnl.SuspendLayout();
            SuspendLayout();
            // 
            // PctrBox
            // 
            PctrBox.Anchor = AnchorStyles.Top;
            PctrBox.Image = (Image)resources.GetObject("PctrBox.Image");
            PctrBox.InitialImage = (Image)resources.GetObject("PctrBox.InitialImage");
            PctrBox.Location = new Point(221, 46);
            PctrBox.Name = "PctrBox";
            PctrBox.Size = new Size(154, 137);
            PctrBox.SizeMode = PictureBoxSizeMode.Zoom;
            PctrBox.TabIndex = 0;
            PctrBox.TabStop = false;
            // 
            // LoginPnl
            // 
            LoginPnl.Anchor = AnchorStyles.Bottom;
            LoginPnl.BackColor = Color.FromArgb(242, 242, 242);
            LoginPnl.Controls.Add(button1);
            LoginPnl.Controls.Add(LoginBtn);
            LoginPnl.Controls.Add(PasswordTxt);
            LoginPnl.Controls.Add(LoginTxt);
            LoginPnl.Controls.Add(PasswordLbl);
            LoginPnl.Controls.Add(EmailLbl);
            LoginPnl.Location = new Point(112, 222);
            LoginPnl.Name = "LoginPnl";
            LoginPnl.Size = new Size(372, 247);
            LoginPnl.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(156, 211, 216);
            button1.Location = new Point(23, 202);
            button1.Name = "button1";
            button1.Size = new Size(327, 26);
            button1.TabIndex = 11;
            button1.Text = "Войти как гость";
            button1.UseVisualStyleBackColor = false;
            // 
            // LoginBtn
            // 
            LoginBtn.BackColor = Color.FromArgb(156, 211, 216);
            LoginBtn.Location = new Point(23, 173);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(327, 26);
            LoginBtn.TabIndex = 10;
            LoginBtn.Text = "Войти";
            LoginBtn.UseVisualStyleBackColor = false;
            LoginBtn.Click += BtnLogin_click;
            // 
            // PasswordTxt
            // 
            PasswordTxt.Location = new Point(23, 123);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.Size = new Size(327, 26);
            PasswordTxt.TabIndex = 9;
            // 
            // LoginTxt
            // 
            LoginTxt.Location = new Point(23, 51);
            LoginTxt.Name = "LoginTxt";
            LoginTxt.Size = new Size(327, 26);
            LoginTxt.TabIndex = 8;
            // 
            // PasswordLbl
            // 
            PasswordLbl.AutoSize = true;
            PasswordLbl.Location = new Point(23, 89);
            PasswordLbl.Name = "PasswordLbl";
            PasswordLbl.Size = new Size(58, 19);
            PasswordLbl.TabIndex = 7;
            PasswordLbl.Text = "Пароль";
            // 
            // EmailLbl
            // 
            EmailLbl.AutoSize = true;
            EmailLbl.Location = new Point(23, 19);
            EmailLbl.Name = "EmailLbl";
            EmailLbl.Size = new Size(42, 19);
            EmailLbl.TabIndex = 6;
            EmailLbl.Text = "Email";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(619, 498);
            Controls.Add(LoginPnl);
            Controls.Add(PctrBox);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Логин";
            Load += FormLogin_Load;
            ((System.ComponentModel.ISupportInitialize)PctrBox).EndInit();
            LoginPnl.ResumeLayout(false);
            LoginPnl.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox PctrBox;
        private Panel LoginPnl;
        private Button button1;
        private Button LoginBtn;
        private TextBox PasswordTxt;
        private TextBox LoginTxt;
        private Label PasswordLbl;
        private Label EmailLbl;
    }
}

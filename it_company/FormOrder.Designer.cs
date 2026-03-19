namespace it_company
{
    partial class FormOrder
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
            panel1 = new Panel();
            lblUserName = new Label();
            btnLogout = new Button();
            DgvTasks = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvTasks).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblUserName);
            panel1.Controls.Add(btnLogout);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(5, 5);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1019, 27);
            panel1.TabIndex = 0;
            // 
            // lblUserName
            // 
            lblUserName.AutoEllipsis = true;
            lblUserName.AutoSize = true;
            lblUserName.Dock = DockStyle.Right;
            lblUserName.Location = new Point(878, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(45, 19);
            lblUserName.TabIndex = 3;
            lblUserName.Text = "11111";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(156, 211, 216);
            btnLogout.Dock = DockStyle.Right;
            btnLogout.Location = new Point(923, 0);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(96, 27);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Выйти";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // DgvTasks
            // 
            DgvTasks.BackgroundColor = Color.White;
            DgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvTasks.Dock = DockStyle.Fill;
            DgvTasks.Location = new Point(5, 32);
            DgvTasks.Name = "DgvTasks";
            DgvTasks.Size = new Size(1019, 533);
            DgvTasks.TabIndex = 1;
            // 
            // FormOrder
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 570);
            Controls.Add(DgvTasks);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "FormOrder";
            Padding = new Padding(5);
            Text = "Заказы";
            Load += FormOrder_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvTasks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnLogout;
        private DataGridView DgvTasks;
        private Label lblUserName;
    }
}
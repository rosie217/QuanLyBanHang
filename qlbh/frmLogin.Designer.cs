namespace qlbh
{
    partial class FormDangnhap
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
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.User = new System.Windows.Forms.Label();
            this.FrmUser = new System.Windows.Forms.TextBox();
            this.Frmpass = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::qlbh.Properties.Resources._8027825e3e46c91890571;
            this.pictureBox1.Image = global::qlbh.Properties.Resources._8027825e3e46c9189057;
            this.pictureBox1.Location = new System.Drawing.Point(161, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // User
            // 
            this.User.AutoSize = true;
            this.User.BackColor = System.Drawing.Color.Transparent;
            this.User.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User.ForeColor = System.Drawing.Color.White;
            this.User.Location = new System.Drawing.Point(94, 182);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(211, 55);
            this.User.TabIndex = 1;
            this.User.Text = "Sneaker";
            // 
            // FrmUser
            // 
            this.FrmUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrmUser.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.FrmUser.Location = new System.Drawing.Point(70, 269);
            this.FrmUser.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.FrmUser.MinimumSize = new System.Drawing.Size(301, 39);
            this.FrmUser.Name = "FrmUser";
            this.FrmUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FrmUser.Size = new System.Drawing.Size(301, 40);
            this.FrmUser.TabIndex = 2;
            this.FrmUser.Text = "Username...";
            this.FrmUser.TextChanged += new System.EventHandler(this.FrmUser_TextChanged);
            this.FrmUser.Enter += new System.EventHandler(this.FrmUser_Enter);
            this.FrmUser.Leave += new System.EventHandler(this.FrmUser_Leave);
            // 
            // Frmpass
            // 
            this.Frmpass.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Frmpass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Frmpass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Frmpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frmpass.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.Frmpass.Location = new System.Drawing.Point(70, 344);
            this.Frmpass.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.Frmpass.MaxLength = 20;
            this.Frmpass.MinimumSize = new System.Drawing.Size(301, 39);
            this.Frmpass.Name = "Frmpass";
            this.Frmpass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Frmpass.Size = new System.Drawing.Size(301, 27);
            this.Frmpass.TabIndex = 3;
            this.Frmpass.Text = "Password...";
            this.Frmpass.UseSystemPasswordChar = true;
            this.Frmpass.WordWrap = false;
            this.Frmpass.TextChanged += new System.EventHandler(this.Frmpass_TextChanged);
            this.Frmpass.Enter += new System.EventHandler(this.Frmpass_Enter);
            this.Frmpass.Leave += new System.EventHandler(this.Frmpass_Leave);
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LoginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoginBtn.Location = new System.Drawing.Point(44, 418);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(182, 41);
            this.LoginBtn.TabIndex = 4;
            this.LoginBtn.Text = "Đăng nhập";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ExitBtn.Location = new System.Drawing.Point(274, 418);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(128, 41);
            this.ExitBtn.TabIndex = 5;
            this.ExitBtn.Text = "Thoát";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormDangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::qlbh.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(443, 515);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.Frmpass);
            this.Controls.Add(this.FrmUser);
            this.Controls.Add(this.User);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(459, 554);
            this.MinimumSize = new System.Drawing.Size(459, 554);
            this.Name = "FormDangnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label User;
        private System.Windows.Forms.TextBox FrmUser;
        private System.Windows.Forms.TextBox Frmpass;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button ExitBtn;
    }
}


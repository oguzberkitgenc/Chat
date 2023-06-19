namespace Chat
{
    partial class Login
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BGiris = new DevExpress.XtraEditors.SimpleButton();
            this.gradientPAnel1 = new Chat.GradientPAnel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TPass = new System.Windows.Forms.TextBox();
            this.TUser = new System.Windows.Forms.TextBox();
            this.gradientPAnel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BGiris
            // 
            this.BGiris.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.BGiris.Appearance.Options.UseBackColor = true;
            this.BGiris.Location = new System.Drawing.Point(337, 181);
            this.BGiris.Name = "BGiris";
            this.BGiris.Size = new System.Drawing.Size(93, 23);
            this.BGiris.TabIndex = 2;
            this.BGiris.Text = "Giriş Yap";
            this.BGiris.Click += new System.EventHandler(this.BGiris_Click);
            // 
            // gradientPAnel1
            // 
            this.gradientPAnel1.Angle = 0F;
            this.gradientPAnel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(155)))));
            this.gradientPAnel1.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(84)))), ((int)(((byte)(123)))));
            this.gradientPAnel1.Controls.Add(this.simpleButton2);
            this.gradientPAnel1.Controls.Add(this.simpleButton1);
            this.gradientPAnel1.Controls.Add(this.label2);
            this.gradientPAnel1.Controls.Add(this.label1);
            this.gradientPAnel1.Controls.Add(this.BGiris);
            this.gradientPAnel1.Controls.Add(this.TPass);
            this.gradientPAnel1.Controls.Add(this.TUser);
            this.gradientPAnel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPAnel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPAnel1.Name = "gradientPAnel1";
            this.gradientPAnel1.Size = new System.Drawing.Size(433, 248);
            this.gradientPAnel1.TabIndex = 0;
            this.gradientPAnel1.TopColor = System.Drawing.Color.Empty;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.simpleButton2.Appearance.Options.UseBackColor = true;
            this.simpleButton2.Location = new System.Drawing.Point(230, 210);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(200, 23);
            this.simpleButton2.TabIndex = 6;
            this.simpleButton2.Text = "ARAMIZA KATIL!";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(230, 181);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(93, 23);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "Şifremi Unuttum";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Castellar", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(171, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "SIFRE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Castellar", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // TPass
            // 
            this.TPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TPass.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TPass.Location = new System.Drawing.Point(230, 155);
            this.TPass.Name = "TPass";
            this.TPass.Size = new System.Drawing.Size(200, 20);
            this.TPass.TabIndex = 1;
            this.TPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TUser_KeyPress);
            // 
            // TUser
            // 
            this.TUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TUser.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TUser.Location = new System.Drawing.Point(230, 129);
            this.TUser.Name = "TUser";
            this.TUser.Size = new System.Drawing.Size(200, 20);
            this.TUser.TabIndex = 0;
            this.TUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TUser_KeyPress);
            // 
            // Login
            // 
            this.AcceptButton = this.BGiris;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(433, 248);
            this.Controls.Add(this.gradientPAnel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.gradientPAnel1.ResumeLayout(false);
            this.gradientPAnel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPAnel gradientPAnel1;
        private System.Windows.Forms.TextBox TPass;
        private System.Windows.Forms.TextBox TUser;
        private DevExpress.XtraEditors.SimpleButton BGiris;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}
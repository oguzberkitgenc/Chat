namespace Chat
{
    partial class NewUser
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
            this.TUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TMail = new System.Windows.Forms.TextBox();
            this.BSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TPassConfirm = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TUser
            // 
            this.TUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TUser.Location = new System.Drawing.Point(82, 34);
            this.TUser.Name = "TUser";
            this.TUser.Size = new System.Drawing.Size(189, 20);
            this.TUser.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Şifre";
            // 
            // TPass
            // 
            this.TPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TPass.Location = new System.Drawing.Point(82, 60);
            this.TPass.Name = "TPass";
            this.TPass.Size = new System.Drawing.Size(189, 20);
            this.TPass.TabIndex = 2;
            this.TPass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "E-Posta";
            // 
            // TMail
            // 
            this.TMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TMail.Location = new System.Drawing.Point(82, 108);
            this.TMail.Name = "TMail";
            this.TMail.Size = new System.Drawing.Size(189, 20);
            this.TMail.TabIndex = 4;
            // 
            // BSave
            // 
            this.BSave.Location = new System.Drawing.Point(196, 134);
            this.BSave.Name = "BSave";
            this.BSave.Size = new System.Drawing.Size(75, 23);
            this.BSave.TabIndex = 6;
            this.BSave.Text = "Üye Ol";
            this.BSave.UseVisualStyleBackColor = true;
            this.BSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Şifre Tekrar";
            // 
            // TPassConfirm
            // 
            this.TPassConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TPassConfirm.Location = new System.Drawing.Point(82, 86);
            this.TPassConfirm.Name = "TPassConfirm";
            this.TPassConfirm.Size = new System.Drawing.Size(189, 20);
            this.TPassConfirm.TabIndex = 7;
            this.TPassConfirm.UseSystemPasswordChar = true;
            // 
            // NewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 178);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TPassConfirm);
            this.Controls.Add(this.BSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TMail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "NewUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TMail;
        private System.Windows.Forms.Button BSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TPassConfirm;
    }
}
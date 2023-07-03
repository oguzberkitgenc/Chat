using Chat.Islemler;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Chat
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }
        DML listLogin;
        Random r = new Random();
        int press = 0;
        void RenkDegis()
        {
            press++;
            if (press % 5 == 0)
            {
                gradientPAnel1.BackColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void BGiris_Click(object sender, EventArgs e)
        {
            listLogin = new DML();
            string u = TUser.Text.ToString();
            string p = TPass.Text.ToString();
            listLogin.GirisYap(TUser.Text,TPass.Text);
            this.Hide();
        }

        private void TUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            RenkDegis();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Opacity += 0.01;
                if (this.Opacity == 1)
                {
                    timer1.Stop();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            NewUser user = new NewUser();
            user.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Henüz aktif değil");
        }
    }
}

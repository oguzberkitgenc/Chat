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
        Connection con = new Connection();
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataReader dr;
        Home home;
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
            try
            {
                home = new Home();
                connection = new SqlConnection(con.Adres);
                connection.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Users WHERE UserName=@p1 AND Password=@p2";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@p1", TUser.Text);
                cmd.Parameters.AddWithValue("@p2", TPass.Text);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.Hide();
                    home.userName = TUser.Text.ToLower(); ;
                    home.Show();
                }
                else 
                {
                    MessageBox.Show("Başarısız");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

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
    }
}

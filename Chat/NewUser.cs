using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        Connection con = new Connection();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TPass.Text == TPassConfirm.Text)
                {
                    SqlConnection connection = new SqlConnection(con.Adres);
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO USERS (UserName,Password,Mail) VALUES (@P1,@P2,@P3)", connection);
                    cmd.Parameters.AddWithValue("@p1", TUser.Text);
                    cmd.Parameters.AddWithValue("@p2", TPass.Text);
                    cmd.Parameters.AddWithValue("@p3", TMail.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Tamamlandı");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hatalı Bilgi");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           

        }
    }
}

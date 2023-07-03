using Chat.Islemler;
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
        DML listLogin;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TPass.Text == TPassConfirm.Text)
                {
                    listLogin = new DML();  
                    listLogin.UyeOl(TUser.Text,TPass.Text,TMail.Text);
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

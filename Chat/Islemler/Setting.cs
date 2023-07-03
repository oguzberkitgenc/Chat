using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Chat
{
    public class Setting
    {
        public void UyariGonder(string Msg)
        {
            System.Windows.Forms.MessageBox.Show(Msg.ToString());
        }
       
    }
}

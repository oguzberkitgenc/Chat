using Chat.Islemler;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        DML listLogin;
        public string userName = "";
        int kontrol = 0;
        int degismismi = 0;
        private void Home_Load(object sender, EventArgs e)
        {
            timer1.Start();
            kontrol = DML.HomeLoad(kontrol);
            gridControl1.DataSource = DML.Listeleme(kontrol);
            gridView1.MoveLast();
            kontrol = degismismi;
            gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
        }
        private void BGonder_Click(object sender, EventArgs e)
        {
            listLogin = new DML();
            listLogin.MesajGonder(richTextBox1.Text, userName);
            richTextBox1.Clear();
        }
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            string kimmis = Convert.ToString(view.GetRowCellValue(e.RowHandle, "Kullanici"));
            string kimmis2 = Convert.ToString(view.GetRowCellValue(e.RowHandle, "Mesaj"));
            if (kimmis == userName || kimmis2 == userName)
            {
                e.Appearance.BackColor = Color.FromArgb(200, 200, 200);
                e.Appearance.BackColor2 = Color.FromArgb(255, 255, 255);
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Setting s = new Setting();
            s.UyariGonder("test");
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Henüz aktif değil");
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Henüz aktif değil");

        }
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Henüz aktif değil");

        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            gridControl1.DataSource = DML.Listeleme(kontrol);
            gridView1.Columns[1].Width = 40;
            gridView1.MoveLast();
        }
        private void BCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}

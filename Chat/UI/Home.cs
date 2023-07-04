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
        int baksay, kontrolet;
        bool ilkAcilis;
        private void Home_Load(object sender, EventArgs e)
        {

            //Connection bgl = new Connection();
            //SqlConnection connection = new SqlConnection(bgl.Adres);
            //ilkAcilis = true;
            //connection.Open();
            //SqlCommand cmd = new SqlCommand("SELECT [S] FROM SAY", connection);
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    baksay = Convert.ToInt16(dr[0]);
            //}
            //connection.Close();
            ilkAcilis = true;
            baksay = DML.HomeLoad();

            timer1.Start();

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
            if (kimmis == userName)
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
        void Listele()
        {

        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Connection bgl = new Connection();
            SqlConnection con = new SqlConnection(bgl.Adres);
            if (ilkAcilis == false)
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT [S] FROM SAY", con);
                kontrolet = Convert.ToInt32(cmd2.ExecuteScalar());
                con.Close();
                if (baksay != kontrolet)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT [Mesaj], [Kullanici] FROM MESSAGE", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    con.Close();
                    baksay = kontrolet;
                    gridControl1.DataSource = dt;
                    gridView1.Columns[1].Width = 40;
                    gridView1.MoveLast();
                }
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT [Mesaj], [Kullanici] FROM MESSAGE", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gridView1.MoveLast();
                con.Close();
                gridControl1.DataSource = dt;
                gridView1.Columns[1].Width = 40;
                gridView1.MoveLast();
                ilkAcilis = false;
            }
        }
        private void BCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}

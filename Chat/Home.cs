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
        Connection bgl = new Connection();
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;
        SqlDataReader dr;
        public string kullanici = "";
        int kontrol = 0;
        int degismismi = 0;
        int karakter = 0;
        string kelimeBol = "";
        private void Home_Load(object sender, EventArgs e)
        {
            timer1.Start();
            SqlConnection con2 = new SqlConnection(bgl.Adres);
            con2.Open();
            cmd = new SqlCommand("SELECT [S] FROM SAY", con2);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                kontrol = Convert.ToInt16(dr[0]);
                break;
            }
            con2.Close();
            con2.Open();
            dt = new DataTable();
            cmd = new SqlCommand();
            cmd.CommandText = "SELECT [ID],[Kullanici],[Mesaj] FROM MESSAGE";
            cmd.Connection = con2;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            con2.Close();
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Width = 2;
            kontrol = degismismi;
            gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            gridView1.MoveLast();
        }
        void Listele()
        {
            SqlConnection con2 = new SqlConnection(bgl.Adres);
            con2.Open();
            cmd = new SqlCommand("SELECT [S] FROM SAY", con2);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                degismismi = Convert.ToInt16(dr[0]);
            }
            con2.Close();
            if (kontrol != degismismi)
            {
                con2.Open();
                dt = new DataTable();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT [ID],[Kullanici],[Mesaj] FROM MESSAGE";
                cmd.Connection = con2;
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                gridControl1.DataSource = dt;
                con2.Close();


                kontrol = degismismi;
                gridView1.MoveLast();
            }
        }
        private void BGonder_Click(object sender, EventArgs e)
        {
            try
            {
                karakter = richTextBox1.TextLength;
                int kelimeSayisi = (int)Math.Ceiling((double)karakter / 80);
                SqlConnection con = new SqlConnection(bgl.Adres);
                for (int i = 0; i < kelimeSayisi; i++)
                {
                    int startIndex = i * 80;
                    int lentgh = Math.Min(80, karakter - startIndex);
                    kelimeBol = richTextBox1.Text.Substring(startIndex, lentgh);
                    con.Open();
                    dt = new DataTable();
                    cmd = new SqlCommand();
                    cmd.CommandText = "INSERT INTO MESSAGE ([Kullanici],[Mesaj]) values (@p1,@p2)";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@p1", kullanici);
                    cmd.Parameters.AddWithValue("@p2", kelimeBol);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    kelimeBol = "";
                }
                richTextBox1.Clear();
                Listele();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Listele();

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            string isim = Convert.ToString(view.GetRowCellValue(e.RowHandle, "Kullanici")).ToLower();
            if (kullanici == isim)
            {
                e.Appearance.BackColor = Color.FromArgb(100, 92, 170);
                e.Appearance.BackColor2 = Color.White;
            }
        }

        private void BCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}

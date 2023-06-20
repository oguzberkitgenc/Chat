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
        SqlCommand cmd;
        SqlDataReader dr;
        public string userName = "";
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

            SiraliListele();
            gridView1.MoveLast();

            kontrol = degismismi;
            gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
        }
        void SiraliListele()
        {
            SqlConnection con = new SqlConnection(bgl.Adres);
            con.Open();
            // Değişiklik kontrolü için mevcut değeri al
            cmd = new SqlCommand("SELECT [S] FROM SAY", con);
            int degismismi = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            if (kontrol != degismismi)
            {
                con.Open();
                // MESSAGE tablosundan verileri al
                cmd = new SqlCommand("SELECT [Kullanici],[Mesaj] FROM MESSAGE", con);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gridControl1.DataSource= dt;
                con.Close();
                kontrol = degismismi;
                gridView1.Columns[1].Width = 40;
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
                    cmd = new SqlCommand();
                    cmd.CommandText = "INSERT INTO MESSAGE ([Kullanici],[Mesaj]) values (@p1,@p2)";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@p1", userName);
                    cmd.Parameters.AddWithValue("@p2", kelimeBol);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    kelimeBol = "";
                }
                richTextBox1.Clear();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            string kimmis = Convert.ToString(view.GetRowCellValue(e.RowHandle, "Kullanici"));
            string kimmis2 = Convert.ToString(view.GetRowCellValue(e.RowHandle, "Mesaj"));
            if (kimmis == userName || kimmis2 == userName)
            {
                e.Appearance.BackColor = Color.FromArgb(200, 200, 200);
                e.Appearance.BackColor2 = Color.FromArgb(255, 255,255);

            }
            //else
            //{
            //    e.Appearance.BackColor = Color.FromArgb(8, 131, 149);
            //    e.Appearance.BackColor2 = Color.FromArgb(99, 110, 114);
            //    e.Appearance.ForeColor = Color.Black;
            //}
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
            SiraliListele();

        }
        private void BCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}

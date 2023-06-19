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
        DataTable dt, yeniTablo;
        SqlDataReader dr;
        DataRow drs, yeniSatir;
        public string userName = "";
        int kontrol = 0;
        int degismismi = 0;
        int karakter = 0;
        string kelimeBol = "";
        bool ColumnWidth = false;

        private void Home_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Kullanici", typeof(string)));
            dt.Columns.Add(new DataColumn("Mesaj", typeof(string)));
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
            //con2.Open();
            //cmd = new SqlCommand("SELECT [Kullanici],[Mesaj] FROM MESSAGE", con2);
            //dr = cmd.ExecuteReader();
            //drs = null;
            //while (dr.Read())
            //{
            //    if (userName != dr[0].ToString())
            //    {
            //        drs = dt.NewRow();
            //        drs["Kullanici"] = dr[0].ToString();
            //        drs["Mesaj"] = dr[1].ToString();
            //        dt.Rows.Add(drs);
            //    }
            //    else
            //    {
            //        drs = dt.NewRow();
            //        drs["Kullanici"] = dr[1].ToString();
            //        drs["Mesaj"] = dr[0].ToString();
            //        dt.Rows.Add(drs);
            //    }
            //}
            //gridControl1.DataSource = dt;
            SiraliListele();

            //con2.Close();

            gridView1.MoveLast();
            //gridView1.BestFitColumns();
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
                con.Close();

                DataTable yeniTablo = new DataTable();
                yeniTablo.Columns.Add("Kullanici", typeof(string));
                yeniTablo.Columns.Add("Mesaj", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    string kullanici = row["Kullanici"].ToString();
                    string mesaj = row["Mesaj"].ToString();
                    //if (userName == kullanici)
                    //{
                    yeniTablo.Rows.Add(mesaj, kullanici);
                    //    ColumnWidth=true;
                    //}
                    //else
                    //{
                    //    yeniTablo.Rows.Add(kullanici,mesaj);
                    //}
                }
                gridControl1.DataSource = yeniTablo;
                kontrol = degismismi;
                gridView1.Columns[1].Width = 40;
                gridView1.MoveLast();
            }
        }
        //void EskiListele()
        //{
        //    SqlConnection con2 = new SqlConnection(bgl.Adres);
        //    con2.Open();
        //    cmd = new SqlCommand("SELECT [S] FROM SAY", con2);
        //    dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        degismismi = Convert.ToInt16(dr[0]);
        //    }
        //    con2.Close();
        //    if (kontrol != degismismi)
        //    {
        //        con2.Open();
        //        dt = new DataTable();
        //        cmd = new SqlCommand();
        //        cmd.CommandText = "SELECT [ID],[Kullanici],[Mesaj] FROM MESSAGE";
        //        cmd.Connection = con2;
        //        da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //        gridControl1.DataSource = dt;
        //        con2.Close();
        //        kontrol = degismismi;
        //        gridView1.MoveLast();
        //    }
        //}
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
            MessageBox.Show("Henüz aktif değil");
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

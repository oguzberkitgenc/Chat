using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Chat.Islemler
{
    public class DML
    {
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection connection; //sql komudu
        Connection bgl; // class komudu
        Home home;

        /// <summary>
        /// Yeni bir veri var mı kontrol eder
        /// </summary>
        /// <param name="_kontrol"></param>
        /// <returns></returns>
        public static int HomeLoad(int _kontrol)
        {
            Connection bgl = new Connection();
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT [S] FROM SAY", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _kontrol = Convert.ToInt16(dr[0]);
                break;
            }
            connection.Close();
            return _kontrol;
        }
        public void GirisYap(string user, string pass)
        {
            try
            {
                bgl = new Connection();
                connection = new SqlConnection(bgl.Adres);
                home = new Home();
                connection.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Users WHERE UserName=@p1 AND Password=@p2";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@p1", user);
                cmd.Parameters.AddWithValue("@p2", pass);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    home.userName = user.ToLower();
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
        public void MesajGonder(string icerik, string user)
        {
            try
            {
                bgl = new Connection();
                connection = new SqlConnection(bgl.Adres);
                int karakter = icerik.Length;
                int kelimeSayisi = (int)Math.Ceiling((double)karakter / 80);
                for (int i = 0; i < kelimeSayisi; i++)
                {
                    int startIndex = i * 80;
                    int lentgh = Math.Min(80, karakter - startIndex);
                    string kelimeBol = icerik.Substring(startIndex, lentgh);
                    connection.Open();
                    cmd = new SqlCommand();
                    cmd.CommandText = "INSERT INTO MESSAGE ([Kullanici],[Mesaj]) values (@p1,@p2)";
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@p1", user);
                    cmd.Parameters.AddWithValue("@p2", kelimeBol);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    kelimeBol = "";
                }
                icerik = "";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        public static DataTable Listeleme(int kontrol)
        {
            Connection bgl = new Connection();
            SqlConnection con = new SqlConnection(bgl.Adres);
            con.Open();
            // Değişiklik kontrolü için mevcut değeri al
            SqlCommand cmd = new SqlCommand("SELECT [S] FROM SAY", con);
            int degismismi = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (kontrol != degismismi)
            {
                con.Open();
                // MESSAGE tablosundan verileri al
                cmd = new SqlCommand("SELECT [Mesaj], [Kullanici] FROM MESSAGE", con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                //gridControl1.DataSource = dt;
                con.Close();
                kontrol = degismismi;
                return dt;
            }
            else
            {
                return null;
            }
        }
    }
}

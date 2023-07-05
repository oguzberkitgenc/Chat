using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using DevExpress.XtraGrid.Views.Grid;

namespace Chat.UI
{
    public partial class PrivaMessage : Form
    {
        public PrivaMessage()
        {
            InitializeComponent();
        }
        Connection bgl;
        SqlConnection connection;
        public string userName;
        private void PrivaMessage_Load(object sender, EventArgs e)
        {
            //bgl = new Connection();
            //connection = new SqlConnection(bgl.Adres);
            //connection.Open();
            //SqlCommand cmd = new SqlCommand("SELECT [UserName],[Message] FROM PrivateMEssage", connection);
            //SqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //connection.Close();
            //gridControl1.DataSource = dt;
            // Özel hücre stilini ayarla
            DuzenleListele();
            gridView1.OptionsView.AllowCellMerge = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["Message"].Width = 400;
            gridView1.Columns["UserName"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            gridView1.Columns["UserName"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gridView1.Columns[0].AppearanceCell.ForeColor = Color.Red;
            gridView1.Columns[1].AppearanceCell.ForeColor = Color.White;
        }
        void DuzenleListele()
        {
            bgl = new Connection();
            connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT [UserName],[Message],[DateTime] FROM PrivateMEssage", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Tablo", typeof(string));
            while (dr.Read())
            {
                int i = 0;
                DataRow row = dt.NewRow();
                string ilisimial = dr[0].ToString();
                //normal bir şekilde yaz
                string ikinciismial = "";
                if (ilisimial != ikinciismial) //Ahmetten sonra mehmet gelirse 1. adım
                {
                    row["Tablo"] = dr[0].ToString();
                    row["Tablo"] = dr[1].ToString();
                    i = 0; //sıra bozulursa tekrar ismi yaz 4. adım
                }
                else // ahmet üst üste gelirse 2.adım
                {       // ilk ahmetin adını yaz sonraki ahmetlerin adını yazma  3.adım
                    row["Tablo"] = dr[0].ToString();
                    i = 1;
                    if (i == 1)
                    {
                        row["Tablo"] = dr[1].ToString();
                    }
                }
                dt.Rows.Add(row);
            }
            connection.Close();

        }
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            string kimmis = Convert.ToString(view.GetRowCellValue(e.RowHandle, "UserName"));
            if (kimmis == userName)
            {
                //e.Appearance.ForeColor = Color.White;
                //e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
            if (e.Column.FieldName == "UserName")
            {
                e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, 12, FontStyle.Regular);
                e.Appearance.Options.UseFont = true;
                e.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            }
        }
    }
}

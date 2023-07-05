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
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Message", typeof(string));
            dt.Columns.Add("DateTime", typeof(string));
            while (dr.Read())
            {
                DataRow row = dt.NewRow();
                row["UserName"] = dr[0].ToString();

                if (dr[0].ToString() == "1")
                {
                    row["Message"] = dr[1].ToString();
                    row["DateTime"] = dr[2].ToString();
                }
                else
                {
                    row["Message"] = dr[1].ToString();
                    row["DateTime"] = dr[2].ToString();
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

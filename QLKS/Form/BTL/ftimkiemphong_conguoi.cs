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

namespace BTL
{
    public partial class ftimkiemphong : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd;
        DataTable dt = new DataTable();
        string sql, connstr;
        int i;
        string tt, sogiuong, loai;
        string sophong;



        public ftimkiemphong()
        {
            InitializeComponent();
        }

        public delegate void TruyenChoCha(string s);
        public TruyenChoCha TruyenData;


        private void btnchon_Click(object sender, EventArgs e)
        {
            i = grdPhong.CurrentRow.Index;
            lblsophong.Text = grdPhong[0, i].Value.ToString();
            TruyenData(lblsophong.Text);
            this.Close();
        }


        private void btnketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            tt = cmbtrangthai.SelectedItem.ToString();
            sogiuong = cmbsogiuong.SelectedItem.ToString();
            loai = cmbloai.SelectedItem.ToString();
            sql = "SELECT * FROM dbo.phong WHERE trangthai LIKE N'%"+tt+"%' AND sogiuong LIKE N'%"+sogiuong+"%' AND loaiphong LIKE N'%"+loai+"%'";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdPhong.DataSource = dt;
            grdPhong.Refresh();
        }

        private void ftimkiemphong_Load(object sender, EventArgs e)
        {
            cmbtrangthai.SelectedIndex = 0;
            cmbloai.SelectedIndex = 0;
            cmbsogiuong.SelectedIndex = 0;
            connstr = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLKS;Integrated Security=True";
            conn.ConnectionString = connstr;
            conn.Open();
            sql = "SELECT * FROM dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdPhong.DataSource = dt;
            grdPhong.Refresh();
        }
    }
}

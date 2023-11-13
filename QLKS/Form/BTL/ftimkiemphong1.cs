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
    public partial class ftimkiemphong1 : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd;
        DataTable dt = new DataTable();
        string sql, connstr;
        int i;
        string tt, sogiuong, loai;
        string sophong;



        public ftimkiemphong1()
        {
            InitializeComponent();
        }

        public delegate void TruyenChoCha(string s);
        public TruyenChoCha TruyenData;



        private void btnchon_Click_1(object sender, EventArgs e)
        {
            i = grdPhong.CurrentRow.Index;
            lblsophong.Text = grdPhong[0, i].Value.ToString();
            TruyenData(lblsophong.Text);
            this.Close();
        }

        private void ftimkiemphong1_Load(object sender, EventArgs e)
        {
            connstr = Bientoancuc.TCconnstr;
            conn.ConnectionString = connstr;
            conn.Open();
            sql = "SELECT idphong, hoten, ngaycheckin, cmnd FROM dbo.hoadonphong,dbo.khachhang "
                 + "WHERE hoadonphong.idkh = khachhang.idkh AND ngaycheckout IS NULL ORDER BY idphong ASC";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdPhong.DataSource = dt;
            grdPhong.Refresh();
        }

        private void btntimkiem_Click_1(object sender, EventArgs e)
        {
            sql = "SELECT idphong, hoten, ngaycheckin, cmnd FROM dbo.hoadonphong,dbo.khachhang "
                 + "WHERE hoadonphong.idkh = khachhang.idkh AND ngaycheckout IS NULL AND hoten LIKE N'%"+txthoten.Text+"%' AND cmnd LIKE '%"+txtcmnd.Text+"%' "
                 + "ORDER BY idphong ASC";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdPhong.DataSource = dt;
            grdPhong.Refresh();
        }

        private void btnketthuc_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

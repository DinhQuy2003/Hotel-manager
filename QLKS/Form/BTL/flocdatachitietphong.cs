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
    public partial class flocdatachitietphong : Form
    {
        public flocdatachitietphong()
        {
            InitializeComponent();
            dtpdau.MaxDate = DateTime.Now;
            dtpketthuc.MaxDate = DateTime.Now;
        }


        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dtrpt = new DataTable();
        DataTable dtrpt1 = new DataTable();
        DataTable dt = new DataTable();
        string sql, connstr;

        private void flocdatachitietphong_Load(object sender, EventArgs e)
        {
            connstr = Bientoancuc.TCconnstr;
            conn.ConnectionString = connstr;
            conn.Open();
            dtpdau.MinDate = Bientoancuc.ngaythanhlap;
            dtpketthuc.MaxDate = DateTime.Now;
        }

        private void btnloc_Click(object sender, EventArgs e)
        {
            string ngaybatdausql = dtpdau.Value.ToString("yyyy-MM-dd");
            string ngayketthucsql = dtpketthuc.Value.ToString("yyyy-MM-dd");

            if (DateTime.Compare(dtpketthuc.Value, dtpdau.Value) != -1)
            {
                sql = "SELECT loaiphong, sogiuong, giaphong, COUNT(*) AS solan " +
                      "FROM dbo.khachhang, dbo.hoadonphong, phong " +
                      "WHERE hoadonphong.idphong = phong.idphong " +
                      "AND ngaycheckin >= '" + ngaybatdausql + "' AND ngaycheckout <= '" + ngayketthucsql + "' " +
                      "GROUP BY loaiphong, sogiuong, trangthai, giaphong";


                da = new SqlDataAdapter(sql, conn);
                dtrpt.Clear();
                da.Fill(dtrpt);

                danhmuckhachhang d = new danhmuckhachhang();

                d.DataSource = dtrpt;

                d.Show();
            }
            else
            {
                MessageBox.Show("Cần chọn ngày bắt đầu trước ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }

}

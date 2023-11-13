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
    public partial class flocdatadanhmucKH : Form
    {
        public flocdatadanhmucKH()
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

        private void flocdatadanhmucKH_Load(object sender, EventArgs e)
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
                sql = "SELECT hoten, cmnd, diachi, COUNT(*) AS solan, SUM(tongtien) AS tongtt FROM dbo.khachhang, dbo.hoadonphong " +
                      " WHERE hoadonphong.idkh = khachhang.idkh " +
                      "AND ngaycheckin >= '" + ngaybatdausql + "' AND ngaycheckout <= '" + ngayketthucsql + "'  " +
                      " GROUP BY cmnd, hoten, diachi ORDER BY tongtt DESC ";

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

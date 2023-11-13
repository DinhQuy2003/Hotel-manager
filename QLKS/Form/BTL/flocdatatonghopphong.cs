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
    public partial class flocdatatonghopphong : Form
    {
        public flocdatatonghopphong()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dtrpt = new DataTable();
        DataTable dtrpt1 = new DataTable();
        DataTable dt = new DataTable();
        string sql, connstr;

        private void btnloc_Click(object sender, EventArgs e)
        {
            string ngaybatdausql = dtpdau.Value.ToString("yyyy-MM-dd");
            string ngaybatdau = dtpdau.Value.ToString("dd-MM-yyyy");
            string ngayketthucsql = dtpketthuc.Value.ToString("yyyy-MM-dd");
            string ngayketthuc = dtpketthuc.Value.ToString("dd-MM-yyyy");
            if (DateTime.Compare(dtpketthuc.Value, dtpdau.Value) != -1)
            {
                sql = "SELECT loaiphong, sogiuong, SUM(tienphong) AS tongtien, COUNT(*) AS soluong, '"+ngaybatdau+"' AS 'ngaybatdau' , '"+ngayketthuc+"' AS 'ngayketthuc' "
                     + "FROM dbo.hoadonphong,dbo.phong WHERE hoadonphong.idphong = phong.idphong "
                     + "AND ngaycheckin >= '"+ngaybatdausql+"' AND ngaycheckout <='"+ngayketthucsql+"'   "
                     + "GROUP BY loaiphong, sogiuong   ";
                da = new SqlDataAdapter(sql, conn);
                dtrpt.Clear();
                da.Fill(dtrpt);
                tonghopphong p = new tonghopphong();
                p.DataSource = dtrpt;
                p.Show();

            }
            else
                MessageBox.Show("Cần chọn ngày bắt đầu trước ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void flocdatatonghopphong_Load(object sender, EventArgs e)
        {
            connstr = Bientoancuc.TCconnstr;
            conn.ConnectionString = connstr;
            conn.Open();
            dtpdau.MinDate = Bientoancuc.ngaythanhlap;
            dtpketthuc.MaxDate = DateTime.Now;
        }
    }
}

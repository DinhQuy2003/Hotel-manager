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
    
    public partial class flocdata : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dtrpt = new DataTable();
        DataTable dt = new DataTable();
        string sql, connstr;
        SqlCommand cmd;
     

        public flocdata()
        {
            InitializeComponent();
        }
       
        private void flocdata_Load(object sender, EventArgs e)
        {
            connstr = Bientoancuc.TCconnstr;
            conn.ConnectionString = connstr;
            conn.Open();
            dtpketthuc.MaxDate = DateTime.Now;
            dtpdau.MinDate = Bientoancuc.ngaythanhlap;
        }

        private void btnloc_Click(object sender, EventArgs e)
        {

            if (DateTime.Compare(dtpketthuc.Value, dtpdau.Value) != -1)
            {
                string ngaybatdausql = dtpdau.Value.ToString("yyyy-MM-dd");
                string ngaybatdau = dtpdau.Value.ToString("dd-MM-yyyy");
                string ngayketthucsql = dtpketthuc.Value.ToString("yyyy-MM-dd");
                string ngayketthuc = dtpketthuc.Value.ToString("dd-MM-yyyy");
              
                sql = "EXEC Laydata '" + ngaybatdausql + "','" + ngayketthucsql + "'";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = "Select * from dbo.data ";
                da = new SqlDataAdapter(sql, conn);
                dtrpt.Clear();
                da.Fill(dtrpt);
            
              
            }
            else
                MessageBox.Show("Cần chọn ngày bắt đầu trước ngày kết thúc", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error) ;


        }
    }
}

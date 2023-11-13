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
    public partial class fdmkh : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        DataTable dtcmb = new DataTable();
        DataTable dtrpt = new DataTable();
        string sql, connstr;

        int i;
        public fdmkh()
        {
            InitializeComponent();
        }

        private void fdmkh_Load(object sender, EventArgs e)
        {
            connstr = Bientoancuc.TCconnstr;
            conn.ConnectionString = connstr;
            conn.Open();
            sql = "SELECT hoten, cmnd, diachi, COUNT(*) AS 'solan',SUM(tongtien) AS 'tongtt' FROM dbo.khachhang,dbo.hoadonphong WHERE hoadonphong.idkh = khachhang.idkh GROUP BY cmnd, hoten, diachi";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdttkh.DataSource = dt;
            grdttkh.Refresh();
                                           
        }

        private void btnlen_Click(object sender, EventArgs e)
        {
            i = grdttkh.CurrentRow.Index;
            if (i > 0)
            {
                grdttkh.CurrentCell = grdttkh[0, i - 1];
                NapCT();
            }
        }

        private void btnxuong_Click(object sender, EventArgs e)
        {
            i = grdttkh.CurrentRow.Index;
            if (i < grdttkh.RowCount - 2)
            {
                grdttkh.CurrentCell = grdttkh[0, i + 1];
                NapCT();
            }
        }

        private void btndau_Click(object sender, EventArgs e)
        {
            grdttkh.CurrentCell = grdttkh[0, 0];
            NapCT();
        }

        private void btncuoi_Click(object sender, EventArgs e)
        {
            grdttkh.CurrentCell = grdttkh[0, grdttkh.RowCount - 2];
            NapCT();
        }


        private void btnloc_Click(object sender, EventArgs e)
        {
            sql = "SELECT hoten, cmnd, diachi, COUNT(*) AS 'solan',SUM(tongtien) AS 'tongtt' FROM dbo.khachhang,dbo.hoadonphong WHERE hoadonphong.idkh = khachhang.idkh GROUP BY cmnd, hoten, diachi";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdttkh.DataSource = dt;
            grdttkh.Refresh();
            
        }
     

        private void btnketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdttkh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            btncapnhat.Enabled = false;
            txthoten.Focus();
       
        }


        private void btninbaocao_Click(object sender, EventArgs e)
        {
            flocdatadanhmucKH f = new flocdatadanhmucKH();
            f.ShowDialog();
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if (txtdiachi.Text != "" && txthoten.Text != "")
            {
                sql = "Update dbo.khachhang set hoten=N'" + txthoten.Text + "',diachi=N'" + txtdiachi.Text +
                        "' where cmnd='" + txtcmnd.Text + "'";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                
                sql = "SELECT hoten, cmnd, diachi, COUNT(*) AS 'solan',SUM(tongtien) AS 'tongtt' FROM dbo.khachhang,dbo.hoadonphong WHERE hoadonphong.idkh = khachhang.idkh GROUP BY cmnd, hoten, diachi";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                grdttkh.DataSource = dt;
                grdttkh.Refresh();
                
                MessageBox.Show("Đã cập nhật thành công", "Thông báo");
                btncapnhat.Enabled = false;
          
            }
            else MessageBox.Show("Chưa điền đầy đủ thông tin", "Thông báo");
        }

    
        private void txttongtt_Leave(object sender, EventArgs e)
        {
            btncapnhat.Focus();
        }

        private void btntimten_Click(object sender, EventArgs e)
        {
            sql = "SELECT hoten, cmnd, diachi, COUNT(*) AS 'solan',SUM(tongtien) AS 'tongtt' FROM dbo.khachhang,dbo.hoadonphong WHERE hoadonphong.idkh = khachhang.idkh " +
                  " and hoten" + " LIKE N'%" + txttimkiem.Text + "%' GROUP BY cmnd, hoten, diachi";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdttkh.DataSource = dt;
            grdttkh.Refresh();
           
        }

        private void cmbtruong_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "SELECT DISTINCT " + cmbtruong.Text + " FROM " +
            "(SELECT hoten, cmnd, diachi, COUNT(*) AS 'solan', SUM(tongtien) AS 'tongtt' FROM dbo.khachhang, dbo.hoadonphong WHERE hoadonphong.idkh = khachhang.idkh GROUP BY cmnd, hoten, diachi) AS bangmoi";
            da = new SqlDataAdapter(sql, conn);
            dtcmb.Clear();
            da.Fill(dtcmb);
            cmbgt.DataSource = dtcmb;
            cmbgt.DisplayMember = cmbtruong.Text;
        }

        private void fdmkh_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void cmbgt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            sql = "Select * from " +
              "(SELECT hoten, cmnd, diachi, COUNT(*) AS 'solan',SUM(tongtien) AS 'tongtt' FROM dbo.khachhang,dbo.hoadonphong WHERE hoadonphong.idkh = khachhang.idkh "
              + " GROUP BY cmnd, hoten, diachi) as bangmoi where " + cmbtruong.Text + "=N'" + cmbgt.Text + "'";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdttkh.DataSource = dt;
            grdttkh.Refresh();
        }

        public void NapCT()
        {
            i = grdttkh.CurrentRow.Index;
            txthoten.Text = grdttkh[0, i].Value.ToString();
            txtcmnd.Text = grdttkh[1, i].Value.ToString();
            txtdiachi.Text = grdttkh[2, i].Value.ToString();
            txtsolan.Text = grdttkh[3, i].Value.ToString();
            txttongtt.Text = grdttkh[4, i].Value.ToString();
        }
    }
}

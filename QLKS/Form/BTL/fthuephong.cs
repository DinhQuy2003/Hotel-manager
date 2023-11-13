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
    public partial class fthuephong : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        DataTable dtkt = new DataTable();
        string sql, connstr;
        int i;
        bool flag; // cờ kiểm tra xem khách mới hay cũ
        public fthuephong()
        {
            InitializeComponent();
            // Chỉnh dtp
            dtpngayden.Value = DateTime.Now;
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }

        string strNhan;
        public fthuephong(string giatrinhan) : this()
        {
            txtsophong.Text = giatrinhan;
        }
        private void fthuephong_Load(object sender, EventArgs e)
        {
            connstr = Bientoancuc.TCconnstr;
            conn.ConnectionString = connstr;
            conn.Open();
            sql = "SELECT cmnd,hoten,diachi FROM dbo.khachhang";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdkhachhang.DataSource = dt;
            grdkhachhang.Refresh();
            dtpngayden.MaxDate = DateTime.Now;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(txthoten.Text != "" && txtsophong.Text != "")
            {
                if(flag)
                {
                    string ngayden = dtpngayden.Value.ToString("yyyy-MM-dd");
                    sql = "INSERT INTO dbo.hoadonphong( idkh ,idphong,ngaycheckin)VALUES(( SELECT idkh FROM dbo.khachhang WHERE cmnd = '"
                        +txtcmnd.Text+"' ) ,'"+txtsophong.Text+"' ,'"+ngayden+"')"
                        + "UPDATE dbo.phong SET trangthai = N'Có người' WHERE idphong = '"+txtsophong.Text+"'";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string ngayden = dtpngayden.Value.ToString("yyyy-MM-dd");
                    sql = "INSERT INTO dbo.khachhang( cmnd, hoten, diachi )VALUES('"+txtcmnd.Text+"',N'"+txthoten.Text+"',N'"+txtdiachi.Text+"') "
                        + "INSERT INTO dbo.hoadonphong( idkh,idphong ,ngaycheckin)"
                        + "VALUES  ( (SELECT idkh FROM dbo.khachhang WHERE cmnd = '"+txtcmnd.Text+"'),'"+txtsophong.Text+"' ,'"+ngayden+"')"
                        + "UPDATE dbo.phong SET trangthai = N'Có người' WHERE idphong = '" + txtsophong.Text + "'";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    sql = "SELECT cmnd,hoten,diachi FROM dbo.khachhang";
                    da = new SqlDataAdapter(sql, conn);
                    dt.Clear();
                    da.Fill(dt);
                    grdkhachhang.DataSource = dt;
                    grdkhachhang.Refresh();
                    grdkhachhang.CurrentCell = grdkhachhang[0, grdkhachhang.RowCount - 2];

                }

                MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK);

                //Đặt lại dữ liệu cho idphong
                txtsophong.Text = "";
                txtcmnd.Text = "";
                txtdiachi.Text = "";
                txthoten.Text = "";
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void grdkhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
            flag = true;
        }

        private void btnlen_Click(object sender, EventArgs e)
        {
            i = grdkhachhang.CurrentRow.Index;
            if (i > 0)
            {
                grdkhachhang.CurrentCell = grdkhachhang[0, i - 1];
            }
        }

        private void btnxuong_Click(object sender, EventArgs e)
        {
            i = grdkhachhang.CurrentRow.Index;
            if(i < grdkhachhang.RowCount - 2)
            {
                grdkhachhang.CurrentCell = grdkhachhang[0, i + 1];
            }
        }
        private void btndau_Click(object sender, EventArgs e)
        {
            grdkhachhang.CurrentCell = grdkhachhang[0, 0];
        }

        private void btncuoi_Click(object sender, EventArgs e)
        {
            grdkhachhang.CurrentCell = grdkhachhang[0, grdkhachhang.RowCount - 2];
        }

        private void btnchon_Click_1(object sender, EventArgs e)
        {
            NapCT();
            flag = true;
        }

        private void btntimkhach_Click(object sender, EventArgs e)
        {
            string tenkhach;
            if (txttimkiem.Text == "Nhập tên khách hàng") tenkhach = "";
            else tenkhach = txttimkiem.Text;
            sql = "SELECT cmnd,hoten,diachi FROM dbo.khachhang WHERE hoten LIKE N'%"+tenkhach+"%'";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdkhachhang.DataSource = dt;
            grdkhachhang.Refresh();
        }

        private void LoadData(string data)
        {
            txtsophong.Text = "";
            txtsophong.Text = data;
        }

        private void btntimphong_Click(object sender, EventArgs e)
        {
            ftimkiemphong f = new ftimkiemphong();
            f.TruyenData = new ftimkiemphong.TruyenChoCha(LoadData);
            f.ShowDialog();
        }

        private void txttimkiem_Enter(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "Nhập tên khách hàng")
            {
                txttimkiem.Text = "";
                txttimkiem.ForeColor = Color.Black;
            }
        }

        private void txttimkiem_Leave(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                txttimkiem.Text = "Nhập tên khách hàng";
                txttimkiem.ForeColor = Color.DarkGray;
            }
        }

        private void txtcmnd_Leave(object sender, EventArgs e)
        {
            sql = "SELECT hoten,diachi FROM dbo.khachhang WHERE cmnd = '"+txtcmnd.Text+"'";
            da = new SqlDataAdapter(sql, conn);
            dtkt.Clear();
            da.Fill(dtkt);
            if(dtkt.Rows.Count > 0)
            {
                txthoten.Text = Convert.ToString(dtkt.Rows[0].ItemArray[0]);
                txtdiachi.Text = Convert.ToString(dtkt.Rows[0].ItemArray[1]);
                flag = true;
            }
            else
            {
                txthoten.Focus();
                flag = false;
            }
        }

        public void NapCT() 
        {
            i = grdkhachhang.CurrentRow.Index;
            txtcmnd.Text = grdkhachhang[0, i].Value.ToString();
            txthoten.Text = grdkhachhang[1, i].Value.ToString();
            txtdiachi.Text = grdkhachhang[2, i].Value.ToString();
        }
    }
}

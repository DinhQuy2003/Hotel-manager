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
    public partial class fdmphong : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        DataTable dtcmb = new DataTable();
        DataTable dtkt = new DataTable();
        string sql, connstr;
        bool flag = false;
        int i;
        public fdmphong()
        {
            InitializeComponent();
        }

        private void fdmphong_Load(object sender, EventArgs e)
        {
            connstr = Bientoancuc.TCconnstr;
            conn.ConnectionString = connstr;
            conn.Open();
            sql = "SELECT * from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grddmphong.DataSource = dt;
            grddmphong.Refresh();
        }

        private void btnlen_Click(object sender, EventArgs e)
        {
            i = grddmphong.CurrentRow.Index;
            if (i != 0)
            {
                grddmphong.CurrentCell = grddmphong[0, i - 1];
                NapCT();
            }
        }

        private void btnxuong_Click(object sender, EventArgs e)
        {
            i = grddmphong.CurrentRow.Index;
            if (i < grddmphong.Rows.Count - 1)
            {
                grddmphong.CurrentCell = grddmphong[0, i + 1];
                NapCT();
            }
        }

        private void btndau_Click(object sender, EventArgs e)
        {
            grddmphong.CurrentCell = grddmphong[0, 0];
            NapCT();
        }

        private void btncuoi_Click(object sender, EventArgs e)
        {
            grddmphong.CurrentCell = grddmphong[0, grddmphong.Rows.Count - 2];
            NapCT();
        }

       
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa bản ghi hiện thời", "Yêu cầu xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int i = grddmphong.CurrentRow.Index;
                sql = "Delete from dbo.phong where idphong='" + grddmphong[0, i].Value.ToString() + "'";
                grddmphong.Rows.RemoveAt(i); // Xóa dòng hiện thời của ô lười
                cmd = new SqlCommand(sql, conn); // khai báo 1 câu lệnh sql chuẩn bị thực hiện
                cmd.ExecuteNonQuery();
                //da = new SqlDataAdapter(sql,conn);
                //dt.Clear();
                //da.Fill(dt);
            }
        }

        private void btnloc_Click(object sender, EventArgs e)
        {
            sql = "SELECT * from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grddmphong.DataSource = dt;
            grddmphong.Refresh();
        }

        private void cmbtruong_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "Select distinct " + cmbtruong.Text + " from dbo.phong";

            da = new SqlDataAdapter(sql, conn);
            dtcmb.Clear();
            da.Fill(dtcmb);
            cmbgt.DataSource = dtcmb;
            cmbgt.DisplayMember = cmbtruong.Text;
        }



        private void cmbgt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            sql = "Select * from dbo.phong Where " + cmbtruong.Text + "=N'" + cmbgt.Text + "'";
            da = new SqlDataAdapter(sql, conn); // thực hiện câu lệnh truy vấn csdl
            dt.Clear();
            da.Fill(dt); // đổ dữ liệu vừa truy vấn được vào bảng dt
            grddmphong.DataSource = dt; //Khai báo nguồn dữ liệu của ô lưới 
            grddmphong.Refresh();
        }

        

        private void btnketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fdmphong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtgiaphong_Leave(object sender, EventArgs e)
        {
            btncapnhat.Focus();
        }


        private void btnsua_Click(object sender, EventArgs e)
        {
            btncapnhat.Enabled = true;
            flag = false;
            NapCT();
            txtloaiphong.Focus();
          
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if (flag == true)
            {
                sql = "select * from dbo.phong where idphong='" + txtidphong.Text + "'";
                da = new SqlDataAdapter(sql, conn); // thực hiện câu lệnh truy vấn csdl
                dtkt.Clear();
                da.Fill(dtkt);
                if (dtkt.Rows.Count == 0 && txtidphong.Text != "")
                {
                    sql = "Insert into dbo.phong values ('" + txtidphong.Text + "',N'" + txtloaiphong.Text + "','" + txtsogiuong.Text + "',N'" + txttrangthai.Text + "','" + txtgiaphong.Text + "')";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm dữ liệu thành công!", "Thông báo");
                    btncapnhat.Enabled = false;
                    flag = false;
                    txtidphong.Enabled = false;
                    sql = "select * from dbo.phong";
                    da = new SqlDataAdapter(sql, conn); // thực hiện câu lệnh truy vấn csdl
                    dt.Clear();
                    da.Fill(dt); // đổ dữ liệu vừa truy vấn được vào bảng dt
                    grddmphong.DataSource = dt; //khai báo nguồn dữ liệu của ô lưới 
                    grddmphong.Refresh();
                    NapCT();
                }
                else
                {
                    MessageBox.Show("Mã phòng sai hoặc bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtidphong.Text = "";
                }
                

            }
            else
            {
                if (txtgiaphong.Text != "" && txtloaiphong.Text != "" && txtsogiuong.Text != "" && txttrangthai.Text != "")
                {
                    sql = " Update dbo.phong set loaiphong=N'" + txtloaiphong.Text + "',sogiuong='"  + txtsogiuong.Text + "',giaphong='" + txtgiaphong.Text +
                            "' where idphong='" + grddmphong[0, i].Value.ToString() + "'";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    
                    MessageBox.Show("Đã cập nhật thành công", "Thông báo");
                    btncapnhat.Enabled = false;
                    grddmphong.ReadOnly = true;
                    sql = "select * from dbo.phong";
                    da = new SqlDataAdapter(sql, conn); // thực hiện câu lệnh truy vấn csdl
                    dt.Clear();
                    da.Fill(dt); // đổ dữ liệu vừa truy vấn được vào bảng dt
                    grddmphong.DataSource = dt; //khai báo nguồn dữ liệu của ô lưới 
                    grddmphong.Refresh();
                    NapCT();
                }
                else MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo");

            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            grddmphong.CurrentCell = grddmphong[0, grddmphong.Rows.Count - 1];
            NapCT();
            flag = true;
            btncapnhat.Enabled = true;
            txtidphong.Enabled = true;
            txttrangthai.Text = "Trống";
            txtidphong.Focus();
        }

        private void tsbtnthem_Click(object sender, EventArgs e)
        {
            grddmphong.CurrentCell = grddmphong[0, grddmphong.Rows.Count - 1];
            NapCT();
            flag = true;
            tsbtncapnhat.Enabled = true;
            txtidphong.Enabled = true;
            txttrangthai.Text = "Trống";
            txtidphong.Focus();
        }

        private void tsbtnsua_Click(object sender, EventArgs e)
        {
            tsbtncapnhat.Enabled = true;
            flag = false;
            NapCT();
            txtloaiphong.Focus();

        }

        private void tsbtncapnhat_Click(object sender, EventArgs e)
        {
            if (flag == true)
            {
                sql = "select * from dbo.phong where idphong='" + txtidphong.Text + "'";
                da = new SqlDataAdapter(sql, conn); // thực hiện câu lệnh truy vấn csdl
                dtkt.Clear();
                da.Fill(dtkt);
                if (dtkt.Rows.Count == 0 && txtidphong.Text != "")
                {
                    sql = "Insert into dbo.phong values ('" + txtidphong.Text + "',N'" + txtloaiphong.Text + "','" + txtsogiuong.Text + "',N'" + txttrangthai.Text + "','" + txtgiaphong.Text + "')";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm dữ liệu thành công!", "Thông báo");
                    tsbtncapnhat.Enabled = false;
                    flag = false;
                    txtidphong.Enabled = false;
                    sql = "select * from dbo.phong";
                    da = new SqlDataAdapter(sql, conn); // thực hiện câu lệnh truy vấn csdl
                    dt.Clear();
                    da.Fill(dt); // đổ dữ liệu vừa truy vấn được vào bảng dt
                    grddmphong.DataSource = dt; //khai báo nguồn dữ liệu của ô lưới 
                    grddmphong.Refresh();
                    NapCT();
                }
                else
                {
                    MessageBox.Show("Mã phòng sai hoặc bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtidphong.Text = "";
                }


            }
            else
            {
                if (txtgiaphong.Text != "" && txtloaiphong.Text != "" && txtsogiuong.Text != "" && txttrangthai.Text != "")
                {
                    sql = " Update dbo.phong set loaiphong=N'" + txtloaiphong.Text + "',sogiuong='" + txtsogiuong.Text + "',giaphong='" + txtgiaphong.Text +
                            "' where idphong='" + grddmphong[0, i].Value.ToString() + "'";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Đã cập nhật thành công", "Thông báo");
                    tsbtncapnhat.Enabled = false;
                    sql = "select * from dbo.phong";
                    da = new SqlDataAdapter(sql, conn); // thực hiện câu lệnh truy vấn csdl
                    dt.Clear();
                    da.Fill(dt); // đổ dữ liệu vừa truy vấn được vào bảng dt
                    grddmphong.DataSource = dt; //khai báo nguồn dữ liệu của ô lưới 
                    grddmphong.Refresh();
                    NapCT();
                }
                else MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo");

            }
        }

        private void tsbtnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa bản ghi hiện thời", "Yêu cầu xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int i = grddmphong.CurrentRow.Index;
                sql = "Delete from dbo.phong where idphong='" + grddmphong[0, i].Value.ToString() + "'";
                grddmphong.Rows.RemoveAt(i); // Xóa dòng hiện thời của ô lười
                cmd = new SqlCommand(sql, conn); // khai báo 1 câu lệnh sql chuẩn bị thực hiện
                cmd.ExecuteNonQuery();
                //da = new SqlDataAdapter(sql,conn);
                //dt.Clear();
                //da.Fill(dt);
            }
        }

        private void tsbtnketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grddmphong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }

        public void NapCT()
        {
            i = grddmphong.CurrentRow.Index;
            txtidphong.Text = grddmphong[0, i].Value.ToString();
            txtloaiphong.Text = grddmphong[1, i].Value.ToString();
            txtsogiuong.Text = grddmphong[2, i].Value.ToString();
            txttrangthai.Text = grddmphong[3, i].Value.ToString();
            txtgiaphong.Text = grddmphong[4, i].Value.ToString();
        }
    }
}

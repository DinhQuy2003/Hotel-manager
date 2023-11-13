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
    public partial class fdmdv : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        DataTable dtcmb = new DataTable();
        DataTable dtkt = new DataTable();
        string sql, connstr;
        String tdonvi, tgiadv;
        bool flag = false;
        int i;



        public fdmdv()
        {
            InitializeComponent();
        }

        //Đổi Connstr
        private void fdmdv_Load(object sender, EventArgs e)
        {
            connstr = Bientoancuc.TCconnstr;
            conn.ConnectionString = connstr;
            conn.Open();
            sql = "Select * from dbo.dichvu";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grddmdv.DataSource = dt;
            grddmdv.Refresh();
        }

        private void btnlen_Click_1(object sender, EventArgs e)
        {
            i = grddmdv.CurrentRow.Index;
            if (i != 0)
            {
                grddmdv.CurrentCell = grddmdv[0, i - 1];
                NapCT();
            }
        }

       
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa bản ghi hiện thời", "Yêu cầu xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "Delete from dbo.dichvu where tendv='" + txttendv.Text + "'";
                grddmdv.Rows.RemoveAt(grddmdv.CurrentRow.Index); // Xóa dòng hiện thời của ô lười
                cmd = new SqlCommand(sql, conn); // khai báo 1 câu lệnh sql chuẩn bị thực hiện
                cmd.ExecuteNonQuery();
                //da = new SqlDataAdapter(sql,conn);
                //dt.Clear();
                //da.Fill(dt);

            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            btncapnhat.Enabled = true;
            flag = false;
            txtdonvi.Enabled = true;
            txtgiadv.Enabled = true;
            txtdonvi.Focus();
            btnthem.Enabled = false;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            grddmdv.CurrentCell = grddmdv[0, grddmdv.Rows.Count - 1];
            NapCT();
            flag = true;
            btncapnhat.Enabled = true;
            txttendv.Enabled = true;
            txtdonvi.Enabled = true;
            txtgiadv.Enabled = true;
            txttendv.Focus();
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if (flag == true)
            {
                sql = "select * from dbo.dichvu where tendv=N'" + txttendv.Text + "'";
                da = new SqlDataAdapter(sql, conn); // thực hiện câu lệnh truy vấn csdl
                dtkt.Clear();
                da.Fill(dtkt);
                if (dtkt.Rows.Count == 0 && txttendv.Text != "")
                {
                    sql = "Insert into dbo.dichvu values (N'" + txttendv.Text + "',N'" + txtdonvi.Text + "','" + txtgiadv.Text + "')";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm dữ liệu thành công!", "Thông báo");
                    btncapnhat.Enabled = false;
                    txttendv.Enabled = false;
                    txtdonvi.Enabled = false;
                    txtgiadv.Enabled = false;
                    btnsua.Enabled = true;
                    btnxoa.Enabled = true;
                    flag = false;
                    sql = "select * from dbo.dichvu";
                    da = new SqlDataAdapter(sql, conn); // thực hiện câu lệnh truy vấn csdl
                    dt.Clear();
                    da.Fill(dt); // đổ dữ liệu vừa truy vấn được vào bảng dt
                    grddmdv.DataSource = dt; //khai báo nguồn dữ liệu của ô lưới 
                    grddmdv.Refresh();
                    NapCT();
                }
                else
                {
                    MessageBox.Show("Tên dịch vụ bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txttendv.Text = "";
                }

            }
            else
            {
                txtdonvi.Enabled = false;
                txtgiadv.Enabled = false;
                txtdonvi.Focus();
                sql = " Update dbo.dichvu set donvi=N'" + txtdonvi.Text + "',giadv='" + txtgiadv.Text +
                    "' where tendv=N'" + txttendv.Text + "'";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                

                //Cập nhật lại dữ liệu bảng
                sql = "select * from dbo.dichvu";
                da = new SqlDataAdapter(sql, conn); // thực hiện câu lệnh truy vấn csdl
                dt.Clear();
                da.Fill(dt); // đổ dữ liệu vừa truy vấn được vào bảng dt
                grddmdv.DataSource = dt; //khai báo nguồn dữ liệu của ô lưới 
                grddmdv.Refresh();
                NapCT();

                MessageBox.Show("Đã cập nhật thành công", "Thông báo");
                btncapnhat.Enabled = false;
                btnthem.Enabled = true;
            }
        }

        private void btnxuong_Click_1(object sender, EventArgs e)
        {
            i = grddmdv.CurrentRow.Index;
            if (i < grddmdv.Rows.Count - 1)
            {
                grddmdv.CurrentCell = grddmdv[0, i + 1];
                NapCT();
            }
        }

        private void btndau_Click_1(object sender, EventArgs e)
        {
            grddmdv.CurrentCell = grddmdv[0, 0];
            NapCT();
        }


        private void grddmdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }

        private void grddmdv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }

        private void btnketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fdmdv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtgiadv_Leave(object sender, EventArgs e)
        {
            btncapnhat.Focus();
        }

        private void tsbtnthem_Click(object sender, EventArgs e)
        {
            grddmdv.CurrentCell = grddmdv[0, grddmdv.Rows.Count - 1];
            NapCT();
            flag = true;
            tsbtncapnhat.Enabled = true;
            txttendv.Focus();
            grddmdv.ReadOnly = false;
        }

        private void tsbtnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa bản ghi hiện thời", "Yêu cầu xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "Delete from dbo.dichvu where tendv='" + txttendv.Text + "'";
                grddmdv.Rows.RemoveAt(grddmdv.CurrentRow.Index); // Xóa dòng hiện thời của ô lười
                cmd = new SqlCommand(sql, conn); // khai báo 1 câu lệnh sql chuẩn bị thực hiện
                cmd.ExecuteNonQuery();
                //da = new SqlDataAdapter(sql,conn);
                //dt.Clear();
                //da.Fill(dt);

            }
        }

        private void tsbtnsua_Click(object sender, EventArgs e)
        {
            tsbtncapnhat.Enabled = true;
            flag = false;
            grddmdv.ReadOnly = false;
        }

        private void tsbtncapnhat_Click(object sender, EventArgs e)
        {

            {
                if (flag == true)
                {
                    sql = "select * from dbo.dichvu where tendv=N'" + txttendv.Text + "'";
                    da = new SqlDataAdapter(sql, conn); // thực hiện câu lệnh truy vấn csdl
                    dtkt.Clear();
                    da.Fill(dtkt);
                    if (dtkt.Rows.Count == 0 && txttendv.Text != "")
                    {
                        sql = "Insert into dbo.dichvu values (N'" + txttendv.Text + "',N'" + txtdonvi.Text + "','" + txtgiadv.Text + "')";
                        cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm dữ liệu thành công!", "Thông báo");
                        tsbtncapnhat.Enabled = false;
                        grddmdv.ReadOnly = true;
                        flag = false;
                        sql = "select * from dbo.dichvu";
                        da = new SqlDataAdapter(sql, conn); // thực hiện câu lệnh truy vấn csdl
                        dt.Clear();
                        da.Fill(dt); // đổ dữ liệu vừa truy vấn được vào bảng dt
                        grddmdv.DataSource = dt; //khai báo nguồn dữ liệu của ô lưới 
                        grddmdv.Refresh();
                        NapCT();
                    }
                    else
                    {
                        MessageBox.Show("Tên dịch vụ bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txttendv.Text = "";
                    }

                }
                else
                {
                    //Cập nhật lại dữ liệu toàn bộ bảng
                    for (i = 0; i < grddmdv.RowCount - 1; i++)
                    {
                        tdonvi = grddmdv[1, i].Value.ToString();
                        tgiadv = grddmdv[2, i].Value.ToString();
                        sql = " Update dbo.dichvu set donvi=N'" + tdonvi + "',giadv='" + tgiadv +
                            "' where tendv=N'" + grddmdv[0, i].Value.ToString() + "'";
                        cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }

                    //Cập nhật lại dữ liệu bảng
                    sql = "select * from dbo.dichvu";
                    da = new SqlDataAdapter(sql, conn); // thực hiện câu lệnh truy vấn csdl
                    dt.Clear();
                    da.Fill(dt); // đổ dữ liệu vừa truy vấn được vào bảng dt
                    grddmdv.DataSource = dt; //khai báo nguồn dữ liệu của ô lưới 
                    grddmdv.Refresh();
                    NapCT();

                    MessageBox.Show("Đã cập nhật thành công", "Thông báo");
                    tsbtncapnhat.Enabled = false;
                    grddmdv.ReadOnly = true;
                    txttendv.Enabled = true;
                    txtgiadv.Enabled = true;
                    txtdonvi.Enabled = true;

                }
            }
        }

        private void grddmdv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }

        private void tsbtnketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncuoi_Click_1(object sender, EventArgs e)
        {
            grddmdv.CurrentCell = grddmdv[0, grddmdv.Rows.Count - 2];
            NapCT();
        }


        void NapCT()
        {
            i = grddmdv.CurrentRow.Index;
            txttendv.Text = grddmdv[0, i].Value.ToString();
            txtdonvi.Text = grddmdv[1, i].Value.ToString();
            txtgiadv.Text = grddmdv[2, i].Value.ToString();
        }

    }
}

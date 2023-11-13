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
    public partial class fdoimk : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string sql, connstr, str;
        int i = 0;

        private void btnhuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                this.Close();
                conn.Close();
            }
        }

        private void btndoimk_Click(object sender, EventArgs e)
        {


            if (txttdn.Text != "" && txtmkcu.Text != "" && (txtmkmoi.Text != null) && (txtmkmoilai.Text != null))
            {

                sql = "SELECT * FROM dbo.dangnhap WHERE tdn = '" + txttdn.Text + "' AND mk = '" + txtmkcu.Text + "'";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                if (i < 3)
                {
                    if (dt.Rows.Count != 0)
                    {
                        if (txtmkmoi.Text == txtmkmoilai.Text)
                        {


                            if (MessageBox.Show("Bạn có muốn đổi mật khẩu", "Xác nhận yêu cầu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                sql = "Update dbo.dangnhap set mk='" + txtmkmoi.Text + "' where tdn='" + txttdn.Text + "'";
                                da = new SqlDataAdapter(sql, conn);
                                dt.Clear();
                                da.Fill(dt);
                                MessageBox.Show("Đã đổi mật khẩu thành công, hệ thống sẽ quay lại màn hình đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dt.Clear();
                                Application.Restart();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu mới không khớp vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtmkcu.Text = "";
                            txtmkmoi.Text = "";
                            txtmkmoilai.Text = "";
                            btndoimk.Enabled = false;
                        }

                    }
                    else
                    {
                        i++;
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtmkcu.Text = "";
                        txtmkmoi.Text = "";
                        txtmkmoilai.Text = "";
                        btndoimk.Enabled = false;
                    }
                }
                else
                {
                    i = 0;
                    MessageBox.Show("Nhập sai mật khẩu cũ quá nhiều lần, hệ thống sẽ quay lại màn hình đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Restart();
                }
            }
        }



        private void txtmkmoilai_TextChanged(object sender, EventArgs e)
        {
            btndoimk.Enabled = true;

        }

        private void txtmkmoilai_Enter(object sender, EventArgs e)
        {
            btndoimk.Focus();
        }

        private void txtmkmoilai_Leave(object sender, EventArgs e)
        {
            btndoimk.Focus();
        }

        private void fdoimk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtmkmoilai_TextChanged_1(object sender, EventArgs e)
        {
            btndoimk.Enabled = true;
        }

        public fdoimk()
        {
            InitializeComponent();
        }

        private void fdoimk_Load(object sender, EventArgs e)
        {
            connstr = Bientoancuc.TCconnstr;
            conn.ConnectionString = connstr;
            conn.Open();
        }
    }
}

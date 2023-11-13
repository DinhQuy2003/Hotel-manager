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
    public partial class fdangnhap : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string sql, connstr, str;
        int i;
        public fdangnhap()
        {
            InitializeComponent();
        }
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn thực sự muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question , MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                this.Close();
                conn.Close();
            }
        }



        private void chbhienmk_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (chbhienmk.Checked)
            {
                txtthu.UseSystemPasswordChar = true;

            }
            else
            {
                txtthu.UseSystemPasswordChar = false;
            }*/
        }

        private void fdangnhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void fdangnhap_Load(object sender, EventArgs e)
        {
            connstr = Bientoancuc.TCconnstr;
            conn.ConnectionString = connstr;
            conn.Open();
            sql = "Select tenks,tenchuks,diachi,sdt,masothue,FORMAT(ngaythanhlap, 'dd-MM-yyyy') AS 'ngaythanhlap',logofile from dbo.thongtin";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
                Bientoancuc.tenks = dt.Rows[0].ItemArray[0].ToString();
                Bientoancuc.tenchuks = dt.Rows[0].ItemArray[1].ToString();
                Bientoancuc.diachi = dt.Rows[0].ItemArray[2].ToString();
                Bientoancuc.sdt = dt.Rows[0].ItemArray[3].ToString();
                Bientoancuc.masothue = dt.Rows[0].ItemArray[4].ToString();
                Bientoancuc.ngaythanhlap = DateTime.Parse(dt.Rows[0].ItemArray[5].ToString());
                Bientoancuc.logofile = dt.Rows[0].ItemArray[6].ToString();
            i = 0;
        }


        private void gunaButton1_Click(object sender, EventArgs e)
        {
            sql = "SELECT * FROM dbo.dangnhap WHERE tdn = '" + txttdn.Text + "' AND mk = '" + txtmk.Text + "'";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            if (i < 3)
            {

                if (dt.Rows.Count != 0)
                {
                    dt.Clear();
                    fmanhinhchinh f = new fmanhinhchinh(txttdn.Text);
                    f.ShowDialog();
                    txttdn.Text = "";
                    txtmk.Text = "";
                }
                else
                {
                    i++;
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn nhập sai quá nhiều lần", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }

            
        }


    }
}

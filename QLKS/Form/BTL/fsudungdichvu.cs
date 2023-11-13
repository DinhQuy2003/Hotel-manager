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
    public partial class fsudungdichvu : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        string sql, connstr, timkiem;
        int i, sl;
        public fsudungdichvu()
        {
            InitializeComponent();
            // Chỉnh dtp
            dtpngaygoi.Value = DateTime.Now;
        }

        private void fqldichvu_Load(object sender, EventArgs e)
        {
            dtpngaygoi.MaxDate = DateTime.Now;

            connstr = Bientoancuc.TCconnstr;
            conn.ConnectionString = connstr;
            conn.Open();
            sql = "SELECT * FROM dbo.dichvu";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grddv.DataSource = dt;
            grddv.Refresh();



            sql = "SELECT idphong FROM dbo.phong WHERE trangthai = N'Có người'";
            da = new SqlDataAdapter(sql,conn);
            da.Fill(dt1);
            cmbsophong.DataSource = dt1;
            cmbsophong.DisplayMember = "idphong";

            sl = Int16.Parse(txtsoluong.Text);
        }

        private void btnlen_Click(object sender, EventArgs e)
        {
            i = grddv.CurrentRow.Index;
            if (i > 0)
            {
                grddv.CurrentCell = grddv[0, i - 1];
                NaCT();
            }
        }

        private void btnxuong_Click(object sender, EventArgs e)
        {
            i = grddv.CurrentCell.RowIndex;
            if(i < grddv.RowCount - 2)
            {
                grddv.CurrentCell = grddv[0, i + 1];
                NaCT();
            }
        }

        private void btndau_Click(object sender, EventArgs e)
        {
            grddv.CurrentCell = grddv[0, 0];
            NaCT();
        }

        private void btncuoi_Click(object sender, EventArgs e)
        {
            grddv.CurrentCell = grddv[0, grddv.RowCount - 2];
            NaCT();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string sophongdv = cmbsophong.Text;
            if (txttendv.Text != "" && cmbsophong.Text !="")
            {
                if(MessageBox.Show("Bạn chắc chắn muốn lưu ?","Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    string ngaygoi = dtpngaygoi.Value.ToString("yyyy-MM-dd");
                    sql = "INSERT INTO dbo.hoadondv( idhdp, tendv, ngaygoi, soluong )VALUES" 
                         +"((SELECT idhdp FROM dbo.hoadonphong WHERE idphong = '"+cmbsophong.Text+"' AND ngaycheckout IS NULL),N'"+txttendv.Text+"','"+ngaygoi+"','"+txtsoluong.Text+"')";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    txttendv.Text = "";
                    txtgiadv.Text = "";
                    txtsoluong.Text = "1";
                    cmbsophong.Text = "";
                    sl = 1;

                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnketthuc_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }

        

        private void btngiamsl_Click(object sender, EventArgs e)
        {
            if(sl > 0)
            {
            sl--;
            txtsoluong.Text = sl.ToString();
            }
        }

        private void txttimkiem_Enter(object sender, EventArgs e)
        {
            if(txttimkiem.Text == "Nhập tên dịch vụ")
            {
                txttimkiem.Text = "";
                txttimkiem.ForeColor = Color.Black;
            }
        }

        private void txttimkiem_Leave(object sender, EventArgs e)
        {
            if(txttimkiem.Text == "")
            {
                txttimkiem.Text = "Nhập tên dịch vụ";
                txttimkiem.ForeColor = Color.DarkGray;
            }
        }

        private void btnketthuc_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grddv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NaCT();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "Nhập tên dịch vụ") timkiem = "";
            else timkiem = txttimkiem.Text;
            sql = "SELECT * FROM dbo.dichvu WHERE tendv LIKE N'%" + timkiem + "%'";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grddv.DataSource = dt;
            grddv.Refresh();
        }

        private void btntangsl_Click(object sender, EventArgs e)
        {
            sl++;
            txtsoluong.Text = sl.ToString();
        }

        public void NaCT()
        {
            i = grddv.CurrentRow.Index;
            txttendv.Text = grddv[0, i].Value.ToString();
            txtgiadv.Text = grddv[2, i].Value.ToString();
        }
    }
}

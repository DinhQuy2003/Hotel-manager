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
    public partial class fthongtinks : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        SqlCommand cmd;
        string sql, connstr;


        public fthongtinks()
        {
            InitializeComponent();
        }


        private void fthongtinks_Load(object sender, EventArgs e)
        {
            connstr = Bientoancuc.TCconnstr;
            conn.ConnectionString = connstr;
            conn.Open();
            txttenks.Text = Bientoancuc.tenks;
            txttenchuks.Text = Bientoancuc.tenchuks;
            txtdiachi.Text = Bientoancuc.diachi;
            txtmasothue.Text = Bientoancuc.masothue;
            txtsdt.Text = Bientoancuc.sdt;
            dtpngaythanhlap.Value = Bientoancuc.ngaythanhlap;
            dtpngaythanhlap.MaxDate = DateTime.Now;
            //Load ảnh
            pathstring = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            pathstring = pathstring.Substring(6);
        }
        private void btncaidatlai_Click(object sender, EventArgs e)
        {
            txttenks.Text = "";
            txttenchuks.Text = "";
            txtdiachi.Text = "";
            txtmasothue.Text = "";
            txtsdt.Text = "";
            grbchinh.Enabled = true;
            btncapnhat.Enabled = true;
            txttenks.Focus();
        }

        private void btnketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fthongtinks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            grbchinh.Enabled = true;
            btncapnhat.Enabled = true;
            txttenks.Focus();
        }


        string typepic; //Lưu type của ảnh (png, jpg, ...)
        string pathstring; //Lưu đường dẫn để file ảnh
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            PictureBox p = sender as PictureBox;
            if (p != null)
            {
                open.Filter = "(*.jpg; *bmp; *.jpeg; *.png)| *.jpg; *bmp; *.jpeg; *.png";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    string filename = open.FileName;
                    p.Image = Image.FromFile(filename);
                    typepic = filename.Split('.').Last();
                }
            }
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn cập nhật thông tin", "Xác nhận yêu cầu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txttenks.Text != "" && txttenchuks.Text != "" && txtdiachi.Text != "" && txtmasothue.Text != "" && txtsdt.Text != "")
                {
                    //Cập nhật ảnh
                    if (pictureBox1.Image != null)
                    {
                        //Lấy đường dẫn đến folder Logo
                        pathstring = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                        pathstring = pathstring.Substring(6);

                        //Xóa file logo cũ 
                        string pathfolderlogo = pathstring + @"\Logo";
                        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(pathfolderlogo);

                        foreach (System.IO.FileInfo file in di.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (System.IO.DirectoryInfo dir in di.GetDirectories())
                        {
                            dir.Delete(true);
                        }

                        //Save ảnh mới vào
                        pathstring = pathstring + @"\Logo\logo." + typepic;
                        Image a = pictureBox1.Image;
                        a.Save(pathstring);
                        
                    }
                    
                    //Cập nhật thông tin khách sạn
                    Bientoancuc.tenks = txttenks.Text;
                    Bientoancuc.tenchuks = txttenchuks.Text;
                    Bientoancuc.diachi = txtdiachi.Text;
                    Bientoancuc.sdt = txtsdt.Text;
                    Bientoancuc.masothue = txtmasothue.Text;
                    Bientoancuc.ngaythanhlap = dtpngaythanhlap.Value;
                    Bientoancuc.logofile = pathstring;
                    sql = "Update dbo.thongtin set tenks=N'" + Bientoancuc.tenks + "',tenchuks=N'" + Bientoancuc.tenchuks + "',diachi=N'" + Bientoancuc.diachi + "',sdt='" + Bientoancuc.sdt
                        + "',masothue='" + Bientoancuc.masothue + "',ngaythanhlap='" + Bientoancuc.ngaythanhlap + "',logofile='" + pathstring + "'";
                    cmd = new SqlCommand(sql, conn); // khai báo 1 câu lệnh sql chuẩn bị thực hiện
                    cmd.ExecuteNonQuery();
                    da = new SqlDataAdapter(sql, conn);
                    dt.Clear();
                    da.Fill(dt);
                    grbchinh.Enabled = false;
                    btncapnhat.Enabled = false;
                    MessageBox.Show("Cập nhật thành công", "Thông báo");

                }
                else
                {
                    MessageBox.Show("Cần nhập đầy đủ thông tin cần thiết", "Thông báo");
                    txttenks.Text = Bientoancuc.tenks;
                    txttenchuks.Text = Bientoancuc.tenchuks;
                    txtdiachi.Text = Bientoancuc.diachi;
                    txtmasothue.Text = Bientoancuc.masothue;
                    txtsdt.Text = Bientoancuc.sdt;
                    dtpngaythanhlap.Value = Bientoancuc.ngaythanhlap;
                    grbchinh.Enabled = false; 
                    btncapnhat.Enabled = false;
                }
            }
            else
            {
                txttenks.Text = Bientoancuc.tenks;
                txttenchuks.Text = Bientoancuc.tenchuks;
                txtdiachi.Text = Bientoancuc.diachi;
                txtmasothue.Text = Bientoancuc.masothue;
                txtsdt.Text = Bientoancuc.sdt;
                dtpngaythanhlap.Value = Bientoancuc.ngaythanhlap;
                grbchinh.Enabled = false;
                btncapnhat.Enabled = false;
            }
        }
    }
}

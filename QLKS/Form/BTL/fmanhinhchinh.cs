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
    public partial class fmanhinhchinh : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataTable dttenv = new DataTable();
        DataTable dtrpt = new DataTable();
        string sql, connstr, sql1;
        string user;
        public fmanhinhchinh(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void fmanhinhchinh_Load(object sender, EventArgs e)
        {

            connstr = Bientoancuc.TCconnstr;
            conn.ConnectionString = connstr;
            conn.Open();

            //Điền mã nhân viên và tên nhân viên
            lblmanv.Text = user;
            sql1 = "SELECT tennv FROM dbo.dangnhap WHERE tdn = '" + user + "'";
            da = new SqlDataAdapter(sql1, conn);
            da.Fill(dttenv);
            lbltennv.Text = dttenv.Rows[0].ItemArray[0].ToString();

            //Truy vấn phòng
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }




        private void sửDụngDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fsudungdichvu f = new fsudungdichvu();
            f.ShowDialog();
        }

        private void trảPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ftraphong f = new ftraphong(lbltennv.Text);
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();

        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fdmdv f = new fdmdv();
            f.ShowDialog();
        }

        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fdmphong f = new fdmphong();
            f.ShowDialog();
        }

        private void danhMụcPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fdmhdphong f = new fdmhdphong();
            f.ShowDialog();
        }

        private void danhMụcHóaĐơnDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fdmhddv f = new fdmhddv();
            f.ShowDialog();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong();
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            fsudungdichvu f = new fsudungdichvu();
            f.ShowDialog();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            ftraphong f = new ftraphong(lbltennv.Text);
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fdmkh f = new fdmkh();
            f.ShowDialog();
        }

        private void saoLưuVàPhụcHồiDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fdoimk f = new fdoimk();
            f.ShowDialog();
        }

        private void đăngNhậpLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hiệuSuấtPhòngTheoThờiGianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flocdata f = new flocdata();
            f.ShowDialog();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn16_Click_1(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong();
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong(grdAN[0, 12].Value.ToString());
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong(grdAN[0, 13].Value.ToString());
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong(grdAN[0, 14].Value.ToString());
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong(grdAN[0, 15].Value.ToString());
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong(grdAN[0, 8].Value.ToString());
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong(grdAN[0, 9].Value.ToString());
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong(grdAN[0, 10].Value.ToString());
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong(grdAN[0, 11].Value.ToString());
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong(grdAN[0, 4].Value.ToString());
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong(grdAN[0, 5].Value.ToString());
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong(grdAN[0, 6].Value.ToString());
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong(grdAN[0, 7].Value.ToString());
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong(grdAN[0, 0].Value.ToString());
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong(grdAN[0, 1].Value.ToString());
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong(grdAN[0, 2].Value.ToString());
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong(grdAN[0, 3].Value.ToString());
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        private void báoCáoTheoPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flocdatatonghopphong f = new flocdatatonghopphong();
            f.ShowDialog();
        }

        private void báoCáoTheoDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flocdatatonghopdv f = new flocdatatonghopdv();
            f.ShowDialog();

           
        }

        private void doanhThuDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flocdatachitietphong f = new flocdatachitietphong();
            f.ShowDialog();
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = "QuanLyKS.pdf";
            System.Diagnostics.Process.Start(filename);
        }

        private void báoCáoDanhMụcKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flocdatadanhmucKH f = new flocdatadanhmucKH();
            f.ShowDialog();
        }

        private void kếtThúcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fthongtinks f = new fthongtinks();
            f.ShowDialog();
        }

        private void thuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fthuephong f = new fthuephong();
            f.ShowDialog();
            sql = "Select idphong,loaiphong,trangthai from dbo.phong";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdAN.DataSource = dt;
            grdAN.Refresh();
            NapCT();
        }

        

        private void NapCT()
        {
            
            lbl1.Text = grdAN[0, 0].Value.ToString() + " " + grdAN[1, 0].Value.ToString();
            lbl2.Text = grdAN[0, 1].Value.ToString() + " " + grdAN[1, 1].Value.ToString();
            lbl3.Text = grdAN[0, 2].Value.ToString() + " " + grdAN[1, 2].Value.ToString();
            lbl4.Text = grdAN[0, 3].Value.ToString() + " " + grdAN[1, 3].Value.ToString();
            lbl5.Text = grdAN[0, 4].Value.ToString() + " " + grdAN[1, 4].Value.ToString();
            lbl6.Text = grdAN[0, 5].Value.ToString() + " " + grdAN[1, 5].Value.ToString();
            lbl7.Text = grdAN[0, 6].Value.ToString() + " " + grdAN[1, 6].Value.ToString();
            lbl8.Text = grdAN[0, 7].Value.ToString() + " " + grdAN[1, 7].Value.ToString();
            lbl9.Text = grdAN[0, 8].Value.ToString() + " " + grdAN[1, 8].Value.ToString();
            lbl10.Text = grdAN[0, 9].Value.ToString() + " " + grdAN[1, 9].Value.ToString();
            lbl11.Text = grdAN[0, 10].Value.ToString() + " " + grdAN[1, 10].Value.ToString();
            lbl12.Text = grdAN[0, 11].Value.ToString() + " " + grdAN[1, 11].Value.ToString();
            lbl13.Text = grdAN[0, 12].Value.ToString() + " " + grdAN[1, 12].Value.ToString();
            lbl14.Text = grdAN[0, 13].Value.ToString() + " " + grdAN[1, 13].Value.ToString();
            lbl15.Text = grdAN[0, 14].Value.ToString() + " " + grdAN[1, 14].Value.ToString();
            lbl16.Text = grdAN[0, 15].Value.ToString() + " " + grdAN[1, 15].Value.ToString();
            if (grdAN[2, 0].Value.ToString() == "Trống") { btn1.BackColor = Color.LimeGreen; btn1.Enabled = true; } else { btn1.BackColor = Color.Red; btn1.Enabled = false; }
            if (grdAN[2, 1].Value.ToString() == "Trống") { btn2.BackColor = Color.LimeGreen; btn2.Enabled = true; } else { btn2.BackColor = Color.Red; btn2.Enabled = false; }
            if (grdAN[2, 2].Value.ToString() == "Trống") { btn3.BackColor = Color.LimeGreen; btn3.Enabled = true; } else { btn3.BackColor = Color.Red; btn3.Enabled = false; }
            if (grdAN[2, 3].Value.ToString() == "Trống") { btn4.BackColor = Color.LimeGreen; btn4.Enabled = true; } else { btn4.BackColor = Color.Red; btn4.Enabled = false; }
            if (grdAN[2, 4].Value.ToString() == "Trống") { btn5.BackColor = Color.LimeGreen; btn5.Enabled = true; } else { btn5.BackColor = Color.Red; btn5.Enabled = false; }
            if (grdAN[2, 5].Value.ToString() == "Trống") { btn6.BackColor = Color.LimeGreen; btn6.Enabled = true; } else { btn6.BackColor = Color.Red; btn6.Enabled = false; }
            if (grdAN[2, 6].Value.ToString() == "Trống") { btn7.BackColor = Color.LimeGreen; btn7.Enabled = true; } else { btn7.BackColor = Color.Red; btn7.Enabled = false; }
            if (grdAN[2, 7].Value.ToString() == "Trống") { btn8.BackColor = Color.LimeGreen; btn8.Enabled = true; } else { btn8.BackColor = Color.Red; btn8.Enabled = false; }
            if (grdAN[2, 8].Value.ToString() == "Trống") { btn9.BackColor = Color.LimeGreen; btn9.Enabled = true; } else { btn9.BackColor = Color.Red; btn9.Enabled = false; }
            if (grdAN[2, 9].Value.ToString() == "Trống") { btn10.BackColor = Color.LimeGreen; btn10.Enabled = true; } else { btn10.BackColor = Color.Red; btn10.Enabled = false; }
            if (grdAN[2, 10].Value.ToString() == "Trống") { btn11.BackColor = Color.LimeGreen; btn11.Enabled = true; } else { btn11.BackColor = Color.Red; btn11.Enabled = false; }
            if (grdAN[2, 11].Value.ToString() == "Trống") { btn12.BackColor = Color.LimeGreen; btn12.Enabled = true; } else { btn12.BackColor = Color.Red; btn12.Enabled = false; }
            if (grdAN[2, 12].Value.ToString() == "Trống") { btn13.BackColor = Color.LimeGreen; btn13.Enabled = true; } else { btn13.BackColor = Color.Red; btn13.Enabled = false; }
            if (grdAN[2, 13].Value.ToString() == "Trống") { btn14.BackColor = Color.LimeGreen; btn14.Enabled = true; } else { btn14.BackColor = Color.Red; btn14.Enabled = false; }
            if (grdAN[2, 14].Value.ToString() == "Trống") { btn15.BackColor = Color.LimeGreen; btn15.Enabled = true; } else { btn15.BackColor = Color.Red; btn15.Enabled = false; }
            if (grdAN[2, 15].Value.ToString() == "Trống") { btn16.BackColor = Color.LimeGreen; btn16.Enabled = true; } else { btn16.BackColor = Color.Red; btn16.Enabled = false; }
            grbchinh.Refresh();

        }
    }
}
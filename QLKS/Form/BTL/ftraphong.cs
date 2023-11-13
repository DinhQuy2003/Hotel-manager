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
    public partial class ftraphong : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd;
        DataTable dt = new DataTable();
        DataTable dtdv = new DataTable();
        DataTable dtrpt = new DataTable();
        string sql, connstr;
        int tt, ttdv;
        int giaphong;
        int tienphong;

        // Gán tên nhân viên từ màn hình chính
        string tennv;
        public ftraphong(string strnhan)
        {
            InitializeComponent();
            tennv = strnhan;
        }
        private void ftraphong_Load(object sender, EventArgs e)
        {
            connstr = Bientoancuc.TCconnstr;
            conn.ConnectionString = connstr;
            conn.Open();
            rbtnthe.Checked = true;
        }

        string ngaydenhoadon;
        private void btndientt_Click_1(object sender, EventArgs e)
        {
            //Điền thông tin phòng và thông tin khách
            sql = "SELECT hoadonphong.idphong, sogiuong, loaiphong, giaphong, hoten, FORMAT (ngaycheckin, 'dd/MM/yyyy '), cmnd, DAY(GETDATE()) - DAY(ngaycheckin), idhdp FROM dbo.phong, dbo.khachhang, dbo.hoadonphong "
                 + "WHERE hoadonphong.idkh = khachhang.idkh AND hoadonphong.idphong = phong.idphong AND ngaycheckout IS NULL "
                 + "AND hoadonphong.idphong = '"+txtidphong.Text+"'";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            lblmaphong.Text = Convert.ToString(dt.Rows[0].ItemArray[0]);
            lblsogiuong.Text = Convert.ToString(dt.Rows[0].ItemArray[1]);
            lblloai.Text = Convert.ToString(dt.Rows[0].ItemArray[2]);
            lblgiatien.Text = Convert.ToString(dt.Rows[0].ItemArray[3]);
            lblhoten.Text = Convert.ToString(dt.Rows[0].ItemArray[4]);
            ngaydenhoadon = dt.Rows[0].ItemArray[5].ToString();
            lblngayden.Text = Convert.ToString(dt.Rows[0].ItemArray[5]);
            lblcmnd.Text = Convert.ToString(dt.Rows[0].ItemArray[6]);
            lblsongayo.Text = Convert.ToString(dt.Rows[0].ItemArray[7]);
            if (lblsongayo.Text == "0") lblsongayo.Text = "1";
            lblidhdphong.Text = Convert.ToString(dt.Rows[0].ItemArray[8]);
            /*
            int ngaydinum = Convert.ToInt16(DateTime.Now.Day);
            int ngaydennum = Convert.ToInt16(dt.Rows[0].ItemArray[7]);
            if (ngaydinum > ngaydennum)
                lblsongayo.Text = (ngaydinum - ngaydennum).ToString();
            else lblsongayo.Text = "1";
            */
            //Điền bảng dịch vụ
            sql = "SELECT dichvu.tendv, giadv, soluong,(giadv*soluong) AS 'tongtien', ngaygoi "
                 + "FROM dbo.hoadondv, dbo.dichvu "
                 + "WHERE idhdp IN (SELECT idhdp FROM dbo.hoadonphong WHERE idphong = '"+txtidphong.Text+"' AND ngaycheckout IS NULL) "
                 + "AND dichvu.tendv = hoadondv.tendv";
            da = new SqlDataAdapter(sql, conn);
            dtdv.Clear();
            da.Fill(dtdv);
            grddv.DataSource = dtdv;
            grddv.Refresh();

            //Tính tổng tiền
            giaphong = Convert.ToInt32(lblgiatien.Text);
            ttdv = 0;
            for (int i = 0; i <= grddv.RowCount - 2; i++)
            {
                ttdv = ttdv + Convert.ToInt32(grddv[3, i].Value.ToString());
            }
            tienphong = giaphong * (Convert.ToInt16(lblsongayo.Text));
            tt = tienphong + ttdv;
            txttongtien.Text = tt.ToString();
            txtkhachdua.Text = txttongtien.Text;
            txttralai.Text = "0";
            btndientt.Enabled = false;
        }
        private void gunaRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtkhachdua.Enabled = true;
            txtkhachdua.Focus();
        }

        private void gunaRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtkhachdua.Text = txttongtien.Text;
            txttralai.Text = "0";
            txtkhachdua.Enabled = false;
        }

       


        //Hàm đổi số thành tiền
        public static string NumberToText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
            string[] placeValues = new string[] { "", "Nghìn", "Triệu", "Tỷ" };
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "Một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "Lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "Lẻ " + result;
                        if (tens == 1) result = "Mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " Mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " Trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result + (suffix ? " Đồng" : "");
        }



        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            //Kiểm tra xem text khách đưa có phải số không
            //bool isNum = int.TryParse(txtkhachdua.Text, out _);
            bool isNum = true;
            if (rbtntienmat.Checked)
            {

                if (txtidphong.Text != "" && txttralai.Text != "" && txtkhachdua.Text != "")
                {
                    if (Convert.ToInt32(txttralai.Text) >= 0 && isNum)
                    {
                        if (MessageBox.Show("Thanh toán và in hóa đơn ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            // không thể có 2 phòng vừa có người và ngày check out lại null
                            sql = "UPDATE dbo.phong SET trangthai=N'Trống' WHERE idphong = '" + txtidphong.Text + "';" +
                                "UPDATE dbo.hoadonphong SET tongtien = '" + txttongtien.Text + "' WHERE idhdp = '" + lblidhdphong.Text + "';" +
                                "UPDATE dbo.hoadonphong SET tienphong = '" + tienphong.ToString() + "' WHERE idhdp = '" + lblidhdphong.Text + "';" +
                                "UPDATE dbo.hoadonphong SET tiendichvu = '" + ttdv.ToString() + "' WHERE idhdp = '" + lblidhdphong.Text + "';" +
                                "UPDATE dbo.hoadonphong SET ngaycheckout = GETDATE() WHERE idhdp = '" + lblidhdphong.Text + "';";
                            cmd = new SqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();


                            // In hóa đơn
                            sql = "SELECT dichvu.tendv, giadv as tiendichvu , soluong, (giadv * soluong) AS thanhtien FROM dbo.hoadondv, dbo.hoadonphong, dbo.dichvu " +
                                "WHERE hoadondv.idhdp = hoadonphong.idhdp " +
                                "AND dichvu.tendv = hoadondv.tendv " +
                                "AND hoadondv.idhdp = '" + lblidhdphong.Text + "' ";
                            da = new SqlDataAdapter(sql, conn);
                            da.Fill(dtrpt);


                            //Đổi số thành chữ
                            string strtongtien = NumberToText(tt);

                      

                            //Reset dữ liệu
                            lblmaphong.Text = "";
                            lblsogiuong.Text = "";
                            lblloai.Text = "";
                            lblgiatien.Text = "";
                            lblhoten.Text = "";
                            ngaydenhoadon = "";
                            lblngayden.Text = "";
                            lblcmnd.Text = "";
                            lblsongayo.Text = "";
                            lblidhdphong.Text = "";
                            txttongtien.Text = "";
                            txtkhachdua.Text = "";
                            txttralai.Text = "";
                            txtidphong.Text = "";


                        }
                    }
                    else
                    {
                        MessageBox.Show("Thông tin thanh toán không chính xác hoặc không đủ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền thông tin chính xác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (txtidphong.Text != "" && txttralai.Text != "")
                {
                    if (Convert.ToInt32(txttralai.Text) >= 0 && isNum)
                    {
                        if (MessageBox.Show("Thanh toán và in hóa đơn ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            // không thể có 2 phòng vừa có người và ngày check out lại null
                            sql = "UPDATE dbo.phong SET trangthai=N'Trống' WHERE idphong = '" + txtidphong.Text + "';" +
                                "UPDATE dbo.hoadonphong SET tongtien = '" + txttongtien.Text + "' WHERE idhdp = '" + lblidhdphong.Text + "';" +
                                "UPDATE dbo.hoadonphong SET tienphong = '" + tienphong.ToString() + "' WHERE idhdp = '" + lblidhdphong.Text + "';" +
                                "UPDATE dbo.hoadonphong SET tiendichvu = '" + ttdv.ToString() + "' WHERE idhdp = '" + lblidhdphong.Text + "';" +
                                "UPDATE dbo.hoadonphong SET ngaycheckout = GETDATE() WHERE idhdp = '" + lblidhdphong.Text + "';";
                            cmd = new SqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();


                            // In hóa đơn
                            sql = "SELECT dichvu.tendv, giadv as tiendichvu , soluong, (giadv * soluong) AS thanhtien FROM dbo.hoadondv, dbo.hoadonphong, dbo.dichvu " +
                                "WHERE hoadondv.idhdp = hoadonphong.idhdp " +
                                "AND dichvu.tendv = hoadondv.tendv " +
                                "AND hoadondv.idhdp = '" + lblidhdphong.Text + "' ";
                            da = new SqlDataAdapter(sql, conn);
                            da.Fill(dtrpt);


                            //Đổi số thành chữ
                            string strtongtien = NumberToText(tt);


                            //Reset dữ liệu
                            lblmaphong.Text = "";
                            lblsogiuong.Text = "";
                            lblloai.Text = "";
                            lblgiatien.Text = "";
                            lblhoten.Text = "";
                            ngaydenhoadon = "";
                            lblngayden.Text = "";
                            lblcmnd.Text = "";
                            lblsongayo.Text = "";
                            lblidhdphong.Text = "";
                            txttongtien.Text = "";
                            txtkhachdua.Text = "";
                            txttralai.Text = "";
                            txtidphong.Text = "";


                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng điền thông tin chính xác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền thông tin chính xác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void btnketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtidphong_TextChanged(object sender, EventArgs e)
        {
            btndientt.Enabled = true;
        }

        private void btntinhtien_Click(object sender, EventArgs e)
        {
            bool isNum = true;
            if (txttongtien.Text != "" && isNum && txtkhachdua.Text != "" )
            {
                txttralai.Text = (Convert.ToInt32(txtkhachdua.Text) - tt).ToString();
            }
            
        }

        private void ftraphong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtkhachdua_Leave(object sender, EventArgs e)
        {
            bool isNum = true;
            if (txttongtien.Text != "" && isNum && txtkhachdua.Text != "" )
            {
                txttralai.Text = (Convert.ToInt32(txtkhachdua.Text) - tt).ToString();
            }
            
          
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }

        private void LoadData(string data)
        {
            txtidphong.Text = "";
            txtidphong.Text = data;
        }


        private void btntimphong_Click_1(object sender, EventArgs e)
        {
            ftimkiemphong1 f = new ftimkiemphong1();
            f.TruyenData = new ftimkiemphong1.TruyenChoCha(LoadData);
            f.ShowDialog();
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;


namespace BTL
{
    public partial class fdmhddv : Form
    {
        public fdmhddv()
        {
            InitializeComponent();
        }



        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd;
        DataTable dt = new DataTable();
        DataTable dtrpt = new DataTable();
        string sql, connstr;
        int i;

        public fdmhddv(string idhdpstr) : this()
        {
            //nhanstr = idhdpstr;
            txtidhdp.Text = idhdpstr;
        }

        private void fdmhddv_Load(object sender, EventArgs e)
        {
            connstr = Bientoancuc.TCconnstr;
            conn.ConnectionString = connstr;
            if (txtidhdp.Text != "")
                sql = "SELECT hoadondv.idhdp, hoten, idphong, dbo.dichvu.tendv, soluong, giadv, (soluong * giadv) AS thanhtien, ngaygoi FROM dbo.hoadonphong,dbo.hoadondv,dbo.khachhang, dbo.dichvu   " +
                      " where hoadondv.idhdp = '" + txtidhdp.Text+ "' and hoadondv.idhdp = hoadonphong.idhdp " +
                      "AND hoadonphong.idkh = khachhang.idkh AND dichvu.tendv = hoadondv.tendv ";
            else
                sql = "SELECT hoadondv.idhdp, hoten, idphong, dbo.dichvu.tendv, soluong, giadv, (soluong * giadv) AS thanhtien, ngaygoi FROM dbo.hoadonphong,dbo.hoadondv,dbo.khachhang, dbo.dichvu   " +
                    "WHERE hoadondv.idhdp = hoadonphong.idhdp  AND hoadonphong.idkh = khachhang.idkh AND dichvu.tendv = hoadondv.tendv ";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdhoadon.DataSource = dt;
            if (dt.Rows.Count >= 1)
                NapCT();
        }

        private void btnloc_Click(object sender, EventArgs e)
        {
            sql = "SELECT hoadondv.idhdp, hoten, idphong, tendv, soluong, ngaygoi FROM dbo.hoadonphong,dbo.hoadondv,dbo.khachhang " +
                  "WHERE hoadondv.idhdp = hoadonphong.idhdp  AND hoadonphong.idkh = khachhang.idkh  " +
                  "AND "+cmbtentruong.Text+" LIKE N'%"+txtgiatriloc.Text+"%' ";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdhoadon.DataSource = dt;
            grdhoadon.Refresh();
        }

        private void grdhoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }

        private void btnketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn chắc chắn muốn xóa hóa đơn này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error,MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                sql = "DELETE FROM dbo.hoadondv WHERE idhddv = '" + txtidhddv.Text + "'";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                i = grdhoadon.CurrentRow.Index;
                grdhoadon.Rows.RemoveAt(i);
            }
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            flocdatatonghopdv f = new flocdatatonghopdv();
            f.ShowDialog();
        }

        private void fdmhddv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void tsbtnketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaIN_Click(object sender, EventArgs e)
        {
            PrintBill();

        }

        private void PrintBill()
        {
            // Get data from the selected row or any necessary data
            int idhddv = int.Parse(grdhoadon[0, i].Value.ToString());
            string idphong = grdhoadon[2, i].Value.ToString();
            string tendv = grdhoadon[3, i].Value.ToString();
            int soluong = int.Parse(grdhoadon[4, i].Value.ToString());

            // Create a new Word application
            Word.Application wordApp = new Word.Application();

            try
            {
                // Create a new document
                Word.Document doc = wordApp.Documents.Add();

                // Add a title
                Word.Paragraph title = doc.Paragraphs.Add();
                title.Range.Text = "Hóa Đơn Dịch Vụ";
                title.Range.Font.Bold = 1;
                title.Range.Font.Size = 16;
                title.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                title.Range.InsertParagraphAfter();

                // Add a table
                Word.Table table = doc.Tables.Add(title.Range, 4, 2);
                table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;


                // Populate the table with data
                table.Cell(1, 1).Range.Text = "ID";
                table.Cell(1, 2).Range.Text = idhddv.ToString();
                table.Cell(2, 1).Range.Text = "Room Number";
                table.Cell(2, 2).Range.Text = idphong;
                table.Cell(3, 1).Range.Text = "Service Name";
                table.Cell(3, 2).Range.Text = tendv;
                table.Cell(4, 1).Range.Text = "Quantity";
                table.Cell(4, 2).Range.Text = soluong.ToString();

                // Show the Word application
                wordApp.Visible = true;

                // Print the document
                doc.PrintOut();

                // Close the document
                doc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the Word application
                Marshal.ReleaseComObject(wordApp);
            }
        }
        public void NapCT()
        {
            i = grdhoadon.CurrentRow.Index;
            txtidhddv.Text = grdhoadon[0, i].Value.ToString();
            txtidhdp.Text = grdhoadon[2, i].Value.ToString();
            txttendv.Text = grdhoadon[3, i].Value.ToString();
            txtsl.Text = grdhoadon[4, i].Value.ToString();
        }
    }
}

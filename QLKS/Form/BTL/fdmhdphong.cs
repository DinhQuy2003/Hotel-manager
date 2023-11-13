using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;


namespace BTL
{
    public partial class fdmhdphong : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd;
        DataTable dt = new DataTable();
        string sql, connstr;
        int i;
        public fdmhdphong()
        {
            InitializeComponent();
        }

        private void fdmhdphong_Load(object sender, EventArgs e)
        {
            connstr = Bientoancuc.TCconnstr;
            conn.ConnectionString = connstr;
            conn.Open();
            sql = "SELECT idhdp,hoten,cmnd, idphong, ngaycheckin,ngaycheckout,tongtien FROM dbo.hoadonphong, dbo.khachhang WHERE hoadonphong.idkh = khachhang.idkh";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdhoadon.DataSource = dt;
            NapCT();
        }
      

        private void btnloc_Click(object sender, EventArgs e)
        {
            sql = "SELECT idhdp,hoten,cmnd, idphong, ngaycheckin,ngaycheckout,tongtien FROM dbo.hoadonphong, dbo.khachhang WHERE hoadonphong.idkh = khachhang.idkh " +
                  " and "+cmbtentruong.Text+" LIKE N'%"+txtgiatriloc.Text+"%'";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdhoadon.DataSource = dt;
            grdhoadon.Refresh();
        }

        private void btnxemchitiet_Click(object sender, EventArgs e)
        {
            fdmhddv f = new fdmhddv(txtidhdp.Text);
            f.ShowDialog();
        }

        private void btnchon_Click(object sender, EventArgs e)
        {
            NapCT();
        }

        public void NapCT()
        {
            i = grdhoadon.CurrentRow.Index;
            txtidhdp.Text = grdhoadon[0, i].Value.ToString();
            txthoten.Text = grdhoadon[1, i].Value.ToString();
            txtcmnd.Text = grdhoadon[2, i].Value.ToString();
            txtsophong.Text = grdhoadon[3, i].Value.ToString();
        }

        private void grdhoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }
        private void PrintInvoice()
        {
            // Get data from the selected row or any necessary data
            int idhdp = int.Parse(grdhoadon[0, i].Value.ToString());
            string hoten = grdhoadon[1, i].Value.ToString();
            string cmnd = grdhoadon[2, i].Value.ToString();
            string sophong = grdhoadon[3, i].Value.ToString();

            // Create a new Word application
            Word.Application wordApp = new Word.Application();

            try
            {
                // Create a new document
                Word.Document doc = wordApp.Documents.Add();

                // Add a title
                Word.Paragraph title = doc.Paragraphs.Add();
                title.Range.Text = "Hóa Đơn Phòng";
                title.Range.Font.Bold = 1;
                title.Range.Font.Size = 16;
                title.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                title.Range.InsertParagraphAfter();

                // Add a table
                Word.Table table = doc.Tables.Add(title.Range, 4, 2);
                table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

                // Populate the table
                table.Cell(1, 1).Range.Text = "ID:";
                table.Cell(1, 2).Range.Text = idhdp.ToString();
                table.Cell(2, 1).Range.Text = "Customer Name:";
                table.Cell(2, 2).Range.Text = hoten;
                table.Cell(3, 1).Range.Text = "ID Card:";
                table.Cell(3, 2).Range.Text = cmnd;
                table.Cell(4, 1).Range.Text = "Room Number:";
                table.Cell(4, 2).Range.Text = sophong;

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

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            PrintInvoice();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

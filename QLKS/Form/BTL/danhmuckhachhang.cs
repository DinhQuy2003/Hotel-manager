using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class danhmuckhachhang : Form
    {
        public DataTable DataSource { get; set; }

        public danhmuckhachhang()
        {
            InitializeComponent();
        }

        private void danhmuckhachhang_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = DataSource;

        }
    }
}

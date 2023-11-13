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
    public partial class Chitietphong : Form
    {
        public DataTable DataSource { get; set; }

        public Chitietphong()
        {
            InitializeComponent();
        }

        private void Chitietphong_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataSource;
        }
    }
}

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
    public partial class tonghopphong : Form
    {
        public tonghopphong()
        {
            InitializeComponent();
        }
        public DataTable DataSource { get; set; }

        private void tonghopphong_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataSource;
        }
    }
}

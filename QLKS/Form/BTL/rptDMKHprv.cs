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
    public partial class rptDMKHprv : Form
    {
        public rptDMKHprv(rptDMKH rpt)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = rpt;
        }

        private void rptDMKHprv_Load(object sender, EventArgs e)
        {

        }
    }
}

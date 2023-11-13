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
    public partial class rptchitietphongPrv : Form
    {
        public rptchitietphongPrv(rptchitietphong rpt)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = rpt;
        }

        private void rptdoanhthutheohoadonPrv_Load(object sender, EventArgs e)
        {

        }
    }
}

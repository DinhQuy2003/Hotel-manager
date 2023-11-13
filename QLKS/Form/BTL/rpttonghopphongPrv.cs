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
    public partial class rpttonghopphongPrv : Form
    {
        public rpttonghopphongPrv(rpttonghopphong rpt)
        {
            InitializeComponent();
            
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}

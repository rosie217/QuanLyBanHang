using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using qlbh.Control;
namespace qlbh
{
    public partial class FromCrystal : Form
    {
        public string MaHD;
        public FromCrystal()
        {
            InitializeComponent();
        }

        private void FromCrystal_Load(object sender, EventArgs e)
        {
            ReportDocument rp = new ReportDocument();
            String path = Path.GetFullPath(@"F:\code c#\qlbh\qlbh\qlbh\CrystalReport2.rpt");
            rp.Load(path);
            rp.RecordSelectionFormula = "{HDBan.MaHDban} = '" + MaHD+"'" ;
            crvHD.ReportSource = rp;
            crvHD.Refresh();
        }

        
    }
}

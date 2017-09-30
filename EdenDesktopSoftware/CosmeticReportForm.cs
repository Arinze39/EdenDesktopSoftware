using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdenDesktopSoftware
{
    public partial class CosmeticReportForm : Form
    {
        string TransID = "";
        public CosmeticReportForm(string transID)
        {
            InitializeComponent();
            this.TransID = transID;
        }

        private void CosmeticReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'EdenDbDataSet.CosmeticItemSold' table. You can move, or remove it, as needed.
            this.CosmeticItemSoldTableAdapter.FillByCosTransID(this.EdenDbDataSet.CosmeticItemSold,this.TransID);

            this.reportViewer1.RefreshReport();
        }
    }
}

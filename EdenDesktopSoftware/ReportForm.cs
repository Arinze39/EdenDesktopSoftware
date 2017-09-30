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
    public partial class ReportForm : Form
    {
        string TransID = "";
        public ReportForm(string transID)
        {
            InitializeComponent();
            this.TransID = transID;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'EdenDbDataSet.FashionItemSold' table. You can move, or remove it, as needed.
            this.FashionItemSoldTableAdapter.FillByTransID2(this.EdenDbDataSet.FashionItemSold,this.TransID);

            this.reportViewer1.RefreshReport();
        }
    }
}

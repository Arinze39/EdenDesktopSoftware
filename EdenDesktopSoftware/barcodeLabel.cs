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
    public partial class barcodeLabel : Form
    {
        public barcodeLabel()
        {
            InitializeComponent();
        }

        private void barcodeLabel_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(98, ParentForm.AutoScrollPosition.Y + 13);  //set x,y to where you want it to appear

        }
    }
}

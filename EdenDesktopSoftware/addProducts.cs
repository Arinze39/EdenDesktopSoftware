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
    public partial class addProducts : Form
    {
        string mprodName = "";
        double price = 0.0, subTotal = 0.0, Percent = 0.0;
        string ProdPic, ProdCode, ItemCode;
        EdenDbDataSetTableAdapters.ProduteDataTableAdapter getProdDetails = new EdenDbDataSetTableAdapters.ProduteDataTableAdapter();

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {           
            cosmeticSales cForm = (cosmeticSales)this.Owner.Owner;
            cForm.AddControls(ItemCode, mprodName, QtyTextBox.Text, PercentTextBox.Text, EquivalentTextBox.Text, PriceTextBox.Text, subTotal);
            cancelButton_Click(sender, e);
        }

        private void PercentTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(PercentTextBox.Text))
            {
                try
                {
                    if (!String.IsNullOrWhiteSpace(SubTotalTextBox.Text))
                    {
                        Percent = ((double.Parse(PercentTextBox.Text) / 100) * subTotal);
                        EquivalentTextBox.Text = "$" + (subTotal - Percent).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else EquivalentTextBox.Text = string.Empty;

        }

        private void QtyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(QtyTextBox.Text))
            {
                try
                {
                    subTotal = (price * Double.Parse(QtyTextBox.Text));
                    SubTotalTextBox.Text = "$" + subTotal.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else SubTotalTextBox.Text = "$0.0";
        }   
       
        public addProducts(string prodName)
        {
            InitializeComponent();
            this.mprodName = prodName;
            price = Convert.ToDouble(getProdDetails.getPrice(prodName));
            ProdPic = getProdDetails.getPicture(prodName).ToString();
            ItemCode = getProdDetails.getItemCode(prodName).ToString();
            ProdCode = getProdDetails.getProdCode(prodName).ToString();

        }

        private void addProducts_Load(object sender, EventArgs e)
        {
            try
            {
                PriceTextBox.Text = "$" + price.ToString();
                if (!string.IsNullOrEmpty(ProdCode))
                {
                    ProdCodeTextBox.Text = ProdCode;
                }
                if (!String.IsNullOrEmpty(ItemCode))
                {
                    ItemCodeLabel.Text = ItemCode;
                }
                DescLabel.Text = mprodName;
                if (!String.IsNullOrEmpty(ProdPic))
                {
                    pictureBox1.Image = Image.FromFile(ProdPic);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        
           
    }
}

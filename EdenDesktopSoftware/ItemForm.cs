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
    public partial class ItemForm : Form
    {
        int Qty = 0;
        double price = 0.0, percent = 0.0, SubTotal = 0.0;
        public bool add = false;
        string Desc2 = "$0.00";
        string Desc1 = "$0.00";

        public ItemForm()
        {
            InitializeComponent();
        }

        private void QtyTextbox_TextChanged(object sender, EventArgs e)
        {
            if (QtyTextbox.Text == string.Empty || QtyTextbox.Text == "0")
                DiscountTextbox.Enabled = false;

            if (PriceTextbox.Text != string.Empty)
            {
                try
                {
                    Qty = Convert.ToInt32(QtyTextbox.Text);
                    price = Convert.ToDouble(PriceTextbox.Text.Substring(1));
                    SubTotal = (Qty * price);
                    SubTotalTextbox.Text = SubTotal.ToString("C");
                    DiscountTextbox.Enabled = true;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Input field cannot be empty");

        }

        private void DiscountTextbox_TextChanged(object sender, EventArgs e)
        {
            double subTotal = 0.0;
            if (!String.IsNullOrEmpty(DiscountTextbox.Text))
            {
                try
                {
                    if (!String.IsNullOrEmpty(SubTotalTextbox.Text))
                    {
                        percent = (double.Parse(DiscountTextbox.Text) / 100) * this.SubTotal;
                        Desc2 = percent.ToString("C");
                        EquivalentTextbox.Text = Desc2;
                        subTotal = this.SubTotal - percent;
                        SubTotalTextbox.Text = subTotal.ToString("C");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                EquivalentTextbox.Text = string.Empty;
                SubTotalTextbox.Text = this.SubTotal.ToString("C");
            }

        }

        private void CancelButton1_Click(object sender, EventArgs e)
        {
            add = false;
            this.Close();
        }

        private void panel1_Enter(object sender, EventArgs e)
        {
            foreach (Button btn in panel1.Controls)
            {
                btn.Click += new EventHandler(btn_Click);
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            if (ActiveControl.Text != "CLR")
            {
                Qty = Convert.ToInt32(ActiveControl.Text);
                QtyTextbox.Text = Qty.ToString(); ;
            }
            else QtyTextbox.Text = "0";

        }

        private void AddButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SubTotalTextbox.Text))
            {
                this.SubTotal = double.Parse(SubTotalTextbox.Text.Substring(1));
                Desc1 = DiscountTextbox.Text;
                price = Convert.ToDouble(PriceTextbox.Text.Substring(1));
                Desc2 = EquivalentTextbox.Text;
                Qty = Convert.ToInt32(QtyTextbox.Text);
                add = true;


            }
            this.Close();
        }

        private void PriceTextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (PriceTextbox.Text.Contains('$'))
                {
                    price = Convert.ToDouble(PriceTextbox.Text.Substring(1));
                }
                else price = Convert.ToDouble(PriceTextbox.Text);

                this.SubTotal = price * Qty;
                SubTotalTextbox.Text = this.SubTotal.ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ActiveControl.Focus();
            }
        }

        private void SubTotalTextbox_TextChanged(object sender, EventArgs e)
        {
            DiscountTextbox_TextChanged(sender, e);
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            QtyTextbox.Focus();
            PriceTextbox.Text = "$10.0";
        }

        public string[] getValues()
        {
            string[] values = new string[5];
            values[0] = Qty.ToString();
            values[1] = Desc1;
            values[2] = Desc2;
            values[3] = price.ToString();
            values[4] = SubTotal.ToString();
            return values;
        }
    }
}

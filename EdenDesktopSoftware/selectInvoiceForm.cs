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
    public partial class selectInvoiceForm : Form
    {
        private bool Clicked = false, FLAG = false;
        string mID = "";
        EdenDbDataSetTableAdapters.FashionItemSoldTableAdapter getItem = new EdenDbDataSetTableAdapters.FashionItemSoldTableAdapter();
        private object[,] Selected;

        public bool getClicked()
        {
            return Clicked;
        }

        public object[,] getSelectedItems()
        {
            return Selected;
        }

        public string getID()
        {
            return mID;
        }

        public static object[,] ToArray(DataTable data)
        {
            var ret = Array.CreateInstance(typeof(object), data.Rows.Count, data.Columns.Count) as object[,];

            for (int i = 0; i < data.Rows.Count; i++)
            {
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    ret[i, j] = data.Rows[i][j];
                }
            }

            return ret;
        }

        public selectInvoiceForm(bool flag)
        {
            InitializeComponent();
            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            this.FLAG = flag;
        }

        public void RemoveDuplicate(DataGridView grv)
        {
            for (int currentRow = 0; currentRow < grv.Rows.Count - 1; currentRow++)
            {
                DataGridViewRow rowToCompare = grv.Rows[currentRow];

                for (int otherRow = currentRow + 1; otherRow < grv.Rows.Count; otherRow++)
                {
                    DataGridViewRow row = grv.Rows[otherRow];

                    bool duplicateRow = true;

                    if (!rowToCompare.Cells[0].Value.Equals(row.Cells[0].Value))
                    {
                        duplicateRow = false;
                    }


                    if (duplicateRow)
                    {
                        grv.Rows.Remove(row);
                        otherRow--;
                    }
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (FLAG == true)
            {
                dataGridView1.ClearSelection();
                FLAG = false;
            }
            else
            {
                if (dataGridView1.Focused)
                {
                    int Row = this.dataGridView1.CurrentCell.RowIndex;
                    mID = this.dataGridView1.Rows[Row].Cells[0].Value.ToString();                    
                    Selected = ToArray(getItem.GetDataByTransID(mID));
                    Clicked = true;
                    this.Close();
                }
            }
        }

        private void selectInvoiceForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'edenDbDataSet.FashionItemSold' table. You can move, or remove it, as needed.
            this.fashionItemSoldTableAdapter.Fill(this.edenDbDataSet.FashionItemSold);
            RemoveDuplicate(dataGridView1);
        }
    }
}

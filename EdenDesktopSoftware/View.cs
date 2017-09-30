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
    public partial class View : Form
    {
        EdenDbDataSetTableAdapters.EmployeeDataTableAdapter GetEmployeeData = new EdenDbDataSetTableAdapters.EmployeeDataTableAdapter();
        EdenDbDataSetTableAdapters.ProduteDataTableAdapter GetProductData = new EdenDbDataSetTableAdapters.ProduteDataTableAdapter();

        private bool FLAG = false, Clicked = false;
        public bool tab0 = false, tab1 = false;
        private string[] mProductData, mEmployeeData;
        string mID = "";

        public void setClicked(bool clicked)
        {
            this.Clicked = clicked;
        }
        public void setFlag(bool flag)
        {
            this.FLAG = flag;
        }
        public bool getClicked()
        {
            return this.Clicked;
        }
        public string[] getmProductData()
        {
            return mProductData;
        }

        public string[] getmEmployeeData()
        {
            return mEmployeeData;
        }

        public string getmID()
        {
            return mID;
        }

        private void View_FormClosing(object sender, FormClosingEventArgs e)
        {
            tab1 = false;
            tab0 = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {           
                if (tab0 == true)
                {
                    if (dataGridView1.Focused)
                    {
                        Clicked = true;
                        int Row = this.dataGridView1.CurrentCell.RowIndex;
                        mID = this.dataGridView1.Rows[Row].Cells[0].Value.ToString();
                        mEmployeeData = GetData(false, mID, 8);
                        this.Close();
                    }
                }            
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {                     
                if (tab1 == true)
                {
                    if (dataGridView2.Focused)
                    {
                        {
                            Clicked = true;
                            int Row = this.dataGridView2.CurrentCell.RowIndex;
                            mID = this.dataGridView2.Rows[Row].Cells[0].Value.ToString();
                            mProductData = GetData(true, mID, 9);
                            this.Close();
                        }

                    }
                }            
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            
        }

        private string[] GetData(bool IsProduct, string ID, int count)
        {
            //DataColumn dataColumn;
            DataTable dataTable;
            String[] result = new String[count];

            if (IsProduct)
            {

                dataTable = GetProductData.GetDataByProduct_ID(ID);

                result = dataTable
                    .AsEnumerable()
                    .SelectMany(row => new string[]{
                        row["ProductCode"].ToString(),
                        row["ProductName"].ToString(),
                        row["ItemCode"].ToString(),
                        row["Price"].ToString(),
                        row["Quantity"].ToString(),
                        row["Description"].ToString(),
                        row["MainCategory"].ToString(),
                        row["SubCategory"].ToString(),
                        row["ProductPicture"].ToString()})
                    .ToArray();
            }
            else
            {
                dataTable = GetEmployeeData.GetDataByEmployee_ID(ID);
                result = dataTable
                   .AsEnumerable()
                   .SelectMany(row => new string[]{
                        row["FirstName"].ToString(),
                        row["LastName"].ToString(),
                        row["StartDate"].ToString(),
                        row["Gender"].ToString(),
                        row["DOB"].ToString(),
                        row["Address"].ToString(),
                        row["Mobile"].ToString(),
                        row["EmployeePicture"].ToString()})
                   .ToArray();

            }
            return result;

        }

        public View()
        {
            InitializeComponent();
            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dataGridView2.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

        private void View_Load(object sender, EventArgs e)
        {           
            // TODO: This line of code loads data into the 'edenDbDataSet.ProduteData' table. You can move, or remove it, as needed.
            this.produteDataTableAdapter.Fill(this.edenDbDataSet.ProduteData);
            // TODO: This line of code loads data into the 'edenDbDataSet.EmployeeData' table. You can move, or remove it, as needed.
            this.employeeDataTableAdapter.Fill(this.edenDbDataSet.EmployeeData);
            if (FLAG == true)
            {
                dataGridView2.ClearSelection();
                dataGridView1.ClearSelection();
                FLAG = false;
            }



        }
    }
}

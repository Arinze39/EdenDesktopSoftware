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
    public partial class SalesMainReportForm : Form
    {
        public SalesMainReportForm()
        {
            InitializeComponent();
        }

        private void createItemsComponents()
        {
            DataGridViewTextBoxColumn iD = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn description = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn desc1 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn desc2 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn price = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn total = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn hST = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn subTotal = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn allTotal = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn amountPaid = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn balanceRemaining = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn employee = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn transactionID = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn mDate = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn quantity = new DataGridViewTextBoxColumn();

            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
            iD,
            transactionID,
            description,
            quantity,
            desc1,
            desc2,
            price,
            total,
            hST,
            subTotal,
            allTotal,
            amountPaid,
            balanceRemaining,
            employee,
            mDate,
            });

            // 
            // iD
            // 
            iD.DataPropertyName = "ID";
            iD.HeaderText = "ID";
            iD.Name = "iD";
            iD.ReadOnly = true;
            // 
            // description
            // 
            description.DataPropertyName = "Description";
            description.HeaderText = "Description";
            description.Name = "description";
            description.ReadOnly = true;
            // 
            // desc1
            // 
            desc1.DataPropertyName = "Desc1";
            desc1.HeaderText = "Desc1";
            desc1.Name = "desc1";
            desc1.ReadOnly = true;
            // 
            // desc2
            // 
            desc2.DataPropertyName = "Desc2";
            desc2.HeaderText = "Desc2";
            desc2.Name = "desc2";
            desc2.ReadOnly = true;
            // 
            // price
            // 
            price.DataPropertyName = "Price";
            price.HeaderText = "Price";
            price.Name = "price";
            price.ReadOnly = true;
            // 
            // total
            // 
            total.DataPropertyName = "Total";
            total.HeaderText = "Total";
            total.Name = "total";
            total.ReadOnly = true;
            // 
            // hST
            // 
            hST.DataPropertyName = "HST";
            hST.HeaderText = "HST";
            hST.Name = "hST";
            hST.ReadOnly = true;
            // 
            // subTotal
            // 
            subTotal.DataPropertyName = "SubTotal";
            subTotal.HeaderText = "SubTotal";
            subTotal.Name = "subTotal";
            subTotal.ReadOnly = true;
            // 
            // allTotal
            // 
            allTotal.DataPropertyName = "AllTotal";
            allTotal.HeaderText = "AllTotal";
            allTotal.Name = "allTotal";
            allTotal.ReadOnly = true;
            // 
            // amountPaid
            // 
            amountPaid.DataPropertyName = "AmountPaid";
            amountPaid.HeaderText = "AmountPaid";
            amountPaid.Name = "amountPaid";
            amountPaid.ReadOnly = true;
            // 
            // balanceRemaining
            // 
            balanceRemaining.DataPropertyName = "BalanceRemaining";
            balanceRemaining.HeaderText = "BalanceRemaining";
            balanceRemaining.Name = "balanceRemaining";
            balanceRemaining.ReadOnly = true;
            // 
            // employee
            // 
            employee.DataPropertyName = "Employee";
            employee.HeaderText = "Employee";
            employee.Name = "employee";
            employee.ReadOnly = true;
            // 
            // transactionID
            // 
            transactionID.DataPropertyName = "TransactionID";
            transactionID.HeaderText = "TransactionID";
            transactionID.Name = "transactionID";
            transactionID.ReadOnly = true;
            // 
            // mDate
            // 
            mDate.DataPropertyName = "mDate";
            mDate.HeaderText = "Date";
            mDate.Name = "mDate";
            mDate.ReadOnly = true;
            // 
            // quantity
            // 
            quantity.DataPropertyName = "Quantity";
            quantity.HeaderText = "Quantity";
            quantity.Name = "quantity";
            quantity.ReadOnly = true;
           
        }

        private void SalesMainReportForm_Load(object sender, EventArgs e)
        {           
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(this.AutoScrollPosition.X + 98, this.AutoScrollPosition.Y + 13);  //set x,y to where you want it to appear
        }

        private void CITbutton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            createItemsComponents();
            this.cosmeticItemSoldTableAdapter.FillByDate(this.edenDbDataSet.CosmeticItemSold,dateTimePickerFrom.Text.ToString(),dateTimePickerTo.Text.ToString());
            dataGridView1.DataSource = cosmeticItemSoldBindingSource;
            
        }

        private void FISbutton_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = DateTime.Parse(dateTimePickerFrom.Text);
            DateTime dateTo = DateTime.Parse(dateTimePickerTo.Text);
            dataGridView1.DataSource = null;
            createItemsComponents();
            this.fashionItemSoldTableAdapter.FillByDate(this.edenDbDataSet.FashionItemSold,dateFrom,dateTo);
            dataGridView1.DataSource = fashionItemSoldBindingSource;
        }

        private void RITbutton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void ByDoBbutton_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = DateTime.Parse(dateTimePickerFrom.Text);
            DateTime dateTo = DateTime.Parse(dateTimePickerTo.Text);
            dataGridView1.DataSource = null;
            this.employeeDataTableAdapter.FillByDOB(this.edenDbDataSet.EmployeeData, dateFrom, dateTo);
            dataGridView1.DataSource = employeeDataBindingSource;
        }

        private void ByStartDatebutton_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = DateTime.Parse(dateTimePickerFrom.Text);
            DateTime dateTo = DateTime.Parse(dateTimePickerTo.Text);
            dataGridView1.DataSource = null;
            this.employeeDataTableAdapter.FillByStartDate(this.edenDbDataSet.EmployeeData, dateFrom, dateTo);
            dataGridView1.DataSource = employeeDataBindingSource;
        }
    }
}

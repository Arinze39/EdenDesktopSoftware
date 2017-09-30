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
    public partial class Admin : Form
    {
        EdenDbDataSetTableAdapters.EmployeeDataTableAdapter AddEmployee = new EdenDbDataSetTableAdapters.EmployeeDataTableAdapter();
        EdenDbDataSetTableAdapters.ProduteDataTableAdapter AddProduct = new EdenDbDataSetTableAdapters.ProduteDataTableAdapter();

        public bool click = false;
        string ProductPicture = "", employeePicture = "", ProductID = "", EmployeeID = "";

        private String generateID(bool Product, string ID)
        {

            int nID = 0;

            if (Product)
            {
                if (string.IsNullOrEmpty(ID))
                {
                    try
                    {
                        int count = (int)AddProduct.CountProd();
                        if (count == 0)
                            return "P-001";

                        //get the userID of the last person 
                        ID = AddProduct.GetProdID(count).ToString();

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "ERROR"); }
                }

                //convert the userID to integer starting from the second character and increment the ID
                nID = Convert.ToInt32(ID.Substring(2)); nID++;

                //if less than 3 characters
                if (nID.ToString().Length < 3)
                {
                    //reconvert to string adding leading zeroes and letter 'P'
                    ID = ("P-" + nID.ToString("D3"));
                }
                //reconvert to string adding letter 'P' with no leading zeroes
                else ID = ("P-" + nID.ToString());
            }
            else
            {
                if (string.IsNullOrEmpty(ID))
                {
                    try
                    {
                        int count = (int)AddEmployee.CountEmp();
                        if (count == 0)
                            return "E-001";

                        //get the userID of the last person 
                        ID = AddEmployee.GetEmp_ID(count).ToString();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "ERROR"); }
                }
                //convert the userID to integer starting from the second character and increment the ID
                nID = Convert.ToInt32(ID.Substring(2));
                nID++;

                //if less than 3 characters
                if (nID.ToString().Length < 3)
                {
                    //reconvert to string adding leading zeroes and letter 'E'
                    ID = ("E-" + nID.ToString("D3"));
                }
                //reconvert to string adding letter 'E' with no leading zeroes
                else ID = ("E-" + nID.ToString());
            }

            return ID;

        }

        private string getPicture()
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            FileDialog.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNG|*png";
            FileDialog.RestoreDirectory = true;

            string image = "";
            if (FileDialog.ShowDialog(this) == DialogResult.OK)
            {
                image = FileDialog.FileName;
            }
            FileDialog.Dispose();
            return image;

        }

        private string saveDatabase()
        {
            string filename = "";
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                save.Filter = "All Files(*.)|*.*|Excel Files(*.xlsx)|*.xlsx";
                save.RestoreDirectory = true;

                if (save.ShowDialog(this) == DialogResult.OK)
                    filename = save.FileName;
                save.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return filename;
        }

        private void employeeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EdenDbDataSetTableAdapters.EmployeeDataTableAdapter employee = new EdenDbDataSetTableAdapters.EmployeeDataTableAdapter();

            DataTable dt = new DataTable();
            dt = employee.GetData();
            string filename = saveDatabase();
            if (filename != "")
                dt.ExportToExcel(filename,"EmployeeData");
        }

        private void productDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EdenDbDataSetTableAdapters.ProduteDataTableAdapter product = new EdenDbDataSetTableAdapters.ProduteDataTableAdapter();

            DataTable dt = new DataTable();
            dt = product.GetData();
            string filename = saveDatabase();
            if (filename != "")
                dt.ExportToExcel(filename, "ProductData");
        }

        private void fashionItemSoldToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            EdenDbDataSetTableAdapters.FashionItemSoldTableAdapter fashion = new EdenDbDataSetTableAdapters.FashionItemSoldTableAdapter();

            DataTable dt = new DataTable();
            dt = fashion.GetData();
            string filename = saveDatabase();
            if (filename != "")
                dt.ExportToExcel(filename,"Fashion Items Sold");
        }

        private void cosmeticItemSoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EdenDbDataSetTableAdapters.CosmeticItemSoldTableAdapter cosmetic = new EdenDbDataSetTableAdapters.CosmeticItemSoldTableAdapter();

            DataTable dt = new DataTable();
            dt = cosmetic.GetData();
            string filename = saveDatabase();
            if (filename != "")
                dt.ExportToExcel(filename,"Cosmetic Items Sold");
        }

        private void employeeBrowseButton_Click(object sender, EventArgs e)
        {
            try
            {
                string image = getPicture();
                if (image != "")
                {
                    employeePictureBox.Image = Image.FromFile(image);
                    employeePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    employeePicture = image;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open this image.", "ERROR");
            }
        }

        private void employeeRemoveButton_Click(object sender, EventArgs e)
        {
            employeePictureBox.Image = Properties.Resources.download;
        }

        private void employeeNewButton_Click(object sender, EventArgs e)
        {
            first_NameTextBox.Clear();
            last_NameTextBox.Clear();
            genderComboBox.Text = "";
            addressTextBox.Clear();
            mobileTextBox.Clear();
            employeePictureBox.Image = Properties.Resources.download;
        }

        private void employeeSaveButton_Click(object sender, EventArgs e)
        {
            string FirstName, LastName, Gender, Address, Mobile;
            DateTime StartDate, DOB;

            FirstName = first_NameTextBox.Text;
            LastName = last_NameTextBox.Text;
            Gender = genderComboBox.Text;
            Address = addressTextBox.Text;
            Mobile = mobileTextBox.Text;
            StartDate = Convert.ToDateTime(start_DateDateTimePicker.Text);
            DOB = Convert.ToDateTime(date_of_BirthDateTimePicker.Text);


            try
            {
                if (FirstName != String.Empty && LastName != String.Empty && Gender != String.Empty)
                {
                    //this.tableAdapterManager.UpdateAll(this.database1DataSet);
                    AddEmployee.Insert(FirstName.ToUpper(), LastName.ToUpper(), StartDate, Gender, DOB, Address, Mobile, EmployeeID, employeePicture);
                    //backgroundWorker1.RunWorkerAsync();
                    MessageBox.Show("Files saved successfully", "STATUS");
                    employeeNewButton_Click(sender, e); EmployeeID = generateID(false, EmployeeID); employee_IDTextBox.Text = EmployeeID;
                }
                else MessageBox.Show("Fields cannot be empty...", "ERROR");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while saving to database. Please try again later.", "ERROR");
            }
        }

        private void employeeUpdateButton_Click(object sender, EventArgs e)
        {
            string FirstName, LastName, Gender, Address, Mobile;
            DateTime StartDate, DOB;

            FirstName = first_NameTextBox.Text;
            LastName = last_NameTextBox.Text;
            Gender = genderComboBox.Text;
            Address = addressTextBox.Text;
            Mobile = mobileTextBox.Text;
            StartDate = Convert.ToDateTime(start_DateDateTimePicker.Text);
            DOB = Convert.ToDateTime(date_of_BirthDateTimePicker.Text);
            string mID = employee_IDTextBox.Text;

            try
            {
                if (FirstName != String.Empty && LastName != String.Empty && Gender != String.Empty)
                {

                    this.AddEmployee.UpdateEmployeeQuery(FirstName.ToUpper(), LastName.ToUpper(), StartDate, Gender, DOB, Address, Mobile, employeePicture, mID);
                    MessageBox.Show("Files updated successfully", "STATUS");
                    employeeNewButton_Click(sender, e); EmployeeID = generateID(false, mID); employee_IDTextBox.Text = EmployeeID;
                    employeeDeleteButton.Enabled = false;
                    employeeUpdateButton.Enabled = false;
                }
                else MessageBox.Show("Fields cannot be empty...", "ERROR");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occured while updating to database. Please try again later.", "ERROR");
            }
        }

        private void employeeDeleteButton_Click(object sender, EventArgs e)
        {
            string mID = employee_IDTextBox.Text;
            try
            {
                this.AddEmployee.DeleteEmployeeQuery(mID);
                System.Windows.Forms.MessageBox.Show("Files deleted successfully", "STATUS");
                employeeNewButton_Click(sender, e); EmployeeID = generateID(false, mID); employee_IDTextBox.Text = EmployeeID;
                employeeDeleteButton.Enabled = false;
                employeeUpdateButton.Enabled = false;
            }
            catch (Exception ex)
            {
               MessageBox.Show("An Error occured while deleting from database. Please try again later.", "ERROR");
            }
        }

        private void employeeGetDataButton_Click(object sender, EventArgs e)
        {
            View view = new View();
            view.setFlag(true);
            view.setClicked(false);
            view.tabControl1.SelectTab(0);
            view.tab0 = true;
            view.tab1 = false;

            view.ShowDialog(this);

            if (view.getClicked() == true)
            {
                string[] returnValue = view.getmEmployeeData();
                string mID = view.getmID();

                employee_IDTextBox.Text = mID;
                first_NameTextBox.Text = returnValue[0];
                last_NameTextBox.Text = returnValue[1];
                start_DateDateTimePicker.Text = returnValue[2];
                genderComboBox.Text = returnValue[3];
                date_of_BirthDateTimePicker.Text = returnValue[4];
                addressTextBox.Text = returnValue[5];
                mobileTextBox.Text = returnValue[6];
                if (returnValue[7] != "")
                {
                    employeePictureBox.Image = Image.FromFile(returnValue[7]);
                    employeePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    employeePicture = returnValue[7];
                }
                else employeePictureBox.Image = Properties.Resources.download;

                employeeUpdateButton.Enabled = true;
                employeeDeleteButton.Enabled = true;

            }
        }

        private void employeeCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BrowsePictureButton_Click(object sender, EventArgs e)
        {
            try
            {
                string image = getPicture();
                if (image != "")
                {
                    productPictureBox.Image = Image.FromFile(image);
                    productPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    ProductPicture = image;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open this image.", "ERROR");
            }
        }

        private void RemoveProdButton_Click(object sender, EventArgs e)
        {
            productPictureBox.Image = Properties.Resources.images;
        }

        private void ProdClearButton_Click(object sender, EventArgs e)
        {
            product_NameTextBox.Clear();
            product_CodeTextBox.Clear();
            item_UPC_CodeTextBox.Clear();
            descriptionTextBox.Clear();
            qantityTextBox.Clear();
            priceTextBox.Clear();
            productPictureBox.Image = Properties.Resources.images;
        }

        private void ProdSaveButton_Click(object sender, EventArgs e)
        {
            string ProductName, ProductCode, ItemCode, Description, price, subCategory, MainCategory;
            decimal ProductPrice;
            int Quantity;

            ProductName = product_NameTextBox.Text;
            ProductCode = product_CodeTextBox.Text;
            subCategory = sub_CategoryComboBox.Text;
            MainCategory = main_CategoryComboBox.Text;
            ItemCode = item_UPC_CodeTextBox.Text.ToString(); ;
            Description = descriptionTextBox.Text;



            try
            {
                ProductPrice = decimal.Parse(priceTextBox.Text); price = ProductPrice.ToString(); Quantity = Int32.Parse(qantityTextBox.Text);
                if (ProductName != String.Empty && ProductCode != String.Empty && subCategory != string.Empty && MainCategory != string.Empty)
                {
                    AddProduct.Insert(ProductName, ProductCode, ItemCode, price, Quantity.ToString(), Description, ProductPicture, MainCategory.ToLower(), subCategory.ToLower(), ProductID);
                    MessageBox.Show("Files saved successfully", "STATUS");
                    ProdClearButton_Click(sender, e); ProductID = generateID(true, ProductID); product_IDTextBox.Text = ProductID;
                }
                else MessageBox.Show("Fields cannot be empty...", "ERROR");
            }
            catch (Exception ex)//"Error occured while saving to database. Please try again later."
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void UpdateProdButton_Click(object sender, EventArgs e)
        {
            string ProductName, ProductCode, ItemCode, Description, price, subCategory, MainCategory;
            decimal ProductPrice;
            int Quantity;

            ProductName = product_NameTextBox.Text;
            ProductCode = product_CodeTextBox.Text;
            subCategory = sub_CategoryComboBox.Text;
            MainCategory = main_CategoryComboBox.Text;
            ItemCode = item_UPC_CodeTextBox.Text.ToString(); ;
            Description = descriptionTextBox.Text;
            string mID = product_IDTextBox.Text;
            try
            {
                ProductPrice = decimal.Parse(priceTextBox.Text); price = ProductPrice.ToString(); Quantity = Int32.Parse(qantityTextBox.Text);
                if (ProductName != String.Empty && ProductCode != String.Empty && subCategory != string.Empty && MainCategory != string.Empty)
                {

                    AddProduct.UpdateProductQuery(ProductName, ProductCode, ItemCode, price, Quantity.ToString(), Description, ProductPicture, MainCategory.ToLower(), subCategory.ToLower(), mID);
                    MessageBox.Show("Files updated successfully", "STATUS");
                    ProdClearButton_Click(sender, e); ProductID = generateID(true, mID); product_IDTextBox.Text = ProductID;
                    UpdateProdButton.Enabled = false;
                    DeleteProdButton.Enabled = false;
                }
                else MessageBox.Show("Fields cannot be empty...", "ERROR");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occured while updating to database. Please try again later.", "ERROR");
            }
        }

        private void DeleteProdButton_Click(object sender, EventArgs e)
        {
            string mID = product_IDTextBox.Text;
            try
            {
                this.AddProduct.DeleteProdQuery(mID);
                System.Windows.Forms.MessageBox.Show("Files deleted successfully", "STATUS");
                ProdClearButton_Click(sender, e); ProductID = generateID(true, mID); product_IDTextBox.Text = ProductID;
                UpdateProdButton.Enabled = false;
                DeleteProdButton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occured while deleting from database. Please try again later.", "ERROR");
            }
        }

        private void GetProdButton_Click(object sender, EventArgs e)
        {
            View view = new View();
            view.setFlag(true);
            view.setClicked(false);
            view.tabControl1.SelectTab(1);
            view.tab0 = false;
            view.tab1 = true;

            view.ShowDialog();

            if (view.getClicked() == true)
            {
                string[] returnValue = view.getmProductData();
                string mID = view.getmID();

                product_IDTextBox.Text = mID;
                product_CodeTextBox.Text = returnValue[0];
                product_NameTextBox.Text = returnValue[1];
                item_UPC_CodeTextBox.Text = returnValue[2];
                priceTextBox.Text = returnValue[3];
                qantityTextBox.Text = returnValue[4];
                descriptionTextBox.Text = returnValue[5];
                main_CategoryComboBox.Text = returnValue[6];
                sub_CategoryComboBox.Text = returnValue[7];
                if (returnValue[8] != "")
                {
                    productPictureBox.Image = Image.FromFile(returnValue[8]);
                    productPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    ProductPicture = returnValue[8];
                }
                else productPictureBox.Image = Properties.Resources.images;


                UpdateProdButton.Enabled = true;
                DeleteProdButton.Enabled = true;
            }
        }

        private void CloseProdButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            employee_IDTextBox.Text = EmployeeID;
            product_IDTextBox.Text = ProductID;
        }

        private void restaurantItemsSoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EdenDbDataSetTableAdapters.RestuarantItemSoldTableAdapter restuarant = new EdenDbDataSetTableAdapters.RestuarantItemSoldTableAdapter();

            DataTable dt = new DataTable();
            dt = restuarant.GetData();
            string filename = saveDatabase();
            if (filename != "")
                dt.ExportToExcel(filename,"Restuarant Items Sold");
        }

        public Admin()
        {
            InitializeComponent();
            ProductID = generateID(true, "");
            EmployeeID = generateID(false, "");
        }

        private void viewDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View view = new View();
            view.ShowDialog();
        }
    }

    public static class My_DataTable_Extensions
    {
        /// <summary>
        /// Export DataTable to Excel file
        /// </summary>
        /// <param name="DataTable">Source DataTable</param>
        /// <param name="ExcelFilePath">Path to result file name</param>
        public static void ExportToExcel(this DataTable DataTable, string ExcelFilePath = null, string DbName = null)
        {
            try
            {
                int ColumnsCount;

                if (DataTable == null || (ColumnsCount = DataTable.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook
                Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                Excel.Workbooks.Add();

                // single worksheet
                Microsoft.Office.Interop.Excel._Worksheet Worksheet = Excel.ActiveSheet;

                object[] Header = new object[ColumnsCount];

                // column headings               
                for (int i = 0; i < ColumnsCount; i++)
                    Header[i] = DataTable.Columns[i].ColumnName;

                Microsoft.Office.Interop.Excel.Range HeaderRange = Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, ColumnsCount]));
                HeaderRange.Value = Header;
                HeaderRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                HeaderRange.Font.Bold = true;
                // DataCells
                int RowsCount = DataTable.Rows.Count;
                object[,] Cells = new object[RowsCount, ColumnsCount];

                for (int j = 0; j < RowsCount; j++)
                    for (int i = 0; i < ColumnsCount; i++)
                        Cells[j, i] = DataTable.Rows[j][i];

                Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount])).Value = Cells;

                // check fielpath
                if (ExcelFilePath != null && ExcelFilePath != "")
                {
                    try
                    {
                        Worksheet.SaveAs(ExcelFilePath);
                        Excel.Quit();
                        MessageBox.Show(DbName + " database has been exported to excel successfully!","Export to Excel");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Excel file could not be exported! Check filepath.\n"
                            + ex.Message);
                    }
                }
                else    // no filepath is given
                {
                    Excel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
    }
}

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
    public partial class salesForm : Form
    {
        int H1 = 13, H2 = 17, H3 = 7, Count = 0, CtrlCount = 0;
        int pH = 70, pH1 = 65; bool Check = true;
        string mAmounttexbox = "AmounttextBox";
        double Total = 0.0, AllTotal = 0.00, TotalAmount = 0.00, TotalBalance = 0.00, CurrentBalance = 0.00, CurrentAmount = 0.00;
        double HST = 0.00;
        EdenDbDataSetTableAdapters.EmployeeDataTableAdapter GetEmployeeNames = new EdenDbDataSetTableAdapters.EmployeeDataTableAdapter();
        EdenDbDataSetTableAdapters.FashionItemSoldTableAdapter getItemsSold = new EdenDbDataSetTableAdapters.FashionItemSoldTableAdapter();
        List<string> comboText = new List<string>();
        string emp = ""; string TransID = "";
        string TID = ""; bool created = false; string password = "2420";

        Panel Passwordpanel = new Panel();
        Button OkButton = new Button();
        Button cancelButton = new Button();
        Label label1 = new Label();
        Label label2 = new Label();
        Label label3 = new Label();
        TextBox passwordTextbox = new TextBox();
        ErrorProvider errorProvider = new ErrorProvider();

        private void CreatePasswordPanel()
        {
            if (created)
            {
                Passwordpanel.Visible = true;
                EnableControl(Passwordpanel);
            }
            else
            {
                // cancelButton
                // 
                cancelButton.Location = new Point(249, 165);
                cancelButton.Name = "cancelButton";
                cancelButton.Size = new Size(79, 33);
                //cancelButton.TabIndex = 5;
                cancelButton.Text = "&Cancel";
                cancelButton.UseVisualStyleBackColor = true;
                cancelButton.Click += new EventHandler(cancelButton_Click);

                // 
                // label3
                // 
                label3.AutoSize = true;
                label3.Font = new Font("Microsoft SansSerif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                label3.Location = new Point(5, 17);
                label3.Name = "label3";
                label3.Size = new Size(152, 16);
                //label3.TabIndex = 4;
                label3.Text = "Enter Your Password";
                // 
                // label2
                // 
                label2.BackColor = Color.Black;
                label2.Location = new Point(2, 42);
                label2.Name = "label2";
                label2.Size = new Size(337, 2);
                //label2.TabIndex = 3;
                // 
                // label1
                // 
                label1.AutoSize = true;
                label1.Location = new Point(10, 96);
                label1.Name = "label1";
                label1.Size = new Size(104, 13);
                //label1.TabIndex = 2;
                label1.Text = "Enter your Password";
                // 
                // OkButton
                // 
                OkButton.Enabled = false;
                OkButton.Location = new Point(156, 165);
                OkButton.Name = "OkButton";
                OkButton.Size = new Size(79, 33);
                //OkButton.TabIndex = 1;
                OkButton.Text = "&OK";
                OkButton.UseVisualStyleBackColor = true;
                OkButton.Click += new EventHandler(OkButton_Click);
                // 
                // passwordTextbox
                // 
                passwordTextbox.Location = new Point(135, 94);
                passwordTextbox.Name = "passwordTextbox";
                passwordTextbox.Size = new Size(100, 20);
                passwordTextbox.TabIndex = 0;
                passwordTextbox.Focus();
                passwordTextbox.UseSystemPasswordChar = true;
                passwordTextbox.TextChanged += new EventHandler(passwordTextbox_TextChanged);

                Passwordpanel.SuspendLayout();

                // Passwordpanel
                // 
                Passwordpanel.Controls.Add(cancelButton);
                Passwordpanel.Controls.Add(label3);
                Passwordpanel.Controls.Add(label2);
                Passwordpanel.Controls.Add(label1);
                Passwordpanel.Controls.Add(OkButton);
                Passwordpanel.Controls.Add(passwordTextbox);
                Passwordpanel.Location = new Point(497, 189);
                Passwordpanel.Name = "Passwordpanel";
                Passwordpanel.Size = new Size(340, 212);
                //Passwordpanel.TabIndex = 50;
                Passwordpanel.Visible = true;

                Passwordpanel.ResumeLayout(false);
                Passwordpanel.PerformLayout();

                created = true;

                this.Controls.Add(Passwordpanel);
            }
            Passwordpanel.BringToFront();
            Passwordpanel.Enabled = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Passwordpanel.Visible = false;
            passwordTextbox.Clear(); //TID = "";
            errorProvider.Clear();
            //EnableAllControls(this);
        }

        private void passwordTextbox_TextChanged(object sender, EventArgs e)
        {
            if (passwordTextbox.Text != "")
                OkButton.Enabled = true;
            else
            {
                OkButton.Enabled = false;
                errorProvider.Clear();
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (passwordTextbox.Text == password.ToString())
            {
                string text = "Are you sure you want to delete this receipt?";
                if (MessageBox.Show(text, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    getItemsSold.DeleteFasItemSoldQuery(TID);
                    MessageBox.Show("Receipt deleted successfully", "Status");
                    TID = "";
                    Clearbutton_Click(Clearbutton, e);
                }
                cancelButton_Click(sender, e);
                

            }
            else
            {
                passwordTextbox.SelectAll();                             
                errorProvider.SetError(passwordTextbox, "Invalid password. Please try Again.");               
            }
        }

        private void salesForm_Load(object sender, EventArgs e)
        {            
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(this.AutoScrollPosition.X + 98, this.AutoScrollPosition.Y + 13);  //set x,y to where you want it to appear
            Datelabel.Text = DateTime.Now.ToShortDateString(); 
            this.PayBycomboBox.SelectedIndex = 0;
        }

        private string[] loadEmployeeNames()
        {
            DataTable dataTable;
            dataTable = GetEmployeeNames.GetDataByEmployeeNames();
            string[] result = dataTable
                    .AsEnumerable()
                    .SelectMany(column => new string[] { column["FirstName"].ToString() + " " + column["LastName"].ToString() })
                    .ToArray();
            return result;


        }

        public salesForm()
        {
            errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            InitializeComponent();
            TransID = generateID("");
            TransIDLabel.Text = TransID;
            setButtons();
           
        }

        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }
            con.Enabled = false;
        }

        private void EnableAllControls(Control con)
        {
            if (con != null)
            {
                foreach (Control c in con.Controls)
                {
                    EnableAllControls(c);
                }
                con.Enabled = true;
            }
        }

        private void EnableControl(Control con)
        {
            if (con != null)
            {
                con.Enabled = true;
                EnableControl(con.Parent);
            }
        }

        private void CreateAddControls(string Name, string Qty, string Desc1, string Desc2, string Price, double subTotal)
        {
            Label Namelabel = new Label();
            Label Qtylabel = new Label();
            Label Desc1label = new Label();
            Label Desc2label = new Label();
            Label pricelabel = new Label();
            TextBox totalTextbox = new TextBox();
            Button deletebutton = new Button();



            Namelabel.Location = new Point(AddControlPanel.AutoScrollPosition.X + 3, AddControlPanel.AutoScrollPosition.Y + H1);
            Namelabel.Size = new Size(AddControlPanel.AutoScrollPosition.X + 206, 20);//System.Drawing.
            Namelabel.BackColor = SystemColors.ActiveBorder;//System.Drawing.
            Namelabel.Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));//System.Drawing.
            Namelabel.Text = Name;
            Namelabel.Tag = deletebutton;

            Qtylabel.Location = new Point(AddControlPanel.AutoScrollPosition.X + 235, AddControlPanel.AutoScrollPosition.Y + H2);//System.Drawing.
            Qtylabel.Size = new Size(51, 20);//System.Drawing.
            Qtylabel.Text = Qty;
            Qtylabel.Tag = deletebutton;

            Desc1label.Location = new Point(AddControlPanel.AutoScrollPosition.X + 296, AddControlPanel.AutoScrollPosition.Y + H2);//System.Drawing.
            Desc1label.Size = new Size(49, 20);//System.Drawing.
            Desc1label.Text = Desc1;
            Desc1label.Tag = deletebutton;

            Desc2label.Location = new Point(AddControlPanel.AutoScrollPosition.X + 353, AddControlPanel.AutoScrollPosition.Y + H2);//System.Drawing.
            Desc2label.Size = new Size(49, 20);//System.Drawing.
            Desc2label.Text = Desc2;
            Desc2label.Tag = deletebutton;

            pricelabel.Location = new Point(AddControlPanel.AutoScrollPosition.X + 421, AddControlPanel.AutoScrollPosition.Y + H2);//System.Drawing.
            pricelabel.Size = new Size(49, 20);//System.Drawing.
            pricelabel.Text = Price.ToString();
            pricelabel.Tag = deletebutton;

            totalTextbox.Location = new Point(AddControlPanel.AutoScrollPosition.X + 477, AddControlPanel.AutoScrollPosition.Y + H2);//System.Drawing.
            totalTextbox.Size = new Size(56, 20);//System.Drawing.
            totalTextbox.Text = subTotal.ToString("C");
            totalTextbox.ReadOnly = true;
            totalTextbox.BackColor = SystemColors.ControlLight;//System. Drawing.
            totalTextbox.BorderStyle = BorderStyle.None;
            totalTextbox.Tag = deletebutton;

            deletebutton.Location = new Point(AddControlPanel.AutoScrollPosition.X + 535, AddControlPanel.AutoScrollPosition.Y + H3);//System.Drawing.
            deletebutton.Size = new Size(52, 30);//System.Drawing.
            deletebutton.Click += new EventHandler(button_Click);
            deletebutton.BackgroundImage = Properties.Resources.delete;
            deletebutton.BackgroundImageLayout = ImageLayout.Zoom;//System.Windows.Forms.


            this.AddControlPanel.Controls.Add(Namelabel);

            this.AddControlPanel.Controls.Add(Qtylabel);

            this.AddControlPanel.Controls.Add(Desc1label);

            this.AddControlPanel.Controls.Add(Desc2label);

            this.AddControlPanel.Controls.Add(pricelabel);

            this.AddControlPanel.Controls.Add(totalTextbox);

            this.AddControlPanel.Controls.Add(deletebutton);

            H1 += 30;
            H2 += 30;
            H3 += 30;
            Count += 1;
            Total += subTotal;

        }

        void button_Click(object sender, EventArgs e)
        {           

            for (int i = 0; i < AddControlPanel.Controls.Count; i++)
            {
                Control item = AddControlPanel.Controls[i];
                if (item.Tag == sender || item == sender)
                {
                    if (item.Text.StartsWith("$") && item is TextBox)
                        Total = Total - double.Parse(item.Text.Substring(1));

                    AddControlPanel.Controls.Remove(item);
                    item.Dispose();
                    i--;
                }
            }
            Count = Count - 1;
            update();
        }

        private String generateID(string ID)
        {

            int nID = 0;

            if (string.IsNullOrEmpty(ID))
            {
                int count = (int)getItemsSold.CountTransID();
                if (count == 0)
                    return "FT-00001";

                //get the TransID of the last transaction 
                ID = getItemsSold.GetTransID(count).ToString();

            }

            //convert the TransID to integer starting from the second character and increment the ID
            nID = Convert.ToInt32(ID.Substring(3)); nID++;

            //if less than 5 characters
            if (nID.ToString().Length < 5)
            {
                //reconvert to string adding leading zeroes and letter 'T'
                ID = ("FT-" + nID.ToString("D5"));
            }
            //reconvert to string adding letter 'T' with no leading zeroes
            else ID = ("FT-" + nID.ToString());
            return ID;
        }

        private void update()
        {
            QtyLabel.Text = Count.ToString();

            if (Total > 0)
            {
                SalesSubTotalLabel.Text = Total.ToString("C");
                HST = 0.13 * Total;
            }
            else SalesSubTotalLabel.Text = "$ 0.00";

            HSTlabel.Text = HST.ToString("C");
            AssignValues();
        }

        private void AssignValues()
        {
            AllTotal = CheckLabel(SalesSubTotalLabel) + CheckLabel(HSTlabel) + CheckLabel(Dlabel);
            Totallabel2.Text = AllTotal.ToString("C");
            CurrentBalance = AllTotal - TotalAmount;
            AmountPaidtextBox.Text = TotalAmount.ToString("C");
            BalancetextBox.Text = CurrentBalance.ToString("C");
        }

        private double CheckLabel(Label label)
        {
            Double value;
            if (Double.TryParse(label.Text.Substring(1), out value))
            {
                return value;
            }
            else
            {
                //logbox.AppendText(string.Format("Box {0} does not contain a double", textBox.Name));
                //label.Text = ("NO DOUBLE FOUND");
                value = double.NaN;
                return value;
            }
        }

        private void HSTcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (HSTcheckBox.Checked == true)
            {
                HSTlabel.Text = HST.ToString("C");
            }
            else HSTlabel.Text = "$0.00";
        }

        private void HSTlabel_TextChanged(object sender, EventArgs e)
        {
            AssignValues();
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            //double Tamount, Cbalance = 0.00;
            Check = false; //disable textChanged code
            TotalAmount = TotalAmount - CheckTextbox(AmounttextBox0); //decrement totalAmount by textbox value
            CurrentBalance = CurrentBalance + CheckTextbox(AmounttextBox0); //increment currentbalance by textbox value
            AmounttextBox0.Clear();
            AmounttextBox0.Enabled = true;
            AmountPaidtextBox.Text = TotalAmount.ToString("C");
            BalancetextBox.Text = CurrentBalance.ToString("C");
            Check = true;//enable textChanged code
        }

        private void PayBypanel_Click(object sender, EventArgs e)
        {
            bool create = false;
            for (int i = 0; i < PayBypanel.Controls.Count; i++)
            {
                Control item = PayBypanel.Controls[i];
                if (item is TextBox)
                {
                    if (item.Name == mAmounttexbox + CtrlCount)
                    {
                        if (item.Text != string.Empty)
                        {
                            ItemFound(item as TextBox); create = true; break;
                        }
                        else break;
                    }
                }
            }
            CreatePayByPanelControls(create);
        }

        private void AmounttextBox0_TextChanged(object sender, EventArgs e)
        {
            text_TextChanged(sender, e);
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (EmployeeComboBox.Text != string.Empty)
            {
                if (AddControlPanel.Controls.Count != 0)
                {
                    emp = EmployeeComboBox.Text;
                    UseWaitCursor = true;
                    CollectItems(AddControlPanel, HSTlabel.Text.ToString(), Dlabel.Text.ToString(), SalesSubTotalLabel.Text.ToString(), Totallabel2.Text.ToString(), AmountPaidtextBox.Text.ToString(), BalancetextBox.Text.ToString(), emp.ToString(), TransID.ToString());
                    ReportForm report = new ReportForm(TransID.ToString());
                    report.Show();
                    UseWaitCursor = false;
                    Clearbutton_Click(Clearbutton, e);
                    EmployeeComboBox.Text = "";
                    TransID = generateID(TransID);
                    TransIDLabel.Text = TransID;
                }
                else MessageBox.Show("No item selected","Error");
            }
            else MessageBox.Show("Please select an employee before making sales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void LoadComboBoxbackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] comboText2 = loadEmployeeNames();
            foreach (string item in comboText2)
            {
                this.comboText.Add(item);
            }
        }

        private void LoadComboBoxbackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (string item in this.comboText)
            {
                if (!EmployeeComboBox.Items.Contains(item))
                {
                    EmployeeComboBox.Items.Add(item);
                }
                EmployeeComboBox.Refresh();
            }
        }

        private void salesForm_Enter(object sender, EventArgs e)
        {
            LoadComboBoxbackgroundWorker.RunWorkerAsync();
        }

        private void toggleButton_Click(object sender, EventArgs e)
        {
            selectInvoiceForm selectInvoice = new selectInvoiceForm(true);
            selectInvoice.ShowDialog(this);
            List<string> test = new List<string>();                     
            if (selectInvoice.getClicked())
            {                
                Clearbutton_Click(Clearbutton, e);
                TID = selectInvoice.getID();
                object[,] selected = selectInvoice.getSelectedItems();
                try
                {
                    for (int i = 0; i < selected.GetLength(0); i++)
                    {
                        for (int j = 0; j < selected.GetLength(1); j++)
                        {
                            test.Add(selected[i, j].ToString());
                        }

                        double test6 = (test[6] != "") ? Convert.ToDouble(test[6].Substring(1)) : 0.00;
                        CreateAddControls(test[1], test[2], test[3], test[4], test[5], test6);
                        update();
                        test.Clear();
                    }
                    TransIDLabel.Text = TID;
                    DisableControls(this);
                    EnableControl(panel14);
                    EnableControl(Clearbutton);
                    EnableControl(voidButton);
                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void voidButton_Click(object sender, EventArgs e)
        {
            if (TID != "")
            {
                CreatePasswordPanel();
            }
        }

        private void SalesNewButton_Click(object sender, EventArgs e)
        {
            Clearbutton_Click(Clearbutton, e);
        }

        private double CheckTextbox(TextBox textbox)
        {
            Double value = 0.00;
            if (textbox.Text != string.Empty)
            {
                if (textbox.Text.StartsWith("$"))
                {
                    if (Double.TryParse(textbox.Text.Substring(1), out value))
                    {
                        return value;
                    }
                    else
                    {
                        //logbox.AppendText(string.Format("Box {0} does not contain a double", textBox.Name));
                        //label.Text = ("NO DOUBLE FOUND");
                        MessageBox.Show("Input string not in a correct format.", "Error");
                        textbox.Focus();
                        textbox.SelectAll();
                        value = 0.00;

                    }
                }
                else
                {
                    if (Double.TryParse(textbox.Text, out value))
                    {
                        return value;
                    }
                    else
                    {
                        //logbox.AppendText(string.Format("Box {0} does not contain a double", textBox.Name));
                        //label.Text = ("NO DOUBLE FOUND");
                        MessageBox.Show("Input string not in a correct format.", "Error");
                        textbox.Focus();
                        textbox.SelectAll();
                        value = 0.00;

                    }

                }
            }
            return value;
        }

        private void setButtons()
        {
            foreach (Button btn in panel1.Controls)
            {
                if (btn.Text.ToLower() != "membership card")
                    btn.Click += new EventHandler(OpenForm);
            }
        }

        private void ClearContents()
        {
            Check = false;
            QtyLabel.Text = "";
            SalesSubTotalLabel.Text = "";
            Totallabel2.Text = "";
            AmountPaidtextBox.Text = "";
            BalancetextBox.Text = "";
            AmounttextBox0.Text = "";
            AmounttextBox0.Enabled = true;
            PayBycomboBox.Text = "";
            CtrlCount = 0;
            TID = "";
            Check = true;
        }

        private void ItemFound(TextBox control)
        {
            try
            {
                Check = false;
                TotalBalance = AllTotal; //Assign the total cost of products to TotalBalance
                CurrentAmount = CheckTextbox(control); //Check if the content of the textbox is double then assing to currentAmount
                control.Text = CurrentAmount.ToString("C"); //After user types the aamount to pay, collect the text attach dollar sign and display it 
                TotalAmount = TotalAmount + CurrentAmount; //Gets the total amount the user has paid for all products.
                AmountPaidtextBox.Text = TotalAmount.ToString("C"); //Display totalAmount paid by user
                CurrentBalance = TotalBalance - TotalAmount; //get the remaining balance for the user
                BalancetextBox.Text = CurrentBalance.ToString("C"); //display the remaining balance
                control.Enabled = false; //disable textbox.

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void CreatePayByPanelControls(bool create)
        {
            if (create)
            {
                ComboBox combo = new ComboBox();
                TextBox text = new TextBox();
                // Button Ok = new Button();
                Button del = new Button();

                CtrlCount += 1;
                Check = true;

                combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                combo.FormattingEnabled = true;
                //combo.Name =
                combo.Items.AddRange(new object[] {
                "On Account",
                "Amex",
                "Cash",
                "Cheque",
                "Gift_Card",
                "Interac",
                "MasterCard",
                "Note_Credit",
                "PayPal",
                "Visa"});
                combo.Location = new Point(PayBypanel.AutoScrollPosition.X + 7, PayBypanel.AutoScrollPosition.Y + pH);
                combo.Size = new System.Drawing.Size(121, 23);
                combo.Tag = del;
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
                combo.SelectedIndex = 0;

                text.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                text.Location = new Point(PayBypanel.AutoScrollPosition.X + 134, PayBypanel.AutoScrollPosition.Y + pH);
                text.Size = new System.Drawing.Size(124, 21);
                text.Tag = del;
                text.Name = mAmounttexbox + CtrlCount;
                text.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                text.TextChanged += new EventHandler(text_TextChanged);

                del.BackgroundImage = Properties.Resources.delete;
                del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                del.Location = new Point(PayBypanel.AutoScrollPosition.X + 259, PayBypanel.AutoScrollPosition.Y + pH1);
                del.Size = new System.Drawing.Size(55, 34);
                del.UseVisualStyleBackColor = true;
                del.Click += new EventHandler(delClick);

                this.PayBypanel.Controls.Add(combo);
                this.PayBypanel.Controls.Add(text);
                this.PayBypanel.Controls.Add(del);

                pH += 40; pH1 += 40;
            }

        }

        private void CollectItems(Panel panel, string HST, string Dot, string SubTotal, string Total, string Amount, string Balance, string Employee, string TransID)
        {
            List<string> Row = new List<string>();
            int mcount = 0;
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                Control item = panel.Controls[i];
                if (!(item is Button))
                {
                    mcount++;
                    Row.Add(item.Text.ToString());
                    if (mcount == 6)
                    {
                        getItemsSold.Insert(Row[0], Row[1], Row[2], Row[3], Row[4], Row[5], HST, Dot, SubTotal, Total, Amount, Balance, Employee, TransID, DateTime.Today);
                        Row.Clear();
                        mcount = 0;
                    }
                }
            }

        }

        void OpenForm(Object sender, EventArgs e)
        {
            string text = ActiveControl.Text;
            ItemForm item = new ItemForm();
            item.ShowDialog(this);

            string[] values = new string[5];
            values = item.getValues();


            if (item.add == true)
            {
                CreateAddControls(text, values[0], values[1], values[2], values[3], Convert.ToDouble(values[4]));
            }

            update();
        }

        void text_TextChanged(object sender, EventArgs e)
        {
            if (Check == true)
            {
                try
                {
                    if (Convert.ToDouble(ActiveControl.Text) > CurrentBalance)
                    {
                        MessageBox.Show("Amount entered cannot be greater than the balance remaining. \nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl.Focus();
                        ActiveControl.Text = "";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ActiveControl.Focus();
                    ActiveControl.Text = "";
                }
            }

        }

        void delClick(object sender, EventArgs e)
        {
            for (int i = 0; i < PayBypanel.Controls.Count; i++) //iterate through all the controls
            {
                Control item = PayBypanel.Controls[i]; //get the control with index as i
                if (item.Tag == sender || item == sender) //check if the control has same tag as the clicked button (sender)
                {
                    if (item is TextBox) //check if item is textbox
                    {
                        Check = false; //do not execute the textChanged code
                        double num = CheckTextbox(item as TextBox); //check that textbox is double value
                        if (num != 0.0)
                        {
                            TotalAmount = TotalAmount - num; //decrement TotalAmount by texbox value
                            CurrentBalance = CurrentBalance + num; //increment CurrentBalance by textbox value                  
                            AmountPaidtextBox.Text = TotalAmount.ToString("C"); //display TotalAmount
                            BalancetextBox.Text = CurrentBalance.ToString("C");//display CurrentBalance
                        }
                    }
                    item.Dispose(); //delete item
                    i--;
                }
            }
        }

        private void Clearbutton_Click(object sender, EventArgs e)
        {
            H1 = 13; H2 = 17; H3 = 7; Count = 0;
            pH = 70; pH1 = 65;
            Total = 0.0; HST = 0.00;
            AllTotal = 0.00;
            TotalAmount = 0.00;
            TotalBalance = 0.00;
            CurrentBalance = 0.00;
            CurrentAmount = 0.00;
            TransIDLabel.Text = TransID;

            AddControlPanel.Controls.Clear();
            update();

            for (int i = 0; i < PayBypanel.Controls.Count; i++)
            {
                Control item = PayBypanel.Controls[i];
                if (item.Tag != sender)
                {
                    item.Dispose(); i--;
                }
            }

            ClearContents();
            EnableAllControls(this);
            Passwordpanel.Visible = false;
        }
    }
}

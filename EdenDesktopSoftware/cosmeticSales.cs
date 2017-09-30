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
    public partial class cosmeticSales : Form
    {
        int Count = 0, CtrlCount = 0;
        double AllTotal = 0.00, HST = 0.00;
        int H1 = 14, H2 = 17, H3 = 8;
        int pH = 70, pH1 = 67;
        string mCosmeticAmountTextBox = "CosmeticAmountTextBox";
        double Total = 0.0, CurrentBalance = 0.00, TotalBalance = 0.00, CurrentAmount = 0.00, TotalAmount = 0.00;
        bool Check = true; string TransID = "", TID = ""; bool created = false;

        EdenDbDataSetTableAdapters.CosmeticItemSoldTableAdapter CosItemSold = new EdenDbDataSetTableAdapters.CosmeticItemSoldTableAdapter();
        
        Panel Passwordpanel = new Panel();
        Button OkButton = new Button();
        Button cancelButton = new Button();
        Label label1 = new Label();
        Label label2 = new Label();
        Label label3 = new Label();
        TextBox passwordTextbox = new TextBox();
        ErrorProvider errorProvider = new ErrorProvider();

        string password = "2420";
    
        public cosmeticSales()
        {
            InitializeComponent();
            TransID = generateID("");
            CosmeticTransIDLabel.Text = TransID;
        }

        private String generateID(string ID)
        {

            int nID = 0;

            if (string.IsNullOrEmpty(ID))
            {
                int count = (int)CosItemSold.CountCosTransID();
                if (count == 0)
                    return "CT-00001";

                //get the TransID of the last transaction 
                ID = CosItemSold.GetCosTransID(count).ToString();

            }

            //convert the TransID to integer starting from the second character and increment the ID
            nID = Convert.ToInt32(ID.Substring(3)); nID++;

            //if less than 5 characters
            if (nID.ToString().Length < 5)
            {
                //reconvert to string adding leading zeroes and letter 'T'
                ID = ("CT-" + nID.ToString("D5"));
            }
            //reconvert to string adding letter 'T' with no leading zeroes
            else ID = ("CT-" + nID.ToString());
            return ID;
        }

        private void passwordTextbox_TextChanged(object sender, EventArgs e)
        {
            if (passwordTextbox.Text != "")
                OkButton.Enabled = true;
            else OkButton.Enabled = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Passwordpanel.Visible = false;
            passwordTextbox.Clear(); TID = "";
            errorProvider.Clear();
            //EnableAllControls(this);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (passwordTextbox.Text == password.ToString())
            {
                string text = "Are you sure you want to delete this receipt?";
                if (MessageBox.Show(text, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    CosItemSold.DeleteCosItemQuery(TID);
                    MessageBox.Show("Receipt deleted successfully", "Status");
                    TID = "";
                    ClearButton_Click(ClearButton, e);
                }
                cancelButton_Click(sender, e);
                passwordTextbox.Clear();
               
            }
            else
            {               
                errorProvider.ContainerControl = this;
                errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
                errorProvider.SetError(passwordTextbox, "Invalid password. Please try Again.");
            }
        }

        private void CreatePasswordPanel()
        {
            if (created == true)
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

        public void AddControls(string ItCode, string Name, string Qty, string Desc1, string Desc2, string Price, double subTotal)
        {
            Label Namelabel = new Label();
            Label Qtylabel = new Label();
            Label Desc1label = new Label();
            Label Desc2label = new Label();
            Label pricelabel = new Label();
            TextBox totalTextbox = new TextBox();
            Button deletebutton = new Button();



            Namelabel.Location = new Point(AddPanel.AutoScrollPosition.X + 4, AddPanel.AutoScrollPosition.Y + H1);
            Namelabel.Size = new Size(178, 23);//System.Drawing.
            Namelabel.BackColor = SystemColors.ActiveBorder;//System.Drawing.
            Namelabel.Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));//System.Drawing.
            Namelabel.Text = string.Format("{0}  {1}", Name, ItCode);
            Namelabel.Tag = deletebutton;

            Qtylabel.Location = new Point(AddPanel.AutoScrollPosition.X + 235, AddPanel.AutoScrollPosition.Y + H2);//System.Drawing.
            Qtylabel.Size = new Size(51, 20);//System.Drawing.
            Qtylabel.Text = Qty;
            Qtylabel.Tag = deletebutton;

            Desc1label.Location = new Point(AddPanel.AutoScrollPosition.X + 296, AddPanel.AutoScrollPosition.Y + H2);//System.Drawing.
            Desc1label.Size = new Size(49, 20);//System.Drawing.
            Desc1label.Text = Desc1;
            Desc1label.Tag = deletebutton;

            Desc2label.Location = new Point(AddPanel.AutoScrollPosition.X + 353, AddPanel.AutoScrollPosition.Y + H2);//System.Drawing.
            Desc2label.Size = new Size(49, 20);//System.Drawing.
            Desc2label.Text = Desc2;
            Desc2label.Tag = deletebutton;

            pricelabel.Location = new Point(AddPanel.AutoScrollPosition.X + 421, AddPanel.AutoScrollPosition.Y + H2);//System.Drawing.
            pricelabel.Size = new Size(49, 20);//System.Drawing.
            pricelabel.Text = Price.ToString();
            pricelabel.Tag = deletebutton;

            totalTextbox.Location = new Point(AddPanel.AutoScrollPosition.X + 477, AddPanel.AutoScrollPosition.Y + H2);//System.Drawing.
            totalTextbox.Size = new Size(56, 20);//System.Drawing.
            totalTextbox.Text = subTotal.ToString("C");
            totalTextbox.ReadOnly = true;
            totalTextbox.BackColor = SystemColors.ControlLight;//System. Drawing.
            totalTextbox.BorderStyle = BorderStyle.None;
            totalTextbox.Tag = deletebutton;

            deletebutton.Location = new Point(AddPanel.AutoScrollPosition.X + 535, AddPanel.AutoScrollPosition.Y + H3);//System.Drawing.
            deletebutton.Size = new Size(52, 30);//System.Drawing.
            deletebutton.Click += new EventHandler(DeleteButton_Click);
            deletebutton.BackgroundImage = Properties.Resources.delete;
            deletebutton.BackgroundImageLayout = ImageLayout.Zoom;//System.Windows.Forms.


            this.AddPanel.Controls.Add(Namelabel);
            this.AddPanel.Controls.Add(Qtylabel);
            this.AddPanel.Controls.Add(Desc1label);
            this.AddPanel.Controls.Add(Desc2label);
            this.AddPanel.Controls.Add(pricelabel);
            this.AddPanel.Controls.Add(totalTextbox);
            this.AddPanel.Controls.Add(deletebutton);

            H1 += 30;
            H2 += 30;
            H3 += 30;
            Count += 1;
            Total += subTotal;
            update();

        }

        void DeleteButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < AddPanel.Controls.Count; i++)
            {
                Control item = AddPanel.Controls[i];
                if (item.Tag == sender || item == sender)
                {
                    if (item.Text.StartsWith("$") && item is TextBox)
                        Total = Total - double.Parse(item.Text.Substring(1));

                    AddPanel.Controls.Remove(item);
                    item.Dispose();
                    i--;
                }
            }
            Count = Count - 1;
            update();
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

        private void update()
        {
            CosmeticQtyLabel.Text = Count.ToString();

            if (Total > 0)
            {
                CosmeticSubTotalLabel.Text = Total.ToString("C");
                HST = 0.13 * Total;
            }
            else CosmeticSubTotalLabel.Text = "$ 0.00";

            CosmeticHSTLabel.Text = HST.ToString("C");
            AssignValues();
        }

        private void AssignValues()
        {
            AllTotal = CheckLabel(CosmeticSubTotalLabel) + CheckLabel(CosmeticHSTLabel) + CheckLabel(CosmeticDOTLabel);
            CosmeticTotalLabel.Text = AllTotal.ToString("C");
            CurrentBalance = AllTotal - TotalAmount;
            CosmeticAmountPaidTextBox.Text = TotalAmount.ToString("C");
            CosmeticBalanceTextBox.Text = CurrentBalance.ToString("C");
        }

        private void NewButton_Click(object sender, EventArgs e)
        {           
            ClearButton_Click(ClearButton,e);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            H1 = 13; H2 = 17; H3 = 7; Count = 0;
            pH = 70; pH1 = 65;
            Total = 0.0; HST = 0.00;
            AllTotal = 0.00;
            TotalAmount = 0.00;
            TotalBalance = 0.00;
            CurrentBalance = 0.00;
            CurrentAmount = 0.00;

            AddPanel.Controls.Clear();
            update();

            for (int i = 0; i < CosmeticPayByPanel.Controls.Count; i++)
            {
                Control item = CosmeticPayByPanel.Controls[i];
                if (item.Tag != sender)
                {
                    item.Dispose(); i--;
                }

            }
            ClearContents();
            EnableAllControls(this);
            Passwordpanel.Visible = false;
        }

        private void lookUpButton_Click(object sender, EventArgs e)
        {
            if (!lookUpPanel.Visible)
                lookUpPanel.Visible = true;
            else lookUpPanel.Visible = false;
        }

        private void CosmeticAcceptButton_Click(object sender, EventArgs e)
        {
            if (AddPanel.Controls.Count != 0)
            {
                CollectItems(AddPanel, CosmeticHSTLabel.Text.ToString(), CosmeticDOTLabel.Text.ToString(), CosmeticSubTotalLabel.Text.ToString(), CosmeticTotalLabel.Text.ToString(), CosmeticAmountPaidTextBox.Text.ToString(), CosmeticBalanceTextBox.Text.ToString(), "Employee", TransID.ToString());

                CosmeticReportForm report = new CosmeticReportForm(TransID);
                ClearButton_Click(ClearButton, e);
                report.Show();                
                TransID = generateID(TransID);
                CosmeticTransIDLabel.Text = TransID;
            }
            else MessageBox.Show("No item selected", "Error");

        }

        private void CosmeticAmountTextBox0_TextChanged(object sender, EventArgs e)
        {
            text_TextChanged(sender, e);
        }

        private void CosmeticDeleteButton_Click(object sender, EventArgs e)
        {
            Check = false; //disable textChanged code
            TotalAmount = TotalAmount - CheckTextbox(CosmeticAmountTextBox0); //decrement totalAmount by textbox value
            CurrentBalance = CurrentBalance + CheckTextbox(CosmeticAmountTextBox0); //increment currentbalance by textbox value
            CosmeticAmountTextBox0.Clear();
            CosmeticAmountTextBox0.Enabled = true;
            CosmeticAmountPaidTextBox.Text = TotalAmount.ToString("C");
            CosmeticBalanceTextBox.Text = CurrentBalance.ToString("C");
            Check = true;//enable textChanged code
        }

        private void CosmeticHSTCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CosmeticHSTCheckBox.Checked == true)
            {
                CosmeticHSTLabel.Text = HST.ToString("C");
            }
            else CosmeticHSTLabel.Text = "$0.00";
        }

        private void CosmeticPayByPanel_Click(object sender, EventArgs e)
        {
            bool create = false;
            for (int i = 0; i < CosmeticPayByPanel.Controls.Count; i++)
            {
                Control item = CosmeticPayByPanel.Controls[i];
                if (item is TextBox)
                {
                    if (item.Name == mCosmeticAmountTextBox + CtrlCount)
                    {
                        if (item.Text != string.Empty)
                        {
                            ItemFound(item as TextBox); create = true; break;
                        }
                        else break;
                    }
                }
            }
            CreatePayByPanelControls(create, CosmeticPayByPanel);

        }

        private void CosmeticHSTLabel_TextChanged(object sender, EventArgs e)
        {
            AssignValues();
        }

        private void HairCareButton_Click(object sender, EventArgs e)
        {
            hairCareForm mhaircare = new hairCareForm("Hair Care", true);
            UseWaitCursor = true;
            mhaircare.Owner = this;
            UseWaitCursor = false;
            mhaircare.Show();
        }

        private void voidButton_Click(object sender, EventArgs e)
        {
            
            if (TID != "")
            {
                CreatePasswordPanel();               
            }
        }

        private void toggleButton_Click(object sender, EventArgs e)
        {
            selectCosInvoice selectInvoice = new selectCosInvoice(true);
            selectInvoice.ShowDialog(this);
            List<string> test = new List<string>();
            if (selectInvoice.getClicked())
            {
                TID = selectInvoice.getID();
                ClearButton_Click(ClearButton, e);
                object[,] selected = selectInvoice.getSelectedItems();
                try
                {
                    for (int i = 0; i < selected.GetLength(0); i++)
                    {
                        for (int j = 0; j < selected.GetLength(1); j++)
                        {
                            test.Add(selected[i, j].ToString());
                        }

                        double test5 = (test[5] != "") ? Convert.ToDouble(test[5].Substring(1)) : 0.00;
                        AddControls(test[1], "", test[15], test[2], test[3], test[4], test5);
                        update();
                        test.Clear();
                    }
                    CosmeticTransIDLabel.Text = TID;
                    DisableControls(this);
                    EnableControl(panel14);
                    EnableControl(ClearButton);
                    EnableControl(voidButton);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
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
                value = double.NaN;
                return value;
            }
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
                        MessageBox.Show("Input string not in a correct format.", "Error");
                        textbox.Focus();
                        textbox.SelectAll();
                        value = 0.00;

                    }

                }
            }
            return value;
        }

        private void ClearContents()
        {
            Check = false;
            CosmeticQtyLabel.Text = "";
            CosmeticSubTotalLabel.Text = "";
            CosmeticTotalLabel.Text = "";
            CosmeticAmountPaidTextBox.Text = "";
            CosmeticBalanceTextBox.Text = "";
            CosmeticAmountTextBox0.Text = "";
            CosmeticAmountTextBox0.Enabled = true;
            CosmeticPayByComboBox.Text = "";
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
                CosmeticAmountPaidTextBox.Text = TotalAmount.ToString("C"); //Display totalAmount paid by user
                CurrentBalance = TotalBalance - TotalAmount; //get the remaining balance for the user
                CosmeticBalanceTextBox.Text = CurrentBalance.ToString("C"); //display the remaining balance
                control.Enabled = false; //disable textbox.

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
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
                        CosItemSold.Insert(Row[0], Row[2], Row[3], Row[4], Row[5], HST.ToString(), Dot.ToString(), SubTotal.ToString(), Total.ToString(), Amount.ToString(), Balance.ToString(), Employee.ToString(), TransID.ToString(), CosmeticDateLabel.Text.ToString(), Row[1]);
                        Row.Clear();
                        mcount = 0;
                    }
                }
            }

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
            for (int i = 0; i < CosmeticPayByPanel.Controls.Count; i++) //iterate through all the controls
            {
                Control item = CosmeticPayByPanel.Controls[i]; //get the control with index as i
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
                            CosmeticAmountPaidTextBox.Text = TotalAmount.ToString("C"); //display TotalAmount
                            CosmeticBalanceTextBox.Text = CurrentBalance.ToString("C");//display CurrentBalance
                        }
                    }
                    item.Dispose(); //delete item
                    i--;
                }
            }
        }

        private void CreatePayByPanelControls(bool create, Panel panel)
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
                combo.Location = new Point(panel.AutoScrollPosition.X + 6, panel.AutoScrollPosition.Y + pH);
                combo.Size = new System.Drawing.Size(121, 24);
                combo.Tag = del;
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
                combo.SelectedIndex = 0;

                text.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                text.Location = new Point(panel.AutoScrollPosition.X + 134, panel.AutoScrollPosition.Y + pH);
                text.Size = new System.Drawing.Size(83, 22);
                text.Tag = del;
                text.Name = mCosmeticAmountTextBox + CtrlCount;
                text.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                text.TextChanged += new EventHandler(text_TextChanged);

                del.BackgroundImage = Properties.Resources.delete;
                del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                del.Location = new Point(panel.AutoScrollPosition.X + 222, panel.AutoScrollPosition.Y + pH1);
                del.Size = new System.Drawing.Size(46, 27);
                del.UseVisualStyleBackColor = true;
                del.Click += new EventHandler(delClick);

                panel.Controls.Add(combo);
                panel.Controls.Add(text);
                panel.Controls.Add(del);

                pH += 40; pH1 += 40;
            }

        }

        private void cosmeticSales_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(this.AutoScrollPosition.X + 98, this.AutoScrollPosition.Y + 11);  //set x,y to where you want it to appear
            CosmeticDateLabel.Text = DateTime.Today.ToShortDateString();
            this.CosmeticPayByComboBox.SelectedIndex = 0;
        }
    }
}

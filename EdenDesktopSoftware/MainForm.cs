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
    public partial class MainForm : Form
    {
        private bool Fashion = false, Cosmetic = false, Resturant = false;
        
        string password = "2420";

        public MainForm()
        {           
            InitializeComponent();
           
        }

        private void exitApp()
        {
            Application.Exit();
        }

        private void closeAllForms()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void enableControls(Control con)
        {
            for (int i = 0; i < con.Controls.Count; i++)
            {
                Control con2 = con.Controls[i];
                if ((con2 as Button) != PreviousButton)
                    con2.Enabled = true;
            }
        }

        private void DisableControls(Control con, Panel panel)
        {
            for (int i = 0; i < con.Controls.Count; i++)
            {
                Control con2 = con.Controls[i]; 
                if ((con2 as Panel) != panel)
                    con2.Enabled = false;               
            }
        }

        private void MoveToRestuarant()
        {
            CosmeticMenuPanel.Visible = false;
            CosmeticButtonPanel.Visible = false;
            ResMenuPanel.Location = new Point(6, 27);
            ResButtonPanel.Location = new Point(6, 171);
            ResMenuPanel.Visible = true;
            ResButtonPanel.Visible = true;
            statusLabel.Text = "Eden Desktop Software: Restaurant";
        }

        private void MoveToCosmetic()
        {
            FashionMenuPanel.Visible = false;
            FashionButtonPanel.Visible = false;
            CosmeticMenuPanel.Location = new Point(6, 27);
            CosmeticButtonPanel.Location = new Point(6, 171);
            CosmeticMenuPanel.Visible = true;
            CosmeticButtonPanel.Visible = true;
            statusLabel.Text = "Eden Desktop Software: Cosmetic";
        }

        private void MoveToFashion()
        {
            CosmeticMenuPanel.Visible = false;
            CosmeticButtonPanel.Visible = false;
            FashionMenuPanel.Visible = true;
            FashionMenuPanel.BringToFront();
            FashionButtonPanel.Visible = true;
            statusLabel.Text = "Eden Desktop Software: Fashion";

        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            MenuButton.Image = Properties.Resources.Clicked;
            MenuButton.ForeColor = Color.White;
            FashionButtonPanel.Show(); FashionButtonPanel.BringToFront();

            if (ConfigButton.Image != Properties.Resources.unclicked)
            {
                ConfigButton.Image = Properties.Resources.unclicked;
                ConfigButton.ForeColor = Color.Black;
            }

            if (ReportsButton.Image != Properties.Resources.unclicked)
            {
                ReportsButton.Image = Properties.Resources.unclicked;
                ReportsButton.ForeColor = Color.Black;
            }
        }

        private void ConfigButton_Click(object sender, EventArgs e)
        {
            ConfigButton.Image = Properties.Resources.Clicked;
            ConfigButton.ForeColor = Color.White;


            if (MenuButton.Image != Properties.Resources.unclicked)
            {
                MenuButton.Image = Properties.Resources.unclicked;
                MenuButton.ForeColor = Color.Black;
            }

            if (ReportsButton.Image != Properties.Resources.unclicked)
            {
                ReportsButton.Image = Properties.Resources.unclicked;
                ReportsButton.ForeColor = Color.Black;
            }          

        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            ReportsButton.Image = Properties.Resources.Clicked;
            ReportsButton.ForeColor = Color.White;

            if (MenuButton.Image != Properties.Resources.unclicked)
            {
                MenuButton.Image = Properties.Resources.unclicked;
                MenuButton.ForeColor = Color.Black;
            }

            if (ConfigButton.Image != Properties.Resources.unclicked)
            {
                ConfigButton.Image = Properties.Resources.unclicked;
                ConfigButton.ForeColor = Color.Black;
            }

            SalesMainReportForm report = new SalesMainReportForm();
            closeAllForms();
            report.MdiParent = this;
            report.Show();
        }

        private void CosmeticMenuButton_Click(object sender, EventArgs e)
        {
            CosmeticMenuButton.Image = Properties.Resources.Clicked;
            CosmeticMenuButton.ForeColor = Color.White;           

            if (CosmeticConfigButton.Image != Properties.Resources.unclicked)
            {
                CosmeticConfigButton.Image = Properties.Resources.unclicked;
                CosmeticConfigButton.ForeColor = Color.Black;
            }

            if (CosmeticReportButton.Image != Properties.Resources.unclicked)
            {
                CosmeticReportButton.Image = Properties.Resources.unclicked;
                CosmeticReportButton.ForeColor = Color.Black;
            }
        }

        private void CosmeticConfigButton_Click(object sender, EventArgs e)
        {
            CosmeticConfigButton.Image = Properties.Resources.Clicked;
            CosmeticConfigButton.ForeColor = Color.White;

            if (CosmeticMenuButton.Image != Properties.Resources.unclicked)
            {
                CosmeticMenuButton.Image = Properties.Resources.unclicked;
                CosmeticMenuButton.ForeColor = Color.Black;
            }

            if (CosmeticReportButton.Image != Properties.Resources.unclicked)
            {
                CosmeticReportButton.Image = Properties.Resources.unclicked;
                CosmeticReportButton.ForeColor = Color.Black;
            }
        }

        private void CosmeticReportButton_Click(object sender, EventArgs e)
        {
            CosmeticReportButton.Image = Properties.Resources.Clicked;
            CosmeticReportButton.ForeColor = Color.White;

            if (CosmeticMenuButton.Image != Properties.Resources.unclicked)
            {
                CosmeticMenuButton.Image = Properties.Resources.unclicked;
                CosmeticMenuButton.ForeColor = Color.Black;
            }

            if (CosmeticConfigButton.Image != Properties.Resources.unclicked)
            {
                CosmeticConfigButton.Image = Properties.Resources.unclicked;
                CosmeticConfigButton.ForeColor = Color.Black;
            }
        }

        private void ResMenuButton_Click(object sender, EventArgs e)
        {
            ResMenuButton.Image = Properties.Resources.Clicked;
            ResMenuButton.ForeColor = Color.White;           

            if (ResConfigButton.Image != Properties.Resources.unclicked)
            {
                ResConfigButton.Image = Properties.Resources.unclicked;
                ResConfigButton.ForeColor = Color.Black;
            }

            if (ResReportButton.Image != Properties.Resources.unclicked)
            {
                ResReportButton.Image = Properties.Resources.unclicked;
                ResReportButton.ForeColor = Color.Black;
            }
        }

        private void ResConfigButton_Click(object sender, EventArgs e)
        {
            ResConfigButton.Image = Properties.Resources.Clicked;
            ResConfigButton.ForeColor = Color.White;

            if (ResMenuButton.Image != Properties.Resources.unclicked)
            {
                ResMenuButton.Image = Properties.Resources.unclicked;
                ResMenuButton.ForeColor = Color.Black;
            }

            if (ResReportButton.Image != Properties.Resources.unclicked)
            {
                ResReportButton.Image = Properties.Resources.unclicked;
                ResReportButton.ForeColor = Color.Black;
            }
        }

        private void ResReportButton_Click(object sender, EventArgs e)
        {
            ResReportButton.Image = Properties.Resources.Clicked;
            ResReportButton.ForeColor = Color.White;

            if (ResMenuButton.Image != Properties.Resources.unclicked)
            {
                ResMenuButton.Image = Properties.Resources.unclicked;
                ResMenuButton.ForeColor = Color.Black;
            }

            if (ResConfigButton.Image != Properties.Resources.unclicked)
            {
                ResConfigButton.Image = Properties.Resources.unclicked;
                ResConfigButton.ForeColor = Color.Black;
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (Fashion)
            {
                MoveToCosmetic();
                Fashion = false; Cosmetic = true;
                PreviousButton.Enabled = true;
            }

            else if (Cosmetic)
            {
                MoveToRestuarant();
                Cosmetic = false; Resturant = true;
                NextButton.Enabled = false;

            }
            closeAllForms();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (Resturant)
            {
                MoveToCosmetic();
                Cosmetic = true; Resturant = false;
                NextButton.Enabled = true;
            }

            else if (Cosmetic)
            {
                MoveToFashion();
                Fashion = true; Cosmetic = false;
                PreviousButton.Enabled = false;
            }
            closeAllForms();
        }

        private void SalesButton_Click(object sender, EventArgs e)
        {
            closeAllForms();
            salesForm sales = new salesForm();
            sales.MdiParent = this;
            sales.Show();
        }

        private void CosmeticSalesButton_Click(object sender, EventArgs e)
        {
            closeAllForms();
            cosmeticSales cosSales = new cosmeticSales();
            cosSales.MdiParent = this;
            cosSales.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void statusMenu_Click(object sender, EventArgs e)
        {
            if (statusMenu.Checked == false)
                statusStrip1.Visible = false;
            else statusStrip1.Visible = true;

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (passwordTextbox.Text == password.ToString())
            {
                Admin admin = new Admin();
                cancelButton_Click(sender, e);                
                admin.ShowDialog();
            }
            else errorProvider.SetError(passwordTextbox, "Invalid password. Please try Again.");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Passwordpanel.Visible = false;
            passwordTextbox.Clear();
            enableControls(this);
        }

        private void CancelButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void passwordTextbox_TextChanged(object sender, EventArgs e)
        {
            if (passwordTextbox.Text != "")
                OkButton.Enabled = true;
            else OkButton.Enabled = false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            exitApp();
        }

        private void adminMenu_Click(object sender, EventArgs e)
        {
            Passwordpanel.Visible = true;
            DisableControls(this, Passwordpanel);
           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {           
            MenuButton_Click(sender, e);
            CosmeticMenuButton_Click(sender, e);
            ResMenuButton_Click(sender, e);
            Fashion = true;           
        }
    }
}

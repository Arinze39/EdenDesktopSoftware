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
    public partial class hairCareForm : Form
    {
        private string MainCategory = "";
        String[] tab1, tab2, tab3, tab4, tab5, tab6, tab7, tab8, tab9, tab10, tab11, tab12, tab13, tab14, tab15, tab16, tab17, tab18;
        bool Clicked0 = false, Clicked1 = false, Clicked2 = false, Clicked3 = false, Clicked4 = false, Clicked5 = false, Clicked6 = false, Clicked7 = false, Clicked8 = false, Clicked9 = false, Clicked10 = false, Clicked11 = false, Clicked12 = false, Clicked13 = false, Clicked14 = false, Clicked15 = false, Clicked16 = false, Clicked17 = false; 
        EdenDbDataSetTableAdapters.ProduteDataTableAdapter getName = new EdenDbDataSetTableAdapters.ProduteDataTableAdapter();

        private void control_Click(object sender, EventArgs e)
        {
            addProducts Add = new addProducts(ActiveControl.Text);
            Add.Owner = this;
            Add.ShowDialog();
        }

        private void MenutabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int tabIndex = MenutabControl1.SelectedIndex;

            switch (tabIndex)
            {
                case 0:
                    {
                        int i = 0;
                        if (Clicked0 == true)
                            break;
                        else
                        {
                            foreach (Button control in MenutabControl1.SelectedTab.Controls)
                            {
                                if (i == tab1.Length)
                                    break;
                                control.Text = tab1[i];
                                control.Click += new EventHandler(control_Click);
                                i++; Clicked0 = true;

                            }
                        }

                    }
                    break;

                case 1:
                    {
                        int i = 0;
                        if (Clicked1 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab2.Length)
                                break;
                            control.Text = tab2[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked1 = true;

                        }
                    }
                    break;

                case 2:
                    {
                        int i = 0;
                        if (Clicked2 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab3.Length)
                                break;
                            control.Text = tab3[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked2 = true;

                        }
                    }
                    break;

                case 3:
                    {
                        int i = 0;
                        if (Clicked3 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab4.Length)
                                break;
                            control.Text = tab4[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked3 = true;

                        }
                    }
                    break;

                case 4:
                    {
                        int i = 0;
                        if (Clicked4 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab5.Length)
                                break;
                            control.Text = tab5[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked4 = true;

                        }
                    }
                    break;

                case 5:
                    {
                        int i = 0;
                        if (Clicked5 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab6.Length)
                                break;
                            control.Text = tab6[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked5 = true;

                        }
                    }
                    break;

                case 6:
                    {
                        int i = 0;
                        if (Clicked6 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab7.Length)
                                break;
                            control.Text = tab7[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked6 = true;

                        }
                    }
                    break;

                case 7:
                    {
                        int i = 0;
                        if (Clicked7 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab8.Length)
                                break;
                            control.Text = tab8[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked7 = true;

                        }
                    }
                    break;

                case 8:
                    {
                        int i = 0;
                        if (Clicked8 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab9.Length)
                                break;
                            control.Text = tab9[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked8 = true;

                        }
                    }
                    break;

                case 9:
                    {
                        int i = 0;
                        if (Clicked9 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab10.Length)
                                break;
                            control.Text = tab10[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked9 = true;

                        }
                    }
                    break;

                case 10:
                    {
                        int i = 0;
                        if (Clicked10 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab11.Length)
                                break;
                            control.Text = tab11[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked10 = true;

                        }
                    }
                    break;

                case 11:
                    {
                        int i = 0;
                        if (Clicked11 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab12.Length)
                                break;
                            control.Text = tab12[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked11 = true;

                        }
                    }
                    break;

                case 12:
                    {
                        int i = 0;
                        if (Clicked12 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab13.Length)
                                break;
                            control.Text = tab13[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked12 = true;

                        }
                    }
                    break;

                case 13:
                    {
                        int i = 0;
                        if (Clicked13 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab14.Length)
                                break;
                            control.Text = tab14[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked13 = true;

                        }
                    }
                    break;

                case 14:
                    {
                        int i = 0;
                        if (Clicked14 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab15.Length)
                                break;
                            control.Text = tab15[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked14 = true;

                        }
                    }
                    break;

                case 15:
                    {
                        int i = 0;
                        if (Clicked15 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab16.Length)
                                break;
                            control.Text = tab16[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked15 = true;

                        }
                    }
                    break;

                case 16:
                    {
                        int i = 0;
                        if (Clicked16 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab17.Length)
                                break;
                            control.Text = tab17[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked16 = true;

                        }
                    }
                    break;

                case 17:
                    {
                        int i = 0;
                        if (Clicked17 == true)
                            break;
                        foreach (Button control in MenutabControl1.SelectedTab.Controls)
                        {
                            if (i == tab18.Length)
                                break;
                            control.Text = tab18[i];
                            control.Click += new EventHandler(control_Click);
                            i++; Clicked17 = true;

                        }
                    }
                    break;
            }
        }

        private static void DrawTabText(TabControl tabControl, DrawItemEventArgs e, System.Drawing.Color backColor, System.Drawing.Color foreColor, string caption)
        {
            #region setup
            Font tabFont;
            Brush foreBrush = new SolidBrush(foreColor);
            Rectangle r = e.Bounds;
            Brush backBrush = new SolidBrush(backColor);
            string tabName = tabControl.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            #endregion

            #region drawing
            e.Graphics.FillRectangle(backBrush, r);

            r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            if (e.Index == tabControl.SelectedIndex)
            {
                tabFont = new Font(e.Font, FontStyle.Italic);
                tabFont = new Font(tabFont, FontStyle.Bold);
            }
            else
            {
                tabFont = e.Font;
            }

            e.Graphics.DrawString(caption, tabFont, foreBrush, r, sf);
            #endregion

            #region cleanup
            sf.Dispose();
            if (e.Index == tabControl.SelectedIndex)
            {
                tabFont.Dispose();
                backBrush.Dispose();
            }
            else
            {
                backBrush.Dispose();
                foreBrush.Dispose();
            }
            #endregion

        }
        
        private void MenutabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = MenutabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = MenutabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.White);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Calibri", (float)15.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));

            DrawTabText(MenutabControl1, e, Color.Black, Color.White, _tabPage.Text);

        }      

        private void hairCareForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(98, Owner.AutoScrollPosition.Y + 3);  //set x,y to where you want it to appear
            MenutabControl1.SelectTab(1); MenutabControl1.SelectTab(0);

        }

        public hairCareForm(string mainCategory, bool execute)
        {
            InitializeComponent();
            this.MainCategory = mainCategory.ToLower();
            if (execute)
                getNamesFromDB();
        }

        private String[] getProdName(string SubCategory)
        {
            DataRow dataRow;
            DataTable dataTable; int count = 0;
            count = Convert.ToInt32(getName.COUNT_BY_CATEGORY(MainCategory, SubCategory));
            String[] result = new String[count];
            if (count != 0)
            {
                dataTable = getName.GetDataByCategory(MainCategory, SubCategory);
                for (int i = 0; i < count; i++)
                {
                    dataRow = dataTable.Rows[i];
                    result[i] = dataRow.ItemArray.GetValue(1).ToString();

                }
            }
            return result;
        }

        public void getNamesFromDB()
        {
            TabControl.TabPageCollection tabs = new TabControl.TabPageCollection(MenutabControl1);
            string[] tabName = new string[tabs.Count]; int i = 0;
            foreach (TabPage page in tabs)
            {
                tabName[i] = page.Text.ToLower();
                //if(tabName[i] != null)
                i++;
            }
            tab1 = getProdName(tabName[0]);
            tab2 = getProdName(tabName[1]);
            tab3 = getProdName(tabName[2]);
            tab4 = getProdName(tabName[3]);
            tab5 = getProdName(tabName[4]);
            tab6 = getProdName(tabName[5]);
            tab7 = getProdName(tabName[6]);
            tab8 = getProdName(tabName[7]);
            tab9 = getProdName(tabName[8]);
            tab10 = getProdName(tabName[9]);
            tab11 = getProdName(tabName[10]);
            tab12 = getProdName(tabName[11]);
            tab13 = getProdName(tabName[12]);
            tab14 = getProdName(tabName[13]);
            tab15 = getProdName(tabName[14]);
            tab16 = getProdName(tabName[15]);
            tab17 = getProdName(tabName[16]);
            tab18 = getProdName(tabName[17]);

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

namespace EdenDesktopSoftware
{
    partial class SalesMainReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ByStartDatebutton = new System.Windows.Forms.Button();
            this.ByDoBbutton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CITbutton = new System.Windows.Forms.Button();
            this.RITbutton = new System.Windows.Forms.Button();
            this.FISbutton = new System.Windows.Forms.Button();
            this.edenDbDataSet = new EdenDesktopSoftware.EdenDbDataSet();
            this.cosmeticItemSoldBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cosmeticItemSoldTableAdapter = new EdenDesktopSoftware.EdenDbDataSetTableAdapters.CosmeticItemSoldTableAdapter();
            this.employeeDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeDataTableAdapter = new EdenDesktopSoftware.EdenDbDataSetTableAdapters.EmployeeDataTableAdapter();
            this.fashionItemSoldBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fashionItemSoldTableAdapter = new EdenDesktopSoftware.EdenDbDataSetTableAdapters.FashionItemSoldTableAdapter();
            this.produteDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produteDataTableAdapter = new EdenDesktopSoftware.EdenDbDataSetTableAdapters.ProduteDataTableAdapter();
            this.restuarantItemSoldBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.restuarantItemSoldTableAdapter = new EdenDesktopSoftware.EdenDbDataSetTableAdapters.RestuarantItemSoldTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edenDbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cosmeticItemSoldBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fashionItemSoldBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produteDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restuarantItemSoldBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 18);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(18, 218);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(113, 20);
            this.dateTimePickerFrom.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date From:";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(161, 218);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(113, 20);
            this.dateTimePickerTo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(158, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date To:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(291, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(839, 552);
            this.panel1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(833, 546);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 317);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Items";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ByStartDatebutton);
            this.groupBox2.Controls.Add(this.ByDoBbutton);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Employee:";
            // 
            // ByStartDatebutton
            // 
            this.ByStartDatebutton.Location = new System.Drawing.Point(139, 18);
            this.ByStartDatebutton.Name = "ByStartDatebutton";
            this.ByStartDatebutton.Size = new System.Drawing.Size(115, 33);
            this.ByStartDatebutton.TabIndex = 1;
            this.ByStartDatebutton.Text = "By Start Date...";
            this.ByStartDatebutton.UseVisualStyleBackColor = true;
            this.ByStartDatebutton.Click += new System.EventHandler(this.ByStartDatebutton_Click);
            // 
            // ByDoBbutton
            // 
            this.ByDoBbutton.Location = new System.Drawing.Point(6, 18);
            this.ByDoBbutton.Name = "ByDoBbutton";
            this.ByDoBbutton.Size = new System.Drawing.Size(115, 33);
            this.ByDoBbutton.TabIndex = 1;
            this.ByDoBbutton.Text = "By Date of Birth...";
            this.ByDoBbutton.UseVisualStyleBackColor = true;
            this.ByDoBbutton.Click += new System.EventHandler(this.ByDoBbutton_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.CITbutton);
            this.panel2.Controls.Add(this.RITbutton);
            this.panel2.Controls.Add(this.FISbutton);
            this.panel2.Location = new System.Drawing.Point(6, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 49);
            this.panel2.TabIndex = 1;
            // 
            // CITbutton
            // 
            this.CITbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CITbutton.Location = new System.Drawing.Point(95, 6);
            this.CITbutton.Name = "CITbutton";
            this.CITbutton.Size = new System.Drawing.Size(75, 36);
            this.CITbutton.TabIndex = 1;
            this.CITbutton.Text = "Cosmetic Items Sold";
            this.CITbutton.UseVisualStyleBackColor = true;
            this.CITbutton.Click += new System.EventHandler(this.CITbutton_Click);
            // 
            // RITbutton
            // 
            this.RITbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RITbutton.Location = new System.Drawing.Point(182, 6);
            this.RITbutton.Name = "RITbutton";
            this.RITbutton.Size = new System.Drawing.Size(75, 36);
            this.RITbutton.TabIndex = 1;
            this.RITbutton.Text = "Restuarant Items Sold";
            this.RITbutton.UseVisualStyleBackColor = true;
            this.RITbutton.Click += new System.EventHandler(this.RITbutton_Click);
            // 
            // FISbutton
            // 
            this.FISbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FISbutton.Location = new System.Drawing.Point(8, 6);
            this.FISbutton.Name = "FISbutton";
            this.FISbutton.Size = new System.Drawing.Size(75, 36);
            this.FISbutton.TabIndex = 1;
            this.FISbutton.Text = "Fashion Items Sold";
            this.FISbutton.UseVisualStyleBackColor = true;
            this.FISbutton.Click += new System.EventHandler(this.FISbutton_Click);
            // 
            // edenDbDataSet
            // 
            this.edenDbDataSet.DataSetName = "EdenDbDataSet";
            this.edenDbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cosmeticItemSoldBindingSource
            // 
            this.cosmeticItemSoldBindingSource.DataMember = "CosmeticItemSold";
            this.cosmeticItemSoldBindingSource.DataSource = this.edenDbDataSet;
            // 
            // cosmeticItemSoldTableAdapter
            // 
            this.cosmeticItemSoldTableAdapter.ClearBeforeFill = true;
            // 
            // employeeDataBindingSource
            // 
            this.employeeDataBindingSource.DataMember = "EmployeeData";
            this.employeeDataBindingSource.DataSource = this.edenDbDataSet;
            // 
            // employeeDataTableAdapter
            // 
            this.employeeDataTableAdapter.ClearBeforeFill = true;
            // 
            // fashionItemSoldBindingSource
            // 
            this.fashionItemSoldBindingSource.DataMember = "FashionItemSold";
            this.fashionItemSoldBindingSource.DataSource = this.edenDbDataSet;
            // 
            // fashionItemSoldTableAdapter
            // 
            this.fashionItemSoldTableAdapter.ClearBeforeFill = true;
            // 
            // produteDataBindingSource
            // 
            this.produteDataBindingSource.DataMember = "ProduteData";
            this.produteDataBindingSource.DataSource = this.edenDbDataSet;
            // 
            // produteDataTableAdapter
            // 
            this.produteDataTableAdapter.ClearBeforeFill = true;
            // 
            // restuarantItemSoldBindingSource
            // 
            this.restuarantItemSoldBindingSource.DataMember = "RestuarantItemSold";
            this.restuarantItemSoldBindingSource.DataSource = this.edenDbDataSet;
            // 
            // restuarantItemSoldTableAdapter
            // 
            this.restuarantItemSoldTableAdapter.ClearBeforeFill = true;
            // 
            // SalesMainReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 576);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.monthCalendar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SalesMainReportForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SalesMainReportForm";
            this.Load += new System.EventHandler(this.SalesMainReportForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edenDbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cosmeticItemSoldBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fashionItemSoldBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produteDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restuarantItemSoldBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ByStartDatebutton;
        private System.Windows.Forms.Button ByDoBbutton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button CITbutton;
        private System.Windows.Forms.Button RITbutton;
        private System.Windows.Forms.Button FISbutton;
        private EdenDbDataSet edenDbDataSet;
        private System.Windows.Forms.BindingSource cosmeticItemSoldBindingSource;
        private EdenDbDataSetTableAdapters.CosmeticItemSoldTableAdapter cosmeticItemSoldTableAdapter;
        private System.Windows.Forms.BindingSource employeeDataBindingSource;
        private EdenDbDataSetTableAdapters.EmployeeDataTableAdapter employeeDataTableAdapter;
        private System.Windows.Forms.BindingSource fashionItemSoldBindingSource;
        private EdenDbDataSetTableAdapters.FashionItemSoldTableAdapter fashionItemSoldTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource produteDataBindingSource;
        private EdenDbDataSetTableAdapters.ProduteDataTableAdapter produteDataTableAdapter;
        private System.Windows.Forms.BindingSource restuarantItemSoldBindingSource;
        private EdenDbDataSetTableAdapters.RestuarantItemSoldTableAdapter restuarantItemSoldTableAdapter;
    }
}
namespace EdenDesktopSoftware
{
    partial class ReportForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.FashionItemSoldBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EdenDbDataSet = new EdenDesktopSoftware.EdenDbDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.FashionItemSoldTableAdapter = new EdenDesktopSoftware.EdenDbDataSetTableAdapters.FashionItemSoldTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.FashionItemSoldBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdenDbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // FashionItemSoldBindingSource
            // 
            this.FashionItemSoldBindingSource.DataMember = "FashionItemSold";
            this.FashionItemSoldBindingSource.DataSource = this.EdenDbDataSet;
            // 
            // EdenDbDataSet
            // 
            this.EdenDbDataSet.DataSetName = "EdenDbDataSet";
            this.EdenDbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.FashionItemSoldBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EdenDesktopSoftware.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(86, 6);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(879, 722);
            this.reportViewer1.TabIndex = 0;
            // 
            // FashionItemSoldTableAdapter
            // 
            this.FashionItemSoldTableAdapter.ClearBeforeFill = true;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1057, 741);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ReportForm";
            this.ShowIcon = false;
            this.Text = "Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FashionItemSoldBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdenDbDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource FashionItemSoldBindingSource;
        private EdenDbDataSet EdenDbDataSet;
        private EdenDbDataSetTableAdapters.FashionItemSoldTableAdapter FashionItemSoldTableAdapter;
    }
}
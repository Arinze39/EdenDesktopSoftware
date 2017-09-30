namespace EdenDesktopSoftware
{
    partial class CosmeticReportForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CosmeticItemSoldBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EdenDbDataSet = new EdenDesktopSoftware.EdenDbDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CosmeticItemSoldTableAdapter = new EdenDesktopSoftware.EdenDbDataSetTableAdapters.CosmeticItemSoldTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CosmeticItemSoldBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdenDbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // CosmeticItemSoldBindingSource
            // 
            this.CosmeticItemSoldBindingSource.DataMember = "CosmeticItemSold";
            this.CosmeticItemSoldBindingSource.DataSource = this.EdenDbDataSet;
            // 
            // EdenDbDataSet
            // 
            this.EdenDbDataSet.DataSetName = "EdenDbDataSet";
            this.EdenDbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.CosmeticItemSoldBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EdenDesktopSoftware.CosmeticReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(146, 6);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(821, 722);
            this.reportViewer1.TabIndex = 0;
            // 
            // CosmeticItemSoldTableAdapter
            // 
            this.CosmeticItemSoldTableAdapter.ClearBeforeFill = true;
            // 
            // CosmeticReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1072, 741);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CosmeticReportForm";
            this.ShowIcon = false;
            this.Text = "Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CosmeticReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CosmeticItemSoldBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdenDbDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CosmeticItemSoldBindingSource;
        private EdenDbDataSet EdenDbDataSet;
        private EdenDbDataSetTableAdapters.CosmeticItemSoldTableAdapter CosmeticItemSoldTableAdapter;
    }
}
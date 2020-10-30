namespace EmployeeInformation.Reports
{
    partial class frmEmployeeListReport
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
            this.dsEmployeeList = new EmployeeInformation.Reports.EmployeeList.dsEmployeeList();
            this.dataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmployeeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dsEmployeeList
            // 
            this.dsEmployeeList.DataSetName = "dsEmployeeList";
            this.dsEmployeeList.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EmployeeInformation.Reports.EmployeeList.rptEmployeeList.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(814, 772);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmEmployeeListReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 796);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmEmployeeListReport";
            this.Text = "frmEmployeeListReport";
            this.Load += new System.EventHandler(this.frmEmployeeListReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsEmployeeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource dataTable1BindingSource;
        private EmployeeList.dsEmployeeList dsEmployeeList;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
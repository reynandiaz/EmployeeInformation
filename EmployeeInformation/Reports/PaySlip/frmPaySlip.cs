using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace EmployeeInformation.Reports.PaySlip
{
    public partial class frmPaySlip : Form
    {
        public static string prEmployeeCode;
        public static string prEmployeeName;
        public static string prRate;
        public static string prHoursOfWork;
        public static string prFrom;
        public static string prTo;
        public static string prPay;

        public frmPaySlip()
        {
            InitializeComponent();
        }

        private void frmPaySlip_Load(object sender, EventArgs e)
        {
            DataTable data = new DataTable();

            ReportParameterCollection reportParams = new ReportParameterCollection();

            reportParams.Add(new ReportParameter("prEmployeeCode", prEmployeeCode));
            reportParams.Add(new ReportParameter("prEmployeeName", prEmployeeName));
            reportParams.Add(new ReportParameter("prRate", prRate));
            reportParams.Add(new ReportParameter("prHoursOfWork", prHoursOfWork));
            reportParams.Add(new ReportParameter("prFrom", prFrom));
            reportParams.Add(new ReportParameter("prTo", prTo));
            reportParams.Add(new ReportParameter("prPay", prPay));

            this.reportViewer1.LocalReport.SetParameters(reportParams);

            this.reportViewer1.RefreshReport();
        }
    }
}

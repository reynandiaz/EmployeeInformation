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

namespace EmployeeInformation.Reports.EmployeeData
{
    public partial class frmEmployeeData : Form
    {
        public static string EmployeeCode;
        public frmEmployeeData()
        {
            InitializeComponent();
        }

        private void frmEmployeeData_Load(object sender, EventArgs e)
        {
            DataTable data = DataProcess.ReportsData.getrtpEmployeeData(EmployeeCode);

            ReportParameterCollection reportParams = new ReportParameterCollection();

            reportParams.Add(new ReportParameter("prLastname", data.Rows[0]["LastName"].ToString()));
            reportParams.Add(new ReportParameter("prFirstname", data.Rows[0]["FirstName"].ToString()));
            reportParams.Add(new ReportParameter("prMiddlename", data.Rows[0]["MiddleName"].ToString()));
            reportParams.Add(new ReportParameter("prAddress", data.Rows[0]["Address"].ToString()));
            reportParams.Add(new ReportParameter("prGender", data.Rows[0]["Gender"].ToString()));
            reportParams.Add(new ReportParameter("prBirthdate", data.Rows[0]["BirthDate"].ToString()));
            reportParams.Add(new ReportParameter("prDepartment", data.Rows[0]["DepartmentName"].ToString()));
            reportParams.Add(new ReportParameter("prSection", data.Rows[0]["DepartmentName"].ToString()));
            this.reportViewer1.LocalReport.SetParameters(reportParams);

            this.reportViewer1.RefreshReport();
        }

    }
}

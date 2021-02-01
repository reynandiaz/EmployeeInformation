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
using EmployeeInformation.DataProcess;

namespace EmployeeInformation.Reports.EmployeeID
{
    public partial class frmEmployeeID : Form
    {
        public static string EmployeeID;
        public frmEmployeeID()
        {
            InitializeComponent();
        }

        private void frmEmployeeID_Load(object sender, EventArgs e)
        {
            DataTable data = getData();

            ReportParameterCollection reportParams = new ReportParameterCollection();
            reportParams.Add(new ReportParameter("prEmployeeName", data.Rows[0]["EmployeeName"].ToString()));
            reportParams.Add(new ReportParameter("prDepartment", data.Rows[0]["DepartmentName"].ToString()));
            reportParams.Add(new ReportParameter("prSection", data.Rows[0]["SectionName"].ToString()));
            reportParams.Add(new ReportParameter("prEmployeeID", data.Rows[0]["EmployeeCode"].ToString()));
            this.reportViewer1.LocalReport.SetParameters(reportParams);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.RefreshReport();
        }

        private static DataTable getData()
        {
            DataTable rtnValue = new DataTable();

            string query = "SELECT e.EmployeeCode,concat(e.Lastname, ', ', e.Firstname,' ',e.Middlename) AS EmployeeName , " +
                            "d.DepartmentName , s.SectionName " +
                            "FROM employees e " +
                            "LEFT JOIN departments d " +
                            "ON d.DepartmentID = e.DepartmentID " +
                            "LEFT JOIN sections s " +
                            "ON s.DepartmentID = d.DepartmentID " +
                            "AND s.SectionID = e.SectionID " +
                            "WHERE e.EmployeeCode = '"+ EmployeeID +"' ";

            rtnValue = Config.RetreiveData(query);

            return rtnValue;
        }
    }
}

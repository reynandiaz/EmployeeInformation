using EmployeeInformation.DataProcess;
using EmployeeInformation.Reports.EmployeeList;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace EmployeeInformation.Reports
{
    public partial class frmEmployeeListReport : Form
    {
        public frmEmployeeListReport()
        {
            InitializeComponent();
        }

        private void frmEmployeeListReport_Load(object sender, EventArgs e)
        {

            dsEmployeeList lstEmployee = GetData();

            ReportDataSource datasource = new ReportDataSource("DataSet1", lstEmployee.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            this.reportViewer1.RefreshReport();
        }
        private dsEmployeeList GetData()
        {
            string query = "SELECT EmployeeCode,concat(lastname,', ',firstname, ' ',Middlename )as EmployeeName " +
                 ",d.DepartmentName as Department, " +
                 "s.SectionName as Section " +
                 "from employees e " +
                 "inner join sections s " +
                 "on s.SectionID = e.SectionID " +
                 "and s.DepartmentID = e.DepartmentID " +
                 "inner join departments d " +
                 "on d.DepartmentID = s.DepartmentID where e.deleteddate is null";

            var command = new MySqlCommand(query,Config.connection);

            try
            {
                Config.connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                dsEmployeeList ds = new dsEmployeeList();
                da.Fill(ds, "DataTable1");
                return ds;
            }
            finally
            {
                Config.connection.Close();
            }
            
        }
    }
}

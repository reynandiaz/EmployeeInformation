using EmployeeInformation.DataProcess;
using EmployeeInformation.Reports.EmployeeID;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using QRCoder;
using System.Data;



namespace EmployeeInformation.Reports.EmployeeID
{
    public partial class frmEmployeeID : Form
    {
        public static string EmployeeCode;
        public frmEmployeeID()
        {
            InitializeComponent();
        }

        private void frmEmployeeID_Load(object sender, EventArgs e)
        {


            dsEmployeeID lstEmployee = GetData();


            string strQRId = "A1R" + lstEmployee.DataTable1.Rows[0]["EmployeeCode"].ToString().PadLeft(6, '0') + "Z";
            lstEmployee.DataTable1.Rows[0]["Barcode"] = strQRId;
            //GenerateBarcodes(strQRId);

            ReportDataSource datasource = new ReportDataSource("DataSet1", lstEmployee.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.RefreshReport();

        }
        private void GenerateBarcodes(string qrValue)
        {
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            pictureBox1.Image = qrcode.Draw(qrValue, 20);
            pictureBox2.Image = qrcode.Draw(qrValue, 20);
        }


        private dsEmployeeID GetData()
        {
            string query = " SELECT EmployeeCode,concat(lastname,', ',firstname, ' ',Middlename )as EmployeeName " +
                 ",d.DepartmentName as Department " +
                 ",s.SectionName as Section " +
                 "from employees e " +
                 "inner join sections s " +
                 "on s.SectionID = e.SectionID " +
                 "and s.DepartmentID = e.DepartmentID " +
                 "inner join departments d " +
                 "on d.DepartmentID = s.DepartmentID where e.deleteddate is null and EmployeeCode = '" + EmployeeCode + "'";

            var command = new MySqlCommand(query, Config.connection);

            try
            {
                Config.connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                dsEmployeeID ds = new dsEmployeeID();
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

using EmployeeInformation.DataProcess;
using EmployeeInformation.Reports.EmployeeID;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;



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
            //testQR();
            //MessageBox.Show(lstEmployee.DataTable1.Rows[0]["EmployeeCode"].ToString());
            //generateQRCode(lstEmployee);

            ReportDataSource datasource = new ReportDataSource("DataSet1", lstEmployee.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.RefreshReport();
        }

        private void testQR()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("The text which should be encoded.", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            //Bitmap qrCodeImage = qrCode.GetGraphic(20);

            Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Bitmap.FromFile("C:\\myimage.png"));
        }
        private dsEmployeeID GetData()
        {
            string query = " SELECT EmployeeCode,concat(lastname,', ',firstname, ' ',Middlename )as EmployeeName " +
                 ",d.DepartmentName as Department, " +
                 "s.SectionName as Section " +
                 "from employees e " +
                 "inner join sections s " +
                 "on s.SectionID = e.SectionID " +
                 "and s.DepartmentID = e.DepartmentID " +
                 "inner join departments d " +
                 "on d.DepartmentID = s.DepartmentID where e.deleteddate is null and EmployeeCode = '"+ EmployeeCode + "'";

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

        private void generateQRCode(dsEmployeeID lstEmployee)
        {
            QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
            QRCoder.QRCodeData qrData = qrGenerator.CreateQrCode(lstEmployee.DataTable1.Rows[0]["EmployeeCode"].ToString(),QRCoder.QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode qrCode = new QRCoder.QRCode(qrData);
            Bitmap bmp = qrCode.GetGraphic(7);
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, ImageFormat.Bmp);
            }
        }


    }
}

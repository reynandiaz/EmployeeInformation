using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeInformation.DataProcess;

namespace EmployeeInformation
{
    public partial class MonthSelection : Form
    {
        public static string prEmployeeCode;
        DataTable monthsdata = new DataTable();
        public MonthSelection()
        {
            InitializeComponent();
        }

        private void MonthSelection_Load(object sender, EventArgs e)
        {
            GenerateMonths();
        }

        private void GenerateMonths()
        {
            monthsdata.Columns.Add(new DataColumn("Month"));
            monthsdata.Columns.Add(new DataColumn("Value"));

            var drow1 = monthsdata.NewRow();
            drow1["Month"] = "January";
            drow1["Value"] = "01";
            monthsdata.Rows.Add(drow1);

            var drow2 = monthsdata.NewRow();
            drow2["Month"] = "February";
            drow2["Value"] = "02";
            monthsdata.Rows.Add(drow2);

            var drow3 = monthsdata.NewRow();
            drow3["Month"] = "March";
            drow3["Value"] = "03";
            monthsdata.Rows.Add(drow3);

            var drow4 = monthsdata.NewRow();
            drow4["Month"] = "April";
            drow4["Value"] = "04";
            monthsdata.Rows.Add(drow4);

            var drow5 = monthsdata.NewRow();
            drow5["Month"] = "May";
            drow5["Value"] = "05";
            monthsdata.Rows.Add(drow5);

            var drow6 = monthsdata.NewRow();
            drow6["Month"] = "June";
            drow6["Value"] = "06";
            monthsdata.Rows.Add(drow6);

            var drow7 = monthsdata.NewRow();
            drow7["Month"] = "July";
            drow7["Value"] = "07";
            monthsdata.Rows.Add(drow7);

            var drow8 = monthsdata.NewRow();
            drow8["Month"] = "August";
            drow8["Value"] = "08";
            monthsdata.Rows.Add(drow8);

            var drow9 = monthsdata.NewRow();
            drow9["Month"] = "September";
            drow9["Value"] = "09";
            monthsdata.Rows.Add(drow9);

            var drow10 = monthsdata.NewRow();
            drow10["Month"] = "October";
            drow10["Value"] = "10";
            monthsdata.Rows.Add(drow10);

            var drow11 = monthsdata.NewRow();
            drow11["Month"] = "November";
            drow11["Value"] = "11";
            monthsdata.Rows.Add(drow11);

            var drow12 = monthsdata.NewRow();
            drow12["Month"] = "December";
            drow12["Value"] = "12";
            monthsdata.Rows.Add(drow12);

            foreach (DataRow row in monthsdata.Rows)
            {
                cmbMonths.Items.Add(row[0]);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(cmbMonths.Text!="")
            {
                string monthValue = "";
                foreach(DataRow row in monthsdata.Rows)
                {
                    if (cmbMonths.Text == row["Month"].ToString())
                    {
                        monthValue =row["Value"].ToString();
                    }
                }
                if(monthValue != "")
                {
                    ComputeData(prEmployeeCode, monthValue);
                }
            }
        }
        private void ComputeData(string EmployeeCode, string  DateValue)
        {
            try
            {
                string Year = DateTime.Now.ToString("yyyy");
                int workhour = 0;
                double dbPay = 0.0;

                DataTable info = new DataTable();
                string query = "SELECT e.EmployeeCode,concat(e.Lastname, ', ', e.Firstname, ' ', e.Middlename) AS EmployeeName, er.Rate FROM employees e " +
                                "LEFT JOIN employeerate er " +
                                "ON er.EmployeeCode = e.EmployeeCode " +
                                "WHERE e.EmployeeCode = '" + EmployeeCode + "' ";
                info = Config.RetreiveData(query);

                DataTable logtimeinfo = new DataTable();
                string getLogTimes = "SELECT DATE_FORMAT(StartTime, '%Y-%m-%d %T') AS TimeIN,DATE_FORMAT(Endtime, '%Y-%m-%d %T') AS TimeOut   FROM logtime lt " +
                                    "WHERE lt.EmployeeCode = '" + EmployeeCode + "' " +
                                    "AND Date(lt.LogDate) BETWEEN  '" + Year + "-" + DateValue + "-01' AND '" + Year + "-" + DateValue + "-31' ";
                logtimeinfo = Config.RetreiveData(getLogTimes);
                foreach (DataRow row in logtimeinfo.Rows)
                {
                    string computehour = "SELECT TIMESTAMPDIFF(HOUR, '" + row["TimeIN"] + "', '" + row["TimeOut"] + "') AS Difference";
                    workhour = workhour + Config.ExecuteIntScalar(computehour);
                }
                dbPay = Convert.ToDouble(info.Rows[0]["Rate"]) * workhour;
                Reports.PaySlip.frmPaySlip.prEmployeeCode = EmployeeCode;
                Reports.PaySlip.frmPaySlip.prEmployeeName = info.Rows[0]["EmployeeName"].ToString();
                Reports.PaySlip.frmPaySlip.prRate = info.Rows[0]["Rate"].ToString();
                Reports.PaySlip.frmPaySlip.prHoursOfWork = workhour.ToString();
                Reports.PaySlip.frmPaySlip.prFrom = Year + "-" + DateValue + "-01";
                Reports.PaySlip.frmPaySlip.prTo = Year + "-" + DateValue + "-31";
                Reports.PaySlip.frmPaySlip.prPay = dbPay.ToString();

                Form slip = new Reports.PaySlip.frmPaySlip();
                slip.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Error Occurred!");
            }
        }
    }
}
 
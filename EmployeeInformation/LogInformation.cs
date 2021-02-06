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
    public partial class LogInformation : Form
    {
        DataTable monthsdata = new DataTable();
        public static string EmployeeCode;
        private string strMonthValue;

        public LogInformation()
        {
            InitializeComponent();
        }

        private void LogInformation_Load(object sender, EventArgs e)
        {
            GenerateMonths();
            RefreshTable();
        }
        private void RefreshTable()
        {
            string Year = DateTime.Now.ToString("yyyy");
            foreach (DataRow row in monthsdata.Rows)
            {
                if (cmbMonths.Text == row["Month"].ToString())
                {
                    strMonthValue = row["Value"].ToString();
                }
            }

            string query = "SELECT DATE_FORMAT(LogDate, '%Y-%m-%d') AS LogDate,DATE_FORMAT(StartTime, '%T') AS TimeIN,DATE_FORMAT(EndTime, '%T') AS TimeOut FROM logtime lt " +
                            "WHERE lt.EmployeeCode = '" + EmployeeCode + "' " +
                            "AND Date(lt.LogDate) BETWEEN  '"+ Year + "-"+ strMonthValue + "-01' AND '"+ Year + "-"+ strMonthValue + "-31' ";

            DataTable data = new DataTable();
            data = Config.RetreiveData(query);

            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = true;
            for (int x = 0; x < data.Rows.Count; x++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[x].Clone();
                row.Cells[0].Value = data.Rows[x]["LogDate"].ToString();
                row.Cells[1].Value = data.Rows[x]["TimeIn"].ToString();
                row.Cells[2].Value = data.Rows[x]["TimeOut"].ToString();
                dataGridView1.Rows.Add(row);
            }
            dataGridView1.AllowUserToAddRows = false;


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

        private void cmbMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataRow row in monthsdata.Rows)
            {
                if (cmbMonths.Text == row["Month"].ToString())
                {
                    strMonthValue = row["Value"].ToString();
                }
            }
            RefreshTable();
        }
    }
}

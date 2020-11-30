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

        private DateTime curDate ;


        public LogInformation()
        {
            InitializeComponent();
        }

        private void LogInformation_Load(object sender, EventArgs e)
        {
            curDate = DateTime.Now;
            //MessageBox.Show(curDate.Day.ToString());
            //this.GenerateData();
        }
        private void GenerateData()
        {
            //1st cutoff 6 - 20
            string query1 = "Select left(logdate,10) as Logdate,EmployeeCode,right(timein,8) as Timein," +
                "right(timeout,8) as Timeout from logtime " +
                "where left(logdate, 10) between '";
                if(curDate.Day>=6 && curDate.Day<=20)
                        {
                query1 = query1 + curDate.Year + "-" + curDate.Month + "-6";
                        }
                query1 = query1 + "' and '"+ curDate.Year + "-" + curDate.Month + "-20" + "'" ;


            //2nd cutoff 21 - 5
            string query2 = "Select left(logdate,10) as Logdate,EmployeeCode,right(timein,8) as Timein," +
            "right(timeout,8) as Timeout from logtime " +
            "where left(logdate, 10) between '";
            if (curDate.Day >= 5 && curDate.Day <= 21)
            {
                query2 = query2 + curDate.Year + "-" + (curDate.Month-1) + "-21";
            }
            query2 = query2 + "' and '" + curDate.Year + "-" + curDate.Month + "-5" + "'";

            //DataTable dtable1 = Config.RetreiveData(query1);
            DataTable dtable2 = Config.RetreiveData(query2);
            try
            {
                //if (curDate.Day >= 6 && curDate.Day <= 20)
                //{
                //    dataGridView1.Rows.Clear();
                //    dataGridView1.AllowUserToAddRows = true;
                //    for (int x = 0; x < dtable1.Rows.Count; x++)
                //    {
                //        DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[x].Clone();
                //        row.Cells[0].Value = dtable1.Rows[x]["LogDate"].ToString();
                //        row.Cells[1].Value = dtable1.Rows[x]["EmployeeCode"].ToString();
                //        row.Cells[2].Value = dtable1.Rows[x]["TimeIn"].ToString();
                //        row.Cells[3].Value = dtable1.Rows[x]["TimeOut"].ToString();

                //        dataGridView1.Rows.Add(row);
                //    }
                //    dataGridView1.AllowUserToAddRows = false;
                //}
                //else
                //{
                    dataGridView2.Rows.Clear();
                    dataGridView2.AllowUserToAddRows = true;
                    for (int x = 0; x < dtable2.Rows.Count; x++)
                    {
                        DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[x].Clone();
                        row.Cells[0].Value = dtable2.Rows[x]["LogDate"].ToString();
                        row.Cells[1].Value = dtable2.Rows[x]["EmployeeCode"].ToString();
                        row.Cells[2].Value = dtable2.Rows[x]["TimeIn"].ToString();
                        row.Cells[3].Value = dtable2.Rows[x]["TimeOut"].ToString();

                        dataGridView2.Rows.Add(row);
                    }
                    dataGridView2.AllowUserToAddRows = false;
                //}
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}

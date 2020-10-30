using LogTimeSwiping.DataProcess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogTimeSwiping
{
    
    public partial class Swiping : Form
    {
        private int SwipeMode;
        //SWIPE MODE =1? "Swipe in":"Swipeout"
        public Swiping()
        {
            InitializeComponent();
        }

        private void Swiping_Load(object sender, EventArgs e)
        {
            
            RefreshTable();
            SwipeMode = 1;
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss");
        }
        private void RefreshTable()
        {
            string query = "select EmployeeCode,convert(LogDate,char(10)) as DateLog,time(TimeIn) as TimeIn, " +
                           "TransIn,time(TimeOut) as TimeOut,TransOut from logtime lt " +
                           "where date(lt.LogDate)= curdate() " +
                           "order by time(lt.TimeIn) desc";
            DataTable dtable = Config.RetreiveData(query);

            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.AllowUserToAddRows = true;
                for (int x = 0; x < dtable.Rows.Count; x++)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[x].Clone();
                    row.Cells[0].Value = dtable.Rows[x]["EmployeeCode"].ToString();
                    row.Cells[1].Value = dtable.Rows[x]["DateLog"].ToString();
                    row.Cells[2].Value = dtable.Rows[x]["TimeIn"].ToString();
                    row.Cells[3].Value = dtable.Rows[x]["TransIn"].ToString();
                    row.Cells[4].Value = dtable.Rows[x]["TimeOut"].ToString();
                    row.Cells[5].Value = dtable.Rows[x]["TransOut"].ToString();

                    dataGridView1.Rows.Add(row);
                }
                dataGridView1.AllowUserToAddRows = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            { 
                txtID.Focus();
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13 && txtID.Text!="")
            {
                //temporary id
                txtEmployeeCode.Text = txtID.Text;

                int isSuccess = SwipingProcess.UpdateTimeIN(txtEmployeeCode.Text,lblDate.Text,lblTime.Text);

                //1 = success/ 2=failed/ 3=already login/ 4=not exist

                if (isSuccess == 2)
                {
                    MessageBox.Show("Failed Swipe!");
                }
                else if (isSuccess == 3)
                {
                    MessageBox.Show("Already Login!");
                }
                else if (isSuccess == 4)
                { MessageBox.Show("Invalid employee!"); }
                else if (isSuccess == 1)
                {
                    DataTable info = new DataTable();
                    info = SwipingProcess.getInformation(txtEmployeeCode.Text);
                    txtName.Text = info.Rows[0]["FirstName"].ToString();
                    txtDepartment.Text = info.Rows[0]["DepartmentName"].ToString();
                    txtSection.Text = info.Rows[0]["SectionName"].ToString();
                }
                RefreshTable();
                txtID.Text = "";
                txtID.Focus();
            }
        }
    }
}

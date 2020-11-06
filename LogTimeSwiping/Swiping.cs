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
                           "order by time(lt.TimeIn) desc limit 15 ";

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
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (txtID.Text != "" && txtID.Text.Length == 10)
                {
                    int isSuccess =0;
                    //temporary id
                    string newEmployeeCode = EvaluateEmployeeID(txtID.Text);

                    if (SwipeMode == 1)
                    {
                        isSuccess = SwipingProcess.UpdateTimeIN(newEmployeeCode, lblDate.Text, lblTime.Text);
                    }
                    else if (SwipeMode == 2)
                    { 
                        isSuccess= SwipingProcess.UpdateTimeOut(newEmployeeCode, lblDate.Text, lblTime.Text);
                    }
                    else
                    { 
                        MessageBox.Show("3"); 
                    }


                    //1 = success/ 2=failed/ 3=already login/ 4=not exist

                    if (isSuccess == 2)
                    {
                        //MessageBox.Show("Failed Swipe!");
                        MessageForm scanned = new MessageForm();
                        MessageForm.strMessage = "Failed Swipe!";
                        scanned.ShowDialog();
                    }
                    else if (isSuccess == 3)
                    {
                        //MessageBox.Show("Already Login!");
                        MessageForm scanned = new MessageForm();
                        MessageForm.strMessage = "Already updated!";
                        scanned.ShowDialog();
                    }
                    else if (isSuccess == 4)
                    { 
                        //MessageBox.Show("Invalid employee!");
                        MessageForm scanned = new MessageForm();
                        MessageForm.strMessage = "Invalid employee!";
                        scanned.ShowDialog();
                    }
                    else if (isSuccess == 5)
                    {
                        //MessageBox.Show("Invalid employee!");
                        MessageForm scanned = new MessageForm();
                        MessageForm.strMessage = "Not Logged in!";
                        scanned.ShowDialog();
                    }
                    else if (isSuccess == 1)
                    {
                        DataTable info = new DataTable();
                        info = SwipingProcess.getInformation(newEmployeeCode);
                        txtEmployeeCode.Text = info.Rows[0]["EmployeeCode"].ToString();
                        txtName.Text = info.Rows[0]["FirstName"].ToString();
                        txtDepartment.Text = info.Rows[0]["DepartmentName"].ToString();
                        txtSection.Text = info.Rows[0]["SectionName"].ToString();
                    }
                    RefreshTable();
                    txtID.Text = "";
                    txtID.Focus();
                }
                else
                { 
                    txtID.Text = "";
                    txtID.Focus();
                }
            }
        } 

        private static string EvaluateEmployeeID(string EmployeeID)
        {
            string GetCompanyEmployeeID = "";
            string ValidatedID;
            char validateEmployeeID;


            validateEmployeeID = Convert.ToChar(EmployeeID.Substring(4, 1));
            try
            {
                //HR
                if (validateEmployeeID == 'R' || validateEmployeeID == '3')
                {
                    GetCompanyEmployeeID = EmployeeID.Substring(4, 5);
                }
                //PV
                else if (validateEmployeeID == 'P' || validateEmployeeID == '0')
                {
                    GetCompanyEmployeeID = '0' + EmployeeID.Substring(4, 6);
                }
                //SCAD
                else if (validateEmployeeID == 'S' || validateEmployeeID == '1')
                {
                    GetCompanyEmployeeID = '1' + EmployeeID.Substring(4, 6);
                }
                //HTI
                else if (validateEmployeeID == 'H' || validateEmployeeID == '2')
                {
                    GetCompanyEmployeeID = '2' + EmployeeID.Substring(4, 6);
                }
                //WKN
                else if (validateEmployeeID == 'W' || validateEmployeeID == '4')
                {
                    GetCompanyEmployeeID = '4' + EmployeeID.Substring(4, 6);
                }
            }
            finally
            {
                ValidatedID = GetCompanyEmployeeID.ToString();
            }
            return ValidatedID;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (SwipeMode == 1)
            {
                SwipeMode = 2;
              
                lblStatus.Text = "(SWIPE OUT)";
                lblStatus.Left = lblStatus.Left - 25;
            }
            else
            {
                SwipeMode = 1;
                lblStatus.Text = "(SWIPE IN)";
                lblStatus.Left = lblStatus.Left + 25;
            }
            txtID.Focus();
        }
    }
}

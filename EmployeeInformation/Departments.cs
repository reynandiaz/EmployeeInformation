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
    public partial class Departments : Form
    {
        //1=new ; 2=update;
        private int intStatus;
        public Departments()
        {
            InitializeComponent();
        }

        private void Departments_Load(object sender, EventArgs e)
        {
            NewDepartment();
            RefreshTable();
        }

        private void RefreshTable()
        {
            string query = "SELECT D.DepartmentID,d.DepartmentName,count(D.DepartmentID) AS DCount FROM departments D " +
                           "left JOIN employees E " +
                           "ON E.DepartmentID = D.DepartmentID " +
                           "WHERE D.DeletedDate IS NULL " +
                           "GROUP BY DepartmentName, D.DepartmentID " +
                           "ORDER BY D.DepartmentID ";

            DataTable data = Config.RetreiveData(query);

            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.Rows.Add(data.Rows.Count);
            int x = 0;
            foreach (DataRow row in data.Rows)
            {
                dataGridView1.Rows[x].Cells[0].Value = row[0].ToString();
                dataGridView1.Rows[x].Cells[1].Value = row[1].ToString();
                dataGridView1.Rows[x].Cells[2].Value = row[2].ToString();
                dataGridView1.Rows[x].Cells[3].Value = ">>";
                x++;
            }
            dataGridView1.AllowUserToAddRows = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (intStatus == 1)
            {
                DialogResult dialogResult = MessageBox.Show("New Record?", "System Message", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var rtnValue = SettingsProcess.AddDepartment(txtID.Text, txtDepartmentName.Text);
                    MessageBox.Show(rtnValue.strMessage);
                    RefreshTable();
                    NewDepartment();
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Update Record?", "System Message", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var rtnValue = SettingsProcess.UpdateDepartment(txtID.Text, txtDepartmentName.Text);
                    if (rtnValue.isSuccess == true)
                    {
                        MessageBox.Show(rtnValue.strMessage);
                        RefreshTable();
                        NewDepartment();
                    }
                }
            }
        }
        private void NewDepartment()
        {
            txtID.Text = SettingsProcess.GenerateDepartmentID().ToString();
            txtDepartmentName.Text = "";
            lblStatus.Text = "(New)";
            intStatus = 1;
            btnDelete.Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewDepartment();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblStatus.Text = "(Update)";
                intStatus = 2;
                txtDepartmentName.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                btnDelete.Visible = true;
            }
        }

        private void Departments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (intStatus == 2)
            {
                DialogResult dialogResult = MessageBox.Show("Delete Department?", "System Message", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var rtnValue = SettingsProcess.DeleteDepartment(txtID.Text);
                    if (rtnValue.isSuccess == true)
                    {
                        MessageBox.Show(rtnValue.strMessage);
                        NewDepartment();
                    }
                }
            }
        }
    }
}

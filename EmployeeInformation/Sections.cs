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
    public partial class Sections : Form
    {
        private int intStatus;
        public Sections()
        {
            InitializeComponent();
        }

        private void Sections_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            DataTable data = SettingsProcess.GetDepartments();

            foreach(DataRow row in data.Rows)
            {
                cmbDept.Items.Add(row["DepartmentName"].ToString());
            }
        }

        private void Sections_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void RefreshTable()
        {
            DataTable data = SettingsProcess.GetSections(cmbDept.Text);

            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = true;
            if (data.Rows.Count>0)
            {  
                dataGridView1.Rows.Add(data.Rows.Count);
            }
            int x = 0;
            foreach (DataRow row in data.Rows)
            {
                dataGridView1.Rows[x].Cells[0].Value = row["SectionID"].ToString();
                dataGridView1.Rows[x].Cells[1].Value = row["SectionName"].ToString();
                dataGridView1.Rows[x].Cells[2].Value = row["EmpCount"].ToString();
                dataGridView1.Rows[x].Cells[3].Value = ">>";
                x++;
            }
            dataGridView1.AllowUserToAddRows = false;
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTable();
            NewData();
        }

        private void NewData()
        {
            txtID.Text = SettingsProcess.GenerateSectionID(cmbDept.Text).ToString();
            txtSectionName.Text = "";
            lblStatus.Text = "(New)";
            intStatus = 1;
            btnDelete.Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (intStatus == 1)
            {
                DialogResult dialogResult = MessageBox.Show("New Record?", "System Message", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var rtnValue = SettingsProcess.AddSection(txtID.Text, txtSectionName.Text, cmbDept.Text);
                    if (rtnValue.isSuccess == true)
                    {
                        MessageBox.Show(rtnValue.strMessage);
                        RefreshTable();
                        NewData();
                    }
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Update Record?", "System Message", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var rtnValue = SettingsProcess.UpdateSection(txtID.Text, txtSectionName.Text, cmbDept.Text);
                    if (rtnValue.isSuccess == true)
                    {
                        MessageBox.Show(rtnValue.strMessage);
                        RefreshTable();
                        NewData();
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblStatus.Text = "(Update)";
                intStatus = 2;
                txtSectionName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                btnDelete.Visible = true;
            }
        }
    }
}

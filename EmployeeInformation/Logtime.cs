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
    public partial class Logtime : Form
    {
        public Logtime()
        {
            InitializeComponent();
        }

        private void Logtime_Load(object sender, EventArgs e)
        {
            dtPicker.Value = DateTime.Now;
            this.RefreshTable();

        }
        private void RefreshTable()
        {
            string query = "Select left(logdate,10) as Logdate,EmployeeCode,right(timein,8) as Timein," +
                "right(timeout,8) as Timeout from logtime " +
                "where left(logdate, 10) = left('"+ Config.GetDate(dtPicker.Value) + "', 10)";
            DataTable dtable = Config.RetreiveData(query);
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.AllowUserToAddRows = true;
                for (int x = 0; x < dtable.Rows.Count; x++)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[x].Clone();
                    row.Cells[0].Value = dtable.Rows[x]["LogDate"].ToString();
                    row.Cells[1].Value = dtable.Rows[x]["EmployeeCode"].ToString();
                    row.Cells[2].Value = dtable.Rows[x]["TimeIn"].ToString();
                    row.Cells[3].Value = dtable.Rows[x]["TimeOut"].ToString();
                    row.Cells[4].Value = ">>";

                    dataGridView1.Rows.Add(row);
                }
                dataGridView1.AllowUserToAddRows = false;

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void dtPicker_ValueChanged(object sender, EventArgs e)
        {
            this.RefreshTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                string CellEmployeeCode = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Informations.EmployeeCode = CellEmployeeCode;
                Form info = new Informations();
                info.ShowDialog();
                Informations.EmployeeCode = null;
                RefreshTable();
            }
        }
    }
}

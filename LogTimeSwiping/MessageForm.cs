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
    public partial class MessageForm : Form
    {

        public static string strMessage;
        public MessageForm()
        {
            InitializeComponent();
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            txtMessage.Text = strMessage;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           this.Close(); 
        }
    }
}

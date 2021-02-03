using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_Ex1_WinTimer1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userControlTimer1.TimeEnabled = false;
        }

        public bool TimeEnabled
        {
            get { return userControlTimer1.Enabled; }
            set { userControlTimer1.Enabled = value; }
           
        }
    }
}

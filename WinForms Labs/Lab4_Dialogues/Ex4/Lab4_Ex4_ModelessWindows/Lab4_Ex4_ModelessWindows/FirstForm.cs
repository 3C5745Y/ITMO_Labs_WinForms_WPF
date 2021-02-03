using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_Ex4_ModelessWindows
{
    public partial class FirstForm : Form
    {
        public FirstForm()
        {
            InitializeComponent();
        }

        public string SolData
        {
            get
            { return textBoxF1.Text; }
            set
            { textBoxF1.Text = value; }
        }

        private void buttonF1_Click(object sender, EventArgs e)
        {
            SecondForm frm2 = new SecondForm();
            frm2.Show(this);
        }
    }
}

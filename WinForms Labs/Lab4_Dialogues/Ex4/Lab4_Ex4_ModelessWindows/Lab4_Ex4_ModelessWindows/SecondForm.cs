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
    public partial class SecondForm : Form
    {
        public SecondForm()
        {
            InitializeComponent();
        }

        private void buttonF2_Click(object sender, EventArgs e)
        {
            string s = textBoxF21.Text + " " + textBoxF22.Text + " " + textBoxF23.Text;
            FirstForm frm1 = this.Owner as FirstForm; if (frm1 != null)
            {
                frm1.SolData = s;
            }
            this.Close();
        }
    }
}

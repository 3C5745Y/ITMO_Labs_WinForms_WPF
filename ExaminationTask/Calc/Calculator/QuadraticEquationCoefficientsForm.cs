using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class QuadraticEquationCoefficientsForm : Form
    {
        public double[] Coeffs { get; set; }

        public QuadraticEquationCoefficientsForm()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Coeffs = new double[3]
            {
                double.Parse(ATextBox.Text),
                double.Parse(BTextBox.Text),
                double.Parse(CTextBox.Text),
            };
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

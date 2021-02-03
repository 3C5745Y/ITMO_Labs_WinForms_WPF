using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyForm
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            userControlForm1.ClickSave += UserControlForm1_ClickSave;
        }

        private void UserControlForm1_ClickSave(object sender, EventArgs e)
        {
            var un = sender as UserControlForm;

            CheckList = "Please check your data for order \n\n";
            CheckList += "Your Name: " + un.UserName + "\n";
            CheckList += "Your Last Name: " + un.UserLastName + "\n";
            CheckList += "Email: " + un.Email + "\n";
            CheckList += "Phone: " + un.Phone + "\n";
            CheckList += "Address: " + un.Address + "\n";
        }

        public string CheckList
        {
            get { return richTextBox1.Text; }
            set { richTextBox1.Text = value; }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

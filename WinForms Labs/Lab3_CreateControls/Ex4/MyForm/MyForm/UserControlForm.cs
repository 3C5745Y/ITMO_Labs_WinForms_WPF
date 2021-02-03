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
    public partial class UserControlForm : UserControl
    {
        public event EventHandler ClickSave;

        public UserControlForm()
        {
            InitializeComponent();
        }

        public string UserName  
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string UserLastName  
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public string Email  
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }            
        }

        public string Phone  
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }

        public string Address  
        {
            get { return textBox5.Text; }
            set { textBox5.Text = value; }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(textBox1, "Поле Name не может быть пустым");
            }
            else
            {
                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    if (char.IsDigit(textBox1.Text[i]))
                    {
                        e.Cancel = true;
                        this.errorProvider1.SetError(textBox1, "Поле Name не может содержать цифры");
                        break;
                    }
                }
            }
            if (!e.Cancel)
            {
                this.errorProvider1.SetError(textBox1, null);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(textBox2, "Поле Last Name не может быть пустым");
            }
            else
            {
                for (int i = 0; i < textBox2.Text.Length; i++)
                {
                    if (char.IsDigit(textBox2.Text[i]))
                    {
                        e.Cancel = true;
                        this.errorProvider1.SetError(textBox2, "Поле Last Name не может содержать цифры");
                        break;
                    }
                }
            }
            if (!e.Cancel)
            {
                this.errorProvider1.SetError(textBox2, null);
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidEmailAddress(textBox3.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                textBox3.Select(0, textBox3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(textBox3, errorMsg);
            }
        }

        private void textBox3_Validated(object sender, EventArgs e)
        {

            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(textBox3, "");

        }

        public bool ValidEmailAddress(string emailAddress, out string errorMessage)
        {
            // Confirm that the email address string is not empty.
            if (emailAddress.Length == 0)
            {
                errorMessage = "email address is required.";
                return false;
            }

            // Confirm that there is an "@" and a "." in the email address, and in the correct order.
            if (emailAddress.IndexOf("@") > -1)
            {
                if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
                {
                    errorMessage = "";
                    return true;
                }
            }

            errorMessage = "email address must be valid email address format.\n" +
               "For example 'someone@example.com' ";
            return false;
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(textBox4, "Поле Phone не может быть пустым");
            }
            else
            {
                for (int i = 0; i < textBox4.Text.Length; i++)
                {
                    if (char.IsLetter(textBox4.Text[i]))
                    {
                        e.Cancel = true;
                        this.errorProvider1.SetError(textBox4, "Поле Phone не может содержать буквы");
                        break;
                    }
                }
            }
            if (!e.Cancel)
            {
                this.errorProvider1.SetError(textBox4, null);
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(textBox5, "Поле Address не может быть пустым");
            }
           
            if (!e.Cancel)
            {
                this.errorProvider1.SetError(textBox5, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ClickSave != null)
                ClickSave(this, EventArgs.Empty);

            UserName = UserLastName = Email = Phone = Address = "";
        }

      
    }
}

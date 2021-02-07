using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyClass;

namespace BiblWorm
{
    public partial class Form1 : Form
    {
        List<Item> its = new List<Item>();

        public Form1()
        {
            InitializeComponent();
        }

        public string Author // автор
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string Title // Название
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public string PublishHouse // Издательство 
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }

        public int Page // Количество страниц
        {
            get { return (int)numericUpDown1.Value; }
            set { numericUpDown1.Value = value; }
        }

        public int Year // Год издания
        {
            get { return (int)numericUpDown2.Value; }
            set { numericUpDown2.Value = value; }
        }

        public int InvNumber // Инвентарный номер
        {
            get { return (int)numericUpDown3.Value; }
            set { numericUpDown3.Value = value; }
        }

        public bool Existence // Наличие
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }

        public bool SortInvNumber // Сортировка по инвентарному номеру 
        {
            get { return checkBox3.Checked; }
            set { checkBox3.Checked = value; }
        }

        public bool ReturnTime // Возвращение в срок
        {
            get { return checkBox2.Checked; }
            set { checkBox2.Checked = value; }
        }

        public int PeriodUse // Срок использования
        {
            get { return (int)numericUpDown4.Value; }
            set { numericUpDown4.Value = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book b = new Book(Author, Title, PublishHouse, Page, Year, InvNumber, Existence);
            if (ReturnTime) 
                b.ReturnSrok();
            b.PriceBook(PeriodUse);
            its.Add(b);

            Author = Title = PublishHouse = ""; 
            Page = InvNumber = PeriodUse = 1; 
            Year = 1900;
            Existence = ReturnTime = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SortInvNumber) 
                its.Sort();

            StringBuilder sb = new StringBuilder(); 
            foreach (Item item in its)
            {
                sb.Append("\n" + item.ToString());
            }
            richTextBox1.Text = sb.ToString();
        }

        List<Item> itsMag = new List<Item>();
        //Журналы
        public int Volume // том
        {
            get { return (int)numericUpDown5.Value; }
            set { numericUpDown5.Value = value; }
        }

        public int Number // номер
        {
            get { return (int)numericUpDown6.Value; }
            set { numericUpDown6.Value = value; }
        }

        public string NameOfMagazine // Название
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }

        public int Release // Год издания
        {
            get { return (int)numericUpDown7.Value; }
            set { numericUpDown7.Value = value; }
        }

        public bool IfSubs // подписка
        {
            get { return checkBox5.Checked; }
            set { checkBox5.Checked = value; }
        }

        public int InvNumberMag // Инвентарный номер
        {
            get { return (int)numericUpDown8.Value; }
            set { numericUpDown8.Value = value; }
        }

        //кнопка Добавить
        private void button3_Click(object sender, EventArgs e)
        {
            Magazine m = new Magazine(Volume, Number, NameOfMagazine, Release, InvNumberMag, IfSubs);
            if (ReturnTime)
                m.Return();
            itsMag.Add(m);

            Volume = Number = 0;
            NameOfMagazine = "";
            Release = 2000;
            IfSubs = false;
        }

        //кнопка Посмотреть
        private void button4_Click(object sender, EventArgs e)
        {
            
            StringBuilder mg = new StringBuilder(); 
            foreach (Item item in itsMag)
            {
                mg.Append("\n" + item.ToString());
            }
            richTextBox2.Text = mg.ToString();
        }

    }
}

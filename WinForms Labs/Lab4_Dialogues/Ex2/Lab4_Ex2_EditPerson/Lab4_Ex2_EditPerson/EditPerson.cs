using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_Ex2_EditPerson
{
    public partial class EditPerson : Form
    {
        public EditPerson()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditPersonForm editForm = new EditPersonForm();

            //заполнение списка ListView главной формы:
            if (editForm.ShowDialog() != DialogResult.OK)
            return; 
            ListViewItem newItem = personsListView.Items.Add(editForm.FirstName); 
            newItem.SubItems.Add(editForm.LastName);
            newItem.SubItems.Add(editForm.Age.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //проверка, что не выбран элемент для редактирования и присвоение выбранного элемента экземпляру списка:
            if (personsListView.SelectedItems.Count == 0) 
                return;
            ListViewItem item = personsListView.SelectedItems[0];

            //передача содержимого элементов списка главной формы в свойства диалогового окна
            EditPersonForm editForm = new EditPersonForm();
            editForm.FirstName = item.Text;
            editForm.LastName = item.SubItems[1].Text;
            editForm.Age = Convert.ToInt32(item.SubItems[2].Text);

            //Изменения данных и нажатие кнопки Сохранить
            if (editForm.ShowDialog() != DialogResult.OK) 
                return;
            item.Text = editForm.FirstName; 
            item.SubItems[1].Text = editForm.LastName;
            item.SubItems[2].Text = editForm.Age.ToString();
        }
    }
}

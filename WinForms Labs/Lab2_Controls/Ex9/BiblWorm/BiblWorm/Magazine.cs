using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyClass
{
    class Magazine : Item, IPubs
    {
        private int volume;    // том
        private int number;        // номер
        private String title;       // название
        private int year;      // дата выпуска
        private bool IfSubs;


        public Magazine(int volume, int number, String title, int year, long invNumber, bool IfSubs)
            : base(invNumber, IfSubs)
        {
            this.volume = volume;
            this.number = number;
            this.title = title;
            this.year = year;
            this.invNumber = invNumber;
            this.IfSubs = IfSubs;
        }
        
        public override void Return()     
        {
            taken = true;
        }

        public void Subs()
        {
        }

        public override string ToString()
        {
           if (IfSubs)
           return "\nЖурнал:\nНазвание: " + title + "\nТом: " + volume +
           "\nНомер: " + number + "\nДата выпуска: " + year + "\nПодписка оформлена";
           else
               return "\nЖурнал:\nНазвание: " + title + "\nТом: " + volume +
           "\nНомер: " + number + "\nДата выпуска: " + year + "\nПодписка не оформлена";
        }
    }
}

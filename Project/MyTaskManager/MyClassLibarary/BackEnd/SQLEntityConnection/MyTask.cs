using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibarary.BackEnd.SQLEntityConnection
{
    public class MyTask
    {
        /// <summary>
        /// поле типу int, яке зберігати в собі ключ таблиці Task
        /// </summary>
        public int numberTask { get; set; }
        /// <summary>
        /// назва завдання.
        /// </summary>
        public string nameTask { get; set; }
        /// <summary>
        /// короткий опис
        /// </summary>
        public string shortDiscription { get; set; }
        /// <summary>
        /// повний опис.
        /// </summary>
        public string discription { get; set; }
        /// <summary>
        /// дата виклику нагадування про завдання.
        /// </summary>
        public DateTime startDate { get; set; }
        /// <summary>
        /// дата зміни стану isComplited(boolean).
        /// </summary>
        public DateTime endDate { get; set; }


        public override string ToString()
        {
            return nameTask;
        }
    }
}

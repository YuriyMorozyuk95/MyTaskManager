using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibarary.BackEnd.SQLEntityConnection
{
    public class TaskTree
    {
        /// <summary>
        /// – поле типу Int, яке зберігати в собі ключ таблиці TaskTree
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// назва завдання.
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// поле яке вказує на кількість виконаних завдань.
        /// </summary>
        public List<int> child { get; set; }
        public int processValue { get; set; }
        public int maxProcessValue { get; set; }
        //public int value { get; set; }
        public SQLEntityConnection.MyTask value { get; set; }

        public override string ToString()
        {
            return name;
        }


    }
}

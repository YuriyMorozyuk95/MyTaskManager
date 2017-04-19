using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibarary.BackEnd.ApiConnection
{
    [DataContract]
    public class MyTaskEntity : JsonEntity
    {
        [DataMember]
        private MyTaskEntity _myTask;

        /// <summary>
        /// поле типу int, яке зберігати в собі ключ таблиці Task
        /// </summary>
        [DataMember]
        public int numberTask { get; set; }
        /// <summary>
        /// назва завдання.
        /// </summary>
        [DataMember]
        public string nameTask { get; set; }
        /// <summary>
        /// короткий опис
        /// </summary>
        [DataMember]
        public string shortDiscription { get; set; }
        /// <summary>
        /// повний опис.
        /// </summary>
        [DataMember]
        public string discription { get; set; }
        /// <summary>
        /// дата виклику нагадування про завдання.
        /// </summary>
        [DataMember]
        public DateTime startDate { get; set; }
        /// <summary>
        /// дата зміни стану isComplited(boolean).
        /// </summary>
        [DataMember]
        public DateTime endDate { get; set; }

        public override void GetEntity(object GetingObject)
        {
            _myTask = GetingObject as MyTaskEntity;
            _thisObject = _myTask;
        }
    }
}

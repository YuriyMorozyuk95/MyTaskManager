using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibarary.BackEnd.ApiConnection
{
    [DataContract]
    class MyTaskTreeEntity:JsonEntity
    {
        [DataMember]
        private MyTaskEntity _myTaskTree;
        /// <summary>
        /// – поле типу Int, яке зберігати в собі ключ таблиці TaskTree
        /// </summary>
        [DataMember]
        public int id { get; set; }
        /// <summary>
        /// назва завдання.
        /// </summary>
        [DataMember]
        public string name { get; set; }
        /// <summary>
        /// поле яке вказує на кількість виконаних завдань.
        /// </summary>
        [DataMember]
        public List<int> child { get; set; }
        [DataMember]
        public int processValue { get; set; }
        [DataMember]
        public int maxProcessValue { get; set; }
        //public int value { get; set; }
        [DataMember]
        public MyTaskEntity value { get; set; }

        public override void GetEntity(object GetingObject)
        {
            _myTaskTree = GetingObject as MyTaskEntity;
            _thisObject = _myTaskTree;
        }
    }
}

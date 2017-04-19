using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManagerLibrary.BackEnd
{
    public class TaskTree
    {
        #region Constructor

        /// <summary>
        /// Створює обєкт дерева, або вузла задач
        /// </summary>
        public TaskTree()
        {            
            _value = null;
            _child = new List<TaskTree>();
            _progressValue = 0;
            _maxProgressValue = 0;
        }
        /// <summary>
        /// Створює обєкт вузла зі значенням і дочірніми елементами
        /// </summary>
        /// <param name="value">Значення вузла</param>
        /// <param name="child">Дочірні елементи</param>
        public TaskTree(MyTask value, List<TaskTree> child)
        {
            _value = value;          
            _child = child;
            _progressValue = 0;
            _maxProgressValue = 0;
        }
        #endregion

        #region Field
        private string _name;
        private MyTask _value;
        private TaskTree _parent;
        private List<TaskTree> _child;

        private int? _progressValue;
        private int? _maxProgressValue;
        #endregion

        #region Property

        /// <summary>
        /// Імя вузла
        /// </summary>
        public string Name
        {
            get
            {
                _name = Value.NameTask;
                return _name;
            }

        }

        /// <summary>
        /// значення
        /// </summary>
        public MyTask Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                _value.Parent = this;
            }
        }
        //вузл
        protected TaskTree Parent
        {
            get
            {
                return this.Value.Parent;
            }
            set
            {
                this.Value.Parent = value;
                _parent = value;
            }
        }

        /// <summary>
        /// Дочірній елемент
        /// </summary>
        public List<TaskTree> Child
        {
            get
            {
                return _child;
            }
            set
            {
                _child = value;
            }
        }

        /// <summary>
        /// значення прогрес бару
        /// </summary>
        public int? ProgressValue
        {
            get
            {
                return _progressValue;
            }
            set
            {
                _progressValue = value;
            }
        }

        /// <summary>
        /// максимальне значення
        /// </summary>
        public int? MaxProgressValue
        {
            get
            {
                _maxProgressValue = Child.Count;
                return _maxProgressValue;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// Добавлення нового дочірнього елемента в список
        /// </summary>
        /// <param name="child">Дочірній елемент типу завдання</param>
        public void AddChild(MyTask child)
        {
            var newTask = new TaskTree()
            {
                Value = child,
                Parent = this
            };

            Child.Add(newTask);
        }



        #endregion


    }
}

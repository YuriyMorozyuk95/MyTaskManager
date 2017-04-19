using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        private int? _count;
        #endregion

        #region Property

        public TaskTree this[int i]
        {
            get
            {
                return Child[i];
            }
            set
            {
                Child[i] = value;
            }
        }
        public TaskTree this[int i,int j]
        {
            get
            {
                return Child[i].Child[j];
            }
            set
            {
                Child[i].Child[j] = value;
            }
        }
        public TaskTree this[int i, int j,int k]
        {
            get
            {
                return Child[i].Child[j].Child[k];
            }
            set
            {
                Child[i].Child[j].Child[k] = value;
            }
        }

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

        public TaskTree Head
        {
            get
            {
                return this;
            }
        }
        //вузл
        public TaskTree Parent
        {
            get
            {
                return _parent;
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
                if (_count == null)
                {
                    _count = 0;
                }
                    _maxProgressValue = _count;
                    return _maxProgressValue;
            }
        }
        /// <summary>
        /// Кількість дочірніх елементів
        /// </summary>
        public int? CountTask
        {
            get
            {
                if (Child != null)
                {
                    _count = Child.Count;
                }
                else
                {
                    _count = 0;
                }
                return _count;
            }
        }
        /// <summary>
        /// Чи виконане завдання
        /// </summary>
        public bool? IsComlited
        {
            get
            {
                return this.Value.IsCompited;
            }

        }

        public int ProcentComplited
        {
            get
            {
                if(_count!=0 || _count!=null)
                {
                    return GetProcentComplited();
                }
                return 0;
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
                _parent = this
            };

            Child.Add(newTask);
            ///
            //var items = new MyTask();
           
            
            //using (var client = new HttpClient())
            //{
            //    var response = client.PostAsJsonAsync("http://localhost:53181/api/MyTasks", child).Result;
            //    var resp = response.StatusCode.ToString();
            //}

        }
        public int GetProcentComplited()
        {
            if (_count == null )
            {
                double count = (double)_count;
                double taskComlited = 0;
                if (Child != null)
                {
                    foreach (TaskTree taskT in Child)
                    {
                        taskComlited++;
                    }
                }
                int proccent = Convert.ToInt32((_count / taskComlited * 100));
                return proccent;
            }
            else
            {
                return 0;
            }
            
        }
        public override string ToString()
        {
            return this.Name;
        }

        #endregion


    }
}

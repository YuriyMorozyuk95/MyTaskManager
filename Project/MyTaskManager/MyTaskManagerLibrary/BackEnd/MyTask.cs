using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace MyTaskManagerLibrary.BackEnd
{
    public class MyTask
    {
        #region Constructor
        /// <summary>
        /// Створює обєкт завдання
        /// </summary>
        /// <param name="numberTask">порядковий номер завдання</param>
        /// <param name="nameTask">назва завданняя</param>
        /// <param name="shortDescription">короткий опис завдання, відображається на панелі списку завданнь</param>
        /// <param name="description">Повний опис завдання</param>
        public MyTask(int? numberTask = null, string nameTask = "My Task",
            string shortDescription = "Short Discription", string description = "Discription")
        {
            IsCompited = false;
            //set number;
            if (numberTask == null)
            {
                if (_counterTask == null)
                {
                    _counterTask = 0;
                }
                _numberTask = _counterTask++;
            }
            else
            {
                _numberTask = numberTask;
            }

            _nameTask = nameTask;
            _shortDescription = shortDescription;
            _description = description;

        }

        #endregion

        #region Field

        private int? _numberTask = null;
        private static int? _counterTask = null;
        private string _nameTask;
        private string _shortDescription;
        private string _description;

        private DateTime _startDate;
        private DateTime _date;
        private DateTime _endDate;

        private TaskTree _parent;

        private bool? _isCompited;

        #endregion

        #region Property
        /// <summary>
        /// порядковий номер завдання
        /// </summary>
        public int? NumberTask
        {
            get
            {
                return _numberTask;
            }
            set
            {
                _numberTask = value;
            }
        }

        /// <summary>
        /// назва завданняя
        /// </summary>
        public string NameTask
        {
            get
            {
                return _nameTask;
            }
            set
            {
                _nameTask = value;
            }
        }

        /// <summary>
        /// короткий опис завдання, відображається на панелі списку завданнь
        /// </summary>
        public string ShortDescription
        {
            get
            {
                return _shortDescription;
            }
            set
            {
                _shortDescription = value;
            }
        }

        /// <summary>
        /// Повний опис завдання
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }


        /// <summary>
        /// Дата запуску завдання   
        /// </summary>
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _date = value;
                _startDate = value;
            }
        }

        /// <summary>
        ///Лічільник відліку до закінчення завдання
        /// </summary>
        public DateTime Date
        {
            get
            {
                _date = DateTime.Now;
                if (_date == EndDate)
                {
                    IsCompited = true;
                }
                return _date;
            }
          
        }

        /// <summary>
        /// Дата закінчення завдання
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
            }
        }

        /// <summary>
        /// Батьківський вузол
        /// </summary>
        public TaskTree Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        /// <summary>
        /// Чи виконалось завдання
        /// </summary>
        private bool? IsCompited
        {
            get
            {
                return _isCompited;
            }
            set
            {
                if ((bool)value)
                {
                    (new MessageDialog(string.Format("Task №{0} Name: {1} IsComplited: {2}",
                        NumberTask, NameTask, IsCompited.ToString())))
                        .ShowAsync();
                }
                _isCompited = value;
            }
        }

        #endregion
    }
}

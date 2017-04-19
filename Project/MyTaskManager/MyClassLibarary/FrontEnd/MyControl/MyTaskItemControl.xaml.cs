using MyTaskManagerLibrary.BackEnd;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MyTaskManagerLibrary.FrontEnd.MyControl
{
    public sealed partial class MyTaskItem : UserControl
    {
        public MyTaskItem()
        {
            this.InitializeComponent();
        }
        public MyTaskItem(TaskTree taskTree):this()
        {
            this.InitializeComponent();
            _thisTaskTree = taskTree;
            TitleTask = null;
            //CounItem = null;
            ShortDescription = null;
            ProcessValue = null;
            MaxProcessValue = null;
            ProccentComplited = null;
            Color = null;
        }


        #region Field
        private TaskTree _thisTaskTree;
        private int? _proccentComplited;
        private string _titleTask;
        private int? _countItem;
        private string _shortDescription;
        private int? _processValue;
        private int? _maxProcessValue;
        private Brush _color;
        #endregion

        #region Property
        public TaskTree ThisTaskTree
        {
            get
            {
                return _thisTaskTree;
            }
            set
            {
                _thisTaskTree = value;
                TitleTask = _thisTaskTree.Name;
                //CounItem = _thisTaskTree.CountTask;
                ShortDescription = _thisTaskTree.Value.ShortDescription;
                ProcessValue = 0;
                MaxProcessValue = null;
            }
        }
        /// <summary>
        /// Назва завдання
        /// </summary>
        public string TitleTask
        {
            get
            {
                return _titleTask;
            }
            set
            {
                if(value == null)
                {
                    _titleTask = _thisTaskTree.Value.NameTask;                   
                }
                else
                {
                    _titleTask = value;                   
                }
                Title.Text = _titleTask;
            }
        }
        /// <summary>
        /// Кількість дочірніх елементів
        /// </summary>
        public int? CounItem
        {
            get
            {
                return _countItem;
            }
            //set
            //{
            //    if (value == null)
            //    { 
            //        if(_thisTaskTree.CountTask == null)
            //        {
            //            _thisTaskTree.CountTask = 0;
            //        }
            //        _countItem = _thisTaskTree.CountTask;               
            //    }
            //    else
            //    {
            //        _countItem = value;
            //    }
            //    ItemsCount.Text = _countItem.ToString();
            //    MaxProcessValue = _countItem;
            //}
        }
        /// <summary>
        /// Короткий опис завдання
        /// </summary>
        public string ShortDescription
        {
            get
            {
                return _shortDescription;
            }
            set
            {
                if (value == null)
                {
                    _shortDescription = _thisTaskTree.Value.ShortDescription;
                }
                else
                {
                    _shortDescription = value;
                }
                Description.Text = _shortDescription;
            }
        }
        /// <summary>
        /// Процес, та процент виконаних завданнь
        /// </summary>
        public int? ProcessValue
        {
            get
            {
                return _processValue;
            }
            set
            {
                if (value == null)
                {
                    _processValue = _thisTaskTree.ProgressValue;
                }
                else
                {
                    _processValue = value;
                }
                MyProgress.Value = (double)_processValue;
            }
        }
        /// <summary>
        /// Кількість всіх завданнь
        /// </summary>
        public int? MaxProcessValue
        {
            get
            {
                return _maxProcessValue;
            }
            set
            {
                if (value == null)
                {
                    _maxProcessValue = _thisTaskTree.MaxProgressValue;
                }
                else
                {
                    _maxProcessValue = value;
                }
                try
                {
                    MyProgress.Maximum = (double)_maxProcessValue;
                }
                catch(System.InvalidOperationException)
                {
                    MyProgress.Maximum = 0;
                    new MessageDialog("This Task don't have a child").ShowAsync();
                }
            }
        }
        /// <summary>
        /// Процентна кількість виконаних завданнь, якщо залити null процент сам вирахується
        /// </summary>
        public int? ProccentComplited
        {
            get
            {
                _proccentComplited = _thisTaskTree.GetProcentComplited();
                ComplitedItem.Text = _proccentComplited.ToString();
                return _proccentComplited;
            }
            set
            {
                if(value == null)
                {
                    _proccentComplited = _thisTaskTree.GetProcentComplited();
                }
                else
                {
                    _proccentComplited = value;
                }
                ComplitedItem.Text = _proccentComplited.ToString();
            }
        }
        #endregion
        public Brush Color
        {
            get
            {
                return _color;
            }
            set
            {
                if(value == null)
                {
                    _color = new SolidColorBrush(
                        Windows.UI.Color.FromArgb(0, 71, 245, 148));
                }
                else
                {
                    _color = value;
                }
                MyBorder.BorderBrush = _color;
                Title.Foreground = _color;
                MyItems.Foreground = _color;
                MyProgress.Foreground = _color;
                MyComlitedItem.Foreground = _color;
                Description.Foreground = _color;

            }
        }
        #region Method

        
        #endregion
    }
}

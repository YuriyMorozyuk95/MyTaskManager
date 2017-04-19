using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MyTaskManagerLibrary.FrontEnd.Control
{
    public sealed partial class TaskItemControl : UserControl
    {
        public TaskItemControl()
        {
            this.InitializeComponent();
        }
        public TaskItemControl(MyTaskManagerLibrary.BackEnd.TaskTree taskTree):this()
        {
            this.InitializeComponent();
            var task = taskTree.Value;
            NameTask = task.NameTask;
            Count = taskTree.Child.Count;
            ShortDescription = task.ShortDescription;
        }
        public string NameTask
        {
            get
            {
                return Title.Text;
            }
            set
            {
                Title.Text = value;
            }
        }
        public int Count
        {
            get
            {
                return Convert.ToInt32(ItemsCount.Text);
            }
            set
            {
                ItemsCount.Text = value.ToString();
            }
        }
        public string ShortDescription
        {
            get
            {
                return Description.Text;
            }
            set
            {
                Description.Text = value;
            }
        }
        public double ProcessValue
        {
            get
            {
                return MyProgress.Value;
            }
            set
            {
                MyProgress.Value = value;
            }
        }
        public double MaxProcessValue;
    }
}

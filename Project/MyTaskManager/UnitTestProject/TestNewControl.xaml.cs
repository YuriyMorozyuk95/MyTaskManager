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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UnitTestProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestNewControl : Page
    {
        public TestNewControl()
        {
            this.InitializeComponent();
        }
        public List<Task> myList;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            myList = new List<Task>();
            var taskA = new Task("TaskA");
            taskA.SubTasks = new List<Task> {
            new Task("SubTaskA"),
            new Task("SubTaskB"),
            new Task("SubTaskC")
        };
            taskA.SubTasks[0].SubTasks = new List<Task> {
            new Task("SubSubTaskA"),
            new Task("SubSubTaskB"),
            new Task("SubSubTaskC"),
            new Task("SubSubTaskD")
        };
            myList.Add(taskA);
        }
    }

    public class Task
    {
        public Task(string name)
        {
            this.Name = name;
        }

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Task> SubTasks { get; set; }

    }

}


using MyTaskManagerLibrary.BackEnd;
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

namespace MyTaskManagerLibrary.FrontEnd.MyControl
{
    public sealed partial class TaskViewControl : UserControl
    {
        #region Field

        private TaskTree _mainTask;
        private TaskTree _currentTaskTree;
        private MyTask _currentMyTask;

        #endregion


        #region Property

        public TaskTree MainTask
        {
            get
            {
                return _mainTask;
            }
            set
            {
                _mainTask = value;
            }
        }
        public List<TaskTree> ChildMainTask
        {
            get
            {
                return MainTask.Child;
            }
            set
            {
                MainTask.Child = value;
            }
        }
        public TaskTree CurrentTaskTree
        {
            get
            {
                return _currentTaskTree;
            }
            set
            {
                _currentTaskTree = value;
                _currentMyTask = value.Value;
            }
        }
        public MyTask CurrentMyTask
        {
            get
            {
                return _currentMyTask;
            }
        }

        #endregion


        #region Constructor

        public TaskViewControl()
        {
            this.InitializeComponent();
            InitTaskTree(ref _mainTask);
        }

        #endregion

        #region Handled

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nameTextBlock = GetNameInButton(sender);
            CurrentTaskTree = GetTaskTree(nameTextBlock, ChildMainTask);

            SetNameTask.Text = CurrentMyTask.NameTask;
            SetNumbeTask.Text = CurrentMyTask.NumberTask.ToString();
            SetShortDescriptionTask.Text = CurrentMyTask.ShortDescription;
            SetDescriptionTask.Document.SetText(Windows.UI.Text.TextSetOptions.None, CurrentMyTask.Description);

            SetDPStartDateTask.Date = new DateTimeOffset(CurrentMyTask.StartDate);

            SetTPStartDateTask.Time = CurrentMyTask.StartDate.TimeOfDay;

            SetDPEndDateTask.Date = CurrentMyTask.Date;
            SetTPEndDateTask.Time = CurrentMyTask.EndDate.TimeOfDay;

            SetParent.Items.Add("MainTask"); //Costi
            SetParent.SelectedIndex = 0;


        }
        #endregion

        #region Method
        public TaskTree GetTaskTree(string Name, List<TaskTree> taskTree)
        {
            for (int i = 0; i < taskTree.Count; i++)
                if (Name == taskTree[i].Name)
                    return taskTree[i];
            return null;
        }
        public string GetNameInButton(object sender)
        {
            Button clickedButton = sender as Button;
            Border borderButton = clickedButton.Content as Border;
            Grid gridButton = borderButton.Child as Grid;
            UIElementCollection collectionUIButton = gridButton.Children;
            StackPanel stackPanelButton = collectionUIButton[0] as StackPanel;
            StackPanel beHindStackPanelButton = stackPanelButton.Children[0] as StackPanel;
            TextBlock NameTextBlock = beHindStackPanelButton.Children[0] as TextBlock;
            return NameTextBlock.Text;
        }
        public void InitTaskTree(ref TaskTree _taskTree)
        {
            MyTask myTask = MyTaskFactory.CreateMyTask();
            TaskTree taskTree = MyTaskFactory.CreateMyTaskTree(MyTaskFactory.CreateListTaskTree(10));
            for (int i = 0; i < 10; i++)
            {
                taskTree[i] = MyTaskFactory.CreateMyTaskTree(MyTaskFactory.CreateListTaskTree(10));
            }
            _taskTree = taskTree;
        }
        #endregion
    }







    //search to presentation

    //static class Searching
    //{
    //    static public List<TaskTree> CurrentNodeMatches;

    //    static private int LastNodeIndex = 0;
    //    static private int NodeIndex = LastNodeIndex;
    //    static private string LastSearchText;

    //    static public taskTree Search(string name, TaskTree taskTree)
    //    {
    //        string searchText = name;
    //        if (LastSearchText != searchText)
    //        {
    //            //It's a new Search
    //            CurrentNodeMatches.Clear();
    //            LastSearchText = searchText;
    //            LastNodeIndex = 0;
    //            SearchNodes(searchText, taskTree.Child[0]);
    //        }

    //        if (LastNodeIndex >= 0 && CurrentNodeMatches.Count > 0 && LastNodeIndex < CurrentNodeMatches.Count)
    //        {
    //            TaskTree selectedNode = CurrentNodeMatches[LastNodeIndex];
    //            LastNodeIndex++;
    //            return selectedNode;
    //        }
    //    }

    //    static private void SearchNodes(string SearchText, TaskTree StartNode)
    //    {
    //        TaskTree node = null;
    //        while (StartNode != null)
    //        {
    //            if (StartNode.Name.ToLower().Contains(SearchText.ToLower()))
    //            {
    //                CurrentNodeMatches.Add(StartNode);
    //            };
    //            if (StartNode.Child.Count != 0)
    //            {
    //                SearchNodes(SearchText, StartNode.Child[0]);//Recursive Search 
    //            };
    //            NodeIndex++;
    //            StartNode = StartNode.NextNode;
    //        };

    //    }
    //}



    ////
}

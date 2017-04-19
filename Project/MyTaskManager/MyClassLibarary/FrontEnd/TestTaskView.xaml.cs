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

namespace MyTaskManagerLibrary.FrontEnd
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestTaskView : Page
    {
        public TestTaskView()
        {
            this.InitializeComponent();
        }

        private void AddNewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            //MainTreeSingleton
            //    .MainTree
            //    .MyTaskFrame
            //    .Navigate(typeof(MyTaskManagerLibrary.FrontEnd.TestTaskView));

        }


        private void EditTaskButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

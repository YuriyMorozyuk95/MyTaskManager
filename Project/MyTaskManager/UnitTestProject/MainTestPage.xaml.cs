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
    public sealed partial class MainTestPage : Page
    {
        public MainTestPage()
        {
            this.InitializeComponent();
            //Singelton 
        }
        bool Theme = true;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Theme = !Theme;
            //if(Theme)
            //{
            //    App.Theme = Theme;
            //}
            //else
            //{
            //    App.Theme = Theme;
            //}


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
         //Frame.Navigate(typeof(MyTaskManagerLibrary.FrontEnd.AddTasksPage));
          Frame.Navigate(typeof(MyTaskManagerLibrary.FrontEnd.AddTasksPage));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MyTaskManagerLibrary.FrontEnd.TestTaskView));
        }
    }
}

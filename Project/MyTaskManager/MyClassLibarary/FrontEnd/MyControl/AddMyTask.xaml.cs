using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class AddMyTask : UserControl
    {
        #region Constructor
        public AddMyTask()
        {
            InitializeComponent();

        }
        #endregion

        #region Field

        #endregion

        #region Property
        MyTaskManagerLibrary.BackEnd.MyTask NewTask { get; set; }

        public bool IsSetName { get; set; } = false;
        public bool IsSetNumber { get; set; } = false;
        public bool IsSetShortDescription { get; set; } = false;
        public bool IsSetDescription { get; set; } = false;
        public bool IsSetStartDate { get; set; } = false;
        public bool IsSetStartTime { get; set; } = false;
        public bool IsSetEndDate { get; set; } = false;
        public bool IsSetEndTime { get; set; } = false;
        public bool IsSetPatent { get; set; } = false;

        public string NameValue { get; set; } = null;
        public int NumberValue { get; set; } = 0;
        public string ShortDescriptionValue { get; set; } = null;
        public string DescriptionValue { get; set; } = null;
        public DateTime StartDateTimeValue { get; set; }
        public DateTime EndDateTimeValue { get; set; }
        public MyTaskManagerLibrary.BackEnd.TaskTree ParentValue { get; set; } = null;

        #endregion

        #region Method

        public void OpenControl(ToggleSwitch _switch, bool isOn)
        {
            Visibility IsOpenControl = Visibility.Collapsed;
            if (isOn)
            {
                IsOpenControl = Visibility.Visible;
            }
            else
            {
                IsOpenControl = Visibility.Collapsed;
            }
            switch (Convert.ToInt32(_switch.Tag))
            {
                case 0:
                    {
                        SetNameTask.Visibility = IsOpenControl;
                        NameTask.Visibility = IsOpenControl;
                        break;
                    }
                case 1:
                    {
                        SetNumbeTask.Visibility = IsOpenControl;
                        NumbeTask.Visibility = IsOpenControl;
                        break;
                    }
                case 2:
                    {
                        SetShortDescriptionTask.Visibility = IsOpenControl;
                        ShortDescriptionTask.Visibility = IsOpenControl;
                        break;
                    }
                case 3:
                    {
                        SetDescriptionTask.Visibility = IsOpenControl;
                        DescriptionTask.Visibility = IsOpenControl;
                        break;
                    }
                case 4:
                    {
                        SetDPStartDateTask.Visibility = IsOpenControl;
                        StartDateTask.Visibility = IsOpenControl;
                        break;
                    }
                case 5:
                    {
                        SetTPStartDateTask.Visibility = IsOpenControl;
                        StartDateTask.Visibility = IsOpenControl;
                        break;
                    }
                case 6:
                    {
                        SetDPEndDateTask.Visibility = IsOpenControl;
                        EndDateTask.Visibility = IsOpenControl;
                        break;
                    }
                case 7:
                    {
                        SetTPEndDateTask.Visibility = IsOpenControl;
                        EndDateTask.Visibility = IsOpenControl;
                        break;
                    }
                case 8:
                    {
                        SetParent.Visibility = IsOpenControl;
                        ParentTask.Visibility = IsOpenControl;
                        break;
                    }
            }
        }

        #endregion



        #region EventHander
        private void Switch_Toggled(object sender, RoutedEventArgs e)
        {
            var toggle = sender as ToggleSwitch;
            OpenControl(toggle, toggle.IsOn);
        }

        //add mEventBack
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            NewTask = new MyTaskManagerLibrary.BackEnd.MyTask();

            if (IsSetName) NewTask.NameTask = NameValue;
            if (IsSetNumber) NewTask.NumberTask = NumberValue;
            if (IsSetShortDescription) NewTask.ShortDescription = ShortDescriptionValue;
            if (IsSetDescription) NewTask.Description = DescriptionValue;

            //settingDate
            if (IsSetStartDate && IsSetStartTime)
            {
                NewTask.StartDate = new DateTime(StartDateTimeValue.Year,
                    StartDateTimeValue.Month, StartDateTimeValue.Day,
                    StartDateTimeValue.Hour, StartDateTimeValue.Minute, StartDateTimeValue.Second);
            }
            if (IsSetStartDate) NewTask.StartDate = new DateTime(StartDateTimeValue.Year,
                StartDateTimeValue.Month, StartDateTimeValue.Day);
            if (IsSetStartTime) NewTask.StartDate = new DateTime(0, 0, 0, StartDateTimeValue.Hour,
                 StartDateTimeValue.Minute, StartDateTimeValue.Second);


            if (IsSetEndDate && IsSetEndTime)
            {
                NewTask.EndDate = new DateTime(EndDateTimeValue.Year,
                    EndDateTimeValue.Month, EndDateTimeValue.Day,
                    EndDateTimeValue.Hour, EndDateTimeValue.Minute, EndDateTimeValue.Second);
            }
            if (IsSetEndDate) NewTask.EndDate = new DateTime(EndDateTimeValue.Year,
               EndDateTimeValue.Month, EndDateTimeValue.Day);
            if (IsSetStartTime) NewTask.EndDate = new DateTime(0, 0, 0, EndDateTimeValue.Hour,
                 EndDateTimeValue.Minute, EndDateTimeValue.Second);

            if (IsSetPatent) NewTask.Parent = ParentValue;

            //add eventBack

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //addEventBack
        }
        //if lost focus add animation to end
        private void SetNameTask_LostFocus(object sender, RoutedEventArgs e)
        {
            NameValue = SetNameTask.Text;
            IsSetName = true;
        }
        private void SetNumbeTask_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                NumberValue = Convert.ToInt32(SetNumbeTask.Text);
            }
            catch(FormatException)
            {
                NumberValue = 0;
                (new MessageDialog("Number must be Number not a text!")).ShowAsync();

            }
            IsSetNumber = true;
        }
        private void SetShortDescriptionTask_LostFocus(object sender, RoutedEventArgs e)
        {
            ShortDescriptionValue = SetShortDescriptionTask.Text;
            IsSetShortDescription = true;
        }
        private void SetDescriptionTask_LostFocus(object sender, RoutedEventArgs e)
        {
            var box = sender as RichEditBox;
            string content;
            box.Document.GetText(Windows.UI.Text.TextGetOptions.None, out content);
            DescriptionValue = content;
            IsSetDescription = true;
        }

        private bool startDateTime { get; set; }
        private void SetDPStartDateTask_LostFocus(object sender, RoutedEventArgs e)
        {
            var picker = sender as DatePicker;
            var date = new DateTime();
            //testing this
            if (!startDateTime)
            {
                StartDateTimeValue = new DateTime();
                startDateTime = true;
            }

            date.AddDays(picker.Date.Day);
            date.AddMonths(picker.Date.Month);
            date.AddYears(picker.Date.Year);


            if (StartDateTimeValue == default(DateTime))
            {
                StartDateTimeValue = new DateTime(date.Year, date.Month, date.Year);
            }
            else
            {
                StartDateTimeValue.AddDays(date.Day);
                StartDateTimeValue.AddMonths(date.Month);
                StartDateTimeValue.AddTicks(date.Year);
            }
            IsSetStartTime = true;
        }
        private void SetTPStartDateTask_LostFocus(object sender, RoutedEventArgs e)
        {
            var picker = sender as TimePicker;
            var date = new DateTime();
            //testing this
            if (!startDateTime)
            {
                StartDateTimeValue = new DateTime();
                startDateTime = true;
            }

            date.AddHours(picker.Time.Hours);
            date.AddMinutes(picker.Time.Minutes);
            date.AddSeconds(picker.Time.Seconds);


            if (StartDateTimeValue == default(DateTime))
            {
                StartDateTimeValue = new DateTime(date.Year,
                    date.Month, date.Year);
            }
            else
            {
                StartDateTimeValue.AddDays(date.Day);
                StartDateTimeValue.AddMonths(date.Month);
                StartDateTimeValue.AddTicks(date.Year);
            }
            IsSetStartDate = true;
        }

        private bool endDateTime { get; set; }
        private void SetDPEndDateTask_LostFocus(object sender, RoutedEventArgs e)
        {
            var picker = sender as DatePicker;
            var date = new DateTime();
            //testing this
            if (!endDateTime)
            {
                StartDateTimeValue = new DateTime();
                endDateTime = true;
            }

            date.AddDays(picker.Date.Day);
            date.AddMonths(picker.Date.Month);
            date.AddYears(picker.Date.Year);


            if (StartDateTimeValue == default(DateTime))
            {
                StartDateTimeValue = new DateTime(date.Year, date.Month,
                    date.Year);
            }
            else
            {
                EndDateTimeValue.AddDays(date.Day);
                EndDateTimeValue.AddMonths(date.Month);
                EndDateTimeValue.AddTicks(date.Year);
            }
            IsSetEndDate = true;
        }
        private void SetTPEndDateTask_LostFocus(object sender, RoutedEventArgs e)
        {
            var picker = sender as TimePicker;
            var date = new DateTime();
            //testing this
            if (!endDateTime)
            {
                StartDateTimeValue = new DateTime();
                endDateTime = true;
            }

            date.AddHours(picker.Time.Hours);
            date.AddMinutes(picker.Time.Minutes);
            date.AddSeconds(picker.Time.Seconds);


            if (EndDateTimeValue == default(DateTime))
            {
                EndDateTimeValue = new DateTime(date.Year,
                    date.Month, date.Year);
            }
            else
            {
                EndDateTimeValue.AddDays(date.Day);
                EndDateTimeValue.AddMonths(date.Month);
                EndDateTimeValue.AddTicks(date.Year);
            }
            IsSetEndTime = true;
        }

        private void SetParent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combBox = sender as ComboBox;
            var perentTask = combBox.SelectedItem as MyTaskManagerLibrary.BackEnd.TaskTree;
            ParentValue = perentTask;

        }
        #endregion
    }
}

    


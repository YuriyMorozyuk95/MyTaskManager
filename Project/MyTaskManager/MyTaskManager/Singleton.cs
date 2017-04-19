using MyTaskManagerLibrary.BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MyTaskManager
{
    public class MainTreeSingleton
    {
        private static TaskTree _mainTree;
        public static TaskTree MainTree
        {
            get
            {
                if(_mainTree==null)
                {
                    _mainTree = new TaskTree();
                }
                return _mainTree;
            }
        }
        public static TaskTree CurrentTask { get; set; }

        public static Frame MyTaskFrame { get; set; } 
    }
}

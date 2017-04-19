using MyTaskManagerLibrary.BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManagerLibrary.BackEnd
{
    static class MyTaskFactory
    {
        #region Field
        static int _numberTask = -1;
        static string _nameTask = "My Task ";

        #endregion

        #region Method
        public static MyTask CreateMyTask()
        {
            _numberTask++;
            return new MyTask(_numberTask, _nameTask + _numberTask,"dsadklasd","dsadasdasdasda",DateTime.Now,DateTime.Now);
        }
        public static TaskTree CreateMyTaskTree()
        {
            return new TaskTree(CreateMyTask(), null);
        }
        public static TaskTree CreateMyTaskTree(List<TaskTree> listTask)
        {
            return new TaskTree(CreateMyTask(), listTask);
        }
        public static List<TaskTree> CreateListTaskTree(int count)
        {
            List<TaskTree> listTaskTree = new List<TaskTree>();
            for (int i = 0; i < count; i++)
            {
                listTaskTree.Add(CreateMyTaskTree());
            }
            return listTaskTree;
        }
        public static TaskTree CreateTeatTaskTree()
        {
            return new TaskTree(CreateMyTask(), CreateListTaskTree(10));
        }

        #endregion
    }
}

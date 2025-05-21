using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MyTask = taskManager2._0.Module.Task;

namespace taskManager2._0.Module
{
    public class TaskManagerList
    {
        /// en lista som innehåller alla tasks
        public List <MyTask> taskList { get; } = new List <MyTask> ();

        /// en konstruktor som tar in en lista av tasks
        public MyTask? CreateTask(string headline, string content)
        {

            if(string.IsNullOrWhiteSpace(headline) || string.IsNullOrWhiteSpace(content))
            {
                Debug.WriteLine("string r null");
                return null;
            }

            taskList.Add(new MyTask(headline, content));

            return new MyTask(headline, content);
         
           
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MyTask = taskManager2._0.Module.Task;

namespace taskManager2._0.Module
{
    public class List
    {

        public List <MyTask> taskList { get; } = new List <MyTask> ();


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
        public void removeTask()
        {
            throw new System.NotImplementedException();
        }

        public void markAsComplete()
        {
            throw new System.NotImplementedException();
        }
    }
}
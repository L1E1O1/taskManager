using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace taskManager2._0.Module

{
    public class Task
    {
        public string headline { get; set; }
        public string content {get; set; }


        public Task(string headline, string content)
        {

            this.headline = headline;
            this.content = content;


        }

        public override string ToString()
        {
            return $"headline: {headline} , your task: {content}";
        }

        public virtual void addToList()
        {
            throw new System.NotImplementedException();
        }
    }
}
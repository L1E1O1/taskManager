using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManager2._0.Module;

namespace taskManager2._0.Module
{
    internal abstract class Person
    {
        public string Name { get; set; }
        public string password { get; set; }
        public int accessLevel { get; set; } // 0 = staff, 1 = customer


        //konstruktur som tar in namn, lösenord och accessnivå
        public Person( string name, string password, int accessLevel)
        {
            this.Name = name;
            this.password = password;
            this.accessLevel = accessLevel;
        }

        public abstract void Login(string name, string password);

        public abstract void Price(int accessLevel);

    }
}

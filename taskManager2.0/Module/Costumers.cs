using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskManager2._0.Module
{
    internal class Costumers : Person  
    {
        public Costumers(string name, string password, int accessLevel) : base(name, password, accessLevel)
        {
            this.Name = name;
            this.password = password;
            this.accessLevel = accessLevel;
        }
        public override void Price(int accessLevel)
        {

        }

        public override void Login(string name, string password)
        {

        }

    }
}

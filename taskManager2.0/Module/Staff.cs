using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManager2._0.Module;

namespace taskManager2._0.Module
{
    internal  class Staff : Person
    {

        public Staff(string name, string password, int accessLevel) : base(name, password, accessLevel)
        {
            this.Name = name;
            this.password = password;
            this.accessLevel = accessLevel;
        }


        // staff har 0% moms
        // customer har 25% moms
        public override void Price(int accessLevel)
        {
            string moms = "";

            if(accessLevel == 0)
            {
                moms = "0%";
            }
            else
            {
                moms = "25%";
            }
        }

        public override void Login(string name, string password)
        {

            if (name == string.Empty)
            {
                throw new ArgumentException("name must be filled");
            }

            if (password == string.Empty)
            {
                throw new ArgumentException("password must be filled");
            }
        }

    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskManager2._0.Module
{
   internal class LoginManagerList
    {
        public List<Person> Users { get; } = new List<Person>();


        public static LoginManagerList LoginManager { get; } = new LoginManagerList();
        public void AddUser(Person user)
        {
            Users.Add(user);
        }


    }
}

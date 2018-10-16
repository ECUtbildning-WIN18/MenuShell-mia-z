using System;
using System.Collections.Generic;

namespace MenuShell
{
    class Program
    {
        public static List<User> Users;

        static void Main(string[] args)
        {
            Users = new List<User>
            {
                {
                    new User("admin", "123", Roles.Admin)
                }
            };

            var login = new LoginView("Log in");
            login.Display();
        }
    }
}

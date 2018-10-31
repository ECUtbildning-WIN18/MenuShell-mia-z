using System.Collections.Generic;
using MenuShell.Domain;

namespace MenuShell
{
    class Program
    {
        public static List<User> Users;

        static void Main(string[] args)
        {
            //Users = new List<User>(); //POPULATE THIS WITH USERS FROM DB
            //var helper = new DatabaseHelper();
            //helper.PopulateDB(Users);
            var running = true;
            while (running)
            {
                var login = new LoginView("Log in");
                login.Run();
            }
        }
    }
}

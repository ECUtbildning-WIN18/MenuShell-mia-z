using System.Collections.Generic;
using MenuShell.Domain;
using MenuShell.Domain.Services;

namespace MenuShell
{
    class Program
    {
        static void Main(string[] args)
        {
            //Users = new List<User>(); //POPULATE THIS WITH USERS FROM DB
            var helper = new DatabaseHelper();
            helper.CreateInitialTable();
            var running = true;
            while (running)
            {
                var login = new LoginView("Log in");
                login.Run();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using MenuShell.Domain;
using MenuShell.Domain.Services;

namespace MenuShell
{
    class Program
    {
        public static List<User> Users;

        static void Main(string[] args)
        {
            Users = new List<User>(); //POPULATE THIS WITH USERS FROM DB
            var builder = new DatabaseBuilder();
            builder.PopulateDB(Users);
            
            var login = new LoginView("Log in");
            login.Run();
        }
    }
}

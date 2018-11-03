using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using MenuShell.Domain;
using MenuShell.Domain.Services;

namespace MenuShell
{
    class Program
    {        
        static void Main(string[] args)
        {
            //Users = new List<User>(); //POPULATE THIS WITH USERS FROM DB
            //var helper = new DatabaseHelper();
            //helper.CreateInitialTable();
            
            using (var context = new MenuShellContext())
            {
                if (context.Users.Count() == 0)
                {
                    context.Users.Add(new User("admin", "secret", "Administrator", "The SysAdmin", "System admin",
                                        Roles.Admin));
                    context.SaveChanges();
                }
            }
            
            var running = true;
            while (running)
            {
                var login = new LoginView("Log in");
                login.Run();
            }
        }
    }
}

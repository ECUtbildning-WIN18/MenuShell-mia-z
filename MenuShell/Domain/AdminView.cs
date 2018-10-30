using System;
using MenuShell.Domain.Services;

namespace MenuShell.Domain
{
    class AdminView : View
    {
        public User LoggedInUser { get; set; }

        public AdminView(string title, User loggedInUser) : base(title)
        {
            LoggedInUser = loggedInUser;
        }

        public void Display()
        {
            ConsoleKey input;
            do
            {
                Console.Clear();
                Console.WriteLine("\n1. Manage users" +
                    "\nESC. Exit");
                input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        ManageUsersView manage = new ManageUsersView("Admin - Manage users");
                        manage.Display();
                        break;
                    case ConsoleKey.Escape:
                        LoginView login = new LoginView("Log in");
                        login.Display();
                        break;
                }
            } while (input != ConsoleKey.Escape);
        }
    }   
}

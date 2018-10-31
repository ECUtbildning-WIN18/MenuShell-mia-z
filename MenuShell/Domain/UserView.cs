using System;
using MenuShell.Domain.Services;

namespace MenuShell.Domain
{
    class UserView : View
    {
        public User LoggedInUser { get; set; }

        public UserView(string title, string[] entries, User loggedInUser) : base(title, entries)
        {
            LoggedInUser = loggedInUser;
        }
        public void Display()
        {
            ConsoleKey input;
            do
            {
                Console.Clear();
                Console.WriteLine("\nView for user logged in, name above" +
                    "\nESC. Exit");
                input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.Escape:
                        LoginView login = new LoginView("Log in");
                        login.Run();
                        break;
                }
            } while (input != ConsoleKey.Escape);
        }
    }
}

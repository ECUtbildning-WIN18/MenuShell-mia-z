using System;
using System.Dynamic;
using MenuShell.Domain.Services;

namespace MenuShell.Domain
{
    class AdminView : View
    {
        public User LoggedInUser { get; set; }

        private string Title { get; }
        private string[] Entries { get; }
        
        public AdminView(string title, string[] entries, User loggedInUser) : base(title, entries)
        {
            LoggedInUser = loggedInUser;
            Title = title;
            Entries = entries;
        }

        public void Run()
        {
            ConsoleKey input;
            do
            {
                CleanView(Title, Entries);
                input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        ManageUsersView manage = new ManageUsersView("Admin - Manage users", new MenuPopulator().GetMenu(11));
                        manage.Run();
                        break;
                    case ConsoleKey.Escape:
                        LoginView login = new LoginView("Log in");
                        login.Run();
                        break;
                }
            } while (input != ConsoleKey.Escape);
        }
    }   
}

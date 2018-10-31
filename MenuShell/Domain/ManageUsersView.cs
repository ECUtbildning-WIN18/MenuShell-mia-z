using System;
using MenuShell.Domain.Services;

namespace MenuShell.Domain
{
    class ManageUsersView : View
    {
        public ManageUsersView(string title, string[] entries) : base(title, entries)
        {

        }

        public void Run()
        {
            ConsoleKey input;
            do
            {
                input = Console.ReadKey(false).Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        AddUserView addUser = new AddUserView("Add a new user");
                        addUser.Run();
                        input = ConsoleKey.Escape;
                        break;
                    case ConsoleKey.D2:
                        SearchUserView searchUser = new SearchUserView("Find a user");
                        searchUser.Run();
                        input = ConsoleKey.Escape;
                        break;
                    case ConsoleKey.Escape:
                        break;
                }
            } while (input != ConsoleKey.Escape);
        }
    }
}

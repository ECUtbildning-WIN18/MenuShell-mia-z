using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShell
{
    class ManageUsersView : BaseView
    {
        public ManageUsersView(string title) : base(title)
        {

        }

        public void Display()
        {
            ConsoleKey input;
            do
            {
                Console.Clear();
                Console.WriteLine("\n1. Add new user" +
                    "\n2. Search for a user" +
                    "\nESC. Exit");
                input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        AddUserView addUser = new AddUserView("Add a new user");
                        addUser.Display();
                        break;
                    case ConsoleKey.D2:
                        SearchUserView searchUser = new SearchUserView("Find a user");
                        searchUser.Display();
                        break;
                    case ConsoleKey.Escape:
                        break;
                }
            } while (input != ConsoleKey.Escape);
        }
    }
}

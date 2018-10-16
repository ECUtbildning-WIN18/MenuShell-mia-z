using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShell
{
    class AdminView : BaseView
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
                Console.WriteLine("\n1. Add new user" +
                    "\n2. Delete existing user" +
                    "\nESC. Exit");
                input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        AddUserView addUser = new AddUserView("Add a new user");
                        addUser.Display();
                        break;
                    case ConsoleKey.D2:
                        DeleteUserView delUser = new DeleteUserView("Add a new user");
                        delUser.Display();
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

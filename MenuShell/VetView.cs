﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShell
{
    class VetView : BaseView
    {
        public User LoggedInUser { get; set; }

        public VetView(string title, User loggedInUser) : base(title)
        {
            LoggedInUser = loggedInUser;
        }

        public void Display()
        {
            ConsoleKey input;
            do
            {
                Console.Clear();
                Console.WriteLine("\nView for vet logged in, name above" +
                    "\nESC. Exit");
                input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.Escape:
                        LoginView login = new LoginView("Log in");
                        login.Display();
                        break;
                }
            } while (input != ConsoleKey.Escape);
        }
    }
}

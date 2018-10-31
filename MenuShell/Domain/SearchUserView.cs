using System;
using System.Collections.Generic;
using MenuShell.Domain.Services;

namespace MenuShell.Domain
{
    class SearchUserView : View
    {
        public static List<User> Users; //Initial database of users
        List<User> FoundUsers; //List of users that matched the search query

        public SearchUserView(string title) : base(title)
        {
            Users = Program.Users;
            FoundUsers = new List<User>();
        }

        public void Run()
        {
            Console.WriteLine("\nEnter your search term");
            Console.Write("\n> ");
            SearchUsers(Console.ReadLine());
        }

        void SearchUsers(string query)
        {
            foreach (User u in Users)
            {
                if (u.Username.Contains(query))
                {
                    FoundUsers.Add(u);
                }
            }
            if (FoundUsers == null)
            {
                Console.WriteLine("\nUser not found - press return to go back");
                Console.ReadLine();
            } else
            {
                FoundUsersView fuv = new FoundUsersView("Admin - Manage - Search - Found users", Users, FoundUsers);
                fuv.Display();
            }
        }
    }
}

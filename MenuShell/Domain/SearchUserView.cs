using System;
using System.Collections.Generic;
using MenuShell.Domain.Services;

namespace MenuShell.Domain
{
    class SearchUserView : View
    {
        private DatabaseHelper helper;

        public SearchUserView(string title) : base(title)
        {
            helper = new DatabaseHelper();
        }

        public void Run()
        {
            WriteJustified("Enter your search term (USERNAME)", 2);
            WriteAt(">", 2, 3);
            SearchUsers(Console.ReadLine());
        }

        void SearchUsers(string query)
        {
            List<User> FoundUsers = helper.SearchUsers(query);
            if (FoundUsers == null)
            {
                ClearInside();
                WriteJustified("Users matching search term were not found - press return to go back", Console.WindowHeight / 2);
                Console.ReadLine();
            } else
            {
                FoundUsersView fuv = new FoundUsersView("Admin - Manage - Search - Found users", FoundUsers);
                fuv.Display();
            }
        }
    }
}

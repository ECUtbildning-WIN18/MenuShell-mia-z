﻿using System;
using System.Collections.Generic;
using MenuShell.Domain.Services;

namespace MenuShell.Domain
{
    class SearchUserView : View
    {
        //private DatabaseHelper helper;
        private SqlEntityHelper entityHelper;
        
        public SearchUserView(string title) : base(title)
        {
            entityHelper = new SqlEntityHelper();
            //helper = new DatabaseHelper();
        }

        public void Run()
        {
            WriteJustified("Enter your search term (USERNAME)", 2);
            WriteAt(">", 2, 3);
            SearchUsers(Console.ReadLine());
        }

        void SearchUsers(string query)
        {
            List<User> FoundUsers = entityHelper.ReturnUsers(query);
            if (FoundUsers.Count < 1)
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

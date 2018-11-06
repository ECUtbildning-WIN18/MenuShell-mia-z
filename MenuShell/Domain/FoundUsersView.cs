using System;
using System.Collections.Generic;
using System.Linq;
using MenuShell.Domain.Services;

namespace MenuShell.Domain
{
    class FoundUsersView : View
    {
        private List<User> FoundUsers { get; }  //List of users that matched the search query

        public FoundUsersView(string title, List<User> foundUsers) : base(title)
        {
            FoundUsers = foundUsers;
        }

        public void Display()
        {
            if (FoundUsers.Count > 1)
                WriteJustified("Following users were found:", 2);
            else
                WriteJustified("Following user was found:", 2);

            for (int x = 0; x < FoundUsers.Count; x++)
            {
                WriteAt($"{FoundUsers[x].Username}", 2, 3 + x);
            }

            WriteAt("Type the full Username of the user to see more details", 2, FoundUsers.Count + 3 + 1);
            WriteAt("Enter nothing to return", 2, FoundUsers.Count + 3 + 2);
            WriteAt(">", 2, FoundUsers.Count + 3 + 3);
            var searchTerm = Console.ReadLine();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                var selectedUser = SelectUser(searchTerm);
                if (selectedUser == null)
                {
                    ClearInside();
                    WriteJustified("You misspelled something - press return to go to back", Console.WindowHeight / 2);
                    Console.ReadLine();
                }
                else
                {
                    UserDetailsView udv = new UserDetailsView("Admin - Manage - Search User - User details", selectedUser);
                    udv.Run();
                }
            }
        }

        User SelectUser(string query)
        {
            foreach(User u in FoundUsers)
            {
                if (query == u.Username)
                {
                    return u;
                }
            }
            return null;
        }
    }
}

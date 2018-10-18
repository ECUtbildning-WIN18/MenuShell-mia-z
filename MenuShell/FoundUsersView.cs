using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShell
{
    class FoundUsersView : BaseView
    {
        public List<User> Users { get; set; } //Initial database of users
        public List<User> FoundUsers { get; set; }  //List of users that matched the search query

        public FoundUsersView(string title, List<User> users, List<User> foundUsers) : base(title)
        {
            Users = users;
            FoundUsers = foundUsers;
        }

        public void Display()
        {
            if (FoundUsers.Count > 1)
                Console.WriteLine("\nFollowing users were found:");
            else
                Console.WriteLine("\nFollowing user was found:");

            foreach (User u in FoundUsers)
            {
                Console.WriteLine($"{u.Username}");
            }

            Console.WriteLine("\nType the full Username of the user to see more details" +
                "\nEnter nothing to return");
            var searchTerm = Console.ReadLine();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                var selectedUser = SearchUser(searchTerm);
                if (selectedUser == null)
                {
                    Console.WriteLine("\nYou misspelled something\nPress return to go to back");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    UserDetailsView udv = new UserDetailsView("Admin - Manage - Search User - User details", Users, selectedUser);
                    udv.Display();
                }
            }
        }

        User SearchUser(string query)
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

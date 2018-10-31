using System;
using System.Collections.Generic;
using MenuShell.Domain.Services;

namespace MenuShell.Domain
{
    class UserDetailsView : View
    {
        private DatabaseHelper helper;
        public User SelectedUser { get; }

        public UserDetailsView(string title, User selectedUser) : base(title)
        {
            helper = new DatabaseHelper();
            SelectedUser = selectedUser;
        }

        public void Run()
        {
            WriteAt($"Username: {SelectedUser.Username}" +
                $"\n# Position: {SelectedUser.Status}" +
                $"\n# First name: {SelectedUser.FirstName}" +
                $"\n# Last name: {SelectedUser.LastName}" +
                $"\n# System role: {SelectedUser.Role.ToString()}", 2, 2);
            WriteAt("Press D to delete this user", 2, 8);
            WriteAt("Press ESC to go back", 2, 9);
            ConsoleKey input;
            do
            {
                input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.D:
                        DeleteUser(SelectedUser);
                        input = ConsoleKey.Escape;
                        break;
                    case ConsoleKey.Escape:
                        break;
                }
            } while (input != ConsoleKey.Escape);

        }

        void DeleteUser(User userToDelete)
        {
            ClearInside();
            WriteJustified(string.Format("Are you sure you want to delete user {0}", userToDelete.Username), 2);
            WriteJustified("(Y)es - (N)o", 4);
            ConsoleKey input = Console.ReadKey().Key;
            ClearInside();
            if (input == ConsoleKey.Y)
            {
                helper.RemoveUser(userToDelete);
                WriteJustified("User deleted - press return to go back", Console.WindowHeight / 2);
                Console.ReadLine();
            }
            else
            {
                WriteJustified("\nUser not deleted - press return to go back", Console.WindowHeight / 2);
                Console.ReadLine();
            }
        }
    }
}

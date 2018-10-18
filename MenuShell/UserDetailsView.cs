using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShell
{
    class UserDetailsView : BaseView
    {
        public List<User> Users { get; set; }
        public User SelectedUser { get; set; }

        public UserDetailsView(string title, List<User> users, User selectedUser) : base(title)
        {
            Users = users;
            SelectedUser = selectedUser;
        }

        public void Display()
        {
            Console.WriteLine($"\nUsername: {SelectedUser.Username}" +
                $"\nPosition: {SelectedUser.Status}" +
                $"\nFirst name: {SelectedUser.FirstName}" +
                $"\nLast name: {SelectedUser.LastName}" +
                $"\nSystem role: {SelectedUser.Role.ToString()}");
            Console.WriteLine("Press D to delete this user\nPress ESC to go back");
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
            Console.WriteLine("\nAre you sure you want to delete user {0}?" +
                        "\n(Y)es - (N)o", userToDelete.Username);
            ConsoleKey input = Console.ReadKey().Key;
            if (input == ConsoleKey.Y)
            {
                Users.Remove(userToDelete);
                Console.WriteLine("\nUser deleted - press return to go back");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nUser not deleted - press return to go back");
                Console.ReadLine();
            }
        }
    }
}

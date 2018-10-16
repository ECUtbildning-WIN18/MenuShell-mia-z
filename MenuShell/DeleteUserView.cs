using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShell
{
    class DeleteUserView :  BaseView
    {
        public static List<User> Users;

        public DeleteUserView(string title) : base(title)
        {
            Users = Program.Users;
        }

        public void Display()
        {
            Console.WriteLine("\nEnter the username of the person you want to remove");
            Console.Write("\n> ");
            SearchUsers(Console.ReadLine());
        }

        void SearchUsers(string query)
        {
            //Had to use a for-loop here since using a foreach wouldnt let me remove values in the list
            //it's currently iterating through - it could be done, but im lazy and its 4am. im a good student i swear.
            for (int i = 0; i < Users.Count; i++)
            {
                if (query == Users[i].Username)
                {
                    Console.WriteLine("User {0} found, are you sure you want to delete?" +
                        "\n(Y)es - (N)o", Users[i].Username);
                    ConsoleKey input = Console.ReadKey().Key;
                    if (input == ConsoleKey.Y)
                    {
                        Users.RemoveAt(i);
                        Console.WriteLine("\nUser deleted - press return to go back");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nUser not deleted - press return to go back");
                        Console.ReadLine();
                        break;
                    }
                } else if (i == Users.Count && query != Users[i].Username)
                {
                    Console.WriteLine("\nUser not found - press return to go back");
                    Console.ReadLine();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using MenuShell.Domain.Services;

namespace MenuShell.Domain
{
    class AddUserView : View
    {
        public static List<User> Users;

        public AddUserView(string title) : base(title)
        {
            Users = Program.Users;
        }

        public void Display()
        {
            Console.WriteLine("\nEnter the username of the person you want to add");
            Console.Write("\n> ");
            var username = ValidInput(Console.ReadLine());

            Console.WriteLine("\nEnter the first name of the person you want to add");
            Console.Write("\n> ");
            var firstname = ValidInput(Console.ReadLine());

            Console.WriteLine("\nEnter the last name of the person you want to add");
            Console.Write("\n> ");
            var lastname = ValidInput(Console.ReadLine());

            Console.WriteLine("\nEnter the password for the person you want to add");
            Console.Write("\n> ");
            var password = ValidInput(Console.ReadLine());

            Console.WriteLine("\nSelect the power level to give to the user:" +
                "\n1. Admin" +
                "\n2. Receptionist" +
                "\n3. Veterinary Doctor" +
                "\n4. User");
            ConsoleKey input;
            do
            {
                input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        Confirmation(new User(username, password, firstname, lastname, "Administrator", Roles.Admin));
                        break;
                    case ConsoleKey.D2:
                        Confirmation(new User(username, password, firstname, lastname, "Receptionist", Roles.Receptionist));
                        break;
                    case ConsoleKey.D3:
                        Confirmation(new User(username, password, firstname, lastname, "Veterinary Doctor", Roles.Vet));
                        break;
                    case ConsoleKey.D4:
                        Confirmation(new User(username, password, firstname, lastname, "User", Roles.User));
                        break;
                }
            } while 
            (input != ConsoleKey.D1 && 
            input != ConsoleKey.D2  && 
            input != ConsoleKey.D3  && 
            input != ConsoleKey.D4);
        }

        string ValidInput(string term)
        {
            while (string.IsNullOrEmpty(term))
            {
                Console.WriteLine("\nInvalid input, please enter something");
                Console.Write("\n> ");
                var i = Console.ReadLine();
                if (!string.IsNullOrEmpty(i))
                    return i;
            }
            return term;
        }

        void Confirmation(User preliminaryUser)
        {
            Console.WriteLine("\nAre you sure you want to add the following user: {0}, with role: {1}?" +
                "\n(Y)es - (N)o",
                preliminaryUser.Username, preliminaryUser.Role.ToString());
            ConsoleKey input = Console.ReadKey().Key;
            if (input == ConsoleKey.Y)
            {
                Console.WriteLine("\nUser added!");
                Users.Add(preliminaryUser);
            }
            else
            {
                Console.WriteLine("\nExiting - press return to go back");
                Console.ReadLine();
            }
            
        }
    }
}

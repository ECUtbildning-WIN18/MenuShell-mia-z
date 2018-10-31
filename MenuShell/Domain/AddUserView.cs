using System;
using System.Collections.Generic;
using MenuShell.Domain.Services;

namespace MenuShell.Domain
{
    class AddUserView : View
    {
        public AddUserView(string title) : base(title)
        {
            //Constructor
        }

        public void Run()
        {
            WriteAt("Enter the username of the person you want to add", 2, 2);
            WriteAt(">", 2, 3);
            var username = ValidInput(Console.ReadLine(), "Username", 2);

            WriteAt("Enter the first name of the person you want to add", 2, 5);
            WriteAt(">", 2, 6);
            var firstname = ValidInput(Console.ReadLine(), "First Name", 5);

            WriteAt("Enter the last name of the person you want to add", 2, 8);
            WriteAt(">", 2, 9);
            var lastname = ValidInput(Console.ReadLine(), "Last name", 8);

            WriteAt("Enter the password of the person you want to add", 2, 11);
            WriteAt(">", 2, 12);
            var password = ValidInput(Console.ReadLine(), "Password", 11);

            WriteAt("Select the power level of the user you are creating" +
                "\n# 1. Admin" +
                "\n# 2. Receptionist" +
                "\n# 3. Veterinary Doctor" +
                "\n# 4. User", 2, 14);
            ConsoleKey input;
            do
            {
                input = Console.ReadKey(true).Key;
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

        string ValidInput(string term, string objectValue, int line)
        {
            while (string.IsNullOrEmpty(term))
            {
                WriteAt($"Invalid input, please enter something({objectValue})\t\t", 2, line);
                WriteAt(">", 2, line + 1);
                var i = Console.ReadLine();
                if (!string.IsNullOrEmpty(i))
                    return i;
            }
            return term;
        }

        void Confirmation(User preliminaryUser)
        {
            WriteJustified("Are you sure you want to add the following user:", 3);                                    
            WriteJustified(preliminaryUser.FirstName, 4);                                    
            WriteJustified("with role:", 5);                                        
            WriteJustified(preliminaryUser.Role.ToString(), 6);                                     
            WriteJustified("(Y)es - (N)o", 7);        
            
            var input = Console.ReadKey().Key;
            if (input == ConsoleKey.Y)
            {
                WriteJustified($"User {preliminaryUser.FirstName}, {preliminaryUser.Status} added!", 6);
            }
            else
            {
                ClearInside();
                WriteJustified("Exiting - press return to go back", Console.WindowHeight / 2);
                Console.ReadLine();
            }
            
        }
    }
}

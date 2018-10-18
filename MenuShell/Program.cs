using System;
using System.Collections.Generic;

namespace MenuShell
{
    class Program
    {
        public static List<User> Users;

        static void Main(string[] args)
        {
            Users = new List<User>
            {
                {
                    new User("admin", "123", "Admin", "Bigdick", "Biggest of all boys", Roles.Admin)
                },
                {
                    new User("rosie2996", "123", "Rosie", "TheReceptionist", "Receptionist", Roles.Receptionist)
                },
                {
                    new User("victorvet", "123", "Victor", "TheVet", "Veterinary Doctor", Roles.Vet)
                },
                {
                    new User("ebrown1932", "123", "Dr. Emmet", "Brown", "Veterinary Doctor", Roles.Vet)
                },
                {
                    new User("testuser1", "123", "John", "Doe", "User", Roles.User)
                },
                {
                    new User("testuser2", "123", "Jane", "Doe", "User", Roles.User)
                }
            };

            var login = new LoginView("Log in");
            login.Display();
        }
    }
}

using System;
using System.Collections.Generic;
using MenuShell.Domain.Services;

namespace MenuShell.Domain
{
    class LoginView : View, IAuthenticationService
    {
        public User UserToLogIn;

        public LoginView(string title) : base(title)
        {
            
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("Please log in to continue..");
            Console.Write("Username: ");
            var tempUsername = Console.ReadLine();
            Console.Write("Password: ");
            var tempPassword = Console.ReadLine();

            switch (Authenticate(Program.Users, tempUsername, tempPassword))
            {
                case Roles.Admin:
                    var adminview = new AdminView("Administrator Menu", UserToLogIn);
                    adminview.Display();
                    break;
                case Roles.Receptionist:
                    ReceptionistView recepview = new ReceptionistView($"Welcome, Receptionist {UserToLogIn.Username}", UserToLogIn);
                    recepview.Display();
                    break;
                case Roles.Vet:
                    VetView vetview = new VetView($"Welcome, Veterinary Doctor {UserToLogIn.Username}", UserToLogIn);
                    vetview.Display();
                    break;
                case Roles.User:
                    UserView userview = new UserView($"Welcome, User {UserToLogIn.Username}", UserToLogIn);
                    userview.Display();
                    break;
                case Roles.Null:
                    Console.WriteLine("\nIncorrect username or password\nPress return to restart..");
                    Console.ReadLine();
                    break;
            }
        }

        public Roles Authenticate(List<User> userList, string login, string password)
        {
            foreach (User u in userList)
            {
                if (login == u.Username && password == u.Password)
                {
                    UserToLogIn = u;
                    return u.Role;
                }
            }
            return Roles.Null;
        }
    }
}

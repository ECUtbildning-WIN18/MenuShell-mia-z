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

        public void Run()
        {
            WriteJustified("Please log in to continue..", 2);
            WriteAt("Username: ", 3, 4);
            var tempUsername = Console.ReadLine();
            WriteAt("Password: ", 3, 5);
            var tempPassword = Console.ReadLine();

            switch (Authenticate(Program.Users, tempUsername, tempPassword))
            {
                case Roles.Admin:
                    var adminview = new AdminView("Administrator Menu", new MenuPopulator().GetMenu(1), UserToLogIn);
                    adminview.Display();
                    break;
                case Roles.Receptionist:
                    var recepview = new ReceptionistView($"Welcome, Receptionist {UserToLogIn.Username}", new MenuPopulator().GetMenu(2), UserToLogIn);
                    recepview.Display();
                    break;
                case Roles.Vet:
                    var vetview = new VetView($"Welcome, Veterinary Doctor {UserToLogIn.Username}", new MenuPopulator().GetMenu(3), UserToLogIn);
                    vetview.Display();
                    break;
                case Roles.User:
                    var userview = new UserView($"Welcome, User {UserToLogIn.Username}", new MenuPopulator().GetMenu(4), UserToLogIn);
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

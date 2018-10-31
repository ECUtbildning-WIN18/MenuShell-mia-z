using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using MenuShell.Domain.Services;

namespace MenuShell.Domain
{
    class LoginView : View, IAuthenticationService
    {
        public User UserToLogIn;
        public DatabaseHelper helper;

        public LoginView(string title) : base(title)
        {
            helper = new DatabaseHelper();
        }

        public void Run()
        {
            WriteJustified("LEAVE FIELD BLANK TO EXIT", 1);
            WriteJustified("Please log in to continue..", 2);
            WriteAt("Username: ", 3, 4);
            var tempUsername = Console.ReadLine();
            if (string.IsNullOrEmpty(tempUsername))
                Environment.Exit(0);
            WriteAt("Password: ", 3, 5);
            var tempPassword = Console.ReadLine();

            switch (Authenticate(tempUsername, tempPassword))
            {
                case Roles.Admin:
                    var adminview = new AdminView("Administrator Menu", new MenuPopulator().GetMenu(1), UserToLogIn);
                    adminview.Run();
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
                    ClearInside();
                    WriteJustified("Incorrect username or password.", 3);
                    WriteJustified("Press return to restart.", 4);
                    Console.ReadLine();
                    break;
            }
        }

        public Roles Authenticate(string login, string password)
        {
            UserToLogIn = helper.LogInUser(login, password);
            return UserToLogIn != null ? helper.LogInUser(login, password).Role : Roles.Null;
        }
    }
}

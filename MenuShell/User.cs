using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShell
{
    class User
    {
        public string Username { get; }
        public string Password { get; }
        public Roles Role { get; }

        public User(string username, string password, Roles role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}

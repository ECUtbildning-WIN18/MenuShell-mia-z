using MenuShell.Domain.Services;

namespace MenuShell.Domain
{
    public class User
    {
        public string Username { get; }
        public string Password { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Status { get; }
        public Roles Role { get; }

        public User(string username, string password, string firstName, string lastName, string status, Roles role)
        {
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Status = status;
            Role = role;
        }
    }
}

using MenuShell.Domain.Services;

namespace MenuShell.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public Roles Role { get; set; }

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

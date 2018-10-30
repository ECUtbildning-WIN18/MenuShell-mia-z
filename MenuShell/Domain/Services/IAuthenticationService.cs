using System.Collections.Generic;

namespace MenuShell.Domain.Services
{
    interface IAuthenticationService
    {
        Roles Authenticate(List<User> userList, string login, string password);
    }
}

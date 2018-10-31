using System.Collections.Generic;

namespace MenuShell.Domain.Services
{
    interface IAuthenticationService
    {
        Roles Authenticate(string login, string password);
    }
}

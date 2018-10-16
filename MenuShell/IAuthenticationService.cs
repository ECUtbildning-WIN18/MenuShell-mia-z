using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShell
{
    interface IAuthenticationService
    {
        Roles Authenticate(List<User> userList, string login, string password);
    }
}

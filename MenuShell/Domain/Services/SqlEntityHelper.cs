using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MenuShell.Domain.Services
{
    public class SqlEntityHelper
    {
        public User LogInUser(string username, string password)
        {
            using (var context = new MenuShellContext())
            {
                foreach (var u in context.Users)
                {
                    if (username == u.Username && password == u.Password)
                    {
                        return u;
                    }
                }
            }
            return null;
        }
        
        public void AddUser(User userToAdd)
        {
            using (var context = new MenuShellContext())
            {
                context.Users.Add(userToAdd);
                context.SaveChanges();
            }
        }

        public void RemoveUser(User userToRemove)
        {
            using (var context = new MenuShellContext())
            {
                context.Users.Remove(userToRemove);
                context.SaveChanges();
            }
        }

        public List<User> ReturnUsers(string searchTerm)
        {
            List<User> usersToReturn = new List<User>();
            using (var context = new MenuShellContext())
            {
                foreach (var u in context.Users)
                {
                    if (u.Username.Contains(searchTerm))
                    {
                        usersToReturn.Add(u);
                        context.SaveChanges();
                    }
                }
            }
            return usersToReturn;
        }

        public bool DuplicationChecker(string usernameQuery)
        {
            using (var context = new MenuShellContext())
            {
                foreach (var u in context.Users)
                {
                    if (u.Username.Equals(usernameQuery))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
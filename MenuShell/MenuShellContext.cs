using MenuShell.Domain;
using Microsoft.EntityFrameworkCore;

namespace MenuShell
{
    public class MenuShellContext : DbContext
    {
        public DbSet<User> Users {get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1;DataBase=MenuShell;user id=SA; pwd=Ryan2134!;");
        }
    }
}
namespace MenuShell.Domain.Services
{
    public struct MenuPopulator
    {
        private static readonly string[] AdminMenu = { "1. Manage Users" };
        
        public string[] GetMenu(int menu)
        {
            switch (menu)
            {
                case 1: return AdminMenu;
                
            }
            return null;
        }
    }
}
namespace MenuShell.Domain.Services
{
    public struct MenuPopulator
    {
        private static readonly string[] AdminMenu =
        {
            "1. Manage Users",
            "ESC: Back"
        };
        
        private static readonly string[] ManageUsersMenu =
        {
            "1. Add new user",
            "2. Search for a user",
            "ESC: Back"
        };
        
        private static readonly string[] ReceptionistMenu =
        {
            "1. Manage Users",
            "ESC: Back"
        };
        
        private static readonly string[] VetMenu =
        {
            "1. Manage Users",
            "ESC: Back"
        };
        
        private static readonly string[] UserMenu =
        {
            "1. Manage Users",
            "ESC: Back"
        };
        
        public string[] GetMenu(int menu)
        {
            switch (menu)
            {
                case 1: return AdminMenu;
                case 11: return ManageUsersMenu;
                case 2: return ReceptionistMenu;
                case 3: return VetMenu;
                case 4: return UserMenu;
            }
            return null;
        }
    }
}
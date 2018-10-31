using System.Collections.Generic;
using System.Data.SqlClient;


namespace MenuShell.Domain.Services
{
    public struct DatabaseBuilder
    {
        //Just realised that this completely defeats the purpose of working with Databases if Im just going to add all the entries to a list
        //At least I learned something, so Im leaving this in anyway hehe
        public void PopulateDB(List<User> users)
        {
            //var connectionString = "Data Source=(local);Initial Catalog=DentalCare;Integrated Security=true;";
            var connectionString = "Server=127.0.0.1;DataBase=DentalCare;user id=SA; pwd=Ryan2134!;";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //BEGIN SQL QUERIES HERE
                var queryString = "SELECT * FROM [USER]";
                var command = new SqlCommand(queryString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(GetUser(reader));
                }
                
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }

        private User GetUser(SqlDataReader data)
        {
            User user = new User(
                data["Username"].ToString(),
                data["Password"].ToString(),
                data["FirstName"].ToString(),
                data["LastName"].ToString(),
                data["Status"].ToString(),
                ParseEnum(data["Role"].ToString())
            );
        return user;
        }

        private Roles ParseEnum(string s)
        {
            switch (s)
            {
                case "Roles.Admin":
                    return Roles.Admin;
                case "Roles.Receptionist":
                    return Roles.Receptionist;
                case "Roles.Vet":
                    return Roles.Vet;
                case "Roles.User":
                    return Roles.User;
            }
            return Roles.Null;
        }
    }
}
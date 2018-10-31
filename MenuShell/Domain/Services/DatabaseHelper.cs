using System.Collections.Generic;
using System.Data.SqlClient;


namespace MenuShell.Domain.Services
{
    public class DatabaseHelper
    {
        public string ConnectionString { get; }
        
        public DatabaseHelper()
        {
            ConnectionString = "Server=127.0.0.1;DataBase=DentalCare;user id=SA; pwd=Ryan2134!;";
            //ConnectionString = "Data Source=(local);Initial Catalog=DentalCare;Integrated Security=true;";
        }
        
        //POPULATES A LIST FROM SQL DB
        public void PopulateDB(List<User> users)
        {
            using (var connection = new SqlConnection(ConnectionString))
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

        public User LogInUser(string username, string password)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var queryString = "SELECT * FROM [USER]";
                var command = new SqlCommand(queryString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (username == reader["Username"].ToString() && password == reader["Password"].ToString())
                    {
                        var userToReturn = GetUser(reader);
                        command.Dispose();
                        connection.Close();
                        connection.Dispose();
                        return userToReturn;
                    }
                }
                
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return null;
        }

        public void AddUser(User userToAdd)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                
                var queryString = string.Format("INSERT INTO [USER] VALUES " +
                                  "('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", 
                    userToAdd.Username, userToAdd.Password, userToAdd.FirstName, userToAdd.LastName, userToAdd.Status, ParseEnumToString(userToAdd.Role));
                
                var command = new SqlCommand(queryString, connection);
                command.ExecuteNonQuery();
                
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }
        
        public User GetUser(SqlDataReader data)
        {
            User user = new User(
                data["Username"].ToString(),
                data["Password"].ToString(),
                data["FirstName"].ToString(),
                data["LastName"].ToString(),
                data["Status"].ToString(),
                ParseStringToEnum(data["Role"].ToString())
            );
        return user;
        }

        private string ParseEnumToString(Roles r)
        {
            switch (r)
            {
                case Roles.Admin:
                    return "Roles.Admin";
                case Roles.Receptionist:
                    return "Roles.Receptionist";
                case Roles.Vet:
                    return "Roles.Vet";
                case Roles.User:
                    return "Roles.User";
            }
            return null;
        }
        
        private Roles ParseStringToEnum(string s)
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
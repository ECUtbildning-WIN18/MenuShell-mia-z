using System.Collections.Generic;
//using System.Data.Entity;
using System.Data.SqlClient;


namespace MenuShell.Domain.Services
{
    public class DatabaseHelper
    {
        public string ConnectionString { get; }
        
        public DatabaseHelper()
        {
            ConnectionString = "Server=127.0.0.1;DataBase=MenuShell;user id=SA; pwd=Ryan2134!;";
            //ConnectionString = "Data Source=(local);Initial Catalog=DentalCare;Integrated Security=true;";
        }

        public void CreateInitialTable()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var queryCreateTable = string.Format("CREATE TABLE [User] ("+
                    "[Username] varchar(100),"+
                    "[Password] varchar(100),"+
                    "[FirstName] varchar(100),"+
                    "[LastName] varchar(100),"+
                    "[Status] varchar(100),"+
                    "[Role] varchar(100)"+
                    ")");
                
                var commandCreateTable = new SqlCommand(queryCreateTable, connection);
                commandCreateTable.ExecuteNonQuery();
                commandCreateTable.Dispose();
                
                var queryPopulateTable = string.Format("INSERT INTO [User] VALUES ('admin', 'secret', 'System', 'Administrator', 'SysAdmin', 'Roles.Admin'), " +
                                                "('johnd1', 'password', 'John', 'Doe', 'Dentist', 'Roles.Vet'), " +
                                                "('janed1', 'password', 'Jane', 'Doe', 'Dentist', 'Roles.Vet')");
                var commandPopulateTable = new SqlCommand(queryPopulateTable, connection);
                commandPopulateTable.ExecuteNonQuery();
                commandPopulateTable.Dispose();
                
                connection.Close();
                connection.Dispose();
            }
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
        
        public void RemoveUser(User userToRemove)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                
                var queryString = string.Format("DELETE FROM [User] WHERE Username = '{0}' ", userToRemove.Username);
                
                var command = new SqlCommand(queryString, connection);
                command.ExecuteNonQuery();
                
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }

        public List<User> SearchUsers(string searchTerm)
        {
            List<User> FoundUsers = new List<User>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var queryString = "SELECT * FROM [User]";
                var command = new SqlCommand(queryString, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader["Username"].ToString().Contains(searchTerm))
                        {
                            FoundUsers.Add(GetUser(reader));
                        }
                    }
                }
                
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return FoundUsers;
        }
        
        private User GetUser(SqlDataReader data)
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

        public bool DuplicationChecker(string usernameQuery)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var queryString = "SELECT * FROM [User]";
                var command = new SqlCommand(queryString, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader["Username"].ToString() == usernameQuery)
                        {
                            return true;
                        }
                    }
                }
                
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
            return false;
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
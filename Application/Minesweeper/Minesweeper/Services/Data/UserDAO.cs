using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Minesweeper.Services.Data
{
    // Class for handling UserModel CRUD actions with SQL Server via DAO
    public class UserDAO
    {
        // Add new user to database. 
        public bool AddUser(UserModel user)
        {
            // Boolean to track success of user insertion
            bool success = false;

            // Query string to insert new into database using prepared statement
            string queryString = "INSERT INTO users VALUES(@FirstName, @LastName, @Age, @Sex, @State, @EmailAddress, @Username, @Password)";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Add user data to INSERT statement
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Age", user.Age);
                command.Parameters.AddWithValue("@Sex", user.Sex);
                command.Parameters.AddWithValue("@State", user.State);
                command.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);

                // Try to access database and insert user
                try
                {
                    connection.Open();

                    // Returns number of rows affected
                    int test = command.ExecuteNonQuery();

                    if(test > 0)
                    {
                        success = true;
                    }                   

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }

            }

            return success;
        }

    }
}
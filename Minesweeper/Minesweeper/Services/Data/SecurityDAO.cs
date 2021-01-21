using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Minesweeper.Services.Data
{
    public class SecurityDAO
    {
        // Check for user. Return true for success, false for failure.
        public bool FindByUser(LoginModel user)
        {
            // Boolean to track success of user insertion
            bool success = false;

            // Query string to check for specific user using prepared statement
            string queryString = "SELECT * FROM dbo.users WHERE username = @Username AND password = @Password";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Set parameters for prepared statement
                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;

                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

                // Try to access database and retrieve results
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if query returned results. If yes, return true.
                    if (reader.HasRows)
                    {
                        success = true;
                    }

                    reader.Close();
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
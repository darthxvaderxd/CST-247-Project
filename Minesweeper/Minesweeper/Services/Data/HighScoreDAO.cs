using MineSweeperClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Minesweeper.Services.Data
{
    public class HighScoreDAO
    {
        // Add new user to database. 
        public void AddScore(PlayerStats playerStats)
        {
            int userID = int.Parse((String) HttpContext.Current.Session["UserId"]);
            long timeSpanTicks = playerStats.time.Ticks;

            // Boolean to track success of user insertion
            bool success = false;

            // Query string to insert new into database using prepared statement
            string queryString = "INSERT INTO highScores VALUES(@UserID, @Timespan, @Difficulty, @BoardSize, @Username)";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Add user data to INSERT statement
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@Timespan", timeSpanTicks);
                command.Parameters.AddWithValue("@Difficulty", playerStats.DifficultyLevel);
                command.Parameters.AddWithValue("@BoardSize", playerStats.BoardSize);
                command.Parameters.AddWithValue("@Username", playerStats.PlayerInitials);

                // Try to access database and insert user
                try
                {
                    connection.Open();

                    // Returns number of rows affected
                    int test = command.ExecuteNonQuery();

                    if (test > 0)
                    {
                        success = true;
                    }

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }

            }

        }

        public List<PlayerStats> GetHighScores(int size, int difficulty)
        {
            List<PlayerStats> highScoreList = new List<PlayerStats>();

               // Boolean to track success of user insertion
                bool success = false;

                // Query string to check for specific user using prepared statement
                string queryString = "SELECT TOP 10 * FROM dbo.highScores WHERE difficulty = @Difficulty AND boardsize = @Boardsize ORDER BY timespan";

                // Set connection with connection string
                using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                // Set parameters for prepared statement
                command.Parameters.Add("@Difficulty", System.Data.SqlDbType.Int).Value = difficulty;

                command.Parameters.Add("@Boardsize", System.Data.SqlDbType.Int).Value = size;
                // Try to access database and retrieve results
                try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        // Check if query returned results. If yes, return true.
                        if (reader.HasRows)
                        {
                            success = true;
                            
                            while (reader.Read())
                            {
                            PlayerStats playerStats = new PlayerStats();
                            TimeSpan ts = new TimeSpan();
                            long timespan;
                            playerStats.PlayerInitials = reader["username"].ToString();
                            timespan = (long) reader["timespan"];
                            ts = TimeSpan.FromTicks(timespan);
                            playerStats.TimeSpanString = ts.ToString();
                            playerStats.time = ts;
                            playerStats.DifficultyLevel = (int) reader["difficulty"];
                            playerStats.BoardSize = (int)reader["boardsize"];
                            highScoreList.Add(playerStats);
                            }
                        }

                        reader.Close();
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message);
                    }

                }
            return highScoreList;
        }
    }
}
using MineSweeperClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

namespace Minesweeper.Services.Data
{
    // Class for handling HighScore CRUD interactions with SQL Server via DAO
    public class HighScoreDAO
    {
        // Add new high score to database.
        public void AddScore(PlayerStats playerStats)
        {
            // Get userID for logged in user and get game time as ticks
            int userID = int.Parse((String)HttpContext.Current.Session["UserId"]);
            long timeSpanTicks = playerStats.Time.Ticks;

            // Query string to insert new high score into database using prepared statement
            string queryString = "INSERT INTO highScores VALUES(@UserID, @Timespan, @Difficulty, @BoardSize, @Username)";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Add high score data to INSERT statement
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@Timespan", timeSpanTicks);
                command.Parameters.AddWithValue("@Difficulty", playerStats.DifficultyLevel);
                command.Parameters.AddWithValue("@BoardSize", playerStats.BoardSize);
                command.Parameters.AddWithValue("@Username", playerStats.PlayerInitials);

                // Try to access database and insert score
                try
                {
                    connection.Open();

                    // Returns number of rows affected
                    int test = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
        }

        // Retrieve top 10 scores for current board size and difficulty setting
        public List<PlayerStats> GetTopTenScores(int size, double difficulty)
        {
            // List to hold results
            List<PlayerStats> highScoreList = new List<PlayerStats>();

            // Query string to retrieve top 10 scores using prepared statement
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

                    // Check if query returned results. If results add to highScoreList
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Get time as ticks from database and convert to timespan
                            TimeSpan ts = new TimeSpan();
                            long timespan;
                            timespan = (long)reader["timespan"];
                            ts = TimeSpan.FromTicks(timespan);

                            // Create PlayerStats instance and populate
                            PlayerStats playerStats = new PlayerStats
                            {
                                TimeSpanString = ts.ToString(),
                                Time = ts,
                                PlayerInitials = reader["username"].ToString(),
                                DifficultyLevel = (int)reader["difficulty"],
                                BoardSize = (int)reader["boardsize"]
                            };

                            // Add PlayerStats to highScoreList
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

        // Retrieve high scores by user id
        public List<PlayerStats> GetScoresForUser(int userId)
        {
            // List to hold results
            List<PlayerStats> scores = new List<PlayerStats>();

            string queryString = "SELECT * FROM dbo.highScores WHERE \"user\" = @userId";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Set parameters for prepared statement
                command.Parameters.Add("@userId", System.Data.SqlDbType.Int).Value = userId;

                // Try to access database and retrieve results
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if query returned results. If results add to highScoreList
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Get time as ticks from database and convert to timespan
                            TimeSpan ts = new TimeSpan();
                            long timespan;
                            timespan = (long)reader["timespan"];
                            ts = TimeSpan.FromTicks(timespan);

                            // Create PlayerStats instance and populate
                            PlayerStats playerStats = new PlayerStats
                            {
                                TimeSpanString = ts.ToString(),
                                Time = ts,
                                PlayerInitials = reader["username"].ToString(),
                                DifficultyLevel = (int)reader["difficulty"],
                                BoardSize = (int)reader["boardsize"]
                            };

                            // Add PlayerStats to highScoreList
                            scores.Add(playerStats);
                        }
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            return scores;
        }

        // Retrieve high scores by username
        public List<PlayerStats> GetScoresByUsername(string username)
        {
            // List to hold results
            List<PlayerStats> scores = new List<PlayerStats>();

            string queryString = "SELECT * FROM dbo.highScores WHERE username LIKE @Username";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Set parameters for prepared statement
                command.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 50).Value = username;

                // Try to access database and retrieve results
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if query returned results. If results add to highScoreList
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Get time as ticks from database and convert to timespan
                            TimeSpan ts = new TimeSpan();
                            long timespan;
                            timespan = (long)reader["timespan"];
                            ts = TimeSpan.FromTicks(timespan);

                            // Create PlayerStats instance and populate
                            PlayerStats playerStats = new PlayerStats
                            {
                                TimeSpanString = ts.ToString(),
                                Time = ts,
                                PlayerInitials = reader["username"].ToString(),
                                DifficultyLevel = (int)reader["difficulty"],
                                BoardSize = (int)reader["boardsize"]
                            };

                            // Add PlayerStats to highScoreList
                            scores.Add(playerStats);
                        }
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            return scores;
        }
    }
}
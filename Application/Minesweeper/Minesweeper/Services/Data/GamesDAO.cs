using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Minesweeper.Services.Data
{
    // Class for handling all CRUD actions related to game data
    public class GamesDAO
    {
        // Save a game. Requires GameData object as argument
        public bool SaveGame(GameData gameData)
        {
            bool GameSaved;

            // Check if save exists for current player in current board size and difficulty
            // If save exists in database, update it. If no existing save, create new one.
            if (LookForSave(gameData.Size, gameData.Difficulty))
            {
                GameSaved = UpdateSaveGame(gameData);
            }
            else
            {
                GameSaved = SaveNewGame(gameData);
            }

            return GameSaved;
        }

        // Method to save a game. Takes GameData object as an argument
         public bool SaveNewGame(GameData gameData)
        {
            bool success = false;

            // Query string to insert save game data into database using prepared statement
            string queryString = "INSERT INTO savedGames VALUES(@UserID, @Turns, @Size, @Difficulty, @Timer, @JSONData)";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Add current game data to INSERT statement
                command.Parameters.AddWithValue("@UserID", gameData.UserId);
                command.Parameters.AddWithValue("@Turns", gameData.Turns);
                command.Parameters.AddWithValue("@Size", gameData.Size);
                command.Parameters.AddWithValue("@Difficulty", gameData.Difficulty);
                command.Parameters.AddWithValue("@Timer", gameData.Timer);
                command.Parameters.AddWithValue("@JSONData", gameData.JSONData);

                // Try to access database and insert saved game
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
            return success;
        }

        // Method to update an existing save game with new one. Takes GameData object as arugment
        public bool UpdateSaveGame(GameData gameData)
        {
            bool success = false;

            // Query string to update saved games in database using prepared statement
            string queryString = "UPDATE dbo.savedGames SET turns = @Turns, timer = @Timer, jsonData = @JSONData WHERE userid = @UserId AND size = @Size AND difficulty = @Difficulty";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Add game data to INSERT statement
                command.Parameters.AddWithValue("@UserID", gameData.UserId);
                command.Parameters.AddWithValue("@Turns", gameData.Turns);
                command.Parameters.AddWithValue("@Size", gameData.Size);
                command.Parameters.AddWithValue("@Difficulty", gameData.Difficulty);
                command.Parameters.AddWithValue("@Timer", gameData.Timer);
                command.Parameters.AddWithValue("@JSONData", gameData.JSONData);

                // Try to access database and update save game
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
            return success;
        }

        // Method to check if a saved game already exists for current player in current board size
        // and current difficulty. Returns a true or false if found.
        public bool LookForSave(int size, double difficulty)
        {
            bool exists = false;

            // Get current user's ID
            int userID = int.Parse((String)HttpContext.Current.Session["UserId"]);

            // Query string to check for current user's saved games using prepared statement
            string queryString = "SELECT * FROM dbo.savedGames WHERE userid = @UserId AND size = @Size AND difficulty = @Difficulty";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Set parameters for prepared statement
                command.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = userID;
                command.Parameters.Add("@Size", System.Data.SqlDbType.Int).Value = size;
                command.Parameters.Add("@Difficulty", System.Data.SqlDbType.Int).Value = difficulty;

                // Try to access database and retrieve results
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if query returned results. If yes, return true.
                    if (reader.HasRows)
                    {
                        exists = true;
                    }

                    reader.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }

            }
            return exists;
        }

        // Method to retrieve a saved game from the database. Takes current board size and difficulty as arguments.
        public GameData LoadGame(int size, double difficulty)
        {
            int userID = int.Parse((String)HttpContext.Current.Session["UserId"]);

            // GameData class to hold results
            GameData gameData = new GameData();

            // Query string to check for current user's saved games using prepared statement
            string queryString = "SELECT * FROM dbo.savedGames WHERE userid = @UserId AND size = @Size AND difficulty = @Difficulty";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Set parameters for prepared statement
                command.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = userID;
                command.Parameters.Add("@Size", System.Data.SqlDbType.Int).Value = size;
                command.Parameters.Add("@Difficulty", System.Data.SqlDbType.Int).Value = difficulty;

                // Try to access database and retrieve results
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if query returned results.
                    while (reader.Read())
                    {      
                        // Load results into GameData object
                        gameData.UserId = (int)reader["userid"];
                        gameData.Size = (int)reader["size"];
                        gameData.Difficulty = (int)reader["difficulty"];
                        gameData.Timer = (int)reader["timer"];
                        gameData.Turns = (int)reader["turns"];
                        gameData.JSONData = (string)reader["jsonData"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }

            }
            // Return results
            return gameData;
        }
    }
}
using Minesweeper.Models;
using Minesweeper.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Services.Business
{
    // Service for registering a user
    public class RegistrationService
    {
        // Method to register a user
        public bool RegisterUser(UserModel user)
        {
            // Data service for adding user to database
            UserDAO userDAO = new UserDAO();

            // Add user to database. Return true for success, false for failure
            return userDAO.AddUser(user);
        }
    }
}
using Minesweeper.Models;
using Minesweeper.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Services.Business
{
    public class SecurityService
    {
        // Check database for authorized user
        public bool Authenticate(LoginModel user)
        {
            // Data service for user validation
            SecurityDAO securityDAO = new SecurityDAO();

            // Find user in database return true for success, false for negative
            return securityDAO.FindByUser(user);
        }
    }
}
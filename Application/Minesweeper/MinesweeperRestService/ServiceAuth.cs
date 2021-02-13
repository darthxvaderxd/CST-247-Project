using Minesweeper.Models;
using Minesweeper.Services.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;

namespace MinesweeperRestService
{
    public class ServiceAuth : UserNamePasswordValidator
    {
        public override void Validate(string username, string password)
        {
            System.Diagnostics.Debug.Write("username => " + username + " password => " + password);
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username or Password is empty");
            }

            SecurityDAO service = new SecurityDAO();
            LoginModel user = new LoginModel
            {
                Username = username,
                Password = password
            };
            if (!service.FindByUser(user))
            {
                throw new SecurityTokenException("unknown user");
            }
        }
    }
}
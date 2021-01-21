using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Services
{
    public static class GlobalVAR
    {
        public const string CONNECTIONSTRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Minesweeper;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
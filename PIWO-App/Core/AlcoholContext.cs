using PIWO_Core;
using PIWO_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIWO_App.Core
{
    internal class AlcoholContext
    {
        private static IAlcoholContext alcohol;
        private static bool isReady;

        private AlcoholContext() { }

        public static IAlcoholContext GetAlcohol()
        {
            if (alcohol == null)
                throw new Exception("Ne bangla");
            return alcohol;
        }

        public static IAlcoholContext CreateContext(string login, string password, string server, string dbName, string port)
        {
            alcohol = Api.CreateDbManager().ConnectToPostgreSqlDatabase(login, password, server, port, dbName, true);
            isReady = true;
            return alcohol;
        }

        public bool IsReady { get { return isReady; } }
    }
}

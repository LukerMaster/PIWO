using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIWO_Core;
using PIWO_Core.Interfaces;

namespace PIWO_App.Core
{
    internal class DatabaseConnector
    {
        private static IDbManager dbManager;
        private DatabaseConnector()
        {

        }
        public static IDbManager GetInstance()
        {
            if (dbManager == null)
                 dbManager = Api.CreateDbManager();
            return dbManager;
        }

        

    }
}

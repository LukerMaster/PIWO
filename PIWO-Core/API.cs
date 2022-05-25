using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIWO_Core.Database;
using PIWO_Core.Interfaces;

namespace PIWO_Core
{
    public class API
    {
        /// <summary>
        /// Creates a new instance of database manager.
        /// </summary>
        public static IDbManager CreateDbManager()
        {
            return new DbManager();
        }

        internal static IAlcoholContext MakeAlcoholContext(string ConnectionString)
        {
            return new AlcoholContext(ConnectionString);
        }
    }
}

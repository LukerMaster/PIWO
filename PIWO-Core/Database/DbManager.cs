using Microsoft.EntityFrameworkCore;
using PIWO_Core.Interfaces;

namespace PIWO_Core.Database
{
    internal class DbManager : IDbManager
    {
        private IAlcoholContext? _dbContext;

        private void CreateOrConnectToDb(string connectionString, bool createIfNonexistent = false)
        {
            _dbContext = Api.MakeAlcoholContext(connectionString);
            if (createIfNonexistent)
                _dbContext.Database.EnsureCreated();

            if (!_dbContext.Database.CanConnect())
                throw new Exception(
                    $"Cannot connect to the database - Connection string given: {_dbContext.Database.GetConnectionString()}");
        }

        public IAlcoholContext CreateAlcoholsDatabase(string connectionString)
        {
            CreateOrConnectToDb(connectionString, true);
            return _dbContext;
        }

        public IAlcoholContext ConnectToDatabase(string connectionString)
        {
            CreateOrConnectToDb(connectionString, false);
            return _dbContext;
        }

        /// <summary>
        /// Connects to the PostgreSql database using provided credentials.
        /// </summary>
        /// <param name="login">Login of the database user</param>
        /// <param name="password">Password of the database user</param>
        /// <param name="server">Address of the database</param>
        /// <param name="port">Port of the database</param>
        /// <param name="dbName">Name of the database to connect to</param>
        /// <param name="createIfNonexistent">If you want to create the database if current one does not exist (Does nothing if database exists).</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IAlcoholContext ConnectToPostgreSqlDatabase(string login, string password, string server, string port, string dbName, bool createIfNonexistent = false)
        {
            var connectionString = $"User ID={login};Password={password};Host={server};Port={port};Database={dbName};";

            if (createIfNonexistent)
                CreateAlcoholsDatabase(connectionString);
            else
                ConnectToDatabase(connectionString);

            
            return _dbContext;
        }
    }
}
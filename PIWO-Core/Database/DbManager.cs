using PIWO_Core.Interfaces;

namespace PIWO_Core.Database
{
    internal class DbManager : IDbManager
    {
        private IAlcoholContext? _dbContext;
        public IAlcoholContext CreateAlcoholsDatabase(string connectionString)
        {
            _dbContext = Api.MakeAlcoholContext(connectionString);
            _dbContext.Database.EnsureCreated();
            return _dbContext;
        }

        public IAlcoholContext ConnectToDatabase(string connectionString)
        {
            _dbContext = Api.MakeAlcoholContext(connectionString);
            return _dbContext;
        }
    }
}
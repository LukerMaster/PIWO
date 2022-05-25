using PIWO_Core.Interfaces;

namespace PIWO_Core.Database
{
    internal class DbManager : IDbManager
    {
        private IAlcoholContext? _dbContext;
        public IAlcoholContext CreateAlcoholsDatabase(string ConnectionString)
        {
            _dbContext = Api.MakeAlcoholContext(ConnectionString);
            _dbContext.Database.EnsureCreated();
            return _dbContext;
        }

        public IAlcoholContext ConnectToDatabase(string ConnectionString)
        {
            _dbContext = Api.MakeAlcoholContext(ConnectionString);
            return _dbContext;
        }
    }
}
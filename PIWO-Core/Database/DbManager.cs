using PIWO_Core.Interfaces;

namespace PIWO_Core.Database
{
    internal class DbManager : IDbManager
    {
        private IAlcoholContext _dbContext;
        public IAlcoholContext CreateAlcoholsDatabase(string ConnectionString)
        {
            _dbContext = API.MakeAlcoholContext(ConnectionString);
            _dbContext.Database.EnsureCreated();
            return _dbContext;
        }
    }
}
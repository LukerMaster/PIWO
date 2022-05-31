namespace PIWO_Core.Interfaces
{
    /// <summary>
    /// Interface that allows for creation and managing of database
    /// context.
    /// </summary>
    public interface IDbManager
    {
        public IAlcoholContext CreateAlcoholsDatabase(string connectionString);
        public IAlcoholContext ConnectToDatabase(string connectionString);
        public IAlcoholContext ConnectToPostgreSqlDatabase(string login, string password, string server, string port, string dbName, bool createIfNonexistent = false);
    }
}

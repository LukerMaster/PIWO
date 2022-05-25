namespace PIWO_Core.Interfaces
{
    /// <summary>
    /// Interface that allows for creation and managing of new
    /// context.
    /// </summary>
    public interface IDbManager
    {
        public IAlcoholContext CreateAlcoholsDatabase(string ConnectionString);
        public IAlcoholContext ConnectToDatabase(string ConnectionString);
    }
}

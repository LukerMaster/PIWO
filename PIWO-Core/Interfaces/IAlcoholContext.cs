using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PIWO_Core.Database.Entities;

namespace PIWO_Core.Interfaces
{
    /// <summary>
    /// Provides access to tables in the database.
    /// </summary>
    public interface IAlcoholContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Alcohol> Alcohols { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        internal DatabaseFacade Database { get; }
        /// <summary>
        /// Closes the connection to the database. Does not save changes.
        /// </summary>
        public void CloseConnection();
        /// <summary>
        /// Saves the changes made locally to objects.
        /// </summary>
        /// <returns>Number of rows affected in the database.</returns>
        public int SaveChanges();
    }
}

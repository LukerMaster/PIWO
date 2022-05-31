using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PIWO_Core.Database.Entities;
using PIWO_Core.Interfaces;

namespace PIWO_Core.Database
{
    internal class AlcoholContext : DbContext, IAlcoholContext
    {
        internal AlcoholContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
        DatabaseFacade IAlcoholContext.Database => Database;
        public void CloseConnection()
        {
            Dispose();
        }
        public string ConnectionString { private set; get; } = String.Empty;
        public DbSet<City> Cities { get; set; }
        public DbSet<Alcohol> Alcohols { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<AlcoholType> AlcoholTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseNpgsql(ConnectionString);
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Alcohol>()
                .Property(e => e.TypeId)
                .HasConversion<int>();

            builder
                .Entity<AlcoholType>()
                .Property(e => e.Id)
                .HasConversion<int>();

            builder.Entity<AlcoholType>().HasData(Enum.GetValues(typeof(AlcoholTypeId))
                .Cast<AlcoholTypeId>()
                .Select(e => new AlcoholType()
                {
                    Id = e,
                    Name = e.ToString()
                }));
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void CloseConnection();
        public int SaveChanges();
    }
}

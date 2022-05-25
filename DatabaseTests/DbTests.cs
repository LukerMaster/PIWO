using PIWO_Core.Database;
using PIWO_Core.Database.Entities;
using PIWO_Core.Interfaces;

namespace DatabaseTests
{
    public class Tests
    {
        public string ConnectionString = "User ID=PIWOAdmin;Password=PIWO;Host=localhost;Port=5432;Database=PiwoDb;";
        public IAlcoholContext Context;
        [SetUp]
        public void Setup()
        {
        }

        [OneTimeSetUp]
        public void CreateDb()
        {
            Context = PIWO_Core.API.CreateDbManager().CreateAlcoholsDatabase(ConnectionString);
        }

        [OneTimeTearDown]
        public void Disconnect()
        {
            Context.CloseConnection();
        }

        [Test]
        [Repeat(10)]
        [TestCase("Testowe PIWO", AlcoholTypeId.Beer, 4.5)]
        [TestCase("Testowa WÓDKA", AlcoholTypeId.Vodka, 40)]
        [TestCase("Testowy SPIRYTUS MMM", AlcoholTypeId.RectifiedSpirit, 95)]
        public void AddAlcohol(string name, AlcoholTypeId typeId, decimal voltage)
        {
            Context.Alcohols.Add(new Alcohol()
            {
                Name = name,
                TypeId = typeId,
                Voltage = (decimal)voltage,
            });
            Context.SaveChanges();
        }
    }
}
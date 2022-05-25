using Microsoft.EntityFrameworkCore;
using PIWO_Core;
using PIWO_Core.Database.Entities;

namespace DatabaseTests
{
    internal class FileTests
    {
        public string ConnectionString = "User ID=PIWOAdmin;Password=PIWO;Host=localhost;Port=5432;Database=PiwoDb;";


        [SetUp]
        public void Setup()
        {
        }

        [OneTimeSetUp]
        public void CreateDb()
        {
        }

        [OneTimeTearDown]
        public void Disconnect()
        {
            
        }

        [Test]
        public void SaveAlcoholsToFileXml()
        {
            DbSet<Alcohol> alcohols = Api.CreateDbManager().ConnectToDatabase(ConnectionString).Alcohols;
            Api.CreateFileManager(FileType.Xml).SaveToFile("tests_outAlcohols1.xml", alcohols);
        }
        
        [Test]
        public void ReadAlcoholsFromFileXml()
        {
            var context = Api.CreateDbManager().ConnectToDatabase(ConnectionString);

            DbSet<Alcohol> alcohols = context.Alcohols;
            
            foreach (var alcohol in alcohols) alcohols.Remove(alcohol);
            Api.CreateFileManager(FileType.Xml).AddFromFile("tests_outAlcohols2.xml", alcohols);
            context.SaveChanges();
        }
        [Test]
        public void SaveAlcoholsToFileYaml()
        {
            DbSet<Alcohol> alcohols = Api.CreateDbManager().ConnectToDatabase(ConnectionString).Alcohols;
            Api.CreateFileManager(FileType.Yaml).SaveToFile("tests_outAlcohols.yaml", alcohols);
        }
        [Test]
        public void ReadAlcoholsFromFileYaml()
        {
            var context = Api.CreateDbManager().ConnectToDatabase(ConnectionString);

            DbSet<Alcohol> alcohols = context.Alcohols;

            foreach (var alcohol in alcohols) alcohols.Remove(alcohol);
            Api.CreateFileManager(FileType.Yaml).AddFromFile("tests_outAlcohols.yaml", alcohols);
            context.SaveChanges();
        }
    }
}

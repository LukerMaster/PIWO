using Microsoft.EntityFrameworkCore;
using PIWO_Core.Interfaces;
using YamlDotNet.Serialization;
namespace PIWO_Core.FileParsing
{
    internal class YamlFileManager : IFileManager
    {
        public void SaveToFile<T>(string filepath, DbSet<T> tableToSave) where T : class
        {
            Serializer serializer = new Serializer();

            List<T> dataToSave = new List<T>();
            foreach (var item in tableToSave)
                dataToSave.Add(item);

            string yaml = serializer.Serialize(dataToSave);
            File .WriteAllText(filepath, yaml);
        }

        public void AddFromFile<T>(string filepath, ref DbSet<T> table) where T : class
        {
            string yaml = File.ReadAllText(filepath);
            Deserializer deserializer = new Deserializer();
            List<T> items = (List<T>)deserializer.Deserialize(yaml, typeof(List<T>));
            table.AddRange(items);
        }
    }
}

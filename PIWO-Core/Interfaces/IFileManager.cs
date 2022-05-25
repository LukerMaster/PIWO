using Microsoft.EntityFrameworkCore;

namespace PIWO_Core.Interfaces
{
    /// <summary>
    /// Allows for serializing and deserializing of objects into different file types (XML, YAML etc.).
    /// </summary>
    public interface IFileManager
    {
        public void SaveToFile<T>(string filepath, DbSet<T> tableToSave) where T : class;

        public void AddFromFile<T>(string filepath, DbSet<T> tableToAddTo) where T : class;
    }
}

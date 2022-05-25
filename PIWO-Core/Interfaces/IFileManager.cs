using Microsoft.EntityFrameworkCore;

namespace PIWO_Core.Interfaces
{
    /// <summary>
    /// Allows for serializing and deserializing of objects into different file types.
    /// </summary>
    public interface IFileManager
    {

        public void SaveToFile<T>(string filepath, DbSet<T> tableToSave) where T : class;

        public void AddFromFile<T>(string filepath, ref DbSet<T> table) where T : class;
    }
}

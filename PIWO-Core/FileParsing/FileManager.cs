using System.Xml;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using PIWO_Core.Interfaces;

namespace PIWO_Core.FileParsing
{
    internal class FileManager : IFileManager
    {
        private IFileParsingStrategy _fileParsingStrategy;

        public FileManager(IFileParsingStrategy fileParsingStrategy)
        {
            _fileParsingStrategy = fileParsingStrategy;
        }

        public void SaveToFile<T>(string filepath, DbSet<T> tableToSave) where T : class
        {
            if (tableToSave == null) { throw new NullReferenceException("Table given for serialization is null."); }

            List<T> dataToSave = new List<T>();

            foreach (T item in tableToSave)
                dataToSave.Add(item);

            _fileParsingStrategy.Save(filepath, dataToSave);
                
        }

        public void AddFromFile<T>(string filepath, DbSet<T> tableToAddTo) where T: class
        {
            if (tableToAddTo == null) { throw new NullReferenceException("Table given for deserialization is null."); }
            if (!File.Exists(filepath)) throw new Exception("File to read " + filepath + " does not exist.");

            List<T> objectsToGet = _fileParsingStrategy.Load<T>(filepath);

            tableToAddTo.AddRange(objectsToGet);
        }
    }
}

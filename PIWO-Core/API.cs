using PIWO_Core.Database;
using PIWO_Core.FileParsing;
using PIWO_Core.Interfaces;

namespace PIWO_Core
{
    public enum FileType
    {
        Xml, Yaml
    }

    public class Api
    {
        /// <summary>
        /// Creates a new instance of database manager.
        /// </summary>
        public static IDbManager CreateDbManager()
        {
            return new DbManager();
        }

        public static IFileManager CreateFileManager(FileType type)
        {
            switch (type)
            {
                case FileType.Xml:
                    return new XmlFileManager();
                case FileType.Yaml:
                    return new YamlFileManager();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        internal static IAlcoholContext MakeAlcoholContext(string connectionString)
        {
            return new AlcoholContext(connectionString);
        }
    }
}

using PIWO_Core.Database;
using PIWO_Core.FileParsing;
using PIWO_Core.FileParsing.Strategies;
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

        /// <summary>
        ///  Creates a new instance of file manager.
        /// </summary>
        /// <param name="type">The type of file manager to use.</param>
        /// <returns>New file manager</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws when given wrong type of manager</exception>
        public static IFileManager CreateFileManager(FileType type)
        {
            switch (type)
            { // SUS. Maybe spring isn't that bad of an idea afterall...? :thonk:
                case FileType.Xml:
                    return new FileManager(new XmlFileStrategy());
                case FileType.Yaml:
                    return new FileManager(new YamlFileStategy());
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Wrong type of file manager given to creating method.");
            }
        }

        internal static IAlcoholContext MakeAlcoholContext(string connectionString)
        {
            return new AlcoholContext(connectionString);
        }
    }
}

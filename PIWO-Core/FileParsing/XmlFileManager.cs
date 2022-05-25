using System.Xml;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using PIWO_Core.Interfaces;

namespace PIWO_Core.FileParsing
{
    internal class XmlFileManager : IFileManager
    {
        public void SaveToFile<T>(string filepath, DbSet<T> tableToSave) where T : class
        {
            if (tableToSave == null) { return; }

            List<T> stuffToSave = new List<T>();

            foreach (T item in tableToSave)
            {
                stuffToSave.Add(item);
            }

            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(stuffToSave.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, stuffToSave);
                stream.Position = 0;
                xmlDocument.Load(stream);
                xmlDocument.Save(filepath);
                stream.Close();
            }
        }

        public void AddFromFile<T>(string filepath, ref DbSet<T> table) where T: class
        {

            List<T> objectsToGet = new List<T>();

            if (!System.IO.File.Exists(filepath)) throw new Exception("File to read " + filepath + " does not exist.");
            
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filepath);
            string xmlString = xmlDocument.OuterXml;

            using (StringReader read = new StringReader(xmlString))
            {
                Type outType = typeof(List<T>);

                XmlSerializer serializer = new XmlSerializer(outType);
                using (XmlReader reader = new XmlTextReader(read))
                {
                    objectsToGet = (List<T>)serializer.Deserialize(reader);
                    reader.Close();
                }

                read.Close();
            }
            table.AddRange(objectsToGet);
        }
    }
}

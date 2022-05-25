using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PIWO_Core.FileParsing.Strategies
{
    internal class XmlFileStrategy : IFileParsingStrategy
    {
        public void Save<T>(string path, List<T> objectsToSave)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(objectsToSave.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, objectsToSave);
                stream.Position = 0;
                xmlDocument.Load(stream);
                xmlDocument.Save(path);
                stream.Close();
            }
        }

        public List<T> Load<T>(string path)
        {
            List<T> itemsRead = new List<T>();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            string xmlString = xmlDocument.OuterXml;

            using (StringReader read = new StringReader(xmlString))
            {
                Type outType = typeof(List<T>);

                XmlSerializer serializer = new XmlSerializer(outType);
                using (XmlReader reader = new XmlTextReader(read))
                {
                    itemsRead = (List<T>)serializer.Deserialize(reader);
                    reader.Close();
                }

                read.Close();
            }

            return itemsRead;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace PIWO_Core.FileParsing.Strategies
{
    internal class YamlFileStategy : IFileParsingStrategy
    {
        public void Save<T>(string path, List<T> objectsToSave)
        {
            Serializer serializer = new Serializer();
            string yaml = serializer.Serialize(objectsToSave);
            File.WriteAllText(path, yaml);
        }

        public List<T> Load<T>(string path)
        {
            string yaml = File.ReadAllText(path);
            Deserializer deserializer = new Deserializer();
            return (List<T>)deserializer.Deserialize(yaml, typeof(List<T>));
        }
    }
}

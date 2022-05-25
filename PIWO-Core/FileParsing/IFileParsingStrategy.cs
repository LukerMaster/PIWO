using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIWO_Core.FileParsing
{
    internal interface IFileParsingStrategy
    {
        public void Save<T>(string path, List<T> objectsToSave);
        public List<T> Load<T>(string path);
    }
}

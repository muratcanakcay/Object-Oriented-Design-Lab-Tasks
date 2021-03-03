using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace Xml.Console
{
    public static class LibraryReader
    {
        public static Library.library ReadLibrary(string path)
        {
            var serializer = new XmlSerializer(typeof(Library.library));
            return (Library.library)serializer.Deserialize(new FileStream(path, FileMode.Open, FileAccess.Read));
        }
    }
}

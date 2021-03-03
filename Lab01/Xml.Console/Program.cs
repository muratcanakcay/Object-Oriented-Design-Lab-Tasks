using System.IO;
using System.Linq;


namespace Xml.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var libraryPath = Path.Combine(Directory.GetCurrentDirectory(), "library.xml");
            var library = LibraryReader.ReadLibrary(libraryPath);

            var authors = library.books.SelectMany(l => l.authors);

            foreach (var author in authors)
            {
                System.Console.WriteLine($"Author: {string.Join(",", author.names.ToArray())}, {author.surname}");
            }
        }
    }
}

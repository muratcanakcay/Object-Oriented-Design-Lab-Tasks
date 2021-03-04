using System.IO;
using System.Linq;
using System.Xml;

namespace Xml.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var libraryPath = Path.Combine(Directory.GetCurrentDirectory(), "library.xml");
            
            // --------- Lab01

            var library = LibraryReader.ReadLibrary1(libraryPath);
            var authors1 = library.books.SelectMany(b => b.authors);

            foreach (var author in authors1)
            {
                System.Console.WriteLine($"Author: {string.Join(",", author.names.ToArray())}, {author.surname}");
            }

            System.Console.WriteLine("---------------------------");
            
            // ---------- Lab02
            
            //var authors2 = LibraryReader.ReadLibrary2(libraryPath);
            //foreach (var author in authors2)
            //{
            //    System.Console.WriteLine($"Author: {author}");
            //}



            // ---------------





        }
    }
}

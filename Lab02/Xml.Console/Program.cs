using System.IO;
using System.Linq;
using System.Xml;
using System.Collections.Generic;

namespace Xml.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var libraryPath = Path.Combine(Directory.GetCurrentDirectory(), "library.xml");
            
            // --------- Lab01

            var library = LibraryReader.ReadLibrary1(libraryPath);
            
            // 1st Method 
            var authors11 = new List<Library.authorType>();
            foreach (var book in library.books)
                foreach (var author in book.authors)
                {
                    // directly write to console:
                    // System.Console.WriteLine($"Author: {string.Join(",", author.names.ToArray())}, {author.surname}"); 
                    
                    // or add to a list for future use:
                    authors11.Add(author);
                }

            foreach (var author in authors11)
            {
                System.Console.WriteLine($"Author: {string.Join(",", author.names.ToArray())}, {author.surname}");
            }
            
            System.Console.WriteLine("---------------------------");

            // 2nd method 
            var authors12 = library.books.SelectMany(b => b.authors);
            foreach (var author in authors12)
            {
                System.Console.WriteLine($"Author: {string.Join(",", author.names.ToArray())}, {author.surname}");
            }

            System.Console.WriteLine("---------------------------");

            // ---------- Lab02

            var authorSurnames = LibraryReader.ReadLibrary2(libraryPath);
            foreach (var surname in authorSurnames)
            {
                System.Console.WriteLine($"Author: {surname}");
            }

            // ---------------

        }
    }
}

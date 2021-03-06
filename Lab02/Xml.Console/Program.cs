using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Xml.Console
{
    using static System.Console;
    
    class Program
    {
        static void Main(string[] args)
        {
            //---We can create the libraryPath string in multiple ways: 
            
            //---1 
            string libraryPath = Directory.GetCurrentDirectory() + "\\library.xml";
            
            //---2
            //var libraryPath = string.Join("\\", new string[] { Directory.GetCurrentDirectory(), "library.xml" });
            
            //---3 
            //var libraryPath = Path.Combine(Directory.GetCurrentDirectory(), "library.xml"); // using system.IO
            
            //---4
            //var sb = new StringBuilder(); // using System.Text
            //sb.Append(Directory.GetCurrentDirectory()).Append("\\library.xml");
            //var libraryPath = sb.ToString();

            WriteLine($"library path is = {libraryPath}");

            // ---------

            var library = LibraryReader.ReadLibrary(libraryPath);
            if (library == null) return;

            //---------- matching key - ref using List<>
            
            var refs = new List<string>();
            foreach (var book in library.books)
                foreach (var author in book.authors)
                    refs.Add(author.@ref);
            
            WriteLine("---------------------------");
            WriteLine("\nAuthors in the library (using id-ref matching):");
            
            foreach (var r in refs.Distinct())
                foreach (var author in library.authors)
                {
                    if (r == author.id)
                        WriteLine($"Author with id:{r} is {string.Join(", ", author.names.ToArray())}, {author.surname}");
                }
            //----------- matching key - ref using Dictionary<>

            var authors = new Dictionary<string, Library.authorType>();
            foreach (var author in library.authors)
                authors.Add(author.id, author);
            
            WriteLine("---------------------------");
            WriteLine("\nAuthors in the library (using dictionary):");
            
            foreach (var r in refs.Distinct())
                WriteLine($"Author with id:{r} is {string.Join(", ", authors[r].names.ToArray())}, {authors[r].surname}");

            WriteLine("---------------------------");
            

                    
              
        }


    
    }
}

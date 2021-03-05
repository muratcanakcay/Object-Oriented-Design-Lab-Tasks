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
            int labNo = 1; // choose which lab task to execute

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
            
            switch (labNo)
            { 
            case 1:
            {         
                // --------- Lab01

                var library = LibraryReader.ReadLibrary1(libraryPath);
            
                // 1st Method 
                var authors11 = new List<Library.authorsTypeAuthor>();
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
                    WriteLine($"Author: {string.Join(",", author.names.ToArray())}, {author.surname}");
                }
            
                WriteLine("---------------------------");

                // 2nd method (using SelectMany() method)
                var authors12 = library.books.SelectMany(b => b.authors);
                foreach (var author in authors12)
                {
                    WriteLine($"Author: {string.Join(",", author.names.ToArray())}, {author.surname}");
                }

                WriteLine("---------------------------");
            
                break;
            } // end case 1
            case 2:

            {
                // ---------- Lab02

                var authorSurnames = LibraryReader.ReadLibrary2(libraryPath);
                foreach (var surname in authorSurnames)
                {
                    WriteLine($"Author: {surname}");
                }

                break;
                // ---------------
            } // end case 2
            } // end switch
        }
    }
}

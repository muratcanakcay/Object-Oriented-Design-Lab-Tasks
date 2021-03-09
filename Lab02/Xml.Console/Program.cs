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

            // ---------

            var library = LibraryReader.ReadLibrary(libraryPath);
            if (library == null) return;

            WriteLine(library); // calls ToString() method of library class to print library contents

            WriteLine("---------------------------");

            // printing all of the authors that appear in the books in the library:

            // look up in each book to get the authors' ref's
            var refs = new List<string>();
            foreach (var book in library.books)
                foreach (var author in book.authors)
                    refs.Add(author.@ref);
            
            // parse all of the possible authors to get their id's
            var authors = new Dictionary<string, Library.authorType>();
            foreach (var author in library.authors)
                authors.Add(author.id, author);

            WriteLine("\nAll authors in the library:");
            foreach (var author in authors)
                WriteLine($"Author with id:{author.Key} is {author.Value.ToString()}");

            WriteLine("\nAuthors of the books in the library:");
            foreach (var r in refs.Distinct())
                WriteLine($"Author with id:{r} is {authors[r]}");

            WriteLine("---------------------------");


            // printing the oldest book in the library:

            Library.bookType oldestBook = library.books[0];
            foreach (var book in library.books)
            {
                if (int.Parse(book.year) < int.Parse(oldestBook.year)) oldestBook = book;
            }

            WriteLine($"The oldest book in the library is:");
            WriteLine($"Title: {oldestBook.title}");
            WriteLine($"Year: {oldestBook.year}");
            WriteLine($"Language: {oldestBook.lang}");
            WriteLine($"Authors:");
            foreach (var author in oldestBook.authors)
                WriteLine($"     {authors[author.@ref]}");
        }
    }
}

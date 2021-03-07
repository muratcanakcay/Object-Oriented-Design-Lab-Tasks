using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xml.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string libraryPath = Directory.GetCurrentDirectory() + "\\library2.xml";  //   c:prog\code\ood     +     \library2.xml
            
            var library = LibraryReader.ReadLibrary(libraryPath);
            if (library == null) return;

            var authors = new Dictionary<string, Library.libraryAuthor>();
            foreach (var author in library.authors)
                authors.Add(author.id, author);

            foreach (var book in library.books)
                foreach (var author in book.authors)
                    System.Console.WriteLine($"Author: {string.Join(",", authors[author.@ref].names.ToArray())}, {authors[author.@ref].surname}");   //  "john, bob, jane" + "surname"



        }
    }
}

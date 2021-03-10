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
            string libraryPath;

            if (args.Length == 0)
            {
                WriteLine("No cmd args");
                libraryPath = Directory.GetCurrentDirectory() + "\\food-example.xml";
            }
            else
            {
                WriteLine($"Cmd arg: {args[0]}");
                libraryPath = Directory.GetCurrentDirectory() + "\\" + args[0];
            }

            var goods = LibraryReader.ReadLibrary(libraryPath);
            if (goods == null) return;

            var additions = new Dictionary<string, Library.goodsAddition>();
            foreach (var addition in goods.additions)
                additions.Add(addition.id, addition);

            foreach (var item in goods.Items)
            {
                var sb = new StringBuilder();

                if (item is Library.goodsFood)
                {
                    var food = (Library.goodsFood)(item);
                    sb.Append("Food: ");
                    sb.Append(food.name + ", ");
                    sb.Append("List of additions: ");
                    foreach (var addition in food.addition)
                        sb.Append(additions[addition].name + ", ");

                    WriteLine(sb.ToString());
                }

                if (item is Library.goodsArticle)
                {
                    var article = (Library.goodsArticle)(item);
                    sb.Append("Article: ");
                    sb.Append(article.name + ", ");
                    sb.Append("List of additions: ");
                    foreach (var addition in article.addition)
                        sb.Append(additions[addition].name + ", ");

                    WriteLine(sb.ToString());
                }
            }
            
            
            /*
            
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



            */
        }
    }
}

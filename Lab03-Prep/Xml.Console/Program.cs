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

                if (item is Library.foodType)
                {
                    var food = (Library.foodType)(item);
                    sb.Append("Food: ");
                    sb.Append(food.name + ". ");
                    sb.Append("List of additions: ");
                    foreach (var addition in food.addition)
                        sb.Append(additions[addition].name + ", ");

                    WriteLine(sb.ToString());
                }

                if (item is Library.articleType)
                {
                    var article = (Library.articleType)(item);
                    sb.Append("Article: ");
                    sb.Append(article.name + ". ");
                    sb.Append("List of additions: ");
                    foreach (var addition in article.addition)
                        sb.Append(additions[addition].name + ", ");

                    WriteLine(sb.ToString());
                }
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var root2 = new DummyDirectory("root2");
            var d1 = new DummyDirectory("dir1", root2);
            var d2 = new DummyDirectory("dir2", root2);
            var f1 = new DummyFile("f1", "f1", root2);
            var f2 = new DummyFile("f2", "f2", d1);
            var d3 = new DummyDirectory("dir3", d1);
            var f3 = new DummyFile("f3", "f3", d2);
            var f4 = new DummyFile("f4", "f4", d2);
            var f5 = new DummyFile("f5", "f5", d3);
            var f6 = new DummyFile("f6", "f6", d3);

            var method2 = new FileSystemBfsIteratorFactory();
            var it2 = root2.GetIteratorFromFactory(method2);
            
            it2.Next();
            while (!it2.IsDone())
            {
                Console.WriteLine(it2.CurrentNode().GetPrintableName());
                it2.Next();
            }











            //------------------------------------
            
            var root = new DummyDirectory("root");

            var csProjects = new DummyDirectory("CSharpProjects", root);
            var csProject1 = new DummyDirectory("CSharpHelloWorld", csProjects);
            new DummyFile("HelloWorld.cs", "--C-o-n-sol--e-.-W---r-i-teLine-(---\"Hello, World!\");", csProject1);
            var csProject2 = new DummyDirectory("CSharpDE", csProjects);
            new DummyFile("HelloWorld.cs", "Console.WriteL----ine(\"Hallo, Welt!\");", csProject2);

            var pythonProjects = new DummyDirectory("python-projects", root);
            var pythonProject1 = new DummyDirectory("python-hw", pythonProjects);
            var pythonProject1Package = new DummyDirectory("hello_world", pythonProject1);
            new DummyFile("requirements.txt", "pyt---est", pythonProject1);
            new DummyFile("main.py", "prin---t('Hello W--orld!')", pythonProject1Package);

            var rustProjects = new DummyDirectory("rust", root);
            var rustProject1 = new DummyDirectory("hello-rust", rustProjects);
            var rustSrc = new DummyDirectory("src", rustProject1);
            new DummyFile("Cargo.toml", "[pac---kage]\nnam---e = \"hello-rust\"", rustProject1);
            new DummyFile("main.rs", "fn main() { pri--nt-l--n--!(\"Hello, student!\"); }", rustSrc);

            var dir1 = new DummyDirectory("very-important-documents", root);
            var dir2 = new DummyDirectory("homework", dir1);
            var dir3 = new DummyDirectory("DONTENTERHERE", dir2);
            var dir4 = new DummyDirectory("dangerous-zone", dir3);
            new DummyFile("cats.txt.cipher", "#9U9w9W---9-#-B-9G9---A-#-u-H-xuH9", dir4);

            Console.WriteLine("--------BFS--------");

            var method = new FileSystemBfsIteratorFactory();
            var it = root.GetIteratorFromFactory(method);

            it.Next();
            while (!it.IsDone())
            {
                Console.WriteLine(it.CurrentNode().GetPrintableName());
                it.Next();
            }



            // 1. Iterate over the dummy filesystem (strating from root) in BFS order
            // For each node please print its name and contents if it's available
            // 
            // var printableContent = node.GetPrintableContent();
            // if (printableContent != null)
            // {
            //     Console.WriteLine(printableContent);
            // }
            Console.WriteLine("-----------------");
            Console.WriteLine("--------DFS--------");
            // 2. Iterate over the dummy filesystem (strating from root) in DFS order
            // For each node please print its name and contents if it's available
            // 
            // var printableContent = node.GetPrintableContent();
            // if (printableContent != null)
            // {
            //     Console.WriteLine(printableContent);
            // }
            // Make sure that:
            // 1. Before each name print '|' and N times '-', where N is the depth of the file in the filesystem
            // (number of parents until null is reached)
            // 2. If node is not a directory, apply a transformation to its content which removes all hyphens ('-').
            // 3. If node is not a directory and its name doesn't end with ".cipher", append newline character to
            // its content ('\n').
            // 4. If node's name ends with ".cipher", in addition to all previous transformations, apply two more:
            //      - Reverse its content (character-wise, e.g. "asd" becomes "dsa")
            //      - Subtract 25 from each character in its content (cast char to int), e.g. 'z' - 25 = 'a'
            Console.WriteLine("-------------------");
            
        }
    }
}

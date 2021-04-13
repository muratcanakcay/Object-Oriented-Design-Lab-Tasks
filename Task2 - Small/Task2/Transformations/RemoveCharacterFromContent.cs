using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class RemoveCharacterFromContent : IFileSystemNode
    {
        public IFileSystemNode Node;
        private char c;

        public RemoveCharacterFromContent(IFileSystemNode node, char c)
        {
            this.Node = node;
            this.c = c;
        }

        public virtual string GetPrintableName()
        {
            return Node.GetPrintableName();
        }

        public virtual string GetPrintableContent()
        {
            if (!Node.IsDir())
            {
                string newContent = RemoveChar(Node.GetPrintableContent(), c);
                return newContent;
            } 
            else return Node.GetPrintableContent();
        }

        public IFileSystemNode GetParent()
        {
            return Node.GetParent();
        }

        public bool IsDir()
        {
            return Node.IsDir();
        }

        public override string ToString()
        {
            return GetPrintableName() + ", " + GetPrintableContent();
        }

        private string RemoveChar(string input, char c)
        {
            var n = input.Length;

            for (int i = 0; i < n; i++)
            {
                if (input[i].Equals(c))
                {
                    input = input.Remove(i--, 1);
                    n--;
                }
                
            }

            return input;

        }
        
        
        
    }
}





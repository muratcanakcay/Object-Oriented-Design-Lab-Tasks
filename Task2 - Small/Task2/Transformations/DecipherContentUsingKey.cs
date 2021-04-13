using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class DecipherContentUsingKey : IFileSystemNode
    {
        public IFileSystemNode Node;
        private int key;

        public DecipherContentUsingKey(IFileSystemNode node, int key)
        {
            this.Node = node;
            this.key = key;
        }

        public virtual string GetPrintableName()
        {
            return Node.GetPrintableName();
        }

        public virtual string GetPrintableContent()
        {
            if (!Node.IsDir())
            {
                string newContent = DecipherContent(Node.GetPrintableContent(), key);
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

        private string DecipherContent(string input, int key)
        {
            var n = input.Length;
            var sb = new StringBuilder();

            for (int i = n-1; i >= 0; i--)
            {
                char newChar = (char)(input[i] - key);
                sb.Append(newChar);
            }

            return sb.ToString();
        }



    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Transformation2 : ITransformation
    {
        private readonly System.Text.RegularExpressions.Regex rHyphens = new System.Text.RegularExpressions.Regex(@"-");
        public IFileSystemNode Node;

        public Transformation2(IFileSystemNode node)
        {
            this.Node = node;
        }

        public virtual string GetPrintableName()
        {
            return Node.GetPrintableName();
        }

        public virtual string GetPrintableContent()
        {
            if (!Node.IsDir())
            {
                string newContent = RemoveHyphens(Node.GetPrintableContent());
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

        private string RemoveHyphens(string input) { return rHyphens.Replace(input, ""); }
    }
}





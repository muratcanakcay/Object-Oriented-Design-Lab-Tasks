using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Item1 : ITransformation
    {
        public IFileSystemNode node;

        public Item1(IFileSystemNode node)
        {
            this.node = node;
        }

        public virtual string GetPrintableName()
        {
            var sb = new StringBuilder();
            sb.Append("|");
            var n = node;
            while (n.GetParent() != null)
            {
                sb.Append("-");
                n = n.GetParent();
            }
            return (sb + node.GetPrintableName());
        }

        public virtual string GetPrintableContent()
        {
            return node.GetPrintableContent();
        }

        public IFileSystemNode GetParent()
        {
            return node.GetParent();
        }

        public bool IsDir()
        {
            return node.IsDir();
        }

        public override string ToString()
        {
            return GetPrintableName() + ", " + GetPrintableContent();
        }
    }
}

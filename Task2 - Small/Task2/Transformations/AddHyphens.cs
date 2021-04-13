using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class AddHyphens : IFileSystemNode
    {
        public IFileSystemNode Node;

        public AddHyphens(IFileSystemNode node)
        {
            this.Node = node;
        }

        public virtual string GetPrintableName()
        {
            var sb = new StringBuilder();
            sb.Append("|");
            
            var n = Node;
            while (n.GetParent() != null)
            {
                sb.Append("-");
                n = n.GetParent();
            }
            
            return (sb + Node.GetPrintableName());
        }

        public virtual string GetPrintableContent()
        {
            return Node.GetPrintableContent();
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
    }
}
using System.Text;

namespace Task2
{
    public class AddHyphensBeforeFileName : Transformation
    {
        public AddHyphensBeforeFileName(IFileSystemNode node) : base(node) {}

        public override string GetPrintableName()
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
    }
}
using System.Text;

namespace Task2
{
    public class AddHyphens : Transformation
    {
        public AddHyphens(IFileSystemNode node) : base(node) {}

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
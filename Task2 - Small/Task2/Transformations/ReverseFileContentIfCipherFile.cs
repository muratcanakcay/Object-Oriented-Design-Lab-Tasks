using System.Text;

namespace Task2
{
    public class ReverseFileContentIfCipherFile : Transformation
    {
        public ReverseFileContentIfCipherFile(IFileSystemNode node) : base(node) {}

        public override string GetPrintableContent()
        {
            if (!Node.IsDir() && Node.GetPrintableName().EndsWith(".cipher"))
            {
                string newContent = Reverse(Node.GetPrintableContent());
                return newContent;
            }
            else return Node.GetPrintableContent();
        }

        private string Reverse(string input)
        {
            var n = input.Length;
            var sb = new StringBuilder();

            for (int i = n-1; i > 0; i--)
            {
                char newChar = input[i];
                sb.Append(newChar);
            }

            return sb.ToString();
        }
    }
}
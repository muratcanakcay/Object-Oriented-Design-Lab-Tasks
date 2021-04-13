using System.Text;

namespace Task2
{
    public class DecipherFileContentUsingKey : Transformation
    {
        private readonly int _key;

        public DecipherFileContentUsingKey(int key, IFileSystemNode node) : base(node)
        {
            this._key = key;
        }

        public override string GetPrintableContent()
        {
            if (!Node.IsDir() && Node.GetPrintableName().EndsWith(".cipher"))
            {
                string newContent = DecipherContent(Node.GetPrintableContent(), _key);
                return newContent;
            }
            else return Node.GetPrintableContent();
        }

        private string DecipherContent(string input, int key)
        {
            var n = input.Length;
            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                char newChar = (char)(input[i] - key);
                sb.Append(newChar);
            }

            return sb.ToString();
        }
    }
}
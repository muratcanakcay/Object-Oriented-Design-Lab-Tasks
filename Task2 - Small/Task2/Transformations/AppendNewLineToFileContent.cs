namespace Task2
{
    public class AppendNewLineToFileContent : Transformation
    {
        public AppendNewLineToFileContent(IFileSystemNode node) : base(node) {}

        public override string GetPrintableContent()
        {
            if (!Node.IsDir() && !Node.GetPrintableName().EndsWith(".cipher"))
            {
                return Node.GetPrintableContent() + "\n";
            }
            else return Node.GetPrintableContent();
        }
    }
}
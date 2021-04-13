namespace Task2
{
    public class AppendNewLineToFileContent : Transformation
    {
        public AppendNewLineToFileContent(IFileSystemNode node) : base(node) {}

        public override string GetPrintableContent()
        {
            if (!Node.IsDir())
            {
                return "\n" + Node.GetPrintableContent();
            }
            else return Node.GetPrintableContent();
        }
    }
}
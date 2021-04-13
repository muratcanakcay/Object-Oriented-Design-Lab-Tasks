namespace Task2
{
    public abstract class Transformation : IFileSystemNode
    {
        protected readonly IFileSystemNode Node;

        protected Transformation(IFileSystemNode node)
        {
            this.Node = node;
        }

        public virtual string GetPrintableName()
        {
            return Node.GetPrintableName();
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
    }
}
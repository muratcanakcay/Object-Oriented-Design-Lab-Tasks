namespace Task2
{

    public abstract class IteratorFactory // abstract class for different iteration types
    {
        public abstract IFileSystemIterator GetFileSystemIterator(DummyNode node);
    }
    
    public class BfsIteratorFactory : IteratorFactory // holds bfs iterators for different collection types
    {
        // returns bfs iterator for collections of FileSystem type
        public override IFileSystemIterator GetFileSystemIterator(DummyNode node)
        {
            return new FileSystemBfsExternalIterator(node);
        }
    }

    public class DfsIteratorFactory : IteratorFactory // holds dfs iterators for different collection types
    {
        // returns dfs iterator for collections of FileSystem type
        public override IFileSystemIterator GetFileSystemIterator(DummyNode node)
        {
            return new FileSystemDfsExternalIterator(node);
        }
    }
}

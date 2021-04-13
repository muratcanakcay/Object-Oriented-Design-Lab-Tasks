﻿namespace Task2
{

    public abstract class IteratorFactory // abstract class for different iteration types
    {
        public abstract IIterator GetFileSystemIterator(DummyNode node);
    }
    
    public class BfsIteratorFactory : IteratorFactory // holds bfs iterators for different collection types
    {
        public override IIterator GetFileSystemIterator(DummyNode node)
        {
            return new FileSystemBfsExternalIterator(node);
        }
    }

    public class DfsIteratorFactory : IteratorFactory // holds dfs iterators for different collection types
    {
        public override IIterator GetFileSystemIterator(DummyNode node)
        {
            return new FileSystemDfsExternalIterator(node);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{

    public abstract class FileSystemIteratorFactory
    {
        public abstract IFilesystemIterator GetIterator(DummyNode node);
    }
    
    public class FileSystemBfsIteratorFactory : FileSystemIteratorFactory
    {
        public override IFilesystemIterator GetIterator(DummyNode node)
        {
            return new FileSystemBfsExternalIterator(node);
        }
    }

    public class FileSystemDfsIteratorFactory : FileSystemIteratorFactory
    {
        public override IFilesystemIterator GetIterator(DummyNode node)
        {
            return new FileSystemDfsExternalIterator(node);
        }
    }
}

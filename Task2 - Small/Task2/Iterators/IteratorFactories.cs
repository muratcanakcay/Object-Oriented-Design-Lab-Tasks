using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{

    public interface IIteratorFactory
    {
        IFilesystemIterator GetIterator(DummyNode node);
    }
    
    public class FileSystemBfsIteratorFactory : IIteratorFactory
    {
        public IFilesystemIterator GetIterator(DummyNode node)
        {
            return new FileSystemBfsExternalIterator(node);
        }
    }

    public class FileSystemDfsIteratorFactory : IIteratorFactory
    {
        public IFilesystemIterator GetIterator(DummyNode node)
        {
            return new FileSystemBfsExternalIterator(node);
        }
    }
}

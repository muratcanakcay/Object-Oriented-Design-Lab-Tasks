using System.Collections.Generic;

namespace Task2
{
    public class FileSystemBfsExternalIterator : IFileSystemIterator
    {
        
        private DummyNode _currentNode;
        private readonly Queue<DummyNode> _queue = new Queue<DummyNode>();

        public FileSystemBfsExternalIterator(DummyNode node)
        { 
            _currentNode = node;
            _queue.Enqueue(node);
        }

        // returns current node and moves iterator to the next node
        public DummyNode Next()
        {
            if (_queue.Count == 0) return null;
            
            _currentNode = _queue.Dequeue(); 
            DummyNode n = _currentNode.FirstChild;

            while (n != null) 
            {
                _queue.Enqueue(n);
                n = n.Next;
            }

            return _currentNode;
        }
    }
}

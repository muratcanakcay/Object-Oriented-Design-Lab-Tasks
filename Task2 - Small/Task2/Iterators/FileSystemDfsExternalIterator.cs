using System.Collections.Generic;

namespace Task2
{
    public class FileSystemDfsExternalIterator : IFileSystemIterator
    {
        private DummyNode _currentNode;
        private readonly Stack<DummyNode> _mainStack = new Stack<DummyNode>();
        private readonly Stack<DummyNode> _helperStack = new Stack<DummyNode>();

        public FileSystemDfsExternalIterator(DummyNode node)
        {
            _currentNode = node;
            _mainStack.Push(node);
        }

        // returns current node and moves iterator to the next node
        public DummyNode Next()
        {
            if (_mainStack.Count == 0) return null; 
            
            _currentNode = _mainStack.Pop();
            DummyNode n = _currentNode.FirstChild;

            // using the helperStack to reverse the order of the children 
            // being added to the stack in order to start listing from 
            // the left branch of the tree.
            
            while (n != null)          
            {
                _helperStack.Push(n);
                n = n.Next;
            }
            
            while (_helperStack.TryPop(out n)) 
            {
                _mainStack.Push(n);
            }

            return _currentNode;
        }
    }
}
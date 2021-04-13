using System.Collections.Generic;

namespace Task2
{
    public class FileSystemBfsExternalIterator : IFileSystemIterator
    {
        
        private DummyNode currentNode;
        private Queue<DummyNode> queue = new Queue<DummyNode>();

        public FileSystemBfsExternalIterator(DummyNode node)
        { 
            this.currentNode = node;
            queue.Enqueue(node);
        }

        // returns current node and moves iterator to the next node
        public DummyNode Next()
        {
            if (queue.Count == 0) return null;
            
            currentNode = queue.Dequeue(); 
            DummyNode n = currentNode.FirstChild;

            while (n != null) 
            {
                queue.Enqueue(n);
                n = n.Next;
            }

            return currentNode;
        }
    }
}

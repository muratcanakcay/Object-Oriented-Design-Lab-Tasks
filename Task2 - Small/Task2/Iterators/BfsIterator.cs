using System;
using System.Collections.Generic;
using System.Text;
using System;

namespace Task2
{
    public class FileSystemBfsExternalIterator : IFilesystemIterator
    {
        
        private DummyNode currentNode;
        private Queue<DummyNode> queue = new Queue<DummyNode>();


        public FileSystemBfsExternalIterator(DummyNode node)
        { 
            this.currentNode = node;
            queue.Enqueue(node);
        }

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

using System;
using System.Collections.Generic;
using System.Text;
using System;

namespace Task2
{
    public class FileSystemDfsExternalIterator : IFilesystemIterator
    {

        private DummyNode currentNode;
        private Queue<DummyNode> queue = new Queue<DummyNode>();


        public FileSystemDfsExternalIterator(DummyNode node)
        {
            this.currentNode = node;
            queue.Enqueue(node);
        }

        public bool IsDone()
        {
            return queue.Count == 0;
        }

        public DummyNode CurrentNode()
        {
            return currentNode;
        }

        public void Next()
        {
            if (IsDone()) return;

            currentNode = queue.Dequeue();
            DummyNode n = currentNode.FirstChild;

            while (n != null)
            { 
                queue.Enqueue(n);
                if (n.FirstChild != null) n = n.FirstChild;
                else if (n.Next != null) n = n.Next;
            }
        }
    }
}
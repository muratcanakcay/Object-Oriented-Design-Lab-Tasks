using System.Collections.Generic;

namespace Task2
{
    public class FileSystemDfsExternalIterator : IIterator
    {

        private DummyNode currentNode;
        private Stack<DummyNode> mainStack = new Stack<DummyNode>();
        private Stack<DummyNode> helperStack = new Stack<DummyNode>();


        public FileSystemDfsExternalIterator(DummyNode node)
        {
            this.currentNode = node;
            mainStack.Push(node);
        }

        public DummyNode Next()
        {
            if (mainStack.Count == 0) return null; 
            
            currentNode = mainStack.Pop();
            DummyNode n = currentNode.FirstChild;

            while (n != null)
            {
                helperStack.Push(n);
                n = n.Next;
            }
            
            while (helperStack.TryPop(out n)) 
            {
                mainStack.Push(n);
            }

            return currentNode;
        }
    }
}
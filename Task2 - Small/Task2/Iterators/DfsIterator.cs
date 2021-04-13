using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.ComponentModel.Design;

namespace Task2
{
    public class FileSystemDfsExternalIterator : IFilesystemIterator
    {

        private DummyNode currentNode;
        private Stack<DummyNode> mainStack = new Stack<DummyNode>();
        private Stack<DummyNode> helperStack = new Stack<DummyNode>();


        public FileSystemDfsExternalIterator(DummyNode node)
        {
            this.currentNode = node;
            mainStack.Push(node);
        }

        public bool IsDone()
        {
            return mainStack.Count == 0;
        }

        public DummyNode CurrentNode()
        {
            return currentNode;
        }

        public void Next()
        {
            if (IsDone()) return;

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
        }
    }
}
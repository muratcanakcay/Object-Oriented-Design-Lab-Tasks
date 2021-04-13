using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public interface IFilesystemIterator
    {
        public bool IsDone();
        public DummyNode CurrentNode();
        public void Next();
    }
}

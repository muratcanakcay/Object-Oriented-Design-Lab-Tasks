using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public interface IDatabaseIterator // common interface for all database iterators
    {
        bool HasNext();
        void Next();
        object Current();
    }
}

using System;

namespace Task3.Decorators
{
    public class Filter : VirusDbIteratorDecorator
    {
        private readonly Func<VirusData, bool> _func;

        public Filter(Func<VirusData, bool> func, IVirusDatabaseIterator iterator) : base(iterator)
        {
            _func = func;
        }

        // HasNext() is the keypoint of the iterator. If Next() is called without checking HasNext() first the behaviour is undefined!
        public override bool HasNext()
        {
            while (_it.HasNext())
            {
                // iterate through the database until filter condition returns true
                _it.Next();
                if (!_func(_it.Current())) continue;
                
                // when filter condition returns true go back to the previous index and return true for HasNext()
                _it.Prev();
                return true;
            }

            // if filter condition  does not return true in any iteration in the database than HasNext() must return false
            return false;
        }
    }
}

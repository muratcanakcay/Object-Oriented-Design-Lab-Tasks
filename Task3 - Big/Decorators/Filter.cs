using System;

namespace Task3.Decorators
{
    public class Filter : Decorator
    {
        private readonly Func<VirusData, bool> _func;

        public Filter(IVirusDatabaseIterator iterator, Func<VirusData, bool> func) : base(iterator)
        {
            _func = func;
        }

        public override bool HasNext()
        {
            while (_it.HasNext())
            {
                _it.Next();
                if (!_func(_it.Current())) continue;
                
                _it.Prev();
                return true;
            }

            return false;
        }
    }
}

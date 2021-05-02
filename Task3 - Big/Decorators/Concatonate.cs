using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class Concatonate : Decorator
    {
        private readonly IVirusDatabaseIterator _it2;
        private bool _secondDatabase = false;

        public Concatonate(IVirusDatabaseIterator iterator2, IVirusDatabaseIterator iterator) : base(iterator)
        {
            _it2 = iterator2;
        }

        public override bool HasNext()
        {
            return base.HasNext() || _it2.HasNext(); 
        }

        public override void Next()
        {
            if (base.HasNext()) base.Next();
            else
            {
                _secondDatabase = true;
                _it2.Next();
            }
        }
        
        public override VirusData Current()
        {
            if (_secondDatabase) return _it2.Current();
            return _it.Current();
        }
    }
}

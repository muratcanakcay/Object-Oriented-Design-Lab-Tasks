using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class Concatonate : Decorator
    {
        private readonly IVirusDatabaseIterator _it2;
        private bool _secondDatabase = false;

        public Concatonate(IVirusDatabaseIterator iterator, IVirusDatabaseIterator iterator2) : base(iterator)
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
            base.Prev();
            if (base.HasNext())
            {
                base.Next();
                return base.Current();
            }
            else
            {
                base.Next();
                return null; // dummy. remove before proceeding
            }
        }
    }
}

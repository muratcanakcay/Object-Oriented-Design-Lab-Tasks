using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class Map : Decorator
    {
        private readonly Func<VirusData, VirusData> _func;

        public Map(Func<VirusData, VirusData> func, IVirusDatabaseIterator iterator) : base(iterator)
        {
            _func = func;
        }

        public override VirusData Current()
        {
            return _func(_it.Current());
        }
    }
}

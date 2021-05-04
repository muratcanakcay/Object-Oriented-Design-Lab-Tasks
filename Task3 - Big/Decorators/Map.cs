using System;

namespace Task3.Decorators
{
    public class Map : VirusDbIteratorDecorator
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

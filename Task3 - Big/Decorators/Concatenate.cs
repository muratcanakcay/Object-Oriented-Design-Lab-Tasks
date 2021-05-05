namespace Task3.Decorators
{
    public class Concatenate : VirusDbIteratorDecorator
    {
        private readonly IVirusDatabaseIterator _it2;
        private bool _secondDatabase = false;

        public Concatenate(IVirusDatabaseIterator iterator, IVirusDatabaseIterator iterator2) : base(iterator)
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
            return _secondDatabase ? _it2.Current() : _it.Current();
        }
    }
}

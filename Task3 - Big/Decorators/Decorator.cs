namespace Task3
{
    public abstract class Decorator : IVirusDatabaseIterator
    {
        protected readonly IVirusDatabaseIterator _it;
        
        protected Decorator(IVirusDatabaseIterator iterator)
        {
            _it = iterator;
        }

        public virtual bool HasNext()
        {
            return _it.HasNext();
        }

        public virtual void Prev() 
        {
            _it.Prev();
        }
        
        public virtual void Next()
        {
            _it.Next();
        }

        public virtual VirusData Current()
        {
            return _it.Current();
        }
    }
}
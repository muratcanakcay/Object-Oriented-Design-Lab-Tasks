namespace Task3.Decorators
{
    public abstract class Decorator : IVirusDatabaseIterator
    {
        protected readonly IVirusDatabaseIterator _it;
        
        protected Decorator(IVirusDatabaseIterator iterator)
        {
            _it = iterator;
        }

        // HasNext() is the keypoint of the iterator. If Next() is called without checking HasNext() first the behaviour is undefined!
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
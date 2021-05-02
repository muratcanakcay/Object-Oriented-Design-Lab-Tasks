namespace Task3
{
    // common interface for all database iterators
    public interface IDatabaseIterator 
    {
        bool HasNext();
        void Next();
        void Prev();
    }

    public interface IVirusDatabaseIterator : IDatabaseIterator
    {
        VirusData Current();
    }

    public interface IGenomeDatabaseIterator : IDatabaseIterator
    {
        GenomeData Current();
    }
}

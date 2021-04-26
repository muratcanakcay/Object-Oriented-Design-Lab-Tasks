namespace Task3
{
    public interface IDatabaseIterator // common interface for all database iterators
    {
        bool HasNext();
        void Next();
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

namespace Task3
{
    public interface IDatabaseIterable {} 

    public interface IVirusDatabaseIterable : IDatabaseIterable
    {
        IVirusDatabaseIterator GetIterator(IGenomeDatabaseIterable genomeDatabase);
    }

    public interface IGenomeDatabaseIterable : IDatabaseIterable
    {
        IGenomeDatabaseIterator GetIterator();
    }
}

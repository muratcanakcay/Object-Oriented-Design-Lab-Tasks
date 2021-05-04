namespace Task3
{
    // base interface for all database types which can be added in the future.
    // -- maybe not necessary but seemed logical, I was goint to ask you about this if we could consult.
    public interface IDatabaseIterable {}

    // interface for genome databases which can be added in the future
    public interface IGenomeDatabaseIterable : IDatabaseIterable
    {
        IGenomeDatabaseIterator GetIterator();
    }
}

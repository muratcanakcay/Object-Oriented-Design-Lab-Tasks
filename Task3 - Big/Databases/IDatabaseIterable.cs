namespace Task3
{
    public interface IDatabaseIterable
    {
        IDatabaseIterator GetIterator(IDatabaseIterable genomeDatabase);
    }
}

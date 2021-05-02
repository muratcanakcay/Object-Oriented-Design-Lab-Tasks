﻿namespace Task3
{
    // base interface for all database types which can be added in the future
    public interface IDatabaseIterable {} 

    // interface for virus databases which can be added in the future
    public interface IVirusDatabaseIterable : IDatabaseIterable
    {
        IVirusDatabaseIterator GetIterator(IGenomeDatabaseIterable genomeDatabase);
    }

    // interface for genome databases which can be added in the future
    public interface IGenomeDatabaseIterable : IDatabaseIterable
    {
        IGenomeDatabaseIterator GetIterator();
    }
}

namespace Task3
{
    public static class IteratorFactory
    {
        // iterators for virus databases
        
        // simpleDatabase
        

        // excellDatabase
        

        // overcomplicatedDatabase
        public static IDatabaseIterator GetIterator(OvercomplicatedDatabase overcomplicatedDatabase, SimpleGenomeDatabase simpleGenomeDatabase)
        {
            return new OvercomplicatedDatabaseIterator(overcomplicatedDatabase, simpleGenomeDatabase);
        }
    }
}

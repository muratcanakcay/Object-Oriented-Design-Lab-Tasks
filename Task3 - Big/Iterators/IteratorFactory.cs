namespace Task3
{
    public static class IteratorFactory
    {
        // iterators for virus databases
        
        // simpleDatabase
        

        // excellDatabase
        public static IDatabaseIterator GetIterator(ExcellDatabase excellDatabase, SimpleGenomeDatabase simpleGenomeDatabase)
        {
            return new ExcellDatabaseIterator(excellDatabase, simpleGenomeDatabase);
        }

        // excellDatabase
        public static IDatabaseIterator GetIterator(OvercomplicatedDatabase overcomplicatedDatabase, SimpleGenomeDatabase simpleGenomeDatabase)
        {
            return new OvercomplicatedDatabaseIterator(overcomplicatedDatabase, simpleGenomeDatabase);
        }
    }
}

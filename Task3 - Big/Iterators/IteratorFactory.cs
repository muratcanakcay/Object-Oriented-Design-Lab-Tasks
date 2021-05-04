using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Iterators
{
    public static class IteratorFactory
    {
        // iterators for virus databases
        
        // simpleDatabase
        public static IVirusDatabaseIterator GetIterator(SimpleDatabase simpleDatabase, SimpleGenomeDatabase simpleGenomeDatabase)
        {
            return new SimpleDatabaseIterator(simpleDatabase, simpleGenomeDatabase);
        }

        // excellDatabase
        public static IVirusDatabaseIterator GetIterator(ExcellDatabase excellDatabase, SimpleGenomeDatabase simpleGenomeDatabase)
        {
            return new ExcellDatabaseIterator(excellDatabase, simpleGenomeDatabase);
        }

        // excellDatabase
        public static IVirusDatabaseIterator GetIterator(OvercomplicatedDatabase overcomplicatedDatabase, SimpleGenomeDatabase simpleGenomeDatabase)
        {
            return new OvercomplicatedDatabaseIterator(overcomplicatedDatabase, simpleGenomeDatabase);
        }
    }
}

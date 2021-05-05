using System;
using System.Collections.Generic;
using System.Text;
using Task3.Repository;

namespace Task3.Iterators
{
    public static class IteratorFactory
    {
        // iterators for virus databases
        
        // simpleDatabase
        public static IVirusDatabaseIterator GetIterator(SimpleDatabase simpleDatabase, IGenomeRepo genomeRepo)
        {
            return new SimpleDatabaseIterator(simpleDatabase, genomeRepo);
        }

        // excellDatabase
        public static IVirusDatabaseIterator GetIterator(ExcellDatabase excellDatabase, IGenomeRepo genomeRepo)
        {
            return new ExcellDatabaseIterator(excellDatabase, genomeRepo);
        }

        // excellDatabase
        public static IVirusDatabaseIterator GetIterator(OvercomplicatedDatabase overcomplicatedDatabase, IGenomeRepo genomeRepo)
        {
            return new OvercomplicatedDatabaseIterator(overcomplicatedDatabase, genomeRepo);
        }
    }
}

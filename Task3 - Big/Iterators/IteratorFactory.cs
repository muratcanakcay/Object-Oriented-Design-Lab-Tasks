﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Task3
{
    public static class IteratorFactory
    {
        // iterators for virus databases
        
        // simpleDatabase
        public static IDatabaseIterator GetIterator(SimpleDatabase simpleDatabase, SimpleGenomeDatabase simpleGenomeDatabase)
        {
            return new SimpleDatabaseIterator(simpleDatabase, simpleGenomeDatabase);
        }

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

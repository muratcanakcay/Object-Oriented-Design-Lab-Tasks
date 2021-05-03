using System;
using System.Collections.Generic;
using Task3.Iterators;

namespace Task3
{
    public class ExcellDatabase : IVirusDatabaseIterable
    {
        public string Names { get; }
        public string DeathRates { get; }
        public string InfectionRates { get; }
        public string GenomeIds { get; }

        public ExcellDatabase(string names, string deathRates, string infectionRates, string genomeIds)
        {
            Names = names;
            DeathRates = deathRates;
            InfectionRates = infectionRates;
            GenomeIds = genomeIds;
        }

        public IVirusDatabaseIterator GetIterator(IGenomeDatabaseIterable genomeDatabase)
        {
            return new ExcellDatabaseIterator(this, genomeDatabase);
        }
    }

    public class SimpleDatabaseRow
    {
        public string VirusName { get; set; }
        public double DeathRate { get; set; }
        public double InfectionRate { get; set; }
        public Guid GenomeId { get; set; }
    }

    public class SimpleDatabase : IVirusDatabaseIterable
    {
        public IReadOnlyList<SimpleDatabaseRow> Rows { get; }
        public SimpleDatabase(IEnumerable<SimpleDatabaseRow> simpleDatabaseRows)
        {
            var list = new List<SimpleDatabaseRow>();
            list.AddRange(simpleDatabaseRows);

            Rows = list;
        }

        public IVirusDatabaseIterator GetIterator(IGenomeDatabaseIterable genomeDatabase)
        {
            return new SimpleDatabaseIterator(this, genomeDatabase);
        }
    }
}

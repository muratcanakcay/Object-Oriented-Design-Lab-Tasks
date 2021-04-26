using System.Collections.Generic;

namespace Task3
{
    public class SimpleGenomeDatabase : IDatabaseIterable
    {
        public List<GenomeData> genomeDatas { get; }

        public SimpleGenomeDatabase(List<GenomeData> genomeDatas)
        {
            this.genomeDatas = genomeDatas;
        }

        public IDatabaseIterator GetIterator(IDatabaseIterable genomeDatabase)
        {
            return new SimpleGenomeDatabaseIterator(this);
        }
    }
}

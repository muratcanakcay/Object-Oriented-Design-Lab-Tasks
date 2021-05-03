using System.Collections.Generic;
using Task3.Iterators;

namespace Task3
{
    public class SimpleGenomeDatabase : IGenomeDatabaseIterable
    {
        public List<GenomeData> genomeDatas { get; }

        public SimpleGenomeDatabase(List<GenomeData> genomeDatas)
        {
            this.genomeDatas = genomeDatas;
        }

        public IGenomeDatabaseIterator GetIterator()
        {
            return new SimpleGenomeDatabaseIterator(this);
        }
    }
}

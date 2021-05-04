using System;
using System.Collections.Generic;
using System.Linq;
using Task3.Repository;

namespace Task3
{
    public class SimpleGenomeDatabase : IGenomeRepo
    {
        public List<GenomeData> genomeDatas { get; }

        public SimpleGenomeDatabase(List<GenomeData> genomeDatas)
        {
            this.genomeDatas = genomeDatas;
        }

        public List<GenomeData> GetById(Guid id)
        {
            return genomeDatas.Where(genome => genome.Id == id).ToList();
        }

        public List<GenomeData> GetByTag(string tag)
        {
            return genomeDatas.Where(genome => genome.Tags.Any(_tag => _tag == tag)).ToList();
        }
    }
}

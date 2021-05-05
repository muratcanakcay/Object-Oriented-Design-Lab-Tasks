using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3.Repository
{
    public class GenomeRepo : IGenomeRepo
    {
        private List<GenomeData> _genomeDatas;

        // different constructors can be implemented for different Genome Database types which could be added in the future
        public GenomeRepo(SimpleGenomeDatabase simpleGenomeDatabase)
        {
            _genomeDatas = simpleGenomeDatabase.genomeDatas;
        }
        
        public List<GenomeData> GetById(Guid id)
        {
            return _genomeDatas.Where(genome => genome.Id == id).ToList();
        }

        public List<GenomeData> GetByTag(string tag)
        {
            return _genomeDatas.Where(genome => genome.Tags.Any(_tag => _tag == tag)).ToList();
        }
    }
}

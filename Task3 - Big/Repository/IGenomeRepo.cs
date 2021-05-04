using System;
using System.Collections.Generic;

namespace Task3.Repository
{
    public interface IGenomeRepo
    {
        public List<GenomeData> GetById(Guid id);
        public List<GenomeData> GetByTag(string tag);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Task3.Repository;

namespace Task3
{
    public class SimpleGenomeDatabase
    {
        public List<GenomeData> genomeDatas { get; }

        public SimpleGenomeDatabase(List<GenomeData> genomeDatas)
        {
            this.genomeDatas = genomeDatas;
        }
    }
}

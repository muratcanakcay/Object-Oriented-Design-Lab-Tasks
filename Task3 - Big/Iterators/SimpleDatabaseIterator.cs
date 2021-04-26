using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    public class SimpleDatabaseIterator : IDatabaseIterator
    {
        private int _currentIndex = 0;
        private readonly List<VirusData> _data = new List<VirusData>();

        public SimpleDatabaseIterator(SimpleDatabase simpleDatabase, SimpleGenomeDatabase simpleGenomeDatabase)
        {
            foreach (var row in simpleDatabase.Rows)
            {
                _data.Add(new VirusData(
                    row.VirusName,
                    row.DeathRate,
                    row.InfectionRate,
                    simpleGenomeDatabase.genomeDatas.Where(genome => row.GenomeId == genome.Id).ToList()
                ));
            }
        }
        
        public bool HasNext()
        {
            return _currentIndex < _data.Count;
        }

        public void Next()
        {
            _currentIndex++;
        }

        public object Current()
        {
            return _data[_currentIndex];
        }
    }
}

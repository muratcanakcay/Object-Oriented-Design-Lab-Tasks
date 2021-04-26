using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    public class ExcellDatabaseIterator : IDatabaseIterator
    {
        private int _currentIndex = 0;
        private readonly List<VirusData> _data = new List<VirusData>();

        public ExcellDatabaseIterator(ExcellDatabase excellDatabase, SimpleGenomeDatabase simpleGenomeDatabase)
        {
            var virusNames=excellDatabase.Names.Split(';');
            var deathRates=excellDatabase.DeathRates.Split(';');
            var infectionRates=excellDatabase.InfectionRates.Split(';');
            var genomeIds=excellDatabase.GenomeIds.Split(';');
            
            for(int i = 0; i < virusNames.Length; i++)
            {
                _data.Add(new VirusData(
                    virusNames[i],
                    Double.Parse(deathRates[i]),
                    Double.Parse(infectionRates[i]),
                    simpleGenomeDatabase.genomeDatas.Where(x=>x.Id==Guid.Parse(genomeIds[i])).ToList())
                );
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
using System;
using System.Collections.Generic;
using System.Linq;
using Task3.Repository;

namespace Task3.Iterators
{
    public class ExcellDatabaseIterator : IVirusDatabaseIterator
    {
        private int _currentIndex = -1;
        private readonly List<VirusData> _data = new List<VirusData>();

        public ExcellDatabaseIterator(ExcellDatabase excellDatabase, IGenomeRepo genomeDatabase)
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
                    genomeDatabase.GetById(Guid.Parse(genomeIds[i]))
                    ));
            }
        }
        
        public bool HasNext()
        {
            return _currentIndex + 1 < _data.Count;
        }

        public void Prev()
        {
            _currentIndex--;
        }
        
        public void Next()
        {
            _currentIndex++;
        }

        public VirusData Current()
        {
            return _data[_currentIndex];
        }
    }
}
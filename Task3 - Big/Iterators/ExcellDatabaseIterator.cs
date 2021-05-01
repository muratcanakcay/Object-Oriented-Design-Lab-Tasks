using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class ExcellDatabaseIterator : IVirusDatabaseIterator
    {
        private int _currentIndex = 0;
        private readonly List<VirusData> _data = new List<VirusData>();
        private readonly List<GenomeData> _genomeData = new List<GenomeData>();

        public ExcellDatabaseIterator(ExcellDatabase excellDatabase, IGenomeDatabaseIterable genomeDatabase)
        {
            var genomeDatabaseIterator = genomeDatabase.GetIterator();
            while (genomeDatabaseIterator.HasNext())
            {
                _genomeData.Add(genomeDatabaseIterator.Current());
                genomeDatabaseIterator.Next();
            }
            
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
                    _genomeData.Where(genome => genome.Id == Guid.Parse(genomeIds[i])).ToList()
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

        public VirusData Current()
        {
            return _data[_currentIndex];
        }
    }
}
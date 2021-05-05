using System;
using System.Collections.Generic;
using Task3.Repository;

namespace Task3.Iterators
{
    public class ExcellDatabaseIterator : IVirusDatabaseIterator
    {
        private int _currentIndex = -1;
        private readonly List<VirusData> _data = new List<VirusData>();

        public ExcellDatabaseIterator(ExcellDatabase excellDatabase, IGenomeRepo genomeRepo)
        {
            InitVirusDataList(excellDatabase, genomeRepo);
        }

        private void InitVirusDataList(ExcellDatabase excellDatabase, IGenomeRepo genomeRepo)
        {
            var virusNames = excellDatabase.Names.Split(';');
            var deathRates = excellDatabase.DeathRates.Split(';');
            var infectionRates = excellDatabase.InfectionRates.Split(';');
            var genomeIds = excellDatabase.GenomeIds.Split(';');

            AddToList(virusNames, deathRates, infectionRates, genomeIds, genomeRepo);
        }

        private void AddToList(string[] virusNames, string[] deathRates, string[] infectionRates, string[] genomeIds, IGenomeRepo genomeRepo)
        {
            for (int i = 0; i < virusNames.Length; i++)
            {
                _data.Add(new VirusData(
                    virusNames[i],
                    double.Parse(deathRates[i]),
                    double.Parse(infectionRates[i]),
                    genomeRepo.GetById(Guid.Parse(genomeIds[i]))
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
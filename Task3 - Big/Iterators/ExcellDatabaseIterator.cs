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

            for (int i = 0; i < virusNames.Length; i++)
            {
                AddToList(virusNames[i], deathRates[i], infectionRates[i], genomeIds[i], genomeRepo);
            }
        }

        private void AddToList(string virusName, string deathRate, string infectionRate, string genomeId, IGenomeRepo genomeRepo)
        {
            _data.Add(new VirusData(
                virusName,
                double.Parse(deathRate),
                double.Parse(infectionRate),
                genomeRepo.GetById(Guid.Parse(genomeId))
            ));
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
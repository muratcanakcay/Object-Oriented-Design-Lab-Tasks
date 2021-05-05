using System.Collections.Generic;
using Task3.Repository;

namespace Task3.Iterators
{
    public class SimpleDatabaseIterator : IVirusDatabaseIterator
    {
        private int _currentIndex = -1;
        private readonly List<VirusData> _virusData = new List<VirusData>();

        public SimpleDatabaseIterator(SimpleDatabase simpleDatabase, IGenomeRepo genomeRepo)
        {
            foreach (var row in simpleDatabase.Rows)
            {
                _virusData.Add(new VirusData(
                    row.VirusName,
                    row.DeathRate,
                    row.InfectionRate,
                    genomeRepo.GetById(row.GenomeId)
                    ));
            }
        }
        
        public bool HasNext()
        {
            return _currentIndex + 1 < _virusData.Count;
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
            return _virusData[_currentIndex];
        }
    }
}

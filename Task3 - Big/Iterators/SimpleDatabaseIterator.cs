using System.Collections.Generic;
using System.Linq;

namespace Task3.Iterators
{
    public class SimpleDatabaseIterator : IVirusDatabaseIterator
    {
        private int _currentIndex = -1;
        private readonly List<VirusData> _virusData = new List<VirusData>();
        private readonly List<GenomeData> _genomeData = new List<GenomeData>();


        public SimpleDatabaseIterator(SimpleDatabase simpleDatabase, IGenomeDatabaseIterable genomeDatabase)
        {
            var genomeDatabaseIterator = genomeDatabase.GetIterator();
            while (genomeDatabaseIterator.HasNext())
            {
                genomeDatabaseIterator.Next();
                _genomeData.Add(genomeDatabaseIterator.Current());
            }
            
            foreach (var row in simpleDatabase.Rows)
            {
                
                _virusData.Add(new VirusData(
                    row.VirusName,
                    row.DeathRate,
                    row.InfectionRate,
                    _genomeData.Where(genome => row.GenomeId == genome.Id).ToList()
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

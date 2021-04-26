using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class SimpleDatabaseIterator : IDatabaseIterator
    {
        private int _currentIndex = 0;
        private readonly List<VirusData> _virusData = new List<VirusData>();
        private readonly List<GenomeData> _genomeData = new List<GenomeData>();


        public SimpleDatabaseIterator(SimpleDatabase simpleDatabase, IDatabaseIterable genomeDatabase)
        {
            IDatabaseIterator genomeDatabaseIterator = genomeDatabase.GetIterator(genomeDatabase);

            while (genomeDatabaseIterator.HasNext())
            {
                _genomeData.Add((GenomeData) genomeDatabaseIterator.Current());
                genomeDatabaseIterator.Next();
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
            return _currentIndex < _virusData.Count;
        }

        public void Next()
        {
            _currentIndex++;
        }

        public object Current()
        {
            return _virusData[_currentIndex];
        }
    }
}

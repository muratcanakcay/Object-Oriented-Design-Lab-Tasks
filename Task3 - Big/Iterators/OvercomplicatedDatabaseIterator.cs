using System.Collections.Generic;
using System.Linq;

namespace Task3.Iterators
{
    public class OvercomplicatedDatabaseIterator : IVirusDatabaseIterator
    {
        private int _currentIndex = -1;
        private readonly List<VirusData> _data = new List<VirusData>();
        private readonly List<GenomeData> _genomeData = new List<GenomeData>();
        
        public OvercomplicatedDatabaseIterator(OvercomplicatedDatabase overcomplicatedDatabase, IGenomeDatabaseIterable genomeDatabase)
        {
            var genomeDatabaseIterator = genomeDatabase.GetIterator();
            while (genomeDatabaseIterator.HasNext())
            {
                genomeDatabaseIterator.Next();
                _genomeData.Add(genomeDatabaseIterator.Current());
            }
            
            // using bfs to traverse the database and create iterator data
            Queue<INode> virusList = new Queue<INode>();
            virusList.Enqueue(overcomplicatedDatabase.Root);

            while (virusList.Count > 0)
            {
                var currentVirus = virusList.Dequeue();

                foreach (var virus in currentVirus.Children)
                {
                    virusList.Enqueue(virus);
                }

                _data.Add(new VirusData(
                        currentVirus.VirusName,
                        currentVirus.DeathRate,
                        currentVirus.InfectionRate,
                        _genomeData.Where(genome => genome.Tags.Any(tag => tag == currentVirus.GenomeTag)).ToList()
                        ));
            }
        }
        
        public VirusData Current()
        {
            return _data[_currentIndex];
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
    }
}
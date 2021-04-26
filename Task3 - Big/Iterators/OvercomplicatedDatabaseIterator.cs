using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class OvercomplicatedDatabaseIterator : IVirusDatabaseIterator
    {
        private int _currentIndex = 0;
        private readonly List<VirusData> _data = new List<VirusData>();
        
        public OvercomplicatedDatabaseIterator(OvercomplicatedDatabase overcomplicatedDatabase, SimpleGenomeDatabase simpleGenomeDatabase)
        {
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
                        simpleGenomeDatabase.genomeDatas.Where(genome => genome.Tags.Any(tag => tag == currentVirus.GenomeTag)).ToList()
                        ));
            }
        }
        
        public VirusData Current()
        {
            return _data[_currentIndex];
        }

        public bool HasNext()
        {
            return _currentIndex < _data.Count;
        }

        public void Next()
        {
            _currentIndex++;
        }
    }
}
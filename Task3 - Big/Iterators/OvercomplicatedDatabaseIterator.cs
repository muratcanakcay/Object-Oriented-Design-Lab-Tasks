using System.Collections.Generic;
using Task3.Repository;

namespace Task3.Iterators
{
    public class OvercomplicatedDatabaseIterator : IVirusDatabaseIterator
    {
        private int _currentIndex = -1;
        private readonly List<VirusData> _data = new List<VirusData>();
        
        public OvercomplicatedDatabaseIterator(OvercomplicatedDatabase overcomplicatedDatabase, IGenomeRepo genomeRepo)
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
                        genomeRepo.GetByTag(currentVirus.GenomeTag)
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
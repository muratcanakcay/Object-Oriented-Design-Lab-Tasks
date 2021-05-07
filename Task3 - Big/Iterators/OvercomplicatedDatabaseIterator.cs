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
            InitVirusDataList(overcomplicatedDatabase, genomeRepo);
        }

        private void InitVirusDataList(OvercomplicatedDatabase overcomplicatedDatabase, IGenomeRepo genomeRepo)
        {
            // using bfs to traverse the database and create iterator data
            Queue<INode> virusList = new Queue<INode>();
            virusList.Enqueue(overcomplicatedDatabase.Root);

            while (virusList.Count > 0)
            {
                var currentVirus = virusList.Dequeue();
                AddToList(currentVirus, genomeRepo);
                EnqueueChildren(currentVirus, virusList);
            }
        }

        private void AddToList(INode currentVirus, IGenomeRepo genomeRepo)
        {
            _data.Add(new VirusData(
                currentVirus.VirusName,
                currentVirus.DeathRate,
                currentVirus.InfectionRate,
                genomeRepo.GetByTag(currentVirus.GenomeTag)
            ));
        }

        private static void EnqueueChildren(INode currentVirus, Queue<INode> virusList)
        {
            foreach (var child in currentVirus.Children)
            {
                virusList.Enqueue(child);
            }
        }

        //-----

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
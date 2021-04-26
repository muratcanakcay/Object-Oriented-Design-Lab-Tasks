using System.Collections.Generic;
using System;
using System.Linq;

namespace Task3
{
    public class OvercomplicatedDatabaseIterator : IDatabaseIterator
    {
        private int _currentIndex = 0;
        private readonly List<VirusData> _data = new List<VirusData>();
        
        public OvercomplicatedDatabaseIterator(OvercomplicatedDatabase overcomplicatedDatabase, SimpleGenomeDatabase simpleGenomeDatabase)
        {
            List<INode> virusList = new List<INode>();
            virusList.Add(overcomplicatedDatabase.Root);
            
            for (int i = 0; i < virusList.Count; i++)
            {
                foreach (var virus in virusList[i].Children)
                {
                    virusList.Add(virus);
                }
            }
            foreach (var virus in virusList)
            {
                _data.Add(new VirusData(virus.VirusName,
                    virus.DeathRate,
                    virus.InfectionRate,
                    simpleGenomeDatabase.genomeDatas.Where(genome => genome.Tags.Any(tag => tag == virus.GenomeTag)).ToList()));
            }
        }
        
        public object Current()
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
using System.Collections.Generic;

namespace Task3
{
    public class SimpleGenomeDatabaseIterator : IGenomeDatabaseIterator
    {
        private readonly List<GenomeData> _data;
        private int _currentIndex = -1;
        
        public SimpleGenomeDatabaseIterator(SimpleGenomeDatabase simpleGenomeDatabase)
        {
            _data = new List<GenomeData>(simpleGenomeDatabase.genomeDatas);
        }
        
        public GenomeData Current()
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

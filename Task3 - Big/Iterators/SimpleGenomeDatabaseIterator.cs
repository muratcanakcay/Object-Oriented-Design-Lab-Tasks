﻿using System.Collections.Generic;

namespace Task3
{
    public class SimpleGenomeDatabaseIterator : IGenomeDatabaseIterator
    {
        private List<GenomeData> _data;
        private int _currentIndex = 0;
        
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
            return _currentIndex < _data.Count;
        }

        public void Next()
        {
            _currentIndex++;
        }
    }
}

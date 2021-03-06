﻿using System;

namespace Task3.Decorators
{
    public class Filter : VirusDbIteratorDecorator
    {
        private readonly Func<VirusData, bool> _func;

        public Filter(Func<VirusData, bool> func, IVirusDatabaseIterator iterator) : base(iterator)
        {
            _func = func;
        }

        // HasNext() is the keypoint of the iterator. If Next() is called without checking HasNext() first the behaviour is undefined!
        public override bool HasNext()
        {
            while (_it.HasNext())
            {
                _it.Next();
                if (!_func(_it.Current())) continue;
                
                _it.Prev();
                return true;
            }

            return false;
        }
    }
}

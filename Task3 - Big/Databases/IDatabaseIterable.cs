﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public interface IDatabaseIterable
    {
        IDatabaseIterator GetIterator(IDatabaseIterable genomeDatabase);
    }
}

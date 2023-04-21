using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinderApp
{
    internal interface IWordFinder
    {
        public IEnumerable<string> Find(IEnumerable<string> dictionary);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL
{
    class NullIterator: IEnumerator
    {
        public bool MoveNext()
        {
            return false;
        }

        public void Reset()
        {
            throw new InvalidOperationException();
        }

        public object Current { get; }
    }
}

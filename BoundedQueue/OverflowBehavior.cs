using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoundedQueue
{
    public enum OverflowBehavior
    {
        RemoveOldest,
        ThrowException
    }
}

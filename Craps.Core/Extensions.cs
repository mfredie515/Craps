using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core
{
    internal static class Extensions
    {
        internal static int FuzzyFloor(this double value)
        {
            if ((value - (int)value) > 0.9)
                return (int)Math.Ceiling(value);
            return (int)Math.Floor(value);
        }
    }
}

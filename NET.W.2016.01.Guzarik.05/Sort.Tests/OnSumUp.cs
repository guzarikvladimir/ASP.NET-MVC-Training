using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Tests
{
    public sealed class OnSumUp : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            var sum1 = 0;
            var sum2 = 0;

            foreach (var t in x)
                checked { sum1 += t; }

            foreach (var t in y)
                checked { sum2 += t; }

            return sum1 - sum2;
        }
    }
}

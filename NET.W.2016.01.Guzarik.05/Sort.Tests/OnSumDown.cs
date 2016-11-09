using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Tests
{
    public sealed class OnSumDown : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            var sum1 = x.Concat(new[] {0}).Sum();
            var sum2 = y.Concat(new[] {0}).Sum();

            return sum2 - sum1;
        }
    }
}

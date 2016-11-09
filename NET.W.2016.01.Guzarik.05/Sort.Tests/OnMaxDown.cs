using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Tests
{
    public sealed class OnMaxDown : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            var max1 = x.Concat(new[] {int.MinValue}).Max();
            var max2 = y.Concat(new[] {int.MinValue}).Max();

            return max2 - max1;
        }
    }
}

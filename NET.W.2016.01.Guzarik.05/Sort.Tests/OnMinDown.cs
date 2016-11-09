using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Tests
{
    public sealed class OnMinDown : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            var min1 = x.Concat(new[] {int.MaxValue}).Min();
            var min2 = y.Concat(new[] {int.MaxValue}).Min();

            return min2 - min1;
        }
    }
}

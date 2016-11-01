using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public sealed class OnSumDown : ICompare
    {
        public int CompareTo(int[] array1, int[] array2)
        {
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < array1.Length; i++)
                checked { sum1 += array1[i]; }

            for (int i = 0; i < array2.Length; i++)
                checked { sum2 += array2[i]; }

            return sum2 - sum1;
        }
    }
}

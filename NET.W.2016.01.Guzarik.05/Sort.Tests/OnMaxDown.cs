using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Tests
{
    public sealed class OnMaxDown : IComparer
    {
        public int Compare(object x, object y)
        {
            int[] array1 = (int[])x;
            int[] array2 = (int[])y;

            int max1 = int.MinValue;
            int max2 = int.MinValue;

            for (int i = 0; i < array1.Length; i++)
                if (max1 < array1[i])
                    max1 = array1[i];

            for (int i = 0; i < array2.Length; i++)
                if (max2 < array2[i])
                    max2 = array2[i];

            return max2 - max1;
        }
    }
}

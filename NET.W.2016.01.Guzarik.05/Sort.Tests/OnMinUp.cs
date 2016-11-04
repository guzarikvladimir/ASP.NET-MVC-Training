using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Tests
{
    public sealed class OnMinUp : IComparer
    {
        public int Compare(object x, object y)
        {
            int[] array1 = (int[])x;
            int[] array2 = (int[])y;

            int min1 = int.MaxValue;
            int min2 = int.MaxValue;

            for (int i = 0; i < array1.Length; i++)
                if (min1 > array1[i])
                    min1 = array1[i];

            for (int i = 0; i < array2.Length; i++)
                if (min2 > array2[i])
                    min2 = array2[i];

            return min1 - min2;
        }
    }
}

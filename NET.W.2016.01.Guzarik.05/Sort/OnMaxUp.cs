﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public sealed class OnMaxUp : ICompare
    {
        public int CompareTo(int[] array1, int[] array2)
        {
            int max1 = int.MinValue;
            int max2 = int.MinValue;

            for (int i = 0; i < array1.Length; i++)
                if (max1 < array1[i])
                    max1 = array1[i];

            for (int i = 0; i < array2.Length; i++)
                if (max2 < array2[i])
                    max2 = array2[i];

            return max1 - max2;
        }
    }
}

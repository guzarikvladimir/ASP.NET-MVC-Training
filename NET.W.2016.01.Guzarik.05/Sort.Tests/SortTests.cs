using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Tests
{
    [TestFixture]
    public class SortTests
    {
        [Test, TestCaseSource("NormalCases")]
        public void Bubble_NormalCases(int[][] actual, int[][] expected, IComparer<int[]> comp)
        {
            //Sort.Bubble(actual, comp);
            Sort.Bubble(actual, SomeMethod);

            CollectionAssert.AreEqual(expected, actual);
        }

        private static int SomeMethod(int[] x, int[] y)
        {
            var min1 = x.Concat(new[] { int.MaxValue }).Min();
            var min2 = y.Concat(new[] { int.MaxValue }).Min();

            return min2 - min1;
        }

        static object[] NormalCases = new object[]
        {
            new object[] { new int[][] { new int[] { 1, 2, 3 }, new int[] { 2, 3, 4, 5 }, new int[] { 1, 4 } },
                new int[][] { new int[] { 1, 4 }, new int[] { 1, 2, 3 }, new int[] { 2, 3, 4, 5 } },
                new OnSumUp() },
            new object[] { new int[][] { new int[] { 1, 2, 3 }, new int[] { 2, 3, 4, 5 }, new int[] { 1, 4 } },
                new int[][] { new int[] { 2, 3, 4, 5 }, new int[] { 1, 2, 3 }, new int[] { 1, 4 } },
                new OnSumDown() },
            new object[] { new int[][] { new int[] { 1, 2, 3 }, new int[] { 2, 3, 4, 5 }, new int[] { 1, 4 } },
                new int[][] { new int[] { 1, 2, 3 }, new int[] { 1, 4 }, new int[] { 2, 3, 4 , 5 } },
                new OnMaxUp() },
            new object[] { new int[][] { new int[] { 1, 2, 3 }, new int[] { 2, 3, 4, 5 }, new int[] { 1, 4 } },
                new int[][] { new int[] { 2, 3, 4, 5 }, new int[] { 1, 4 }, new int[] { 1, 2, 3 } },
                new OnMaxDown() },
            new object[] { new int[][] { new int[] { 1, 2, 3 }, new int[] { 2, 3, 4, 5 }, new int[] { 1, 4 } },
                new int[][] { new int[] { 1, 2, 3 }, new int[] { 1, 4 }, new int[] { 2, 3, 4, 5 } },
                new OnMinUp() },
            new object[] { new int[][] { new int[] { 1, 2, 3 }, new int[] { 2, 3, 4, 5 }, new int[] { 1, 4 } },
                new int[][] { new int[] { 2, 3, 4, 5 }, new int[] { 1, 2, 3 }, new int[] { 1, 4 } },
                new OnMinDown() }
        };
    }
}

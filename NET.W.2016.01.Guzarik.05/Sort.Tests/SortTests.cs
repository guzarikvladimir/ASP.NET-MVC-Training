using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
namespace Sort.Tests
{
    [TestFixture]
    public class SortTests
    {
        [Test, TestCaseSource(nameof(NormalCases))]
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

        private static readonly object[] NormalCases = {
            new object[] { new[] { new[] { 1, 2, 3 }, new[] { 2, 3, 4, 5 }, new[] { 1, 4 } },
                new[] { new[] { 1, 4 }, new[] { 1, 2, 3 }, new[] { 2, 3, 4, 5 } },
                new OnSumUp() },
            new object[] { new[] { new[] { 1, 2, 3 }, new[] { 2, 3, 4, 5 }, new[] { 1, 4 } },
                new[] { new[] { 2, 3, 4, 5 }, new[] { 1, 2, 3 }, new[] { 1, 4 } },
                new OnSumDown() },
            new object[] { new[] { new[] { 1, 2, 3 }, new[] { 2, 3, 4, 5 }, new[] { 1, 4 } },
                new[] { new[] { 1, 2, 3 }, new[] { 1, 4 }, new[] { 2, 3, 4 , 5 } },
                new OnMaxUp() },
            new object[] { new[] { new[] { 1, 2, 3 }, new[] { 2, 3, 4, 5 }, new[] { 1, 4 } },
                new[] { new[] { 2, 3, 4, 5 }, new[] { 1, 4 }, new[] { 1, 2, 3 } },
                new OnMaxDown() },
            new object[] { new [] { new[] { 1, 2, 3 }, new[] { 2, 3, 4, 5 }, new[] { 1, 4 } },
                new[] { new[] { 1, 2, 3 }, new[] { 1, 4 }, new[] { 2, 3, 4, 5 } },
                new OnMinUp() },
            new object[] { new[] { new[] { 1, 2, 3 }, new[] { 2, 3, 4, 5 }, new[] { 1, 4 } },
                new[] { new[] { 2, 3, 4, 5 }, new[] { 1, 2, 3 }, new[] { 1, 4 } },
                new OnMinDown() }
        };
    }
}

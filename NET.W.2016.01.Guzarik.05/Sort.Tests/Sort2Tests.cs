
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Sort.Tests
{
    [TestFixture]
    class Sort2Tests
    {
        [Test, TestCaseSource(nameof(NormalCases))]
        public void Bubble_IComparer(int[][] actual, int[][] expected, IComparer<int[]> comp)
        {
            Sort2.Bubble(actual, comp);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Bubble_Comparison()
        {
            var actual = new[] { new[] { 1, 2, 3 }, new[] { 2, 3, 4, 5 }, new[] { 1, 4 } };
            var expected = new[] { new[] { 2, 3, 4, 5 }, new[] { 1, 2, 3 }, new[] { 1, 4 } };

            Sort2.Bubble(actual, SomeMethod);

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

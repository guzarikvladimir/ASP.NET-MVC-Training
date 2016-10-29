using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Tests
{
    [TestFixture]
    public class SortTests
    {
        [Test]
        public void Sum_nullArray_ArgumentNullException()
        {
            int[][] actual = null;

            Assert.Throws<ArgumentNullException>(() => Sort.Sum(actual));
        }

        [Test, TestCaseSource("Cases1")]
        public void Sum(int[][] actualArray, int[][] expectedArray)
        {
            Sort.Sum(actualArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        static object[] Cases1 =
        {
            new object[] { new int[][] { new int[] { 4, 5, 6, 7 }, new int[] { 3, 4, 5 }, new int[] { 7, 10, 5 }, new int[] { 1, 2, 3} },
                new int[][] { new int[] { 1, 2, 3}, new int[] { 3, 4, 5 }, new int[] { 4, 5, 6, 7 } , new int[] { 7, 10, 5 } } },
            new object[] { new int[][] { new int[] { 3, 4, 5 }, new int[] { 4, 5, 6 } },
                new int[][] { new int[] { 3, 4, 5 }, new int[] { 4, 5, 6 } } }
        };

        [Test, TestCaseSource("Cases2")]
        public void SumReverse(int[][] actualArray, int[][] expectedArray)
        {
            Sort.SumReverse(actualArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        static object[] Cases2 =
        {
            new object[] { new int[][] { new int[] { 4, 5, 6, 7 }, new int[] { 3, 4, 5 }, new int[] { 7, 10, 5 } },
                new int[][] { new int[] { 4, 5, 6, 7 }, new int[] { 7, 10, 5 } , new int[] { 3, 4, 5 } } },
            new object[] { new int[][] { new int[] { 3, 4, 5 }, new int[] { 4, 5, 6 } },
                new int[][] { new int[] { 4, 5, 6 }, new int[] { 3, 4, 5 } } }
        };

        [Test, TestCaseSource("Cases3")]
        public void Max(int[][] actualArray, int[][] expectedArray)
        {
            Sort.Max(actualArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        static object[] Cases3 =
        {
            new object[] { new int[][] { new int[] { 4, 5, 6, 7 }, new int[] { 3, 4, 5 }, new int[] { 7, 10, 5 } },
                new int[][] { new int[] { 3, 4, 5 }, new int[] { 4, 5, 6, 7 } , new int[] { 7, 10, 5 } } },
            new object[] { new int[][] { new int[] { 3, 4, 5 }, new int[] { 4, 5, 6 } },
                new int[][] { new int[] { 3, 4, 5 }, new int[] { 4, 5, 6 } } }
        };

        [Test, TestCaseSource("Cases4")]
        public void MaxReverse(int[][] actualArray, int[][] expectedArray)
        {
            Sort.MaxReverse(actualArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        static object[] Cases4 =
        {
            new object[] { new int[][] { new int[] { 4, 5, 6, 7 }, new int[] { 3, 4, 5 }, new int[] { 7, 10, 5 } },
                new int[][] { new int[] { 7, 10, 5 }, new int[] { 4, 5, 6, 7 } , new int[] { 3, 4, 5 } } },
            new object[] { new int[][] { new int[] { 3, 4, 5 }, new int[] { 4, 5, 6 } },
                new int[][] { new int[] { 4, 5, 6 }, new int[] { 3, 4, 5 } } }
        };

        [Test, TestCaseSource("Cases5")]
        public void Min(int[][] actualArray, int[][] expectedArray)
        {
            Sort.Min(actualArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        static object[] Cases5 =
        {
            new object[] { new int[][] { new int[] { 4, 5, 6, 7 }, new int[] { 3, 4, 5 }, new int[] { 7, 10, 5 } },
                new int[][] { new int[] { 3, 4, 5 }, new int[] { 4, 5, 6, 7 } , new int[] { 7, 10, 5 } } },
            new object[] { new int[][] { new int[] { 3, 4, 5 }, new int[] { 4, 5, 6 } },
                new int[][] { new int[] { 3, 4, 5 }, new int[] { 4, 5, 6 } } }
        };

        [Test, TestCaseSource("Cases6")]
        public void MinReverse(int[][] actualArray, int[][] expectedArray)
        {
            Sort.MinReverse(actualArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        static object[] Cases6 =
        {
            new object[] { new int[][] { new int[] { 4, 5, 6, 7 }, new int[] { 3, 4, 5 }, new int[] { 7, 10, 5 } },
                new int[][] { new int[] { 7, 10, 5 }, new int[] { 4, 5, 6, 7 } , new int[] { 3, 4, 5 } } },
            new object[] { new int[][] { new int[] { 3, 4, 5 }, new int[] { 4, 5, 6 } },
                new int[][] { new int[] { 4, 5, 6 }, new int[] { 3, 4, 5 } } }
        };
    }
}

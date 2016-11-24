using System;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    class SymmetricMatrixTests
    {
        [TestCase(2, 1, 2, 2, 3)]
        [TestCase(3, 1, 3, 0, 3, 2, 6, 0, 6, 5)]
        public void Constructor_ValidRank(int expected, params int[] numbers)
        {
            var matrix = new SymmetricMatrix<int>(numbers);

            Assert.AreEqual(expected, matrix.Rank);
        }

        [TestCase(1, 2, 2, 3)]
        [TestCase(1, 3, 0, 3, 2, 6, 0, 6, 5)]
        public void ToString_Integers(params int[] numbers)
        {
            var matrix = new SymmetricMatrix<int>(numbers);

            Console.WriteLine(matrix.ToString());
        }
    }
}

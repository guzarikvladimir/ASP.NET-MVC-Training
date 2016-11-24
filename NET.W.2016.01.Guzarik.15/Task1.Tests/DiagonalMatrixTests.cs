using System;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    class DiagonalMatrixTests
    {
        [TestCase(2, 1, 0, 0, 4)]
        [TestCase(3, 1, 0, 0, 0, 5, 0, 0, 0, 9)]
        [TestCase(4, 1, 0, 0, 0, 0, 6, 0, 0, 0, 0, 11, 0, 0, 0, 0, 16)]
        public void Constructor_ValidRank(int expected, params int[] numbers)
        {
            var matrix = new DiagonalMatrix<int>(numbers);

            Assert.AreEqual(expected, matrix.Rank);
        }

        [TestCase(1, 0, 0, 4)]
        [TestCase(1, 0, 0, 0, 5, 0, 0, 0, 9)]
        [TestCase(1, 0, 0, 0, 0, 6, 0, 0, 0, 0, 11, 0, 0, 0, 0, 16)]
        public void ToString_Integers(params int[] numbers)
        {
            var matrix = new DiagonalMatrix<int>(numbers);

            Console.WriteLine(matrix.ToString());
        }
    }
}

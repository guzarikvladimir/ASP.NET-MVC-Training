using System;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class SquareMatrixTests
    {
        [TestCase(2, 1, 2, 3, 4)]
        [TestCase(3, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        [TestCase(4, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void Constructor_ValidRank(int expected, params int[] numbers)
        {
            var matrix = new SquareMatrix<int>(numbers);

            Assert.AreEqual(expected, matrix.Rank);
        }

        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9)]
        [TestCase(1, 2, 3, 4)]
        public void ToString_Integers(params int[] numbers)
        {
            var matrix = new SquareMatrix<int>(numbers);

            Console.WriteLine(matrix.ToString());
        }

        [TestCase("one", null, null, "four")]
        [TestCase("one", null, null, null, "five", null, null, null, "nine")]
        [TestCase("one", null, null, null, null, "six", null, null, null, null, "eleven", null, null, null, null, "six")]
        public void ToString_Strings(params string[] strings)
        {
            var matrix = new DiagonalMatrix<string>(strings);

            Console.WriteLine(matrix.ToString(2));
        }

        [TestCase(0, 2, 3)]
        [TestCase(1, 0, 4)]
        [TestCase(1, 2, 6)]
        [TestCase(2, 2, 9)]
        public void Indexer_GetValueByTwoIndexes(int i, int j, int expected)
        {
            var matrix = new SquareMatrix<int>(1, 2, 3, 4, 5, 6, 7, 8, 9);

            Assert.AreEqual(expected, matrix[i, j]);
        }

        [Test]
        public void Event_Register()
        {
            var matrix = new SquareMatrix<int>(1, 2, 3, 4, 5, 6, 7, 8, 9);
            matrix.RegisterOnIndexSetted(new SetterSender());

            // до регистрации
            StringAssert.AreEqualIgnoringCase(null, matrix.MessageFromIndexSetted);

            // после регистрации
            const string expected = "Index [1,2] has changed";

            matrix[1, 2] = 32;

            StringAssert.AreEqualIgnoringCase(expected, matrix.MessageFromIndexSetted);
        }

        [Test]
        public void Sum()
        {
            var matrix1 = new SquareMatrix<int>(1, 2, 3, 4);

            var matrix = matrix1.Sum(matrix1, (a, b) => a + b);

            Console.WriteLine(matrix);
        }
    }
}

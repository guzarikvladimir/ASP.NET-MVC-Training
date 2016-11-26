using System;
using NUnit.Framework;
using Task1.extensions;
using Task1.hierarchy;

namespace Task1.Tests
{
    [TestFixture]
    class DiagonalMatrixTests
    {
        [Test]
        public void Event()
        {
            var matrix = new DiagonalMatrix<int>(1, 0, 0, 0, 5, 0, 0, 0, 9);
            var expected = "Index [1,1] has changed in diagonal matrix" + Environment.NewLine;

            matrix[1, 1] = 32;

            StringAssert.AreEqualIgnoringCase(expected, matrix.MessageFromIndexSetted);
        }

        [Test]
        public void Sum()
        {
            var matrix = new DiagonalMatrix<int>(1, 0, 0, 0, 5, 0, 0, 0, 9);

            var actual = matrix.Sum(matrix);

            foreach (var variable in actual)
                Console.WriteLine(variable);
        }
    }
}

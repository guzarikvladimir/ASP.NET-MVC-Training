using System;
using NUnit.Framework;
using Task1.extensions;
using Task1.hierarchy;

namespace Task1.Tests
{
    [TestFixture]
    public class SquareMatrixTests
    {
        [Test]
        public void Event()
        {
            var matrix = new SquareMatrix<int>(1, 2, 3, 4, 5, 6, 7, 8, 9);
            var expected = "Index [1,2] has changed in square matrix" + Environment.NewLine;

            matrix[1, 2] = 32;
            
            StringAssert.AreEqualIgnoringCase(expected, matrix.MessageFromIndexSetted);
        }

        [Test]
        public void Sum_SquareAndSquare_Square()
        {
            var matrix = new SquareMatrix<int>(1, 2, 3, 4, 5, 6, 7, 8, 9);

            var actual = matrix.Sum(matrix);

            foreach (var variable in actual)
            {
                Console.WriteLine(variable);
            }
        }

        [Test]
        public void Sum_SquareAndDiagonal_Square()
        {
            var matrix = new SquareMatrix<int>(1, 2, 3, 4, 5, 6, 7, 8, 9);
            var matrix1 = new DiagonalMatrix<int>(1, 0, 0, 0, 5, 0, 0, 0, 9);

            var actual = matrix.Sum(matrix1);

            foreach (var variable in actual)
            {
                Console.WriteLine(variable);
            }
        }
    }
}

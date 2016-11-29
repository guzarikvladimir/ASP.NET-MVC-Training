using System;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    class DiagonalMatrixTests
    {
        [Test]
        public void Event()
        {
            var matrix = new DiagonalMatrix<int>(1, 0, 0, 0, 5, 0, 0, 0, 9);

            matrix[1, 1] = 32;

            Console.WriteLine(matrix.EventInfo.IndexI);
            Console.WriteLine(matrix.EventInfo.IndexJ);
            Console.WriteLine(matrix.EventInfo.PreviousValue);
            Console.WriteLine(matrix.EventInfo.NewValue);
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

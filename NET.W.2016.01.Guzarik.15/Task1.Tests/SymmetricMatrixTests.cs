using System;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    class SymmetricMatrixTests
    {
        [Test]
        public void Event()
        {
            var matrix = new SymmetricMatrix<int>(1, 2, 3, 2, 4, 5, 3, 5, 6);

            matrix[1, 2] = 32;

            Console.WriteLine(matrix.EventInfo.IndexI);
            Console.WriteLine(matrix.EventInfo.IndexJ);
            Console.WriteLine(matrix.EventInfo.PreviousValue);
            Console.WriteLine(matrix.EventInfo.NewValue);
        }

        [Test]
        public void Sum()
        {
            var matrix = new SymmetricMatrix<int>(1, 2, 3, 2, 4, 5, 3, 5, 6);

            var actual = matrix.Sum(matrix);

            foreach (var variable in actual)
            {
                Console.WriteLine(variable);
            }
        }
    }
}

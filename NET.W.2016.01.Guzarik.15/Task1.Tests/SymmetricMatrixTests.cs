using System;
using NUnit.Framework;
using Task1.extensions;
using Task1.hierarchy;

namespace Task1.Tests
{
    [TestFixture]
    class SymmetricMatrixTests
    {
        [Test]
        public void Event()
        {
            var matrix = new SymmetricMatrix<int>(1, 2, 3, 4, 5, 6, 7, 8, 9);
            var expected = "Index [1,2] has changed in symmetric matrix" + Environment.NewLine;

            matrix[1, 2] = 32;

            StringAssert.AreEqualIgnoringCase(expected, matrix.MessageFromIndexSetted);
        }

        [Test]
        public void Sum()
        {
            var matrix = new SymmetricMatrix<int>(1, 2, 3, 4, 5, 6, 7, 8, 9);

            var actual = matrix.Sum(matrix);

            foreach (var variable in actual)
            {
                Console.WriteLine(variable);
            }
        }
    }
}

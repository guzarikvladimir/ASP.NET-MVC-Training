using System.Linq;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class GenerateTests
    {
        [TestCase(2, new[] {1, 1})]
        [TestCase(10, new[] {1, 1, 2, 3, 5, 8, 13, 21, 34, 55})]
        public void Fibonacci_ValidSmallNumbers(int number, int[] expected)
        {
            var actual = Generate.Fibonacci(number).ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}

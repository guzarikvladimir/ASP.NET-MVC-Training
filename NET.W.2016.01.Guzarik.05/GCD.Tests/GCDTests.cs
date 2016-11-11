using NUnit.Framework;
using System;
using System.Diagnostics;

namespace GCD.Tests
{
    [TestFixture]
    public class GcdTests
    {
        [TestCase(1, 10, 1)]
        [TestCase(0, 0, 0)]
        [TestCase(5, 0, 5)]
        [TestCase(0, 5, 5)]
        [TestCase(-5, 10, 5)]
        public void Euclidean_2Arguments_ThereIsAnswer(int a, int b, int expected)
        {
            var actual = Gcd.Euclidean(a, b);
            
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 9, 4, 1)]
        [TestCase(720, 110, 540, 10)]
        [TestCase(24, 0, 48, 24)]
        [TestCase(5, -25, -10, 5)]
        public void Euclidean_3Arguments_ThereIsAnswer(int a, int b, int c, int expected)
        {
            long ticks;
            var actual = Gcd.Euclidean(a, b, c, out ticks);

            Debug.WriteLine(ticks);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, -150, -230, 650, 310)]
        [TestCase(1, 1, 2, 3, 4, 0)]
        public void Euclidean_AnyNumberOfNumbers(int expected, params int[] numbers)
        {
            Assert.AreEqual(expected, Gcd.Euclidean(numbers));
        }

        [TestCase]
        public void Euclidean_NoArguments_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Gcd.Euclidean());
        }

        [TestCase(1, 10, 1)]
        [TestCase(0, 0, 0)]
        [TestCase(5, 0, 5)]
        [TestCase(0, 5, 5)]
        [TestCase(-5, 10, 5)]
        public void Binary_2ArgumentsThereIsAnswer(int a, int b, int expected)
        {
            var actual = Gcd.Binary(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 9, 4, 1)]
        [TestCase(720, 110, 540, 10)]
        [TestCase(24, 0, 48, 24)]
        [TestCase(5, -25, -10, 5)]
        public void Binary_3ArgumentsThereIsAnswer(int a, int b, int c, int expected)
        {
            long ticks;
            var actual = Gcd.Binary(a, b, c, out ticks);

            Debug.WriteLine(ticks);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, -150, -230, 650, 310)]
        [TestCase(1, 1, 2, 3, 4, 0)]
        public void Binary_AnyNumberOfNumbers(int expected, params int[] numbers)
        {
            Assert.AreEqual(expected, Gcd.Binary(numbers));
        }

        [TestCase]
        public void Binary_NoArguments_ArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => Gcd.Binary(null));
        }
    }
}

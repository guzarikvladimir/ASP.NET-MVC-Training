using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD.Tests
{
    [TestFixture]
    public class GCDTests
    {
        [TestCase(1, 10, 1)]
        [TestCase(5, 10, 5)]
        [TestCase(24, -24, 24)]
        [TestCase(0, 0, 0)]
        [TestCase(5, 0, 5)]
        [TestCase(0, 5, 5)]
        [TestCase(-5, 10, 5)]
        public void Euclidean_2ArgumentsThereIsAnswer(int a, int b, int expected)
        {
            int actual = GCD.Euclidean(a, b);
            Debug.WriteLine(GCD.GetLastMethodTime());
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 9, 4, 1)]
        [TestCase(720, 110, 540, 10)]
        [TestCase(24, 0, 48, 24)]
        [TestCase(5, -25, -10, 5)]
        [TestCase(-5, 10, 15, 5)]
        public void Euclidean_3ArgumentsThereIsAnswer(int a, int b, int c, int expected)
        {
            int actual = GCD.Euclidean(a, b, c);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1, 2, 3, 4)]
        [TestCase(10, -150, -230, 650, 310)]
        [TestCase(1, 1, 2, 3, 4, 0)]
        public void Euclidean_AnyNumberOfNumbers(int expected, params int[] numbers)
        {
            Assert.AreEqual(expected, GCD.Euclidean(numbers));
        }

        [TestCase]
        public void Euclidean_NoArguments_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCD.Euclidean());
        }

        [TestCase(1, 10, 1)]
        [TestCase(5, 10, 5)]
        [TestCase(24, -24, 24)]
        [TestCase(0, 0, 0)]
        [TestCase(5, 0, 5)]
        [TestCase(0, 5, 5)]
        [TestCase(-5, 10, 5)]
        public void Binary_2ArgumentsThereIsAnswer(int a, int b, int expected)
        {
            int actual = GCD.Binary(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(720, 110, 540, 10)]
        [TestCase(24, 0, 48, 24)]
        [TestCase(5, -25, -10, 5)]
        [TestCase(-5, 10, 15, 5)]
        public void Binary_3ArgumentsThereIsAnswer(int a, int b, int c, int expected)
        {
            int actual = GCD.Binary(a, b, c);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 6, 9, 4, 4)]
        [TestCase(10, -150, -230, 650, 310)]
        [TestCase(1, 1, 2, 3, 4, 0)]
        public void Binary_AnyNumberOfNumbers(int expected, params int[] numbers)
        {
            Assert.AreEqual(expected, GCD.Binary(numbers));
        }

        [TestCase]
        public void Binary_NoArguments_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCD.Binary());
        }
    }
}

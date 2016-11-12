using System;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    class SquareTests
    {
        [Test, TestCaseSource(nameof(Data))]
        public void GeneralTest(double side)
        {
            var c = GetSquare(side);

            Console.WriteLine($"Area: {c.Area()}");
            Console.WriteLine($"Perimeter: {c.Perimeter()}");
            Console.WriteLine($"Incircle radius: {c.IncircleRadius()}");
            Console.WriteLine($"Circumcircle radius: {c.CircumcircleRadius()}");
        }

        [Test, TestCaseSource(nameof(Data))]
        public void Equls(double side)
        {
            var c = GetSquare(side);
            var c2 = GetSquare(side);

            Assert.IsTrue(c.Equals(c2));
        }

        private static Square GetSquare(double side) => new Square(side);

        private static readonly object[] Data =
        {
            new object[] {3},
            new object[] {15.2312}
        };
    }
}

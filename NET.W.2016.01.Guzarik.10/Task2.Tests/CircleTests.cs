using System;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class CircleTests
    {
        [Test, TestCaseSource(nameof(Data))]
        public void Test(double radius, double angle)
        {
            var c = GetCircle(radius);

            Console.WriteLine($"Area: {c.Area()}");
            Console.WriteLine($"Perimeter: {c.Perimeter()}");
            Console.WriteLine($"Sector: {c.Sector(angle)}");
            Console.WriteLine($"Segment: {c.Segment(angle)}");
        }

        [Test, TestCaseSource(nameof(Data))]
        public void Equals(double radius, double angle)
        {
            var c = GetCircle(radius);
            var c2 = GetCircle(radius);
            //var c2 = c;
            //var o = c;
            //var o2 = c2;

            Assert.IsTrue(c.Equals(c2));
            //Assert.IsTrue(o.Equals(o2));
        }

        private static Circle GetCircle(double radius) => new Circle(radius);

        private static readonly object[] Data =
        {
            new object[] {3, 540},
            new object[] {15.2312, 25}
        };
    }
}

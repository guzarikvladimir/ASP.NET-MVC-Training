using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    class TriangleTests
    {
        [Test]
        public void IsIsosceles()
        {
            const double side = 13.41 - 4.412;
            var a = new Triangle(side, 8, side);
            
            Assert.IsTrue(a.IsIsosceles());
        }

        [Test]
        public void IsEquilateral()
        {
            const double side = 13.41 - 4.412;
            var a = new Triangle(side, side, side);

            Assert.IsTrue(a.IsEquilateral());
        }
    }
}

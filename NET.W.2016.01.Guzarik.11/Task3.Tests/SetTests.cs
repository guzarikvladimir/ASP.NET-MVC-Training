using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task3.Tests
{
    [TestFixture]
    public class SetTests
    {
        [Test]
        public void Constructor_AddingEqualElementsAndCheckingCount_CountOfUniqueElements()
        {
            var set = new Set<string> {"one", "one", "two", "three", "four"};

            foreach (var variable in set)
            {
                Console.WriteLine(variable);
            }

            Assert.AreEqual(4, set.Count);
        }

        [Test]
        public void Remove_()
        {
            var set = new Set<string> { "one", "one", "two", "three", "four" };

            set.Remove("one");

            foreach (var variable in set)
            {
                Console.WriteLine(variable);
            }

            Assert.AreEqual(3, set.Count);
        }
    }

    class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point() : this(default(int), default(int)) { }
    }
}

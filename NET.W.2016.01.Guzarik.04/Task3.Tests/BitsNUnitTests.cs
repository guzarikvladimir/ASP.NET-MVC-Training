using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Tests
{
    [TestFixture]
    class BitsNUnitTests
    {
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(0, 15, 30, 30, ExpectedResult = 1073741824)]
        [TestCase(0, 15, 0, 30, ExpectedResult = 15)]
        [TestCase(15, -15, 0, 4, ExpectedResult = 31)]
        [TestCase(15, int.MaxValue, 3, 5, ExpectedResult = 63)]
        public int Insertion_NormalBehaviur_ChangedNumber(int a, int b, int i, int j)
        {
            return Bits.Insertion(a, b, i, j);
        }
    }
}

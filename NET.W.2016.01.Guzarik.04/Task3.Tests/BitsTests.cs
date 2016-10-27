using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task3.Tests
{
    [TestClass]
    public class BitsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Insertion_iBiggerThanj_ArgumentException()
        {
            Bits.Insertion(8, 15, 30, 0);
        }
    }

}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Text;

namespace TaskExtension.Tests
{
    [TestClass]
    public class DoubleExtensionTests
    {
        [TestMethod]
        public void GetBits()
        {
            double a = 2.4;
            BitArray expected = new BitArray(BitConverter.GetBytes(a));

            BitArray actual = a.GetBits();

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}

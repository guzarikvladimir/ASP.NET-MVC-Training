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
            BitArray bitArray = new BitArray(BitConverter.GetBytes(a));
            string expected = BitsToString(bitArray);

            BitArray bits = a.GetBits();
            string actual = BitsToString(bits);

            Assert.AreEqual(expected, actual);
            Console.WriteLine(expected);
        }

        private string BitsToString(BitArray bits)
        {
            StringBuilder str = new StringBuilder();

            foreach (bool b in bits)
                str.Append(b ? 1 : 0);

            return str.ToString();
        }
    }
}

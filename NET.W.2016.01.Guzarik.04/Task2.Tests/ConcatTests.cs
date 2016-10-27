using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.Tests
{
    [TestClass]
    public class ConcatTests
    {
        [TestMethod]
        public void ExceptRepeating_TwoExpectedStrings_ConcatedStringExceptRepeating()
        {
            string first = "xyaabbbccccdefww";
            string second = "xxxxyyyyabklmopq";

            string actualString = Concat.ExceptRepeating(first, second);

            Assert.AreEqual("abcdefklmopqwxy", actualString);
        }

        [TestMethod]
        public void ExceptRepeating_IdenticalStringsExceptRepeating_SortedString()
        {
            string first = "abcdefghijklmnopqrstuvwxyz";

            string actualString = Concat.ExceptRepeating(first, first);

            Assert.AreEqual("abcdefghijklmnopqrstuvwxyz", actualString);
        }

        [TestMethod]
        public void ExceptRepeating_IdenticalStringsWithRepeating_SortedStringExceptRepeating()
        {
            string first = "aabbccddeeffgghhiijjkkllmmnnooppqqrrssttuuvvwwxxyyzz";

            string actualString = Concat.ExceptRepeating(first, first);

            Assert.AreEqual("abcdefghijklmnopqrstuvwxyz", actualString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptRepeating_NullString_ArgumentNullException()
        {
            string first = null;
            string second = "It doesn't matter";

            Concat.ExceptRepeating(first, second);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptRepeating_IncorrectStrings_ArgumentException()
        {
            string first = "This is string with different incorrect symbols like 1, 2, 3, 4, 5";
            string second = "Icanbeanormalstringbutitdoesntmatter";

            Concat.ExceptRepeating(first, second);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptRepeating_StringWithUpperRegister_ArgumentException()
        {
            string first = "ImJustWithUpperRegister";

            Concat.ExceptRepeating(first, first);
        }
    }
}

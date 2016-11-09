using NUnit.Framework;
using System;

namespace Task1.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void ToString_AllFieldsWithStandardFormat()
        {
            var cust = GetCustomer();
            const string expected = "Jeffrey Richter, +1 (425) 555-0100, 1000000";

            var actual = cust.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Jeffrey Richter, 1000000", Feature.Name, Feature.Revenue)]
        [TestCase("1000000", Feature.Revenue)]
        public void ToString_DifferentFieldsWithStandardFormat(string expected, params Feature[] features)
        {
            var cust = GetCustomer();
            Assert.AreEqual(expected, cust.ToString(features));
        }

        [Test]
        public void ToString_BuiltInFormatRevenue()
        {
            const string expected = "1 000 000,00";
            var cust = GetCustomer();

            //Assert.IsTrue(expected.Equals(cust.ToString(null, "N", Feature.Revenue), StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(expected, cust.ToString(null, "N", Feature.Revenue));
        }

        [Test]
        public void ToString_CustomFormatRevenue()
        {
            const string expected = "1,000,000.00";
            var cust = GetCustomer();

            Assert.AreEqual(expected, string.Format(new CustomFormat(),
                "{0:REV1}", cust.Revenue));
        }

        private static Customer GetCustomer() => new Customer("Jeffrey Richter", 
            1000000, "+14255550100");
    }
}

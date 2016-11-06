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
            Customer cust = GetCustomer();
            string expected = "Jeffrey Richter, 1000000, +14255550100";

            string actual = cust.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Jeffrey Richter, 1000000", true, true, false)]
        [TestCase("1000000", false, true, false)]
        public void ToString_DifferentFieldsWithStandardFormat(string expected, 
            bool name, bool revenue, bool phone)
        {
            Customer cust = GetCustomer();

            Assert.AreEqual(expected, cust.ToString(name, revenue, phone));
        }

        [TestCase("+1 (425) 555-0100")]
        public void ToString_CustomFormatPhone(string expected)
        {
            Customer cust = GetCustomer();

            Assert.AreEqual(expected, String.Format(new CustomFormat(), 
                "{0:PHONE1}", cust.ContactPhone));
        }

        [TestCase("1,000,000.00")]
        public void ToString_CustomFormatRevenue(string expected)
        {
            Customer cust = GetCustomer();

            Assert.AreEqual(expected, String.Format(new CustomFormat(),
                "{0:REV1}", cust.Revenue));
        }

        private Customer GetCustomer() => new Customer("Jeffrey Richter", 
            1000000, "+14255550100");
    }
}

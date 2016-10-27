using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TaskNewton.Tests
{
    [TestClass]
    public class ComputeTests
    {
        [TestMethod]
        public void Sqrt_PositiveIntNumer81WhereNIs4_3()
        {
            double eps = 0.001;
            double actual = Compute.Sqrt(81, 4, eps);

            Assert.IsTrue(actual >= 3 - eps && actual <= 3 + eps);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Sqrt_NegativeNumber_ArgumentException()
        {
            Compute.Sqrt(-1);
        }
    }
}
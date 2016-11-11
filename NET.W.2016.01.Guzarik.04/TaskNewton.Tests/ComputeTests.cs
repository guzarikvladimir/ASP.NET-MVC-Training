using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TaskNewton.Tests
{
    [TestClass]
    public class ComputeTests
    {
        [TestMethod]
        public void Sqrt_PositiveNumer_()
        {
            double eps = 0.001;
            int pow = 11;
            double num = -323;
            double actual = Compute.Sqrt(num, pow, eps);
            Debug.WriteLine(actual);
            Assert.IsTrue(num <= Math.Pow(actual, pow) + eps 
                & num >= Math.Pow(actual, pow) - eps);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Sqrt_AccuracityBiggerThan1_ArgumentOutOfRangeException()
        {
            Compute.Sqrt(85, 5, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Sqrt_AccuracityEqualsTo0_ArgumentOutOfRangeException()
        {
            Compute.Sqrt(85, 5, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Sqrt_NegativeNumbersWithEvenPower_ArgumentException()
        {
            Compute.Sqrt(-1, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Sqrt_NegativePower_ArgumentOutOfRangeException()
        {
            Compute.Sqrt(1, -4);
        }
    }
}
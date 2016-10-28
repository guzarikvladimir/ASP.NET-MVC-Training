using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ElemWithEqualSumBothSides_NormalArrayWhenElementExists_ReturningIndexOfElement()
        {
            int[] array = new int[] { 1, 100, 50, -51, 1, 1 };

            int expectedElem = Find.ElemWithEqualSumBothSides(array);

            Assert.AreEqual(expectedElem, 1);
        }

        [TestMethod]
        public void ElemWithEqualSumBothSides_NormalArrayWhenElementDoesntExist_ReturningMinus1()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };

            int expectedElem = Find.ElemWithEqualSumBothSides(array);

            Assert.AreEqual(expectedElem, -1);
        }

        [TestMethod]
        public void ElemWithEqualSumBothSides_ArrayOfSize1_ReturningIndexOfElement0()
        {
            int[] array = new int[] { 1 };

            int expectedElem = Find.ElemWithEqualSumBothSides(array);

            Assert.AreEqual(expectedElem, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ElemWithEqualSumBothSides_NullArray_ArgumentNullException()
        {
            int[] array = null;

            Find.ElemWithEqualSumBothSides(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ElemWithEqualSumBothSides_ArraySizeBiggerThanNeeded_ArgumentOutOfRangeException()
        {
            int[] array = new int[1000];

            Find.ElemWithEqualSumBothSides(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ElemWithEqualSumBothSides_ArraySizeLessThanNeeded_ArgumentOutOfRangeException()
        {
            int[] array = new int[0];

            Find.ElemWithEqualSumBothSides(array);
        }

        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\Data.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("Task1.Tests\\Data.xml")]
        [TestMethod]
        public void DDT()
        {
            int[] arrayModel = new int[]
            {
                Convert.ToInt32(TestContext.DataRow["First"]),
                Convert.ToInt32(TestContext.DataRow["Second"]),
                Convert.ToInt32(TestContext.DataRow["Third"])
            };
            var expectedIndex = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            var actual = Find.ElemWithEqualSumBothSides(arrayModel);

            Assert.AreEqual(expectedIndex, actual);
        }
    }
}

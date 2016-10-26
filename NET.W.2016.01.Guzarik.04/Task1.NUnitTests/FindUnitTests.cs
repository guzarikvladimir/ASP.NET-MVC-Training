using NUnit.Framework;

namespace Task1.NUnitTests
{
    [TestFixture]
    public class FindUnitTests
    {
        [TestCase]
        public void ElemWithEqualSumBothSides_NormalArrayWhenElementExists_ReturningIndexOfElement_NUnit()
        {
            int[] array = new int[] { 1, 2, 3, 4, 3, 2, 1 };

            int actualIndex = Find.ElemWithEqualSumBothSides(array);

            Assert.AreEqual(3, actualIndex);
        }

        [Test, TestCaseSource("NormalArrayCases")]
        public void ElemWithEqualSumBothSides_NormalArraySize_ValidBorderSizeValue_NUnit(int[] array, int actualLength)
        {
            Assert.AreEqual(actualLength, array.Length);
        }
        static object[] NormalArrayCases =
        {
            new object[] { new int[1], 1 },
            new object[] { new int[999], 999 },
            new object[] { new int[500], 500 }
        };
    }
}

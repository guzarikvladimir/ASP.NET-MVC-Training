using NUnit.Framework;

namespace Poly.Tests
{
    [TestFixture]
    public class PolinomeTests
    {
        [Test, TestCaseSource("PolinomeOperators")]
        public void Operators_NormalCases_AreEqual(Polinome a, Polinome b, Polinome expected)
        {
            Assert.True(expected.Equals(a + b));
        }

        [Test, TestCaseSource("PolinomeToString")]
        public void ToString_(Polinome a, string expected)
        {
            string actual = a.ToString();

            StringAssert.AreEqualIgnoringCase(expected, actual);

        }

        [Test, TestCaseSource("PolinomeTrue")]
        public void Equals_SamePolinomes_True(Polinome a, Polinome b)
        {
            Assert.True(a.Equals(b));
        }

        [Test, TestCaseSource("PolinomeFalse")]
        public void Equals_DifferentPolimomes_False(Polinome a, Polinome b)
        {
            Assert.False(a.Equals(b));
        }

        [Test]
        public void Equals_Null_False()
        {
            Polinome p = new Polinome();

            Assert.False(p.Equals(null));
        }

        [Test]
        public void Indexer_ChangeValueByIndex_AreEqual()
        {
            Polinome p = new Polinome(0, 1.1, -2.2, 3.3, 4.4);
            int index = 1;
            double expected = 13.2;

            p[index] = expected;

            Assert.AreEqual(expected, p[index]); 
        }

        [Test]
        public void Indexer_GetValueByIndex_AreEqual()
        {
            Polinome p = new Polinome(0, 1.1, -2.2, 3.3, 4.4);
            int index = 1;

            double expected = p[index];

            Assert.AreEqual(expected, p[index]);
        }

        public Polinome GetPolinome() => new Polinome(0, 1.1, -2.2, 3.3, 4.4);

        static object[] PolinomeTrue = new object[]
        {
            new object[] { new Polinome(0, 1.1, -2.2, 3.3, 4.4), new Polinome(0, 1.1, -2.2, 3.3, 4.4) },
            new object[] { new Polinome(), new Polinome() }
        };

        static object[] PolinomeFalse = new object[]
        {
            new object[] { new Polinome(0, 1.1, -2.2, 3.3, 4.4), new Polinome(0, -1.1, 2.2, -3.3, 4.4) }
        };

        static object[] PolinomeToString = new object[]
        {
            new object[] { new Polinome(0, 1.1, -2.2, 3.3, 4.4), "4,4x^4+3,3x^3-2,2x^2+1,1x" }
        };

        static object[] PolinomeOperators = new object[]
        {
            new object[] { new Polinome(0, 1.1, -2.2, 3.3, 4.4), new Polinome(1.0, 1.1, 2.2, 3.3, 4.4), new Polinome(1.0, 2.2, 0, 6.6, 8.8) }
        };

        static object[] PolinomePlusNumber = new object[]
        {
            new object[] { new Polinome(0, 1.1, -2.2, 3.3, 4.4), new Polinome(3.0, 4.1, 0.8, 6.3, 7.4) }
        };
    }
}

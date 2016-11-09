using NUnit.Framework;
using System;

namespace Poly.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        private static Polynomial Polynomial1 => new Polynomial(1.1, -2.2, 3.3, -4.4, 0, 6.6);
        private static Polynomial GetPolynomial2() => new Polynomial(0, 0, 0, 0, 0, 0);

        [Test]
        public void ToString_NormalCase()
        {
            Polynomial a = Polynomial1;
            string expected = "6,6x^5-4,4x^3+3,3x^2-2,2x+1,1";

            string actual = a.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Equals_EqualPolynomials_True()
        {
            Polynomial a = Polynomial1;
            Polynomial b = Polynomial1;

            Assert.True(a.Equals(b));
        }

        [Test]
        public void Equals_Null_False()
        {
            Polynomial a = Polynomial1;

            Assert.False(a.Equals(null));
        }

        [Test]
        public void Equals_DifferentPolynomials_False()
        {
            Polynomial a = Polynomial1;
            Polynomial b = GetPolynomial2();

            Assert.False(a.Equals(b));
        }

        [Test]
        public void GetHashCode_EqualPolynomials_EqualHash()
        {
            Polynomial a = Polynomial1;
            Polynomial b = Polynomial1;

            Console.WriteLine($"{a.GetHashCode()}\t{b.GetHashCode()}");
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [Test]
        public void GetHashCode_DifferentPolynomes_DifferentHash()
        {
            Polynomial a = Polynomial1;
            Polynomial b = GetPolynomial2();

            Console.WriteLine($"{a.GetHashCode()}\t{b.GetHashCode()}");
            Assert.AreNotEqual(a.GetHashCode(), b.GetHashCode());
        }

        [Test, TestCaseSource(nameof(AddCases))]
        public void Add_(dynamic a, dynamic b, Polynomial expected)
        {
            Polynomial actual = a + b;
            //Polynomial actual = Polynomial.Add(a, b);

            Console.WriteLine($"{expected}\t{actual}");
            Assert.True(expected.Equals(actual));
        }

        [Test, TestCaseSource(nameof(SubCases))]
        public void Subtract_(dynamic a, dynamic b, Polynomial expected)
        {
            Polynomial actual = a - b;
            //Polynomial actual = Polynomial.Subtract(a, b);

            Console.WriteLine($"{expected}\t{actual}");
            Assert.True(expected.Equals(actual));
        }

        [Test]
        public void Increment()
        {
            Polynomial a = new Polynomial(1, 2, 3, 0, 4, 5);
            Polynomial expected = new Polynomial(2, 3, 4, 1, 5, 6);

            //Polynomial actual = a++;
            Polynomial actual = a.Increment();

            Assert.True(expected.Equals(actual));
        }
        
        [Test]
        public void Decrement()
        {
            Polynomial a = new Polynomial(1, 2, 3, 0, 4, 5);
            Polynomial expected = new Polynomial(0, 1, 2, -1, 3, 4);

            //Polynomial actual = a--;
            Polynomial actual = a.Decrement();

            Assert.True(expected.Equals(actual));
        }

        [TestCase(20)]
        [TestCase(-1)]
        public void Indexer_OutOfRange_ArgumentOutOfRangeException(int index)
        {
            var a = Polynomial1;

            Assert.Throws<ArgumentOutOfRangeException>(() => {
                var d = a[index];
            });
        }

        static object[] AddCases = new object[]
        {
            new object[] { new Polynomial(1.1, -2.2, 3.3, 0, 4.4), new Polynomial(4.6, 2.5, -5.1, 4.3) ,
                new Polynomial(5.7, 0.3, -1.8, 4.3, 4.4) },
            new object[] { new Polynomial(1.1, -2.2, 3.3, 0, 4.4), 6.6,
                new Polynomial(7.7, 4.4, 9.9, 6.6, 11.0 ) },
            new object[] { 6.6, new Polynomial(1.1, -2.2, 3.3, 0, 4.4),
                new Polynomial(7.7, 4.4, 9.9, 6.6, 11.0 ) }
        };

        static object[] SubCases = new object[]
        {
            new object[] { new Polynomial(1.1, -2.2, 3.3, 0, 4.4), new Polynomial(4.6, 2.5, -5.1, 4.3) ,
                new Polynomial(-3.5, -4.7, 8.4, -4.3, 4.4) },
            new object[] { new Polynomial(1.1, -2.2, 3.3, 0, 4.4), 6.6,
                new Polynomial(-5.5, -8.8, -3.3, -6.6, -2.2 ) },
            new object[] { 6.6, new Polynomial(1.1, -2.2, 3.3, 0, 4.4),
                new Polynomial(5.5, 8.8, 3.3, 6.6, 2.2 ) }
        };
    }
}

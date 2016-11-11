using System;
using System.Diagnostics;

namespace GCD
{
    /// <summary>
    /// Class for finding the greatest common divisor of integers
    /// </summary>
    public static class Gcd
    {
        /// <summary>
        /// Finding GCD for two arguments by Euclidean
        /// </summary>
        public static int Euclidean(int a, int b) => GCD(EuclideanHelper, a, b);
        /// <summary>
        /// Finding GCD for three arguments by Euclidean
        /// </summary>
        public static int Euclidean(int a, int b, int c) => GCD(EuclideanHelper, a, b, c);
        /// <summary>
        /// Finding GCD for several arguments by Euclidean
        /// </summary>
        public static int Euclidean(params int[] numbers) => GCD(EuclideanHelper, numbers);
        /// <summary>
        /// Finding GCD for two arguments by Euclidean with ticks
        /// </summary>
        public static int Euclidean(int a, int b, out long ticks) => GCD(EuclideanHelper, out ticks, a, b);
        /// <summary>
        /// Finding GCD for three arguments by Euclidean with ticks
        /// </summary>
        public static int Euclidean(int a, int b, int c, out long ticks) => GCD(EuclideanHelper, out ticks, a, b, c);
        /// <summary>
        /// Finding GCD for several arguments by Euclidean with ticks
        /// </summary>
        public static int Euclidean(out long ticks, params int[] numbers) => GCD(EuclideanHelper, out ticks, numbers);
        /// <summary>
        /// Finding GCD for two arguments by Euclidean-Stein
        /// </summary>
        public static int Binary(int a, int b) => GCD(BinaryHelper, a, b);
        /// <summary>
        /// Finding GCD for three arguments by Euclidean-Stein
        /// </summary>
        public static int Binary(int a, int b, int c) => GCD(BinaryHelper, a, b, c);
        /// <summary>
        /// Finding GCD for several arguments by Euclidean-Stein
        /// </summary>
        public static int Binary(int[] numbers) => GCD(BinaryHelper, numbers);
        /// <summary>
        /// Finding GCD for two arguments by Euclidean-Stein with ticks
        /// </summary>
        public static int Binary(int a, int b, out long ticks) => GCD(BinaryHelper, out ticks, a, b);
        /// <summary>
        /// Finding GCD for three arguments by Euclidean-Stein with ticks
        /// </summary>
        public static int Binary(int a, int b, int c, out long ticks) => GCD(BinaryHelper, out ticks, a, b, c);
        /// <summary>
        /// Finding GCD for several arguments by Euclidean-Stein with ticks
        /// </summary>
        public static int Binary(out long ticks, params int[] numbers) => GCD(BinaryHelper, out ticks, numbers);

        #region 

        private static int GCD(Func<int, int, int> method, int a, int b) => method.Invoke(a, b);
        private static int GCD(Func<int, int, int> method, int a, int b, int c)
        {
            var gcd = method.Invoke(a, b);
            gcd = method.Invoke(gcd, c);

            return gcd;
        }
        private static int GCD(Func<int, int, int> method, params int[] numbers)
        {
            if (ReferenceEquals(numbers, null))
                throw new ArgumentNullException();
            if (numbers.Length == 0)
                throw new ArgumentException();

            var gcd = numbers[0];
            for (var i = 0; i < numbers.Length - 1; i++)
                gcd = method.Invoke(gcd, numbers[i + 1]);

            return gcd;
        }
        private static int GCD(Func<int, int, int> method, out long ticks, int a, int b)
        {
            var sw = new Stopwatch();
            sw.Start();
            var gcd = method.Invoke(a, b);
            sw.Stop();

            ticks = sw.Elapsed.Ticks;

            return gcd;
        }
        private static int GCD(Func<int, int, int> method, out long ticks, int a, int b, int c)
        {
            var sw = new Stopwatch();
            sw.Start();
            var gcd = method.Invoke(a, b);
            gcd = method.Invoke(gcd, c);
            sw.Stop();

            ticks = sw.Elapsed.Ticks;

            return gcd;
        }
        private static int GCD(Func<int, int, int> method, out long ticks, params int[] numbers)
        {
            if (numbers.Length == 0)
                throw new ArgumentException();

            var sw = new Stopwatch();
            sw.Start();
            var gcd = numbers[0];
            for (var i = 0; i < numbers.Length - 1; i++)
                gcd = method.Invoke(gcd, numbers[i + 1]);
            sw.Stop();

            ticks = sw.Elapsed.Ticks;

            return gcd;
        }

        #endregion

        #region Почему бы не использовать эти 2 метода вместо 6 выше?

        //private static int GCD(Func<int, int, int> method, params int[] numbers)
        //{
        //    if (ReferenceEquals(numbers, null))
        //        throw new ArgumentNullException();
        //    if (numbers.Length == 0)
        //        throw new ArgumentException();

        //    var gcd = numbers[0];
        //    for (var i = 0; i < numbers.Length - 1; i++)
        //        gcd = method.Invoke(gcd, numbers[i + 1]);

        //    return gcd;
        //}

        //private static int GCD(Func<int, int, int> method, out long ticks, params int[] numbers)
        //{
        //    if (numbers.Length == 0)
        //        throw new ArgumentException();

        //    var sw = new Stopwatch();
        //    sw.Start();
        //    var gcd = Euclidean(numbers);
        //    sw.Stop();

        //    ticks = sw.Elapsed.Ticks;

        //    return gcd;
        //}

        #endregion

        private static int EuclideanHelper(int a, int b)
        {
            while (b != 0)
            {
                var tmp = b;
                b = a % b;
                a = tmp;
            }

            return Math.Abs(a);
        }
        private static int BinaryHelper(int a, int b)
        {
            if (a == b)
                return a;

            if (a == 0)
                return b;

            if (b == 0)
                return a;

            a = Math.Abs(a);
            b = Math.Abs(b);

            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                    return Binary(a >> 1, b);
                else
                    return Binary(a >> 1, b >> 1) << 1;
            }

            if ((~b & 1) != 0)
                return Binary(a, b >> 1);

            if (a > b)
                return Binary((a - b) >> 1, b);

            return Binary((b - a) >> 1, a);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    /// <summary>
    /// Класс для нахождение наибольшего общего делителя целых чисел
    /// </summary>
    public static class GCD
    {
        static Stopwatch sw = new Stopwatch();
        
        /// <summary>
        /// Позволяет узнать время выполнения последнего использованного метода класса GCD
        /// </summary>
        /// <returns>Время выполнения последнего метода</returns>
        public static int GetLastMethodTime()
        {
            return sw.Elapsed.Minutes * 60 + sw.Elapsed.Seconds;
        }

        /// <summary>
        /// Находит НОД двух целых чисел методом Евклида
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Наибольшее общее кратное двух чисел</returns>
        public static int Euclidean(int a, int b)
        {
            sw.Reset();
            sw.Start();
            int gcd = EuclideanIteration(a, b);
            sw.Stop();

            return Math.Abs(gcd);
        }

        /// <summary>
        /// Находит НОД трех целых чисел методом Евклида
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="c">Третье число</param>
        /// <returns>Наибольшее общее кратное трех чисел</returns>
        public static int Euclidean(int a, int b, int c)
        {
            sw.Reset();
            sw.Start();
            int gcd = EuclideanIteration(a, b);
            gcd = EuclideanIteration(gcd, c);
            sw.Stop();

            return Math.Abs(gcd);
        }

        /// <summary>
        /// Находит НОД произвольного количества целых чисел методом Евклида
        /// </summary>
        /// <param name = "numbers" > Произвольное количество целых чисел</param>
        /// <returns>Наибольшее общее кратное чисел</returns>
        /// <exception cref = "ArgumentException" > Происходит, если не передано ни одного аргумента</exception>
        public static int Euclidean(params int[] numbers)
        {
            if (numbers.Length == 0)
                throw new ArgumentException();

            sw.Reset();
            sw.Start();
            int gcd = numbers[0];
            for (int i = 0; i < numbers.Length - 1; i++)
                gcd = EuclideanIteration(gcd, numbers[i + 1]);
            sw.Stop();

            return Math.Abs(gcd);
        }

        /// <summary>
        /// Находит НОД двух целых чисел методом Стейна (бинарный алгоритм Евклида)
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Наибольшее общее кратное двух чисел</returns>
        public static int Binary(int a, int b)
        {
            sw.Reset();
            sw.Start();
            int gcd = BinaryIteration(a, b);
            sw.Stop();

            return Math.Abs(gcd);
        }

        /// <summary>
        /// Находит НОД трех целых чисел методом Стейна (бинарный алгоритм Евклида)
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="c">Третье число</param>
        /// <returns>Наибольшее общее кратное трех чисел</returns>
        public static int Binary(int a, int b, int c)
        {
            sw.Reset();
            sw.Start();
            int gcd = BinaryIteration(a, b);
            gcd = BinaryIteration(gcd, c);
            sw.Stop();

            return Math.Abs(gcd);
        }

        /// <summary>
        /// Находит НОД произвольного количества целых чисел методом Стейна (бинарный алгоритм Евклида)
        /// </summary>
        /// <param name="numbers">Произвольное количество целых чисел</param>
        /// <returns>Наибольшее общее кратное чисел</returns>
        /// <exception cref="ArgumentException">Происходит, если не передано ни одного аргумента</exception>
        public static int Binary(params int[] numbers)
        {
            if (numbers.Length == 0)
                throw new ArgumentException();

            int gcd = numbers[0];
            for (int i = 0; i < numbers.Length - 1; i++)
                gcd = BinaryIteration(gcd, numbers[i + 1]);

            return Math.Abs(gcd);
        }

        /// <summary>
        /// Выисляет НОД двух целых чисел методом Евклида
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Наибольшее общее кратное двух чисел</returns>
        private static int EuclideanIteration(int a, int b)
        {
            int tmp;

            while (b != 0)
            {
                tmp = b;
                b = a % b;
                a = tmp;
            }

            return a;
        }

        /// <summary>
        /// Находит НОД двух целых чисел методом Стейна (бинарный алгоритм Евклида)
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Наибольшее общее кратное двух чисел</returns>
        public static int BinaryIteration(int a, int b)
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

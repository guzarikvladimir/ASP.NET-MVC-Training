﻿using System;
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
        /// <summary>
        /// Находит НОД двух целых чисел методом Евклида
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Наибольшее общее кратное двух чисел</returns>
        public static int Euclidean(int a, int b)
        {
            int tmp;

            while (b != 0)
            {
                tmp = b;
                b = a % b;
                a = tmp;
            }

            return Math.Abs(a);
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
            int gcd = Euclidean(a, b);
            gcd = Euclidean(gcd, c);

            return gcd;
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

            int gcd = numbers[0];
            for (int i = 0; i < numbers.Length - 1; i++)
                gcd = Euclidean(gcd, numbers[i + 1]);

            return gcd;
        }

        /// <summary>
        /// Находит НОД двух целых чисел методом Евклида с вычислением времени выполнения
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="ticks">Количество тактов</param>
        /// <returns>Наибольшее общее кратное двух чисел</returns>
        public static int Euclidean(int a, int b, out long ticks)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int gcd = Euclidean(a, b);
            sw.Stop();

            ticks = ((TimeSpan)sw.Elapsed).Ticks;

            return gcd;
        }

        /// <summary>
        /// Находит НОД трех целых чисел методом Евклида с вычислением времени выполнения
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="c">Третье число</param>
        /// <param name="ticks">Количество тактов</param>
        /// <returns>Наибольшее общее кратное трех чисел</returns>
        public static int Euclidean(int a, int b, int c, out long ticks)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int gcd = Euclidean(a, b, c);
            sw.Stop();

            ticks = ((TimeSpan)sw.Elapsed).Ticks;

            return gcd;
        }

        /// <summary>
        /// Находит НОД произвольного количества целых чисел методом Евклида с вычислением времени выполнения
        /// </summary>
        /// <param name="ticks">Количество тактов</param>
        /// <param name = "numbers" > Произвольное количество целых чисел</param>
        /// <returns>Наибольшее общее кратное чисел</returns>
        /// <exception cref = "ArgumentException" > Происходит, если не передано ни одного аргумента</exception>
        public static int Euclidean(out long ticks, params int[] numbers)
        {
            if (numbers.Length == 0)
                throw new ArgumentException();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            int gcd = Euclidean(numbers);
            sw.Stop();

            ticks = ((TimeSpan)sw.Elapsed).Ticks;

            return gcd;
        }

        /// <summary>
        /// Находит НОД двух целых чисел методом Стейна (бинарный алгоритм Евклида)
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Наибольшее общее кратное двух чисел</returns>
        public static int Binary(int a, int b)
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

        /// <summary>
        /// Находит НОД трех целых чисел методом Стейна (бинарный алгоритм Евклида)
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="c">Третье число</param>
        /// <returns>Наибольшее общее кратное трех чисел</returns>
        public static int Binary(int a, int b, int c)
        {
            int gcd = Binary(a, b);
            gcd = Binary(gcd, c);

            return gcd;
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
                gcd = Binary(gcd, numbers[i + 1]);

            return gcd;
        }

        /// <summary>
        /// Находит НОД двух целых чисел методом Стейна (бинарный алгоритм Евклида) с вычислением времени выполнения
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="ticks">Количество тактов</param>
        /// <returns>Наибольшее общее кратное двух чисел</returns>
        public static int Binary(int a, int b, out long ticks)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int gcd = Binary(a, b);
            sw.Stop();

            ticks = ((TimeSpan)sw.Elapsed).Ticks;

            return gcd;
        }

        /// <summary>
        /// Находит НОД трех целых чисел методом Стейна (бинарный алгоритм Евклида) с вычислением времени выполнения
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="c">Третье число</param>
        /// <param name="ticks">Количество тактов</param>
        /// <returns>Наибольшее общее кратное трех чисел</returns>
        public static int Binary(int a, int b, int c, out long ticks)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int gcd = Binary(a, b, c);
            sw.Stop();

            ticks = ((TimeSpan)sw.Elapsed).Ticks;

            return gcd;
        }

        /// <summary>
        /// Находит НОД произвольного количества целых чисел методом Стейна (бинарный алгоритм Евклида) с вычислением времени выполнения
        /// </summary>
        /// <param name="ticks">Количество тактов</param>
        /// <param name="numbers">Произвольное количество целых чисел</param>
        /// <returns>Наибольшее общее кратное чисел</returns>
        /// <exception cref="ArgumentException">Происходит, если не передано ни одного аргумента</exception>
        public static int Binary(out long ticks, params int[] numbers)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int gcd = Binary(numbers);
            sw.Stop();

            ticks = ((TimeSpan)sw.Elapsed).Ticks;

            return gcd;
        }
    }
}
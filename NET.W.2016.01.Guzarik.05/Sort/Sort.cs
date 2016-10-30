using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    /// <summary>
    /// Класс, содержащий различные сортировки непрямоугольного целочисленного массива
    /// </summary>
    public static class Sort
    {
        /// <summary>
        /// Сотрирует строки матрицы в порядке возрастания сумм элементов строк
        /// </summary>
        /// <param name="array">Непрямоугольный целочисленный массив</param>
        /// <exception cref="ArgumentNullException">Происходит, если на вход подается null массив</exception>
        public static void Sum(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            Sum(array, Sum);
        }

        /// <summary>
        /// Сотрирует строки матрицы в порядке убывания сумм элементов строк
        /// </summary>
        /// <param name="array">Непрямоугольный целочисленный массив</param>
        /// <exception cref="ArgumentNullException">Происходит, если на вход подается null массив</exception>
        public static void SumReverse(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            Sum(array, SumReverse);
        }

        /// <summary>
        /// Метод, в котором собственно и реализуется алгоритм сортировки по суммам
        /// </summary>
        /// <param name="array">Непрямоугольный целочисленный массив</param>
        /// <param name="res">Метод сравнения</param>
        private static void Sum(int[][] array, Func<long, long, bool> res)
        {
            bool flag = true;

            while (flag)
            {
                flag = false;

                for (int i = 1; i < array.Length; i++)
                {
                    long sumCur = 0;
                    long sumPrev = 0;

                    for (int j = 0; j < array[i].Length; j++)
                        checked { sumCur += array[i][j]; }

                    for (int j = 0; j < array[i - 1].Length; j++)
                        checked { sumPrev += array[i - 1][j]; }

                    if (res(sumCur, sumPrev))
                    {
                        flag = true;
                        int[] tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                    }
                }
            }
        }
        private static bool Sum(long sumCur, long sumPrev)
        {
            return sumCur < sumPrev;
        }
        private static bool SumReverse(long sumCur, long sumPrev)
        {
            return sumCur > sumPrev;
        }

        /// <summary>
        /// Сотрирует строки матрицы в порядке возрастания максимальных элементов строк
        /// </summary>
        /// <param name="array">Непрямоугольный целочисленный массив</param>
        /// <exception cref="ArgumentNullException">Происходит, если на вход подается null массив</exception>
        public static void Max(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            Max(array, Max);
        }

        /// <summary>
        /// Сотрирует строки матрицы в порядке убывания максимальных элементов строк
        /// </summary>
        /// <param name="array">Непрямоугольный целочисленный массив</param>
        /// <exception cref="ArgumentNullException">Происходит, если на вход подается null массив</exception>
        public static void MaxReverse(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            Max(array, MaxReverse);
        }

        /// <summary>
        /// Метод, в котором собственно и реализуется алгоритм сортировки по максимальным элементам
        /// </summary>
        /// <param name="array">Непрямоугольный целочисленный массив</param>
        /// <param name="res">Метод сравнения</param>
        private static void Max(int[][] array, Func<int, int, bool> res)
        {
            bool flag = true;

            while (flag)
            {
                flag = false;

                for (int i = 1; i < array.Length; i++)
                {
                    int maxCur = array[i][0];
                    int maxPrev = array[i - 1][0];

                    for (int j = 1; j < array[i].Length; j++)
                        if (maxCur < array[i][j])
                            maxCur = array[i][j];

                    for (int j = 1; j < array[i - 1].Length; j++)
                        if (maxPrev < array[i - 1][j])
                            maxPrev = array[i - 1][j];

                    if (res(maxCur, maxPrev))
                    {
                        flag = true;
                        int[] tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                    }
                }
            }
        }
        private static bool Max(int maxCur, int maxPrev)
        {
            return maxCur < maxPrev;
        }
        private static bool MaxReverse(int maxCur, int maxPrev)
        {
            return maxCur > maxPrev;
        }

        /// <summary>
        /// Сотрирует строки матрицы в порядке возрастания минимальнцых элементов строк
        /// </summary>
        /// <param name="array">Непрямоугольный целочисленный массив</param>
        /// <exception cref="ArgumentNullException">Происходит, если на вход подается null массив</exception>
        public static void Min(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            Min(array, Min);
        }

        /// <summary>
        /// Сотрирует строки матрицы в порядке убывания минимальных элементов строк
        /// </summary>
        /// <param name="array">Непрямоугольный целочисленный массив</param>
        /// <exception cref="ArgumentNullException">Происходит, если на вход подается null массив</exception>
        public static void MinReverse(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            Min(array, MinReverse);
        }

        /// <summary>
        /// Метод, в котором собственно и реализуется алгоритм сортировки по минимальным элементам
        /// </summary>
        /// <param name="array">Непрямоугольный целочисленный массив</param>
        /// <param name="res">Метод сравнения</param>
        private static void Min(int[][] array, Func<int, int, bool> res)
        {
            bool flag = true;

            while (flag)
            {
                flag = false;

                for (int i = 1; i < array.Length; i++)
                {
                    int minCur = array[i][0];
                    int minPrev = array[i - 1][0];

                    for (int j = 1; j < array[i].Length; j++)
                        if (minCur > array[i][j])
                            minCur = array[i][j];

                    for (int j = 1; j < array[i - 1].Length; j++)
                        if (minPrev > array[i - 1][j])
                            minPrev = array[i - 1][j];

                    if (res(minCur, minPrev))
                    {
                        flag = true;
                        int[] tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                    }
                }
            }
        }
        private static bool Min(int minCur, int minPrev)
        {
            return minCur < minPrev;
        }
        private static bool MinReverse(int minCur, int minPrev)
        {
            return minCur > minPrev;
        }
    }
}

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

                    if (sumCur < sumPrev)
                    {
                        flag = true;
                        int[] tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                    }
                }
            }
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

                    if (sumCur > sumPrev)
                    {
                        flag = true;
                        int[] tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                    }
                }
            }
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

                    if (maxCur < maxPrev)
                    {
                        flag = true;
                        int[] tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                    }
                }
            }
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

                    if (maxCur > maxPrev)
                    {
                        flag = true;
                        int[] tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                    }
                }
            }
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

                    if (minCur < minPrev)
                    {
                        flag = true;
                        int[] tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                    }
                }
            }
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

                    if (minCur > minPrev)
                    {
                        flag = true;
                        int[] tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                    }
                }
            }
        }
    }
}

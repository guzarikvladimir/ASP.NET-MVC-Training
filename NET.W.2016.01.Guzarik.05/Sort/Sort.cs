using System;
using System.Collections.Generic;

namespace Sort
{
    /// <summary>
    /// Класс, содержащий различные сортировки непрямоугольного целочисленного массива
    /// </summary>
    public static class Sort
    {
        /// <summary>
        /// Сортировка целочисленного непрямоугольного массива пузырьком заданным образом
        /// </summary>
        /// <param name="array">Непрямоугольный целочисленный массив</param>
        /// <param name="comp">Класс, реализующий метод сравнения</param>
        public static void Bubble(int[][] array, IComparer<int[]> comp)
        {
            var flag = true;

            while (flag)
            {
                flag = false;

                for (var i = 0; i < array.Length - 1; i++)
                {
                    if (comp.Compare(array[i], array[i + 1]) <= 0) continue;
                    flag = true;
                    Swap(ref array[i], ref array[i + 1]);
                }
            }
        }
        /// <summary>
        /// Сортировка целочисленного непрямоугольного массива пузырьком заданным образом
        /// </summary>
        /// <param name="array">Непрямоугольный целочисленный массив</param>
        /// <param name="comp">Метод, реализующий логику сортировки</param>
        public static void Bubble(int[][] array, Comparison<int[]> comp)
        {
            
        }

        /// <summary>
        /// Метод, осуществляющий обмен элементов
        /// </summary>
        private static void Swap(ref int[] a, ref int[] b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
    }
}

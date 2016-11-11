using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    /// <summary>
    /// Класс, содержащий различные сортировки непрямоугольного целочисленного массива
    /// </summary>
    public static class Sort2
    {
        /// <summary>
        /// Сортировка целочисленного непрямоугольного массива пузырьком заданным образом
        /// </summary>
        /// <param name="array">Непрямоугольный целочисленный массив</param>
        /// <param name="comp">Класс, реализующий метод сравнения</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Bubble(int[][] array, IComparer<int[]> comp)
        {
            if (ReferenceEquals(comp, null))
                throw new ArgumentNullException();
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException();

            Bubble(array, comp.Compare);
        }
        /// <summary>
        /// Сортировка целочисленного непрямоугольного массива пузырьком заданным образом
        /// </summary>
        /// <param name="array">Непрямоугольный целочисленный массив</param>
        /// <param name="comp">Метод, реализующий логику сортировки</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Bubble(int[][] array, Comparison<int[]> comp)
        {
            if (ReferenceEquals(comp, null))
                throw new ArgumentNullException();
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException();

            var flag = true;

            while (flag)
            {
                flag = false;

                for (var i = 0; i < array.Length - 1; i++)
                {
                    if (comp(array[i], array[i + 1]) <= 0) continue;
                    flag = true;
                    Swap(ref array[i], ref array[i + 1]);
                }
            }
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

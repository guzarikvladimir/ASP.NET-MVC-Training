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
        /// Сортировка целочисленного непрямоугольного массива пузырьком заданным образом
        /// </summary>
        /// <param name="array">Непрямоугольный целочисленный массив</param>
        /// <param name="comp"></param>
        public static void Bubble(int[][] array, IComparer comp)
        {
            bool flag = true;

            while (flag)
            {
                flag = false;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (comp.Compare(array[i], array[i + 1]) > 0)
                    {
                        flag = true;
                        Swap(ref array[i], ref array[i + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Метод, осуществляющий обмен элементов
        /// </summary>
        /// <param name="a">Первый целочисленный массив</param>
        /// <param name="b">Второй целочисленный массив</param>
        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] tmp = a;
            a = b;
            b = tmp;
        }
    }
}

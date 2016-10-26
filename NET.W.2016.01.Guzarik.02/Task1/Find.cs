using System;

namespace Task1
{
    /// <summary>
    /// Класс для поиска в массиве специальных элементов
    /// </summary>
    public static class Find
    {
        /// <summary>
        /// Метод для поиска индекса элемента, для которого сумма элементов слева от него равна сумме элементов справа.
        /// </summary>
        /// <param name="arr">Целочисленный массив длины (0, 1000)</param>
        /// <returns>Наименьший индекс, для которого сторона слева равна стороне справа.
        /// Если такого индекса не существует возвращает -1</returns>
        /// <exception cref="ArgumentOutOfRangeException">Происходит, если длина массива находится вне границ</exception>
        /// <exception cref="ArgumentNullException">Происходит, если на вход функции подается null массив</exception>
        public static int ElemWithEqualSumBothSides(int[] arr)
        {
            if (ReferenceEquals(arr, null))
                throw new ArgumentNullException();

            if (arr.Length < 1 || arr.Length > 999)
                throw new ArgumentOutOfRangeException();

            if (arr.Length == 1)
                return 0;

            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (Sum(arr, 0, i - 1) == Sum(arr, i + 1, arr.Length - 1))
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Вспомогательный метод подсчета суммы
        /// </summary>
        /// <param name="arr">Целочисленный массив</param>
        /// <param name="first">Первый элемент</param>
        /// <param name="last">Второй элемент</param>
        /// <returns>Сумма элементов между первым входным и вторым</returns>
        private static int Sum(int[] arr, int first, int last)
        {
            int sum = 0;

            for (int i = first; i <= last; i++)
                sum += arr[i];

            return sum;
        }
    }
}

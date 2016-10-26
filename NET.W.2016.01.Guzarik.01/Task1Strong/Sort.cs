namespace Task1Strong
{
    /// <summary>
    /// Статический класс, содержащий различные виды сортировок
    /// </summary>
    public static class Sort
    {
        /// <summary>
        /// Открытый метод быстрой сортировки
        /// </summary>
        /// <param name="arr">Целочисленный массив</param>
        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        /// <summary>
        /// Скрытый метод быстрой сортирвки
        /// </summary>
        /// <param name="arr">Целочисленный массив</param>
        /// <param name="first">Левая граница</param>
        /// <param name="last">Правая граница</param>
        private static void QuickSort(int[] arr, int first, int last)
        {
            int p = arr[(last - first) / 2 + first];
            int temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (arr[i] < p && i <= last) ++i;
                while (arr[j] > p && j >= first) --j;
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    ++i;
                    --j;
                }
            }
            if (j > first) QuickSort(arr, first, j);
            if (i < last) QuickSort(arr, i, last);
        }
    }
}

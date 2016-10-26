using System;
using System.Diagnostics;

namespace Task1.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10000000];
            Random rand = new Random();
            for (int i = 0; i < array.Length - 1; i++)
                array[i] = rand.Next(1000000);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Sort.QuickSort(array);
            sw.Stop();
            Console.WriteLine($"Время сортировки:  {sw.Elapsed.Seconds} сек.");

            Console.ReadKey();
        }
    }
}

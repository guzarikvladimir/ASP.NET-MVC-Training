using System;
using Task1;
using Task2;
using Task3;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Task1 */

            int[] arr = null;
            int[] arr1 = new int[100];
            int[] arr2 = new int[] { 1, 2, 3, 4, 3, 2, 1 };
            int[] arr3 = new int[] { 1, 100, 50, -51, 1, 1};

            Random rand = new Random();

            for (int i = 0; i < arr1.Length; i++)
                arr1[i] = rand.Next(-100, 100);

            try
            {
                Console.WriteLine($"Индекс массива 1: {Find.ElemWithEqualSumBothSides(arr)}");
                Console.WriteLine($"Индекс массива 2: {Find.ElemWithEqualSumBothSides(arr2)}");
                Console.WriteLine($"Индекс массива 3: {Find.ElemWithEqualSumBothSides(arr3)}");
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (ArgumentNullException exc)
            {
                Console.WriteLine(exc.Message);
            }

            Console.WriteLine();

            /* Task2 */

            string str1 = "xyaabbbccccdefww";
            string str2 = "xxxxyyyyabklmopq";
            string str3 = "abcdefghijklmnopqrstuvwxyz";

            Console.WriteLine($"Строка 1: {str1}");
            Console.WriteLine($"Строка 2: {str2}");
            Console.WriteLine($"Строка 3: {str3}");

            try
            {
                Console.WriteLine($"Результивная строка 1 и 2: {Concat.ExceptRepeating(str1, str2)}");
                Console.WriteLine($"Результивная строка 3 и 3: {Concat.ExceptRepeating(str3, str3)}");
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.Message);
            }

            /* Task3 */

            int n1 = 0;
            int n2 = 15;

            Console.WriteLine($"Строка 1: {n1}");
            Console.WriteLine($"Строка 2: {n2}");

            try
            {
                Console.WriteLine($"Результивная строка 1 и 2: {Bits.Insertion(n1, n2, 0, 30)}");
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.Message);
            }

            Console.ReadLine();
        }
    }
}

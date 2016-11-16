using System.Collections.Generic;

namespace Task1
{
    /// <summary>
    /// Class for generating different sequences
    /// </summary>
    public static class Generate
    {
        /// <summary>
        /// Generating the sequences of Fibonacci numbers
        /// </summary>
        public static IEnumerable<int> Fibonacci(int count)
        {
            int i = 0;
            int prev = 0, current = 1;

            do
            {
                yield return current;

                int tmp = current;
                current = prev + tmp;
                prev = tmp;
            } while (++i < count);
        }
    }
}

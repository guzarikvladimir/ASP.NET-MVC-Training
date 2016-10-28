using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNewton
{
    /// <summary>
    /// Класс для различных операций над числами
    /// </summary>
    public static class Compute
    {
        /// <summary>
        /// Метод для вычисления корня n-ой степени из числа методом Ньютона с заданной точностью
        /// </summary>
        /// <param name="num">Число для вычисления</param>
        /// <param name="n">Степень корня</param>
        /// <param name="eps">Точность</param>
        /// <returns>Приближенное значение корня числа</returns>
        /// <exception cref="ArgumentException">Проиходит, если входное число отрицательное при четной степени корня</exception>
        /// <exception cref="ArgumentOutOfRangeException">Происходит, если значений точности не входит в (0, 1) или значение степени корня отрицательно</exception>
        public static double Sqrt(double num, int n = 2, double eps = 0.001)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException();

            if (eps <= 0 || eps >= 1)
                throw new ArgumentOutOfRangeException();

            if (n % 2 == 0 & num < 0)
                throw new ArgumentException();

            double x1, x2 = 1;
            do
            {
                x1 = x2;
                x2 = (x1 * (n - 1) + num / Math.Pow(x1, n - 1)) / n;
            }
            while (Math.Abs(x1 - x2) >= eps);

            return x2;
        }
    }
}

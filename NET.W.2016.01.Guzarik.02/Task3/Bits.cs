using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Класс для преобразования целых чсиел с помощью битовых операций
    /// </summary>
    public static class Bits
    {
        /// <summary>
        /// Метод вставки одного числа в другое так, чтобы второе число занимало позицию с бита i по бит j (биты нумеруются справа налево)
        /// </summary>
        /// <param name="first">Первое число</param>
        /// <param name="second">Второе число</param>
        /// <param name="i">Первая позиция в первом числе справа</param>
        /// <param name="j">Вторая позиция в первом числе слева</param>
        /// <returns>Результат вставки битов из второго числа в первое</returns>
        /// <exception cref="ArgumentException">Происходит, если позиция i > j</exception>
        public static int Insertion(int first, int second, int i, int j)
        {
            if (i > j)
                throw new ArgumentException();

            int mask = 0;

            for (int k = 0; k <= j - i; k++)
            {
                mask <<= 1;
                mask |= 1;
            }

            mask <<= i;

            second &= mask;
            first |= second;

            return first;
        }
    }
}

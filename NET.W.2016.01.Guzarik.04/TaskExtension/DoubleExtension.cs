using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskExtension
{
    /// <summary>
    /// Класс, содержащий методы расширения для чисел Double
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Метод для получения двоичного представления числа
        /// </summary>
        /// <param name="seed"></param>
        /// <returns>Битовое представление числа, типа BitArray</returns>
        public static BitArray GetBits(this double seed)
        {
            BitArray bits = new BitArray(BitConverter.GetBytes(seed));
            
            return bits;
        }
    }
}

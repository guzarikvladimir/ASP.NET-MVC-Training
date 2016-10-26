using System;
using System.Linq;
using System.Text;

namespace Task2
{
    /// <summary>
    /// Класс для работы с конкатенацией строк
    /// </summary>
    public static class Concat
    {
        /// <summary>
        /// Возвращает конкатенированную остортированную по алфавиту строку, исключая повторяющиеся символы
        /// </summary>
        /// <param name="str1">Первая строка</param>
        /// <param name="str2">Вторая строка</param>
        /// <returns>Конкатенированная остортированная по алфавиту строка без повторяющихся символов</returns>
        /// <exception cref="ArgumentNullException">Происходит, если на вход подается null строка</exception>
        /// <exception cref="ArgumentException">Происходит, если строка содержит символы, отличные от букв</exception>
        public static string ExceptRepeating(string str1, string str2)
        {
            if (ReferenceEquals(str1, null) || ReferenceEquals(str2, null))
                throw new ArgumentNullException();

            for (int i = 0; i < str1.Length; i++)
                if (str1[i] < 'a' || str1[i] > 'z')
                    throw new ArgumentException();

            for (int i = 0; i < str2.Length; i++)
                if (str2[i] < 'a' || str2[i] > 'z')
                    throw new ArgumentException();

            StringBuilder str;

            if (str1 == str2)
                str = new StringBuilder(string.Concat(str1.OrderBy(x => x).ToArray()));
            else
                str = new StringBuilder(string.Concat(string.Concat(str1, str2).OrderBy(x => x).ToArray()));

            int j = 0;
            while (j < str.Length - 1)
            {
                if (str[j].Equals(str[j + 1]))
                    str.Remove(j + 1, 1);
                else
                    j++;
            }

            return str.ToString();
        }
    }
}

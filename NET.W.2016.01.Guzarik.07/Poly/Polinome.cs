using System.Text;

namespace Poly
{
    /// <summary>
    /// Класс для работы с многочленами степени от одной переменной вещественного типа
    /// </summary>
    public sealed class Polinome
    {
        private double[] array;

        /// <summary>
        /// Конструктор, принимающий неопределенное количество чисел
        /// </summary>
        /// <param name="coefficients">Переменные вещественного типа</param>
        public Polinome(params double[] coefficients)
        {
            array = coefficients;
        }

        /// <summary>
        /// Конструктор, задающий размер многочлена
        /// </summary>
        /// <param name="capacity">Максимальны размер многочлена</param>
        public Polinome(int capacity)
        {
            array = new double[capacity];
        }

        /// <summary>
        /// Возвращает ранг многочлена
        /// </summary>
        public int Count { get { return array.Length; } }

        /// <summary>
        /// Индексатор, соответствующий степени x
        /// </summary>
        /// <param name="index">Индекс элемента (степень x)</param>
        /// <returns>Возвращает коэффициент по индексу (степени x)</returns>
        public double this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        /// <summary>
        /// Позволяет получить строковое представление многочлена
        /// </summary>
        /// <returns>Строковое представление многочлена</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string powerX;
            string sign;

            for (int i = Count - 1; i >= 0; i--)
            {
                if (this[i] == 0)
                    continue;

                if (i > 1)
                    powerX = $"x^{i}";
                else if (i == 1)
                    powerX = "x";
                else
                    powerX = "";

                if (this[i] > 0)
                    if (i == Count - 1)
                        sign = string.Empty;
                    else
                        sign = "+";
                else
                    sign = string.Empty;

                sb.AppendFormat($"{sign}{this[i]}{powerX}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Сравнивает многочлены по их коэффициентам
        /// </summary>
        /// <param name="obj">Многочлен</param>
        /// <returns>Правду, если многочлены идентичны</returns>
        public override bool Equals(object obj)
        {
            Polinome poly = obj as Polinome;

            if (poly == null)
                return false;

            if (poly.Count != Count)
                return false;

            for (int i = 0; i < Count; i++)
                if (this[i] != poly[i])
                    return false;

            return true;
        }

        /// <summary>
        /// Позволяет получиить Hash объекта
        /// </summary>
        /// <returns>Hash объекта</returns>
        public override int GetHashCode()
        {
            int q = 37;
            double hash = Count % 2 == 0 ? 0 : this[Count - 1];

            for (int i = 0; i < Count; i += 2)
                hash += this[i] * q + this[i + 1];

            return (int)hash;
        }

        /// <summary>
        /// Складывает коэффициенты двух многочленов по соответствующим степеням x
        /// </summary>
        /// <param name="a">Первый многочлен</param>
        /// <param name="b">Второй многочлен</param>
        /// <returns>Многочлен, являющийся результатом суммирования двух входящих многочленов</returns>
        public static Polinome operator +(Polinome a, Polinome b)
        {
            int length = a.Count < b.Count ? a.Count : b.Count;

            Polinome p = b;

            for (int i = 0; i < length; i++)
                p[i] += a[i];

            return p;
        }

        /// <summary>
        /// Складывает коэффициенты многочлена с числом
        /// </summary>
        /// <param name="a">Многочлен</param>
        /// <param name="b">Число</param>
        /// <returns>Многочлен, являющийся результатом суммирования</returns>
        public static Polinome operator +(Polinome a, double b)
        {
            for (int i = 0; i < a.Count; i++)
                a[i] += b;

            return a;
        }

        /// <summary>
        /// Складывает коэффициенты многочлена с числом
        /// </summary>
        /// <param name="b">Многочлен</param>
        /// <param name="a">Число</param>
        /// <returns>Многочлен, являющийся результатом суммирования</returns>
        public static Polinome operator +(double b, Polinome a) => a + b;

        /// <summary>
        /// Вычитает коэффициенты одного многочлена из коэффициентов другого многочлена
        /// </summary>
        /// <param name="a">Первый многочлен</param>
        /// <param name="b">Второй многочлен</param>
        /// <returns>Многочлен, являющийся реультатом разности двух многочленов</returns>
        public static Polinome operator -(Polinome a, Polinome b)
        {
            Polinome p;

            if (a.Count > b.Count)
            {
                for (int i = 0; i < b.Count; i++)
                    a[i] -= b[i];

                p = a;
            }
            else
            {
                p = new Polinome(b.Count);

                int i = 0;

                for (; i < a.Count; i++)
                    p[i] = a[i] - b[i];

                for (; i < b.Count; i++)
                    p[i] = -b[i];
            }

            return p;
        }

        /// <summary>
        /// Вычитает число из каждого элемента многочлена
        /// </summary>
        /// <param name="a">Многочлен</param>
        /// <param name="b">Число</param>
        /// <returns>Многочлен, являющийся результатом разности многочлена и числа</returns>
        public static Polinome operator -(Polinome a, double b)
        {
            for (int i = 0; i < a.Count; i++)
                a[i] -= b;

            return a;
        }

        /// <summary>
        /// Вычитает число из каждого элемента многочлена
        /// </summary>
        /// <param name="b">Число</param>
        /// <param name="a">Многочлен</param>
        /// <returns>Многочлен, являющийся результатом разности многочлена и числа</returns>
        public static Polinome operator -(double b, Polinome a) => a - b;

        /// <summary>
        /// Инкрементирует каждый элемент многочлена
        /// </summary>
        /// <param name="a">Многочлен</param>
        /// <returns>Многочлен, являющийся результатом инкрементирования элементов</returns>
        public static Polinome operator ++(Polinome a) => a + 1;

        /// <summary>
        /// Декрементирует каждый элемент многочлена
        /// </summary>
        /// <param name="a">Многочлен</param>
        /// <returns>Многочлен, являющийся результатом декрементирования элементов</returns>
        public static Polinome operator --(Polinome a) => a - 1;
    }
}

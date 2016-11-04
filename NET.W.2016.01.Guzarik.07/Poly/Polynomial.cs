using System;
using System.Text;

namespace Poly
{
    /// <summary>
    /// Класс для работы с многочленами степени от одной переменной вещественного типа
    /// </summary>
    public sealed class Polynomial : ICloneable, IEquatable<Polynomial>
    {
        private double[] polynomial = { };

        public static double Epsilon { get; private set; } = 0.00001;

        /// <summary>
        /// Конструктор из некоторого количества вещественных чисел
        /// </summary>
        public Polynomial(params double[] coefficients)
        {
            polynomial = new double[coefficients.Length];
            Array.Copy(coefficients, polynomial, coefficients.Length);
        }

        /// <summary>
        /// Конструктор на основе другого полинома
        /// </summary>
        public Polynomial(Polynomial polynomial) : this(polynomial.polynomial) { }

        static Polynomial()
        {
            //Epsilon = double.Parse(System.Configuration.ConfigurationManager.AppSettings["epsilon"]);
        }

        /// <summary>
        /// Индексатор, соответствующий степени x
        /// </summary>
        /// <param name="index">Индекс элемента (степень x)</param>
        /// <returns>Возвращает коэффициент по индексу (степени x)</returns>
        public double this[int index]
        {
            get
            {
                if (index > polynomial.Length)
                    throw new ArgumentOutOfRangeException();

                return polynomial[index];
            }
            private set
            {
                polynomial[index] = value;
            }
        }

        /// <summary>
        /// Позволяет получить строковое представление многочлена
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string powerX;
            string sign;

            for (int i = polynomial.Length - 1; i >= 0; i--)
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
                    if (i == polynomial.Length - 1)
                        sign = string.Empty;
                    else
                        sign = "+";
                else
                    sign = string.Empty;

                sb.Append($"{sign}{this[i]}{powerX}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Указывает, эквивалентен ли текущий объект другому объекту того же типа
        /// </summary>
        public bool Equals(Polynomial poly)
        {
            if (ReferenceEquals(null, poly)) return false;
            if (ReferenceEquals(this, poly)) return true;

            if (polynomial.Length != poly.polynomial.Length) return false;

            for (int i = 0; i < polynomial.Length; i++)
                if (this[i] - Epsilon > poly[i] || this[i] + Epsilon < poly[i])
                    return false;

            return true;
        }

        /// <summary>
        /// Сравнивает полиномы
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != GetType()) return false;

            return Equals((Polynomial)obj);
        }

        /// <summary>
        /// Позволяет получиить Hash объекта
        /// </summary>
        /// <returns>Hash объекта</returns>
        public override int GetHashCode()
        {
            int hash = 0;

            for (int i = 0; i < polynomial.Length; i++)
                hash += this[i].GetHashCode();

            return hash ^ polynomial.Length;
        }

        /// <summary>
        /// Создает новый объект, являющийся копией текущего экземпляра
        /// </summary>
        public object Clone() => new Polynomial(polynomial);

        #region Перегрузки операций (методы)

        /// <summary>
        /// Складывает коэффициенты двух полиномов по соответствующим степеням x
        /// </summary>
        public static Polynomial Add(Polynomial lhs, Polynomial rhs) => lhs + rhs;

        /// <summary>
        /// Складывает коэффициенты полинома с числом
        /// </summary>
        public static Polynomial Add(Polynomial lhs, double rhs) => lhs + rhs;

        /// <summary>
        /// Вычитает коэффициенты одного полинома из коэффициентов другого полинома
        /// </summary>
        public static Polynomial Subtract(Polynomial lhs, Polynomial rhs) => lhs - rhs;

        /// <summary>
        /// Вычитает число из каждого элемента многочлена
        /// </summary>
        public static Polynomial Subtract(Polynomial lhs, double rhs) => lhs - rhs;

        /// <summary>
        /// Инкрементирует каждый элемент полинома
        /// </summary>
        public Polynomial Increment() => this + 1;

        /// <summary>
        /// Декрементирует каждый элемент полинома
        /// </summary>
        public Polynomial Decrement() => this - 1;

        /// <summary>
        /// Инвертирует знак элементов полинома
        /// </summary>
        public static Polynomial SignInversion(Polynomial poly) => -poly;

        #endregion

        #region Перегрузки операций

        /// <summary>
        /// Инвертирует знак элементов полинома
        /// </summary>
        public static Polynomial operator -(Polynomial lhs)
        {
            for (int i = 0; i < lhs.polynomial.Length; i++)
                lhs[i] = -lhs[i];

            return lhs;
        }

        /// <summary>
        /// Складывает коэффициенты двух полиномов по соответствующим степеням x
        /// </summary>
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException();
            if (ReferenceEquals(rhs, null)) throw new ArgumentNullException();

            int minLength = Math.Min(lhs.polynomial.Length, rhs.polynomial.Length);
            Polynomial poly = lhs.polynomial.Length > rhs.polynomial.Length ? 
                new Polynomial(lhs) : new Polynomial(rhs);

            for (int i = 0; i < minLength; i++)
                poly[i] += lhs.polynomial.Length > rhs.polynomial.Length ? rhs[i] : lhs[i];

            return poly;
        }

        /// <summary>
        /// Складывает коэффициенты полинома с числом
        /// </summary>
        public static Polynomial operator +(Polynomial lhs, double rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException();

            for (int i = 0; i < lhs.polynomial.Length; i++)
                lhs[i] += rhs;

            return lhs;
        }

        /// <summary>
        /// Складывает коэффициенты полинома с числом
        /// </summary>
        public static Polynomial operator +(double lhs, Polynomial rhs) => rhs + lhs;

        /// <summary>
        /// Вычитает коэффициенты одного полинома из коэффициентов другого полинома
        /// </summary>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs) => lhs + (-rhs);

        /// <summary>
        /// Вычитает число из каждого элемента многочлена
        /// </summary>
        public static Polynomial operator -(Polynomial lhs, double rhs) => lhs + (-rhs);

        /// <summary>
        /// Вычитает каждый элемент полинома из числа
        /// </summary>
        public static Polynomial operator -(double lhs, Polynomial rhs) => (-rhs) + lhs;

        /// <summary>
        /// Инкрементирует каждый элемент полинома
        /// </summary>
        public static Polynomial operator ++(Polynomial lhs) => lhs + 1;

        /// <summary>
        /// Декрементирует каждый элемент полинома
        /// </summary>
        public static Polynomial operator --(Polynomial lhs) => lhs - 1;

        /// <summary>
        /// Сравнивает на равенство полиномов
        /// </summary>
        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, rhs)) return true;
            if (ReferenceEquals(lhs, null)) return false;

            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Сравнивает на неравенство двух полиномов
        /// </summary>
        /// <returns></returns>
        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, rhs)) return false;

            return !lhs.Equals(rhs);
        }
        
        #endregion
    }
}

using System;
using System.Linq;

namespace Task1
{
    /// <summary>
    /// Пользовательский формат
    /// </summary>
    public sealed class Customer
    {
        private string _name;
        private string _contactPhone;
        private decimal _revenue;

        /// <summary>
        /// Получить имя
        /// </summary>
        /// <exception cref="ArgumentException">Неверный формат (не буквы или пробельные символы) или недопустимая длина (больше 50) имени</exception>
        public string Name
        {
            get { return _name; }
            private set
            {
                if (value.Any(c => !char.IsLetter(c) && !char.IsWhiteSpace(c)))
                {
                    throw new ArgumentException("Неверный формат имени");
                }

                if (value.Length < 2 || value.Length > 50)
                    throw new ArgumentException("Недопустимая длина имени");

                _name = value;
            }
        }
        /// <summary>
        /// Получить или установить контактный телефон
        /// </summary>
        /// <exception cref="ArgumentException">Неверный формат (начинается с +) или недопустимая длина (не больше 13 символов) телефона</exception>
        public string ContactPhone
        {
            get { return _contactPhone; }
            set
            {
                if (value.Length > 13)
                    throw new ArgumentException("недопустимая длина телефона");

                if (value[0] != '+' & value != string.Empty)
                    throw new ArgumentException("Неверный формат телефона");

                _contactPhone = value;
            }
        }
        /// <summary>
        /// Получить или установить доходы
        /// </summary>
        /// <exception cref="ArgumentException">Неверный формат доходов (меньше 0)</exception>
        public decimal Revenue
        {
            get { return _revenue; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Неверный формат доходов");

                _revenue = value;
            }
        }

        /// <summary>
        /// Конструктор, позволяющий задать все данные
        /// </summary>
        public Customer(string name, decimal revenue, string contactPhone)
        {
            Name = name;
            Revenue = revenue;
            ContactPhone = contactPhone;
        }
        /// <summary>
        /// Конструктор, на случай отсутстия контактного телефона
        /// </summary>
        public Customer(string name, decimal revenue) : this(name, revenue, string.Empty) { }
        /// <summary>
        /// Конструктор, на случай клиента, не имеющего доход
        /// </summary>
        public Customer(string name, string contactPhone) : this(name, 0, contactPhone) { }
        /// <summary>
        /// Конструктор, на случай отсутстия информации о доходах и контактного телефона
        /// </summary>
        public Customer(string name) : this(name, 0, string.Empty) { }

        /// <summary>
        /// Возвращает полное строковое представление информации о клиенте
        /// </summary>
        public override string ToString()
        {
            return ToString(null, "G", Feature.Name, Feature.ContactPhone, Feature.Revenue);
        }
        /// <summary>
        /// Возвращает частичное строковое представление
        /// </summary>
        /// <param name="features">Необходимые для отображение данные</param>
        public string ToString(params Feature[] features)
        {
            return features.Length == 0 ? ToString(null, "G", Feature.Name, Feature.ContactPhone, Feature.Revenue) 
                : ToString(null, "G", features);
        }
        /// <summary>
        /// Возвращает частичное строковое представление в формате
        /// </summary>
        /// <param name="fp">Пользовательский формат</param>
        /// <param name="format">Формат строки</param>
        /// <param name="features">Необходимые для отображение данные</param>
        /// <exception cref="ArgumentException">Недопустимое количество данных для вывода (больше 3) или данные повторяются</exception>
        public string ToString(IFormatProvider fp, string format = "G", params  Feature[] features)
        {
            if (features.Length == 0)
                throw  new ArgumentException("Нет аргументов для вывода");

            if (features.Length > 3)
                throw new ArgumentException("Недопустимое количество данных");

            if (features.Distinct().Count() != features.Length)
                throw new ArgumentException("Не должно содержаться повторяющихся данных");

            var result = string.Empty;
            const string sHelper = ", ";

            foreach (var variable in features)
            {
                if (result != string.Empty)
                    result += sHelper;
                result += ToStringHelper(fp, format, variable);
            }

            return result;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fp"></param>
        /// <param name="format"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        private string ToStringHelper(IFormatProvider fp, string format, Feature f)
        {
            if (f == Feature.Name)
                return Name.ToString(fp);
            if (f == Feature.ContactPhone)
                return FormatPhone();
            return f == Feature.Revenue ? Revenue.ToString(format, fp) : string.Empty;
        }
        /// <summary>
        /// Возвращает форматированный контактный телефон
        /// </summary>
        private string FormatPhone()
        {
            return _contactPhone.Substring(0, 2) + " (" +
                _contactPhone.Substring(2, 3) + ") " +
                _contactPhone.Substring(5, 3) + "-" +
                _contactPhone.Substring(8);
        }
    }

    /// <summary>
    /// Если один из перечисляемых значений указан в выводе, соответствующая
    /// запись будет выведена
    /// </summary>
    public enum Feature
    {
        /// <summary>
        /// Указать, если необходимо вывести имя
        /// </summary>
        Name = 1,
        /// <summary>
        /// Указать, если необходимо вывести телефон
        /// </summary>
        ContactPhone,
        /// <summary>
        /// Указать, если необходимо вывести доходы
        /// </summary>
        Revenue
    }
}

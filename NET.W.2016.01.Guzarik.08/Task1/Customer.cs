using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public sealed class Customer
    {
        string name;
        string contactPhone;
        decimal revenue;

        public string Name
        {
            get { return name; }
            private set
            {
                foreach (char c in value)
                    if (!Char.IsLetter(c) && !Char.IsWhiteSpace(c))
                        throw new ArgumentException();

                if (value.Length < 2 || value.Length > 50)
                    throw new ArgumentException();

                name = value;
            }
        }

        public string ContactPhone
        {
            get { return contactPhone; }
            set
            {
                if (value.Length > 13)
                    throw new ArgumentException();

                if (value[0] != '+' & value != string.Empty)
                    throw new ArgumentException();

                contactPhone = value;
            }
        }

        public decimal Revenue
        {
            get { return revenue; }
            set
            {
                if (value < 0)
                    throw new ArgumentException();

                revenue = value;
            }
        }

        public Customer(string name, decimal revenue, string contactPhone)
        {
            Name = name;
            Revenue = revenue;
            ContactPhone = contactPhone;
        }

        public Customer(string name, decimal revenue) : this(name, revenue, string.Empty) { }

        public Customer(string name, string contactPhone) : this(name, 0, contactPhone) { }

        public Customer(string name) : this(name, 0, string.Empty) { }

        public override string ToString()
        {
            return ToString();
        }

        public string ToString(bool name = true, bool revenue = true, bool phone = true)
        {
            string result = string.Empty;

            if (name)
                result = string.Format("{0}", this.name);
            if (revenue)
                if (result == string.Empty)
                    result = string.Format("{0}", this.revenue);
                else
                    result += string.Format(", {0}", this.revenue);
            if (phone)
                if (result == string.Empty)
                    result = string.Format("{0}", contactPhone);
                else
                    result += string.Format(", {0}", contactPhone);

            return result;
        }
    }
}

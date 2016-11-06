using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public sealed class CustomFormat : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;

            return Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                format = "G";

            string customerString = arg.ToString();

            format = format.ToUpper();
            switch (format)
            {
                case "REV1":
                    string result = string.Empty;

                    for (int i = 0; i < customerString.Length; i++)
                    {
                        if ((customerString.Length - i) % 3 == 0 && i != 0)
                            result += ',';

                        result += customerString[i];
                    }

                    return result += ".00";
                case "PHONE1":
                    return customerString.Substring(0, 2) + " (" +
                        customerString.Substring(2, 3) + ") " +
                        customerString.Substring(5, 3) + "-" +
                        customerString.Substring(8);
            }

            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, formatProvider);

            return arg.ToString();
        }
    }
}

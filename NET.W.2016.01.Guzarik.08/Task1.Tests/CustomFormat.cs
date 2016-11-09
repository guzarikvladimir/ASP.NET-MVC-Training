using System;
using System.Threading;

namespace Task1.Tests
{
    public sealed class CustomFormat : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                format = "G";

            var customerString = arg.ToString();

            format = format.ToUpper();
            switch (format)
            {
                case "REV1":
                    var result = string.Empty;

                    for (var i = 0; i < customerString.Length; i++)
                    {
                        if ((customerString.Length - i) % 3 == 0 && i != 0)
                            result += ',';

                        result += customerString[i];
                    }

                    return result + ".00";
                case "PHONE1":
                    return customerString.Substring(0, 2) + " (" +
                        customerString.Substring(2, 3) + ") " +
                        customerString.Substring(5, 3) + "-" +
                        customerString.Substring(8);
            }

            var formattable = arg as IFormattable;
            return formattable?.ToString(format, formatProvider) ?? arg.ToString();
        }
    }
}

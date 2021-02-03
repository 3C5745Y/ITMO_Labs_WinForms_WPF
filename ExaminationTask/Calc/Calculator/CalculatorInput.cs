using System.Globalization;

namespace Calculator
{
    public static class CalculatorInput
    {
        private static readonly string _decimalSeparator = CultureInfo
                .CurrentCulture
                .NumberFormat
                .NumberDecimalSeparator;

        public static string TryAddDigit(string number, int digit)
        {
            if (number == "0")
                return digit.ToString();

            return number + digit;
        }

        public static string TryAddDecimalSeparator(string number)
        {
            if (!HasDecimalDelimeter(number))
                number += _decimalSeparator;

            return number;
        }

        private static bool HasDecimalDelimeter(string number)
        {
            return (number.IndexOf(_decimalSeparator[0]) != -1);
        }
    }
}

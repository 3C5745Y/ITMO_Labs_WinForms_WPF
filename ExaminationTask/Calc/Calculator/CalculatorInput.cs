using System.Globalization;

namespace Calculator
{
    public static class CalculatorInput
    {
        private static readonly string decimalSeparator = CultureInfo
                .CurrentCulture
                .NumberFormat
                .NumberDecimalSeparator;

        //проверка ввода нескольких "0" до цифры
        public static string TryAddDigit(string number, int digit)
        {
            if (number == "0")
                return digit.ToString();

            return number + digit;
        }

        public static string TryAddDecimalSeparator(string number)
        {
            if (!HasDecimalDelimeter(number))
                number += decimalSeparator;

            return number;
        }

        private static bool HasDecimalDelimeter(string number)
        {
            return (number.IndexOf(decimalSeparator[0]) != -1);
        }
    }
}

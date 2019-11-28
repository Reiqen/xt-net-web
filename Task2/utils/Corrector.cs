using System;
using System.Globalization;

namespace com.GitHub.Reiqen.Task2.utils
{
    class Corrector
    {
        public static bool IsMenuCase(String input)
        {
            if (int.TryParse(input, out int intResult) && intResult > 0 && intResult <= 9) return true;
            else return false;
        }
        public static bool IsCorrectCoordinatePoint(String input)
        {
            if (int.TryParse(input, out int intResult)) return true;
            else return false;
        }

        public static bool IsCorrectLength(String input)
        {
            if (double.TryParse(input, out double intResult) && intResult > 0) return true;
            else return false;
        }

        public static bool IsCorrectDate(String input)
        {
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _)) return true;
            else return false;
        }
    }
}
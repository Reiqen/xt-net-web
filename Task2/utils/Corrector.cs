using System;
using System.Globalization;

namespace com.GitHub.Reiqen.Task2.utils
{
    /*
        This class provides methods to check if the value which is read from input is valid for further operations.
        Please read comments above methods for more information.
    */
    class Corrector
    {
        // Checks if user inputs correct digit which fits one of the menu options
        public static bool IsMenuCase(String input)
        {
            if (int.TryParse(input, out int intResult) && intResult > 0 && intResult <= 9) return true;
            else return false;
        }

        // Checks if coordinate point is integer
        public static bool IsCorrectCoordinatePoint(String input)
        {
            if (int.TryParse(input, out int _)) return true;
            else return false;
        }

        // Checks if length is double and positive
        public static bool IsCorrectLength(String input)
        {
            if (double.TryParse(input, out double intResult) && intResult > 0) return true;
            else return false;
        }

        // Checks if date can be parsed correctly
        public static bool IsCorrectDate(String input)
        {
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _)) return true;
            else return false;
        }
    }
}
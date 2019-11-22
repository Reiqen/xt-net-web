using System;

namespace com.GitHub.Reiqen.Task0
{
    /*
        This class provides methods to check if the number which is read from input is valid for further operations.
        It has an interface to check if the input value is a number and it is positive and both positive and odd.
    */
    class Corrector
    {
        // Checks if the input value is a number and it is positive
        public static bool IsPositiveInt(String input)
        {
            if (Int32.TryParse(input, out int intResult) && intResult > 0) return true;
            else return false;
        }

        // Checks if the input value is a number and it is both positive and odd
        public static bool IsPositiveOddInt(String input)
        {
            if (IsPositiveInt(input))
            {
                if (Int32.Parse(input) % 2 == 0) return false;
                else return true;
            }
            else return false;
        }
    }
}
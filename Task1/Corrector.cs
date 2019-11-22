using System;

namespace com.GitHub.Reiqen.Task1
{
    /*
        This class provides methods to check if the number which is read from input is valid for further operations.
        Please read comments above methods for more information.
    */
    class Corrector
    {

        // Checks if the input value is int
        public static bool IsInt(String input)
        {
            if (Int32.TryParse(input, out _)) return true;
            else return false;
        }

        // Checks if the input value is a number and it is positive
        public static bool IsPositiveInt(String input)
        {
            int intResult;
            if (IsInt(input))
            {
                intResult = Int32.Parse(input);
                if (intResult > 0) return true;
                else return false;
            }
            else return false;
        }

        // Checks if the input value is a number in the range of 1 to 4
        public static bool IsOneToFour(String input)
        {
            int intResult;
            if (IsInt(input))
            {
                intResult = Int32.Parse(input);
                if (intResult >= 1 && intResult <= 4) return true;
                else return false;
            }
            else return false;
        }
    }
}
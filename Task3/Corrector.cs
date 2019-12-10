using System;

namespace com.GitHub.Reiqen.Task3
{
    class Corrector
    {
        public static bool IsPositiveInt(String input)
        {
            if (Int32.TryParse(input, out int intResult) && intResult > 0) return true;
            else return false;
        }

        public static bool IsNotNullString(String input)
        {
            if (!String.IsNullOrEmpty(input)) return true;
            else return false;
        }
        
    }
}
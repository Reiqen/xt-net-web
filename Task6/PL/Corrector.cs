using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.GitHub.Reiqen.Task6.PL
{
    class Corrector
    {
        public static bool IsCorrectDate(String input)
        {
            if (DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _)) return true;
            else return false;
        }
    }
}

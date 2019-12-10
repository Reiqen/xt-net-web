using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.GitHub.Reiqen.Task4
{
    class CustomSort
    {

        public static void Sort<T>(T[] arr, Func<T, T, int> compare)
        {
            if (compare == null)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = (i + 1); j < arr.Length; j++)
                {
                    if (compare(arr[j], arr[i]) > 0)
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        public static int CompareString(string s, string t)
        {
            if (s == t) return 0;
            if (s == null) return 1;
            if (t == null) return -1;

            if (s.Length < t.Length) return 1;
            if (s.Length > t.Length) return -1;

            return s.CompareTo(t);
        }

        public static int CompareDouble(double s, double t)
        {
            if (s == t) return 0;

            if (s < t) return 1;
            if (s > t) return -1;

            return s.CompareTo(t);
        }
    }
}

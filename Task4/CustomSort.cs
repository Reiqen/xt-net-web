using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace com.GitHub.Reiqen.Task4
{
    class CustomSort
    {
        public delegate void SortingHandler(string message);
        public event SortingHandler Notify;


        public void Sort<T>(T[] arr, Func<T, T, int> compare)
        {
            if (compare == null)
            {
                throw new ArgumentException();
            }
            T temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = (i + 1); j < arr.Length; j++)
                {
                    if (compare(arr[j], arr[i]) > 0)
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            Notify?.Invoke("Sorting finished");
        }

        public void ThreadSort<T>(T[] arr, Func<T, T, int> compare)
        {
            ThreadStart thStart = new ThreadStart(() => Sort(arr, compare));
            Thread th = new Thread(thStart);
            th.Start();
            th.Join();
        }

        public static int CompareString(string s, string t)
        {
            if (s == t) return 0;
            if (s == null) return 1;
            if (t == null) return -1;

            if (s.Length < t.Length) return 1;
            if (s.Length > t.Length) return -1;

            return t.CompareTo(s);
        }

        public static int CompareDouble(double s, double t)
        {
            if (s == t) return 0;

            if (s < t) return 1;
            if (s > t) return -1;

            return t.CompareTo(s);
        }

        public static int Sum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        public void ShowSum(int[] arr, Func <int[], int> operation)
        {
            Console.WriteLine("Результат операции: " + operation(arr));
        }

        public static bool Check(string str)
        {
            char[] charArr = str.ToCharArray();
            foreach (char ch in charArr)
            {
                if (!Char.IsDigit(ch)) return false;  
            }
            return true;
        }

        public void ShowString(string str, Func<string, bool> checker)
        {
            Console.WriteLine("Результат операции: " + checker(str));
        }
    }
}
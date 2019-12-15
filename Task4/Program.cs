using System;
using static com.GitHub.Reiqen.Task4.CustomSort;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace com.GitHub.Reiqen.Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomSort customSort = new CustomSort();
            customSort.Notify += SortingFinished;
            string[] array = new string[] { "bacd", "abcd", "ff", "rty", "r", "ss", "uu", "aa" };
            Func<string, string, int> cs = CompareString;
            customSort.Sort(array, cs);
            // or customSort.ThreadSort(array, cs);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            double[] arrayDouble = new double[] { 2F, 5F, 6F, 1F, -1F };
            Func<double, double, int> csDouble = CompareDouble;
            customSort.Sort(arrayDouble, csDouble);
            // or customSort.ThreadSort(arrayDouble, csDouble);
            for (int i = 0; i < arrayDouble.Length; i++)
            {
                Console.WriteLine(arrayDouble[i]);
            }

            int[] arrayInt = new int[] { 2, 5, 6, 1, -1 };
            Func<int[], int> csInt = Sum;
            customSort.ShowSum(arrayInt, csInt);

            string str = "-10";
            Func<string, bool> csString = Check;
            customSort.ShowString(str, csString);


            Console.ReadLine();
        }
        public static void SortingFinished(String message)
        {
            Console.WriteLine(message);
        }
    }
}

using System;
using static com.GitHub.Reiqen.Task4.CustomSort;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.GitHub.Reiqen.Task4
{
    class Program
    {
        static void Main(string[] args)
        {
                string[] array = new string[] { "bacd", "abcd", "ff", "rty", "r" };
                Func<string, string, int> cs = CompareString;
                Sort(array, cs);

                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(array[i]);
                }

            double[] arrayDouble = new double[] { 2F, 5F, 6F, 1F, -1F };
            Func<double, double, int> csDouble = CompareDouble;
            Sort(arrayDouble, csDouble);

            for (int i = 0; i < arrayDouble.Length; i++)
            {
                Console.WriteLine(arrayDouble[i]);
            }

            Console.ReadLine();
        }
    }
}

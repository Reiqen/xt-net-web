using System;
using static System.Math;

namespace com.GitHub.Reiqen.Task0
{
    /*
        This class provides methods to perform actions for task needs.
        It has an interface to create a sequence, show simplicity information, print a square of '*' symbols,
        create a jagged array and sort it by subarray values and all values.
    */
    class Functions
    {
        // Creates a sequence of a range from 1 to the number from received argument
        public static void MakeSequence(int arg)
        {
            for (var i = 1; i <= arg; i++) Console.Write(i + " ");
        }

        // Shows if the number from received argument is simple
        public static void SimplicityInfo(int arg)
        {
            var checker = true;
                for (var i = 2; i<=Sqrt(arg); i++)
                {
                    if (arg % i == 0)
                    {
                        checker = false;
                        break;
                    }
                    else checker = true;
                }
            if (checker) Console.WriteLine("Число является простым");
            else Console.WriteLine("Число не является простым");
        }

        // Prints a square of '*' symbols with a hole in the middle
        public static void PrintSquare(int arg)
        {
            for (var i = 0; i < arg; i++)
            {
                for (var j = 0; j < arg; j++)
                {
                    if (i == arg / 2 && j == arg / 2) Console.Write("  ");
                    else Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        // Prints a jagged array filled with random numbers and returns it.
        // Takes a parameter of array of values where size of each subarray is defined.
        // Further return is made for sending it to the sort method.
        public static int[][] PrintAndReturnUnsortedArray(int[] arrayOfValues)
        {
            var randomNumber = new Random();
            var unsortedArray = new int[arrayOfValues.Length][];
            Console.WriteLine("\nНесортированный массив:\n");
            for (var i = 0; i < arrayOfValues.Length; i++)
            {
                unsortedArray[i] = new int[arrayOfValues[i]];
                Console.Write("Подмассив " + (i + 1) + ": [");
                for (var j = 0; j < arrayOfValues[i]; j++)
                {
                    unsortedArray[i][j] = randomNumber.Next(0, 100);
                    if (j + 1 == arrayOfValues[i]) Console.Write(unsortedArray[i][j]);
                    else Console.Write(unsortedArray[i][j] + " ");
                }
                Console.WriteLine("]");
            }
            return unsortedArray;
        }

        // Provides sorting by subarray values and all values
        public static void PrintSortedArray(int[][] unsortedArray)
        {
            // Sort by subarray values
            Console.WriteLine("\nОтсортированный по значениям в подмассиве массив:\n");
            var sortedArray = unsortedArray;
            for (var i = 0; i < sortedArray.Length; i++)
            {
                Array.Sort(sortedArray[i]);
                Console.Write("Подмассив " + (i + 1) + ": [");
                for (var j = 0; j < sortedArray[i].Length; j++)
                {
                    if (j+1 == sortedArray[i].Length) Console.Write(unsortedArray[i][j]);
                    else Console.Write(unsortedArray[i][j] + " ");
                }
                Console.WriteLine("]");
            }

            // Sort by all values
            Console.WriteLine("\nОтсортированный по всем значениям массив:\n");
            int counter = 0;
            for (var i = 0; i < sortedArray.Length; i++)
            {
                for (var j = 0; j < sortedArray[i].Length; j++) counter++;
            }
            var tempArray = new int[counter];
            counter = 0;
            for (var i = 0; i < sortedArray.Length; i++)
            {
                for (var j = 0; j < sortedArray[i].Length; j++)
                {
                    tempArray[counter] = sortedArray[i][j];
                    counter++;
                }
            }
            counter = 0;
            Array.Sort(tempArray);
            for (var i = 0; i < sortedArray.Length; i++)
            {
                Console.Write("Подмассив " + (i + 1) + ": [");
                for (var j = 0; j < sortedArray[i].Length; j++)
                {
                    sortedArray[i][j] = tempArray[counter];
                    counter++;
                    if (j + 1 == sortedArray[i].Length) Console.Write(unsortedArray[i][j]);
                    else Console.Write(unsortedArray[i][j] + " ");
                }
                Console.WriteLine("]");
            }
        }
    }
}
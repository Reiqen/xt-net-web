using System;
using System.Collections.Generic;
using static Task1.Entities;

namespace com.GitHub.Reiqen.Task1
{    
    /*
        This class provides methods to perform actions for task needs.
        Please read comments above methods for more information.
    */
    class Functions
    {
        public static Random random = new Random();

        // Returns any dimensional figure area
        public static int FigureArea(int[] sides)
        {
            int area = 1;
            foreach (int side in sides) area *= side;
            return area;
        }

        // Builds a right triangle with '*' symbols
        public static void RightTriangle(int rows)
        {
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j <= i; j++) Console.Write("*");
                Console.WriteLine();
            }
        }

        // Builds a regular triangle with '*' symbols
        public static void RegularTriangle(int rows)
        {
            int counter = 1;
            for (var i = 0; i < rows; i++)
            {
                for (var j = rows - 1; j > i; j--) Console.Write(" ");
                for (var k = 0; k < counter; k++) Console.Write("*");
                Console.WriteLine();
                counter += 2;
            }
        }

        // Builds an x-mas tree with '*' symbols
        public static void xmasTree(int rows)
        {
            int counter;
            for (var n = 0; n < rows; n++) 
            {
                counter = 1;
                for (var i = 0; i < n+1; i++)
                {
                    for (var j = rows - 1; j > i; j--) Console.Write(" ");
                    for (var k = 0; k < counter; k++) Console.Write("*");
                    Console.WriteLine();
                    counter += 2;
                }
            }
        }

        // Calculates a sum of numbers which can be divided by 3 and 5
        public static int SumOfNumbers()
        {
            int sumModule = 0;
            for(var i = 1; i < 1000; i++) if (i % 3 == 0 || i % 5 == 0) sumModule += i;
            return sumModule;
        }

        // First variation of font adjustment function. Sets and returns 'None'.
        public static Font FontAdjustment()
        {
            var font = Font.Bold | Font.Italic | Font.Underline;
            font = font ^ Font.Bold ^ Font.Italic ^ Font.Underline;
            return font;
        }

        // Second variation of font adjustment function. Sets and returns font parameters.
        public static Font FontAdjustment(int arg, Font savedFont)
        {
            var font = savedFont;
            if (arg == 3) arg = 4;
            font ^= (Font)arg;
            return font;
        }

        // Builds an array, sorts it and shows min and max elements
        public static void ArrayProccesing() 
        {
            int[] arrayProccesing = new int[10];
            int temp;
            Console.WriteLine("Дан массив из 10 элементов, заполненный случайными целыми числами.");
            Console.WriteLine("Массив до сортировки:");
            for (var i = 0; i < arrayProccesing.Length; i++)
            {
                arrayProccesing[i] = random.Next(-100, 100);
                Console.Write(arrayProccesing[i] + " ");
            }
            for (var i = 0; i < arrayProccesing.Length; i++)
            {
                for (var j = i + 1; j < arrayProccesing.Length; j++)
                {
                    if (arrayProccesing[i] > arrayProccesing[j])
                    {
                        temp = arrayProccesing[i];
                        arrayProccesing[i] = arrayProccesing[j];
                        arrayProccesing[j] = temp;
                    }
                }
            }
            Console.WriteLine("\nМассив после сортировки:");
            for (var i = 0; i < arrayProccesing.Length; i++) Console.Write(arrayProccesing[i] + " ");
            Console.WriteLine("\nМинимальное число: " + arrayProccesing[0] + ", максимальное число: "
                                                    + arrayProccesing[arrayProccesing.Length - 1]);
        }

        // Builds a three dimensional array and replace all positive numbers with zero
        public static void NoPositive()
        {
            int[,,] noPositive = new int[5, 5, 5];
            Console.WriteLine("Дан трехмерный массив из 5 элементов в каждом измерении, заполненный случайными целыми числами.");
            Console.WriteLine("Массив до замены положительных чисел на 0:");
            for (var i = 0; i < noPositive.GetLength(0); i++)
            {
                Console.WriteLine("\nИзмерение " + (i + 1));
                for (var j = 0; j < noPositive.GetLength(1); j++)
                {
                    Console.Write("[");
                    for (var k = 0; k < noPositive.GetLength(2); k++)
                    {
                        noPositive[i, j, k] = random.Next(-100, 100);
                        Console.Write(noPositive[i, j, k] + " ");
                    }
                    Console.Write("] ");
                }
            }
            Console.WriteLine("\nМассив после замены положительных чисел на 0:");
            for (var i = 0; i < noPositive.GetLength(0); i++)
            {
                Console.WriteLine("\nИзмерение " + (i + 1));
                for (var j = 0; j < noPositive.GetLength(1); j++)
                {
                    Console.Write("[");
                    for (var k = 0; k < noPositive.GetLength(2); k++)
                    {
                        if (noPositive[i, j, k] > 0) noPositive[i, j, k] = 0;
                        Console.Write(noPositive[i, j, k] + " ");
                    }
                    Console.Write("]");
                }
            }
        }

        // Builds an array and shows a sum of all positive numbers
        public static void NoNegativeSum()
        {
            int[] nonNegativeSum = new int[10];
            int sum = 0;
            Console.WriteLine("\nДан массив из 10 элементов, заполненный случайными целыми числами.");
            Console.WriteLine("Массив:");
            for (var i = 0; i < nonNegativeSum.Length; i++)
            {
                nonNegativeSum[i] = random.Next(-100, 100);
                if (nonNegativeSum[i] > 0) sum += nonNegativeSum[i];
                Console.Write(nonNegativeSum[i] + " ");
            }
            Console.WriteLine("\nСумма неотрицательных элементов: " + sum);
        }

        // Builds a two dimensional array and show a sum of all even elements
        public static void TwoDimensionalArray()
        {
            int[,] twoDimensionalArray = new int[5, 5];
            int sum = 0;
            Console.WriteLine("Дан двумерный массив из 5 элементов в каждом измерении, заполненный случайными целыми числами.");
            Console.WriteLine("Массив:");
            for (var i = 0; i < twoDimensionalArray.GetLength(0); i++)
            {
                Console.WriteLine("\nПодмассив " + (i + 1));
                for (var j = 0; j < twoDimensionalArray.GetLength(1); j++)
                {
                    twoDimensionalArray[i, j] = random.Next(0, 100);
                    if ((i + j) % 2 == 0) sum += twoDimensionalArray[i, j];
                    Console.Write(twoDimensionalArray[i, j] + " ");
                }
            }
            Console.WriteLine("\nСумма элементов на четной позиции: " + sum);
        }

        // Shows a sum of all letters, number of words and average word length
        public static void AverageLetters(string stringToWorkOn)
        {
            int sumOfLetters = 0;
            int numberOfWords = 0;
            float average;
            char[] stringToArray = stringToWorkOn.ToCharArray();
            for (var i = 0; i < stringToArray.Length; i++)
            {
                if (Char.IsLetter(stringToArray[i])) sumOfLetters++;
                if (i > 0 && Char.IsLetter(stringToArray[i - 1]) && !Char.IsLetter(stringToArray[i])) numberOfWords++;
            }
            if (Char.IsLetter(stringToArray[stringToArray.Length - 1])) numberOfWords++;
            if (numberOfWords != 0)
            {
                average = (float)sumOfLetters / numberOfWords;
                Console.WriteLine("Количество слов: " + numberOfWords + ". Количество букв во всех словах: "
                                                      + sumOfLetters + ". Средняя длина слова: " + average + ".");
            }
            else Console.WriteLine("В строке нет слов.");
        }

        // Doubles all symbols in the first string which are in the second one
        public static void DoubleLetters(string firstString, string secondString)
        {
            var charList = new List<char>();
            foreach (var character in secondString) if (!charList.Contains(character)) charList.Add(character);
            foreach (var character in charList) firstString = firstString.Replace(character.ToString(),
                                                                                  character.ToString() + character.ToString());
            Console.WriteLine("Результат: " + firstString);
        }
    }
}
using System;
using static com.GitHub.Reiqen.Task1.Corrector;
using static com.GitHub.Reiqen.Task1.Functions;
using static Task1.Entities;

namespace com.GitHub.Reiqen.Task1
{
    /*
        This is the extraction point of the program.
        It solves tasks from the first exercise.
    */

    class Program
    {
        public static string ValueToCheck;
        public static string StringToWorkOn;

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в Task1.");
            // First task solution
            int[] sides = new int[2];
            for (var i = 0; i < sides.Length; i++)
            {
                Console.WriteLine("Введите положительное целое число {0} (сторону прямоугольника):", i + 1);
                ValueToCheck = Console.ReadLine();
                if (IsInt(ValueToCheck))
                {
                    if (IsPositiveInt(ValueToCheck)) sides[i] = Int32.Parse(ValueToCheck);
                    else
                    {
                        Console.WriteLine("Введенное вами значение отличается от положительного целого числа!");
                        i--;
                    }
                }
                else i--;
            }
            Console.WriteLine("Площадь прямоугольника: " + FigureArea(sides)); ;

            // Second, third and fourth tasks solution
            for (var i = 0; i < 1; i++)
            {
                Console.WriteLine("Введите положительное целое число (количество строк в прямоугольном треугольнике):", i + 1);
                ValueToCheck = Console.ReadLine();
                if (IsPositiveInt(ValueToCheck))
                {
                    Console.WriteLine("Прямоугольный треугольник");
                    RightTriangle(Int32.Parse(ValueToCheck));
                    Console.WriteLine("Обычный треугольник");
                    RegularTriangle(Int32.Parse(ValueToCheck));
                    Console.WriteLine("Рождественская ёлка");
                    xmasTree(Int32.Parse(ValueToCheck));
                }
                else
                {
                    Console.WriteLine("Введенное вами значение отличается от положительного целого числа!");
                    i--;
                }
            }

            // Fifth task solution
            Console.WriteLine("Сумма чисел от 1 до 1000, кратные 3 и 5: " + SumOfNumbers());

            // Sixth task solution
            Font font = FontAdjustment();
            while (true)
            {
                Console.WriteLine("Введите:\n\t1: bold\n\t2: italic\n\t3: underline\n\t4: выход из задания");
                ValueToCheck = Console.ReadLine();
                if (IsOneToFour(ValueToCheck))
                {
                    if (Int32.Parse(ValueToCheck) == 4) break;
                    else
                    {
                        font = FontAdjustment(Int32.Parse(ValueToCheck), font);
                        Console.WriteLine("Параметры надписи: " + font);
                    }
                }
                else Console.WriteLine("Введенное вами значение отличается от положительного целого числа от 1 до 4!");
            }

            // Seven task solution
            ArrayProccesing();

            // Eighth task solution
            NoPositive();

            // Ninth task solution
            NoNegativeSum();

            // Tenth task solution
            TwoDimensionalArray();

            // Eleventh task solution
            while (true)
            {
                Console.WriteLine("Введите строку:");
                StringToWorkOn = Console.ReadLine();
                if (!String.IsNullOrEmpty(StringToWorkOn))
                {
                    AverageLetters(StringToWorkOn);
                    break;
                }
                else Console.WriteLine("Строка не должна быть пустой!");
            }

            // Eleventh task solution
            string firstString;
            string secondString;
            while (true)
            {
                Console.WriteLine("Введите первую строку:");
                firstString = Console.ReadLine();
                if (!String.IsNullOrEmpty(firstString))
                {
                    Console.WriteLine("Введите вторую строку (может быть пустой):");
                    secondString = Console.ReadLine();
                    DoubleLetters(firstString, secondString);
                    break;
                }
                else Console.WriteLine("Первая строка не должна быть пустой!");
            }

            // The end of the program
            Console.WriteLine("\nСпасибо за пользование программой.\nНажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
}

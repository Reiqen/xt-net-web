using System;
using static com.GitHub.Reiqen.Task0.Corrector;
using static com.GitHub.Reiqen.Task0.Functions;

namespace com.GitHub.Reiqen.Task0
{
    /*
        This is the extraction point of the program.
        It solves tasks from the intro exercise.
    */
    class Program
    {
        // Contains a value which needs to be scanned for validity
        public static String ValueToCheck;
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в Task0.");

            // First task solution
            while (true)
            {
                Console.WriteLine("Введите положительное целое число:");
                ValueToCheck = Console.ReadLine();
                if (IsPositiveInt(ValueToCheck))
                {
                    MakeSequence(Int32.Parse(ValueToCheck));
                    break;
                }
                else Console.WriteLine("Введенное вами значение отличается от положительного целого числа!");
            }

            // Second task solution
            while (true)
            {
                Console.WriteLine("\nВведите положительное целое число:");
                ValueToCheck = Console.ReadLine();
                if (IsPositiveInt(ValueToCheck))
                {
                    SimplicityInfo(Int32.Parse(ValueToCheck));
                    break;
                }
                else Console.WriteLine("Введенное вами значение отличается от положительного целого числа!");
            }

            // Third task solution
            while (true)
            {
                Console.WriteLine("\nВведите положительное нечетное целое число:");
                ValueToCheck = Console.ReadLine();
                if (IsPositiveOddInt(ValueToCheck))
                {
                    PrintSquare(Int32.Parse(ValueToCheck));
                    break;
                }
                else Console.WriteLine("Введенное вами значение отличается от положительного нечетного целого числа!");
            }

            // Fourth task solution
            while (true)
            {
                Console.WriteLine("\nВведите положительное целое число (размерность массива):");
                ValueToCheck = Console.ReadLine();
                if (IsPositiveInt(ValueToCheck))
                {
                    var arrayOfValues = new int[Int32.Parse(ValueToCheck)];
                    for (var subArray = 1; subArray <= arrayOfValues.Length; subArray++) {
                        Console.WriteLine("\nВведите положительное целое число (количество элементов в подмассиве " + subArray + "):");
                        ValueToCheck = Console.ReadLine();
                        if (IsPositiveInt(ValueToCheck)) arrayOfValues[subArray - 1] = Int32.Parse(ValueToCheck);
                        else
                        {
                            Console.WriteLine("Введенное вами значение отличается от положительного целого числа!");
                            subArray--;
                        }
                    }
                    PrintSortedArray(PrintAndReturnUnsortedArray(arrayOfValues));
                    break;
                }
                else Console.WriteLine("Введенное вами значение отличается от положительного целого числа!");
            }

            // The end of the program
            Console.WriteLine("\nСпасибо за пользование программой.\nНажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
}
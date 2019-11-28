using System;
using static com.GitHub.Reiqen.Task2.utils.Corrector;
using static com.GitHub.Reiqen.Task2.utils.Performer;

namespace com.GitHub.Reiqen.Task2
{
    class Program
    {
        public static String ValueToCheck;
        public static bool exit = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в Task2.");

            while (!exit)
            {
                Console.WriteLine("Введите задачу:\n1. Работа с кругом.\n2. Работа с треугольником." +
                    "\n3. Работа с пользователем.\n4. Работа с MyString.\n5. Работа с Employee." +
                    "\n6. Работа с кольцом.\n7. Работа с Vector Graphics Editor.\n8. Работа с игрой." +
                    "\n9. Выход из программы.");
                ValueToCheck = Console.ReadLine();
                if (IsMenuCase(ValueToCheck)) 
                {
                    switch (int.Parse(ValueToCheck))
                    {
                        case 1: PerformRound(); break;
                        case 2: PerformTriangle(); break;
                        case 3: PerformUser(); break;
                        case 4: PerformMyString(); break;
                        case 5: PerformEmployee(); break;
                        case 6: PerformRing(); break;
                        case 7: PerformEditor(); break;
                        case 8: PerformGame(); break;
                        case 9: exit = true; break;
                    }
                }
                else Console.WriteLine("Введенное значение отличается от номера задачи!");
            }
            Console.WriteLine("\nСпасибо за пользование программой.\nНажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
}
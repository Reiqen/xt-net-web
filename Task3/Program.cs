using System;
using System.Collections.Generic;
using static com.GitHub.Reiqen.Task3.Lost;
using static com.GitHub.Reiqen.Task3.Corrector;

namespace com.GitHub.Reiqen.Task3
{
    class Program
    {
        public static String ValueToCheck;
        static void Main(string[] args)
        {
            // First task
            Console.WriteLine("Введите положительное число:");
            ValueToCheck = Console.ReadLine();
            if (IsPositiveInt(ValueToCheck))
            {
                var list = new List<string>();
                Console.WriteLine("Список людей:");
                for (int i = 0; i < int.Parse(ValueToCheck); i++)
                {
                    list.Add("Person " + (i + 1));
                }

                foreach (string person in list)
                {
                    Console.WriteLine(person);
                }

                Console.WriteLine("Последний оставшийся: " + RemoveEachSecondItem<string>(list));
            }
            else Console.WriteLine("Ошибка ввода числа");

            // Second task
            Console.WriteLine("Введите строку:");
            ValueToCheck = Console.ReadLine();
            if (IsNotNullString(ValueToCheck))
            {
                string str = ValueToCheck;
                str = str.ToLower();
                str = str.Replace(".", " ");

                SortedList<string, int> dict = new SortedList<string, int>();
                foreach (string s in str.Split(' '))
                {
                    if (dict.ContainsKey(s))
                    {
                        dict[s] = dict[s] + 1;
                    }
                    else
                    {
                        dict.Add(s, 1);
                    }

                    dict.Remove("");
                }
                foreach (KeyValuePair<string, int> kvp in dict)
                {
                    Console.WriteLine("Слово = {0}, частота встречаемости = {1}", kvp.Key, kvp.Value);
                }
            }
            else Console.WriteLine("Строка не должна быть пустой");

            // Third task implementation in DynamicArray class
        Console.ReadKey();
        }
    }
}
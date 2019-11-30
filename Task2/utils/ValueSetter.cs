using System;
using static com.GitHub.Reiqen.Task2.utils.Corrector;
using com.GitHub.Reiqen.Task2.entities;
using System.Text.RegularExpressions;
using System.Globalization;

namespace com.GitHub.Reiqen.Task2.utils
{
    /*
        This class provides methods to set neccesary values correctly.
        Please read comments above methods for more information.
    */
    class ValueSetter
    {
        public static string ValueToCheck;

        // Sets integer coordinate which can be positive or negative
        public static void SetCoordinate(Figure figure, string propertyName)
        {
            var property = figure.GetType().GetProperty(propertyName);
            while (true)
            {
                Console.WriteLine("Введите координату " + propertyName + ":");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectCoordinatePoint(ValueToCheck))
                {
                    property.SetValue(figure, int.Parse(ValueToCheck));
                    break;
                }
                else Console.WriteLine("Величина должна быть целым числом!");
            }
        }

        // Sets length of something, for example, radius. Must be positive double.
        public static void SetLength(Figure figure, string propertyName, string description)
        {
            var property = figure.GetType().GetProperty(propertyName);
            while (true)
            {
                Console.WriteLine("Введите длину переменной " + propertyName + description + ":");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectLength(ValueToCheck))
                {
                    property.SetValue(figure, double.Parse(ValueToCheck));
                    break;
                }
                else Console.WriteLine("Величина должна быть положительным double!");
            }
        }

        // Sets title such as name or job title. Must fit regex from parameter.
        public static void SetTitle(User user, string propertyName, Regex rgx)
        {
            var property = user.GetType().GetProperty(propertyName);
            while (true)
            {
                Console.WriteLine("Введите переменную " + propertyName + ":");
                ValueToCheck = Console.ReadLine();
                if (rgx.IsMatch(ValueToCheck))
                {
                    property.SetValue(user, ValueToCheck);
                    break;
                }
                else Console.WriteLine("Написанное должно быть на русском языке и начинаться с заглавной буквы, " +
                                       "также не должно быть посторонних символов!");
            }
        }

        // Sets date. Must fit regex from parameter.
        public static void SetDate(User user, string propertyName, Regex rgx, string description)
        {
            var property = user.GetType().GetProperty(propertyName);
            while (true)
            {
                Console.WriteLine("Введите в формате дд-мм-гггг переменную " + propertyName + description + ":");
                ValueToCheck = Console.ReadLine();
                if (rgx.IsMatch(ValueToCheck))
                {
                    if (IsCorrectDate(ValueToCheck))
                    {
                        property.SetValue(user, DateTime.ParseExact(ValueToCheck, "dd-MM-yyyy", CultureInfo.InvariantCulture));
                        break;
                    }
                    else Console.WriteLine("Произошла ошибка записи даты. Возможно, такого числа в месяце не существует.");
                }
                else Console.WriteLine("Формат даты не соблюден!");
            }
        }

        // Sets string. Checks if it is not null or empty.
        public static void SetString(MyString myStr, string propertyName)
        {
            var property = myStr.GetType().GetProperty(propertyName);
            while (true)
            {
                Console.WriteLine("Введите переменную " + propertyName + ":");
                ValueToCheck = Console.ReadLine();
                if (!String.IsNullOrEmpty(ValueToCheck))
                {
                    property.SetValue(myStr, ValueToCheck);
                    break;
                }
                else Console.WriteLine("Строка не должна быть пустой!");
            }
        }

        // Sets symbol. Must be exactly one symbol.
        public static void SetSymbol(MyString myStr, string propertyName)
        {
            var property = myStr.GetType().GetProperty(propertyName);
            while (true)
            {
                Console.WriteLine("Введите переменную " + propertyName + ":");
                ValueToCheck = Console.ReadLine();
                if (ValueToCheck.Length == 1)
                {
                    property.SetValue(myStr, ValueToCheck[0]);
                    break;
                }
                else Console.WriteLine("Должен быть один символ!");
            }
        }
    }
}
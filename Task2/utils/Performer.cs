using System;
using static com.GitHub.Reiqen.Task2.utils.Corrector;
using com.GitHub.Reiqen.Task2.entities;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;

namespace com.GitHub.Reiqen.Task2.utils
{
    class Performer
    {
        public static string ValueToCheck;
        public static Regex rgx;
        public static void PerformRound()
        {
            var round = new Round();
            while (true)
            {
                Console.WriteLine("Введите координату X:");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectCoordinatePoint(ValueToCheck))
                {
                    round.X1 = int.Parse(ValueToCheck);
                    break;
                }
                else Console.WriteLine("Величина должна быть целым числом!");
            }
            while (true)
            {
                Console.WriteLine("Введите координату Y:");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectCoordinatePoint(ValueToCheck))
                {
                    round.Y1 = int.Parse(ValueToCheck);
                    break;
                }
                else Console.WriteLine("Величина должна быть целым числом!");
            }
            while (true)
            {
                Console.WriteLine("Введите радиус:");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectLength(ValueToCheck))
                {
                    round.Radius = double.Parse(ValueToCheck);
                    break;
                }
                else Console.WriteLine("Величина должна быть положительным double!");
            }
            Console.WriteLine(round.Info());
        }
        public static void PerformTriangle()
        {
            var triangle = new Triangle();
            while (true)
            {
                Console.WriteLine("Введите длину A:");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectLength(ValueToCheck))
                {
                    triangle.A = double.Parse(ValueToCheck);
                    break;
                }
                else Console.WriteLine("Величина должна быть положительным double!");
            }
            while (true)
            {
                Console.WriteLine("Введите длину B:");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectLength(ValueToCheck))
                {
                    triangle.B = double.Parse(ValueToCheck);
                    break;
                }
                else Console.WriteLine("Величина должна быть положительным double!");
            }
            while (true)
            {
                Console.WriteLine("Введите длину C:");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectLength(ValueToCheck))
                {
                    triangle.C = double.Parse(ValueToCheck);
                    break;
                }
                else Console.WriteLine("Величина должна быть положительным double!");
            }
            Console.WriteLine(triangle.ToString());
        }
        public static void PerformUser()
        {
            var user = new User();
            rgx = new Regex(@"^[А-Я][а-я]+$");
            while (true)
            {
                Console.WriteLine("Введите имя:");
                ValueToCheck = Console.ReadLine();
                if (rgx.IsMatch(ValueToCheck))
                {
                    user.Name = ValueToCheck;
                    break;
                }
                else Console.WriteLine("Имя должно быть на русском языке и начинаться с заглавной буквы, " +
                                       "также не должно быть посторонних символов!");
            }
            while (true)
            {
                Console.WriteLine("Введите фамилию:");
                ValueToCheck = Console.ReadLine();
                if (rgx.IsMatch(ValueToCheck))
                {
                    user.Surname = ValueToCheck;
                    break;
                }
                else Console.WriteLine("Фамилия должна быть на русском языке и начинаться с заглавной буквы, " +
                                       "также не должно быть посторонних символов!");
            }
            rgx = new Regex(@"^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](19|20)[0-9][0-9]$");
            while (true)
            {
                Console.WriteLine("Введите дату в формате дд-мм-гггг:");
                ValueToCheck = Console.ReadLine();
                if (rgx.IsMatch(ValueToCheck))
                {
                    if (IsCorrectDate(ValueToCheck))
                    {
                        user.DateOfBirth = DateTime.ParseExact(ValueToCheck, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        break;
                    }
                    else Console.WriteLine("Произошла ошибка записи даты. Возможно, такого числа в месяце не существует.");
                }
                else Console.WriteLine("Формат даты не соблюден!");
            }
            Console.WriteLine(user.ToString());
        }
        public static void PerformMyString()
        {
            var MyStr = new MyString();
            while (true)
            {
                Console.WriteLine("Введите строку 1:");
                ValueToCheck = Console.ReadLine();
                if (!String.IsNullOrEmpty(ValueToCheck))
                {
                    MyStr.First = ValueToCheck;
                    break;
                }
                else Console.WriteLine("Строка не должна быть пустой!");
            }
            while (true)
            {
                Console.WriteLine("Введите строку 2:");
                ValueToCheck = Console.ReadLine();
                if (!String.IsNullOrEmpty(ValueToCheck))
                {
                    MyStr.Second = ValueToCheck;
                    break;
                }
                else Console.WriteLine("Строка не должна быть пустой!");
            }
            while (true)
            {
                Console.WriteLine("Введите символ для поиска:");
                ValueToCheck = Console.ReadLine();
                if (ValueToCheck.Length == 1)
                {
                    MyStr.Ch = ValueToCheck[0];
                    break;
                }
                else Console.WriteLine("Должен быть один символ!");
            }
            Console.WriteLine(MyStr.ToString());
        }
        public static void PerformEmployee()
        {
            var employee = new Employee();
            rgx = new Regex(@"^[А-Я][а-я]+$");
            while (true)
            {
                Console.WriteLine("Введите имя:");
                ValueToCheck = Console.ReadLine();
                if (rgx.IsMatch(ValueToCheck))
                {
                    employee.Name = ValueToCheck;
                    break;
                }
                else Console.WriteLine("Имя должно быть на русском языке и начинаться с заглавной буквы, " +
                                       "также не должно быть посторонних символов!");
            }
            while (true)
            {
                Console.WriteLine("Введите фамилию:");
                ValueToCheck = Console.ReadLine();
                if (rgx.IsMatch(ValueToCheck))
                {
                    employee.Surname = ValueToCheck;
                    break;
                }
                else Console.WriteLine("Фамилия должна быть на русском языке и начинаться с заглавной буквы, " +
                                       "также не должно быть посторонних символов!");
            }
            rgx = new Regex(@"^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](19|20)[0-9][0-9]$");
            while (true)
            {
                Console.WriteLine("Введите дату в формате дд-мм-гггг:");
                ValueToCheck = Console.ReadLine();
                if (rgx.IsMatch(ValueToCheck))
                {
                    if (IsCorrectDate(ValueToCheck))
                    {
                        employee.DateOfBirth = DateTime.ParseExact(ValueToCheck, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        break;
                    }
                    else Console.WriteLine("Произошла ошибка записи даты. Возможно, такого числа в месяце не существует.");
                }
                else Console.WriteLine("Формат даты не соблюден!");
            }
            rgx = new Regex(@"^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](20)[1][0-9]$");
            while (true)
            {
                Console.WriteLine("Введите дату приема на работу в формате дд-мм-гггг (с 2010 года):");
                ValueToCheck = Console.ReadLine();
                if (rgx.IsMatch(ValueToCheck))
                {
                    if (IsCorrectDate(ValueToCheck))
                    {
                        employee.DateOfHire = DateTime.ParseExact(ValueToCheck, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        break;
                    }
                    else Console.WriteLine("Произошла ошибка записи даты. Возможно, такого числа в месяце не существует.");
                }
                else Console.WriteLine("Формат даты не соблюден!");
            }
            rgx = new Regex(@"^[А-Я][а-я]+$");
            while (true)
            {
                Console.WriteLine("Введите должность:");
                ValueToCheck = Console.ReadLine();
                if (rgx.IsMatch(ValueToCheck))
                {
                    employee.Position = ValueToCheck;
                    break;
                }
                else Console.WriteLine("Должность должна быть на русском языке и начинаться с заглавной буквы, " +
                                       "также не должно быть посторонних символов!");
            }
            Console.WriteLine(employee.ToString());
        }
        public static void PerformRing()
        {
            var ring = new Ring();
            var inner = new Round();
            var outer = new Round();
            while (true)
            {
                Console.WriteLine("Введите координату X:");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectCoordinatePoint(ValueToCheck))
                {
                    inner.X1 = int.Parse(ValueToCheck);
                    outer.X1 = int.Parse(ValueToCheck); ;
                    break;
                }
                else Console.WriteLine("Величина должна быть целым числом!");
            }
            while (true)
            {
                Console.WriteLine("Введите координату Y:");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectCoordinatePoint(ValueToCheck))
                {
                    inner.Y1 = int.Parse(ValueToCheck);
                    outer.Y1 = int.Parse(ValueToCheck);
                    break;
                }
                else Console.WriteLine("Величина должна быть целым числом!");
            }
            while (true)
            {
                Console.WriteLine("Введите радиус внутренней окружности:");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectLength(ValueToCheck))
                {
                    inner.Radius = double.Parse(ValueToCheck);
                    break;
                }
                else Console.WriteLine("Величина должна быть положительным double!");
            }
            while (true)
            {
                Console.WriteLine("Введите радиус внешней окружности:");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectLength(ValueToCheck))
                {
                    if (double.Parse(ValueToCheck) > inner.Radius)
                    {
                        outer.Radius = double.Parse(ValueToCheck);
                        break;
                    }
                    else Console.WriteLine("Радиус внешней окружности должен быть больше радиуса внутренней!");
                }
                else Console.WriteLine("Величина должна быть положительным double!");
            }
            ring.inner = inner;
            ring.outer = outer;
            Console.WriteLine(ring.Info());
        }
        public static void PerformEditor()
        {
            var list = new List<Figure>();
            int X1;
            int Y1;
            int X2;
            int Y2;
            double innerRadius;
            double outerRadius;
            while (true)
            {
                Console.WriteLine("Введите координату X1:");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectCoordinatePoint(ValueToCheck))
                {
                    X1 = int.Parse(ValueToCheck);
                    break;
                }
                else Console.WriteLine("Величина должна быть целым числом!");
            }
            while (true)
            {
                Console.WriteLine("Введите координату Y1:");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectCoordinatePoint(ValueToCheck))
                {
                    Y1 = int.Parse(ValueToCheck);
                    break;
                }
                else Console.WriteLine("Величина должна быть целым числом!");
            }
            while (true)
            {
                Console.WriteLine("Введите координату X2:");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectCoordinatePoint(ValueToCheck))
                {
                    X2 = int.Parse(ValueToCheck);
                    break;
                }
                else Console.WriteLine("Величина должна быть целым числом!");
            }
            while (true)
            {
                Console.WriteLine("Введите координату Y2:");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectCoordinatePoint(ValueToCheck))
                {
                    Y2 = int.Parse(ValueToCheck);
                    break;
                }
                else Console.WriteLine("Величина должна быть целым числом!");
            }
            while (true)
            {
                Console.WriteLine("Введите радиус внутренней окружности:");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectLength(ValueToCheck))
                {
                    innerRadius = double.Parse(ValueToCheck);
                    break;
                }
                else Console.WriteLine("Величина должна быть положительным double!");
            }
            while (true)
            {
                Console.WriteLine("Введите радиус внешней окружности:");
                ValueToCheck = Console.ReadLine();
                if (IsCorrectLength(ValueToCheck))
                {
                    if (double.Parse(ValueToCheck) > innerRadius)
                    {
                        outerRadius = double.Parse(ValueToCheck);
                        break;
                    }
                    else Console.WriteLine("Радиус внешней окружности должен быть больше радиуса внутренней!");
                }
                else Console.WriteLine("Величина должна быть положительным double!");
            }
            var round = new Round();
            var inner = new Round();
            var outer = new Round();
            var ring = new Ring();
            var rectangle = new Rectangle();
            var line = new Line();
            var circle = new Circle();
            round.X1 = X1;
            round.Y1 = Y1;
            round.Radius = innerRadius;
            inner.X1 = X1;
            inner.Y1 = Y1;
            outer.X1 = X1;
            outer.Y1 = Y1;
            inner.Radius = innerRadius;
            outer.Radius = outerRadius;
            ring.inner = inner;
            ring.outer = outer;
            rectangle.X1 = X1;
            rectangle.X2 = X2;
            rectangle.Y1 = Y1;
            rectangle.Y2 = Y2;
            line.X1 = X1;
            line.X2 = X2;
            line.Y1 = Y1;
            line.Y2 = Y2;
            circle.X1 = X1;
            circle.Y1 = Y1;
            circle.Radius = innerRadius;
            list.Add(round);
            list.Add(ring);
            list.Add(rectangle);
            list.Add(line);
            list.Add(circle);
            foreach (Figure figure in list)
            {
                Console.WriteLine("Полный тип: " + figure.GetType());
                Console.WriteLine("Описание: " + figure.Info());
            }
        }
        public static void PerformGame()
        {
            Console.WriteLine("Смотрите классы в папке \"game\"");
        }
    }
}
using System;
using static com.GitHub.Reiqen.Task2.utils.ValueSetter;
using com.GitHub.Reiqen.Task2.entities;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace com.GitHub.Reiqen.Task2.utils
{
    /*
        This class provides methods to perform tasks.
        Please read comments above methods for more information.
    */
    class Performer
    {
        public static Regex rgx;

        // Creates a round and shows info about it
        public static void PerformRound()
        {
            var round = new Round();
            SetCoordinate(round, "X1");
            SetCoordinate(round, "Y1");
            SetLength(round, "Radius", "");
            Console.WriteLine(round.Info());
        }

        // Creates a triangle and shows info about it
        public static void PerformTriangle()
        {
            var triangle = new Triangle();
            SetLength(triangle, "A", "");
            SetLength(triangle, "B", "");
            SetLength(triangle, "C", "");
            Console.WriteLine(triangle.Info());
        }

        // Creates a user and shows info about it
        public static void PerformUser()
        {
            var user = new User();
            rgx = new Regex(@"^[А-Я][а-я]+$");
            SetTitle(user, "Name", rgx);
            SetTitle(user, "Surname", rgx);
            rgx = new Regex(@"^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](19|20)[0-9][0-9]$");
            SetDate(user, "DateOfBirth", rgx, " (не раньше 1900 года)");
            Console.WriteLine(user.ToString());
        }

        // Creates a string and shows info about it
        public static void PerformMyString()
        {
            var MyStr = new MyString();
            SetString(MyStr, "FirstString");
            SetString(MyStr, "SecondString");
            SetSymbol(MyStr, "Symbol");
            Console.WriteLine(MyStr.ToString());
        }

        // Creates an employee and shows info about it
        public static void PerformEmployee()
        {
            var employee = new Employee();
            rgx = new Regex(@"^[А-Я][а-я]+$");
            SetTitle(employee, "Name", rgx);
            SetTitle(employee, "Surname", rgx);
            rgx = new Regex(@"^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](19|20)[0-9][0-9]$");
            SetDate(employee, "DateOfBirth", rgx, " (не раньше 1900 года)");
            rgx = new Regex(@"^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](20)[1][0-9]$");
            SetDate(employee, "DateOfHire", rgx, " (не раньше 2010 года)");
            rgx = new Regex(@"^[А-Я][а-я]+$");
            SetTitle(employee, "Position", rgx);
            Console.WriteLine(employee.ToString());
        }

        // Creates a ring and shows info about it
        public static void PerformRing()
        {
            var ring = new Ring();
            var inner = new Round();
            var outer = new Round();
            SetCoordinate(inner, "X1");
            outer.X1 = inner.X1;
            SetCoordinate(inner, "Y1");
            outer.Y1 = inner.Y1;
            SetLength(inner, "Radius", " (внутренний круг)");
            while (true)
            {
                SetLength(outer, "Radius", " (внешний круг)");
                if (outer.Radius <= inner.Radius) Console.WriteLine("Радиус внешней окружности должен быть больше радиуса внутренней!");
                else break;
            }
            ring.inner = inner;
            ring.outer = outer;
            Console.WriteLine(ring.Info());
        }

        // Creates several figures in one list and shows info about them
        public static void PerformEditor()
        {
            var list = new List<Figure>();
            var round = new Round();
            var inner = new Round();
            var outer = new Round();
            var ring = new Ring();
            var rectangle = new Rectangle();
            var line = new Line();
            var circle = new Circle();
            SetCoordinate(rectangle, "X1");
            SetCoordinate(rectangle, "X2");
            SetCoordinate(rectangle, "Y1");
            SetCoordinate(rectangle, "Y2");
            SetLength(inner, "Radius", " (внутренний круг)");
            while (true)
            {
                SetLength(outer, "Radius", " (внешний круг)");
                if (outer.Radius <= inner.Radius) Console.WriteLine("Радиус внешней окружности должен быть больше радиуса внутренней!");
                else break;
            }
            round.X1 = rectangle.X1;
            round.Y1 = rectangle.Y1;
            round.Radius = inner.Radius;
            inner.X1 = rectangle.X1;
            inner.Y1 = rectangle.Y1;
            outer.X1 = rectangle.X1;
            outer.Y1 = rectangle.Y1;
            ring.inner = inner;
            ring.outer = outer;
            line.X1 = rectangle.X1;
            line.X2 = rectangle.X2;
            line.Y1 = rectangle.Y1;
            line.Y2 = rectangle.Y2;
            circle.X1 = rectangle.X1;
            circle.Y1 = rectangle.Y1;
            circle.Radius = inner.Radius;
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

        // Shows info about last task
        public static void PerformGame() => Console.WriteLine("Смотрите классы в папке \"game\"");
    }
}
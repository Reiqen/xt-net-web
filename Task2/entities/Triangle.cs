using System;
using static System.Math;

namespace com.GitHub.Reiqen.Task2.entities
{
    class Triangle : Figure
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        private double GetPerimeter() => A + B + C;

        private double GetArea()
        {
            double p = GetPerimeter() / 2F;
            double result = Sqrt(p * (p - A) * (p - B) * (p - C));
            return result;
        }

        public override string Info()
        {
            if (double.IsNaN(GetArea())) return "Одна из сторон треугольника больше суммы двух других, указанный треугольник не существует";
            else
            {
                string info = string.Format("Треугольник со сторонами {0}, {1}, {2}, периметр: {3}, площадь: {4}.",
                  A, B, C, GetPerimeter(), GetArea());
                return info;
            }
        }
    }
}

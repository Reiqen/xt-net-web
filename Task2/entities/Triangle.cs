using static System.Math;

namespace com.GitHub.Reiqen.Task2.entities
{
    class Triangle
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        private double GetPerimeter() => this.A + this.B + this.C;

        private double GetArea()
        {
            double p = GetPerimeter() / 2;
            return Sqrt(p * (p - this.A) * (p - this.B) * (p - this.C));
        }

        public override string ToString()
        {
            string info = string.Format("Треугольник со сторонами {0}, {1}, {2}, периметр: {3}, площадь: {4}.",
                A, B, C, GetPerimeter(), GetArea());
            return info;
        }
    }
}

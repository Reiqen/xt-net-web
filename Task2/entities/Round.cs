using static System.Math;

namespace com.GitHub.Reiqen.Task2.entities
{
    class Round : Figure
    {
        public double Radius { get; set; }

        private double GetCircumference() => 2 * PI * this.Radius;

        private double GetArea() => PI * this.Radius * this.Radius;

        public override string Info()
        {
            string info = string.Format("Круг с координатами {0}, {1}, радиус: {2}, длина окружности: {3}, площадь: {4}.",
                                        X1, Y1, Radius, GetCircumference(), GetArea());
            return info;
        }
    }
}
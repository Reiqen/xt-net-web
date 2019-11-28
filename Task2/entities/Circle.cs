using static System.Math;

namespace com.GitHub.Reiqen.Task2.entities
{
    class Circle : Figure
    {
        public double Radius { get; set; }

        private double GetCircumference() => 2 * PI * this.Radius;

        public override string Info()
        {
            string info = string.Format("Окружность с координатами {0}, {1}, радиус: {2}, длина окружности: {3}.",
                                        X1, Y1, Radius, GetCircumference());
            return info;
        }
    }
}
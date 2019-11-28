using static System.Math;

namespace com.GitHub.Reiqen.Task2.entities
{
    class Ring : Figure
    {
        public Round inner { get; set; }
        public Round outer { get; set; }
        private double GetArea() => PI * ((outer.Radius * outer.Radius) - (inner.Radius * inner.Radius));

        private double GetCommonLength() => 2 * PI * (inner.Radius + outer.Radius);

        public override string Info()
        {
            X1 = inner.X1;
            Y1 = inner.Y1;
            string info = string.Format("Кольцо с координатами {0}, {1}, площадь кольца: {2}, суммарная длина окружностей: {3}.",
                                        X1, Y1, GetArea(), GetCommonLength());
            return info;
        }
    }
}

namespace com.GitHub.Reiqen.Task2.entities
{
    class Rectangle : Figure
    {
        public int X2 { get; set; } = 0;
        public int Y2 { get; set; } = 0;

        public override string Info()
        {
            string info = string.Format("Прямоугольник с координатами [{0}, {1}], [{2}, {3}], [{4}, {5}], [{6}, {7}].",
                                        X1, Y1, X1, Y2, X2, Y2, X2, Y1);
            return info;
        }
    }
}

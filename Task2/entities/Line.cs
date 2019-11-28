
namespace com.GitHub.Reiqen.Task2.entities
{
    class Line : Figure
    {
        public int X2 { get; set; } = 0;
        public int Y2 { get; set; } = 0;
        public override string Info()
        {
            string info = string.Format("Линия с начальными координатами {0}, {1}, конечными координатами {2}, {3}",
                                        X1, Y1, X2, Y2);
            return info;
        }
    }
}
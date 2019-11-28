
namespace com.GitHub.Reiqen.Task2.game
{
    abstract class Bonus : IUpable
    {
        Field field;
        double Coordinate1;
        double Coordinate2;

        public abstract void SetCoordinates();
        public abstract void Up(Skills skills);
    }
}
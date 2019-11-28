
namespace com.GitHub.Reiqen.Task2.game
{
    class Cherry : Bonus
    {
        Field field = new Field();
        double Coordinate1;
        double Coordinate2;

        public override void SetCoordinates()
        {
            Coordinate1 = field.Coordinate1;
            Coordinate2 = field.Coordinate2;
        }

        public override void Up(Skills skills)
        {
        }
    }
}
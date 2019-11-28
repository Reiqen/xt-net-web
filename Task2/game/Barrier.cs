
namespace com.GitHub.Reiqen.Task2.game
{
    abstract class Barrier : IStoppable
    {
        Field field;
        double Coordinate1;
        double Coordinate2;

        public abstract void SetCoordinates();

        public abstract void Stop(Barrier barrier, double speed);
    }
}

namespace com.GitHub.Reiqen.Task2.game
{
    abstract class Monster : Character
    {
        public abstract override void Attack(Character character, double damage);

        public abstract override void Move(double speed, Direction direction);
    }
}
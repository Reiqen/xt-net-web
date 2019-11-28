
namespace com.GitHub.Reiqen.Task2.game
{
    abstract class Character: IMovable, IAttackable
    {
        Skills skills;
        Direction direction;
        public string Name { get; set; }
        public abstract void Move(double speed, Direction direction);
        public abstract void Attack(Character character, double damage);
    }
}

namespace com.GitHub.Reiqen.Task2.game
{
    class Player : Character
    {
        Skills skills = new Skills();
        Direction direction = new Direction();
        
        public override void Move(double speed, Direction direction)
        {
        }
        public override void Attack(Character character, double damage)
        {
        }

        public void Win(Bonus bonus, double health)
        {
        }
    }
}
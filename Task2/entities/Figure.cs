
namespace com.GitHub.Reiqen.Task2.entities
{
    public abstract class Figure
    {
        public int X1 { get; set; } = 0;
        public int Y1 { get; set; } = 0;

        public virtual string Info() => base.ToString();
    }
}

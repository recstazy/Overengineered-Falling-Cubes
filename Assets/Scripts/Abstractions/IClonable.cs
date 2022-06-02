namespace FallingDamage
{
    public interface IClonable<T> where T : IClonable<T>
    {
        T Clone();
    }
}

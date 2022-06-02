namespace FallingDamage
{
    public interface IDependent<T> 
    {
        void Initialize(T param);
    }
}

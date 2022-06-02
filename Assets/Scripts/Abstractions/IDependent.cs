namespace FallingCubes.Abstractions
{
    public interface IDependent<T> 
    {
        void Initialize(T param);
    }
}

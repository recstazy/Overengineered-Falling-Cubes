namespace FallingCubes
{
    public interface IDependent<T> 
    {
        void Initialize(T param);
    }
}

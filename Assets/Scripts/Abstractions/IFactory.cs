namespace FallingCubes.Abstractions
{
    public interface IFactory<T>
    {
        T Create();
    }

    public interface IFactory<TParam, TResult>
    {
        TResult Create(TParam param);
    }
}

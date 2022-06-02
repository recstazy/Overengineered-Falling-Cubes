namespace FallingCubes
{
    public interface IInterpolatable
    {
        float LerpFactor { get; set; }
    }

    public interface IInterpolatable<T> : IInterpolatable where T : struct
    {
        T MinValue { get; set; }
        T MaxValue { get; set; }
    }
}

using System;

namespace FallingCubes
{
    public interface IStatModifier<T> where T : IComparable<T> 
    {
        T Modify(in T value);
    }
}

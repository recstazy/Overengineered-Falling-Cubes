using System;

namespace FallingCubes.Stats.Abstract
{
    public interface IStatModifier<T> where T : IComparable<T> 
    {
        T Modify(in T value);
    }
}

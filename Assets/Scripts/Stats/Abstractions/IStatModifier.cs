using System;

namespace FallingDamage
{
    public interface IStatModifier<T> where T : IComparable<T> 
    {
        T Modify(in T value);
    }
}

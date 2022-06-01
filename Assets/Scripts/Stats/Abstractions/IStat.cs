using System;
using System.Collections.Generic;

namespace FallingDamage
{
    public interface IStat<T> where T : IComparable<T>
    {
        T MinValue { get; }
        T MaxValue { get; }
        T DefaultValue { get; }
        T CurrentValue { get; }
        IReadOnlyCollection<IStatModifier<T>> Modifiers { get; } 
        void AddModifier(IStatModifier<T> modifier);
        void RemoveModifier(int index);
    }
}

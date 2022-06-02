using System;
using System.Collections.Generic;
using FallingCubes.Abstractions;

namespace FallingCubes.Stats.Abstract
{
    public interface IStat<T> : IClonable<IStat<T>> where T : IComparable<T>
    {
        public event Action OnValueChanged;

        T MinValue { get; }
        T MaxValue { get; }
        T DefaultValue { get; }
        T CurrentValue { get; }
        IReadOnlyCollection<IStatModifier<T>> Modifiers { get; } 
        void AddModifier(IStatModifier<T> modifier);
        void RemoveModifier(int index);
        void ClearModifiers();
    }
}

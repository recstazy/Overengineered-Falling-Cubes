using System;
using System.Collections.Generic;

namespace FallingDamage
{
    public abstract class AbstractStat<T> : IStat<T> where T : IComparable<T>
    {
        public event Action OnValueChanged;

        public virtual T MinValue { get; protected set; }
        public virtual T MaxValue { get; protected set; }
        public virtual T DefaultValue { get; protected set; }
        public T CurrentValue => CalculateResultCurrentValue();

        public IReadOnlyCollection<IStatModifier<T>> Modifiers => modifiers.AsReadOnly();
        private List<IStatModifier<T>> modifiers = new List<IStatModifier<T>>();

        public void AddModifier(IStatModifier<T> modifier)
        {
            modifiers.Add(modifier);
            OnValueChanged?.Invoke();
        }

        public void RemoveModifier(int index)
        {
            modifiers.RemoveAt(index);
            OnValueChanged?.Invoke();
        }

        public abstract IStat<T> Clone();

        protected virtual T CalculateResultCurrentValue()
        {
            var currentValue = DefaultValue;

            foreach (var modifier in modifiers)
                currentValue = modifier.Modify(currentValue);

            if (currentValue.CompareTo(MinValue) < 0)
                currentValue = MinValue;
            else if (currentValue.CompareTo(MaxValue) > 0)
                currentValue = MaxValue;

            return currentValue;
        }
    }
}

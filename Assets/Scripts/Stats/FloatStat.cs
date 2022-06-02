using System;
using UnityEngine;

namespace FallingDamage
{
    [Serializable]
    public class FloatStat : AbstractStat<float>
    {
        [SerializeField]
        private float defaultValue;

        [SerializeField]
        private float minValue;

        [SerializeField]
        private float maxValue;

        public override float MinValue { get => minValue; protected set => minValue = value; }
        public override float MaxValue { get => maxValue; protected set => maxValue = value; }
        public override float DefaultValue { get => defaultValue; protected set => defaultValue = value; }

        public FloatStat(FloatStat source)
        {
            defaultValue = source.defaultValue;
            minValue = source.minValue;
            maxValue = source.maxValue;
        }

        public FloatStat(float defaultValue, float minValue, float maxValue)
        {
            this.defaultValue = defaultValue;
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
    }
}

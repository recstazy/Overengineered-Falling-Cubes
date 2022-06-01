using System;
using UnityEngine;

namespace FallingDamage
{
    public class HealthSystem : IDamagable, IOwnable
    {
        public event Action<DamageArgs> OnDamaged;
        public event Action<DamageArgs> OnDeath;

        public IStat<float> Health { get; private set; }
        public bool IsAlive { get; private set; }
        public object Owner { get; set; }

        public void Initialize(IStat<float> config)
        {
            Health = config;
            IsAlive = true;
        }

        public void TakeDamage(IDamaging damageCauser)
        {
            if (!IsAlive)
                return;

            var lastHealth = Health.CurrentValue;
            var newHealth = Health.CurrentValue - damageCauser.DamageAmount;

            IsAlive = newHealth > Health.MinValue;
            Health.AddModifier(new DecreaseFloat(damageCauser.DamageAmount));
            var healthDelta = lastHealth - Health.CurrentValue;

            if (Mathf.Approximately(healthDelta, 0f))
                return;

            var args = new DamageArgs(healthDelta, this, damageCauser);
            OnDamaged?.Invoke(args);

            if (!IsAlive)
                OnDeath?.Invoke(args);
        }
    }
}

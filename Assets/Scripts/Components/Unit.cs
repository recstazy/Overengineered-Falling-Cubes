using UnityEngine;

namespace FallingDamage
{
    public class Unit : MonoBehaviour, IDamagable
    {
        public HealthSystem HealthSystem { get; private set; }
        public object Owner => this;

        public void Initialize(HealthSystem healthSystem)
        {
            HealthSystem = healthSystem;
            HealthSystem.Owner = this;
        }

        public void TakeDamage(IDamaging damageCauser)
        {
            HealthSystem.TakeDamage(damageCauser);
        }
    }
}

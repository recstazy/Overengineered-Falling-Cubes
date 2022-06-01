using UnityEngine;

namespace FallingDamage
{
    public class Unit : MonoBehaviour, IDamagable
    {
        public IDamagable HealthSystem { get; private set; }
        public object Owner => this;

        public void Initialize(IDamagable healthSystem)
        {
            HealthSystem = healthSystem;
        }

        public void TakeDamage(IDamaging damageCauser)
        {
            HealthSystem.TakeDamage(damageCauser);
        }
    }
}

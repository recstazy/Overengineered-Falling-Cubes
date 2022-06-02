using UnityEngine;

namespace FallingDamage
{
    public class Unit : MonoBehaviour, IDamagable
    {
        public HealthSystem HealthSystem { get; private set; }
        public object Owner => this;

        private void OnDestroy()
        {
            if (HealthSystem != null)
                HealthSystem.OnDeath -= HealthDead;
        }

        public void Initialize(HealthSystem healthSystem)
        {
            HealthSystem = healthSystem;
            HealthSystem.Owner = this;
            HealthSystem.OnDeath += HealthDead;
        }

        private void HealthDead(DamageArgs obj)
        {
            gameObject.SetActive(false);
        }

        public void TakeDamage(IDamaging damageCauser)
        {
            HealthSystem.TakeDamage(damageCauser);
        }
    }
}

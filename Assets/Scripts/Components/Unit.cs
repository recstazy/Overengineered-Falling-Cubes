using UnityEngine;

namespace FallingDamage
{
    public class Unit : MonoBehaviour, IDamagable
    {
        public HealthSystem HealthSystem { get; private set; }
        public object Owner => this;

        private IInterpolatable[] healthDependencies;

        private void OnDestroy()
        {
            if (HealthSystem != null)
            {
                HealthSystem.OnDamaged -= DamageTaken;
                HealthSystem.OnDeath -= HealthDead;
            }
        }

        private void Start()
        {
            HealthSystem.OnDamaged += DamageTaken;
            HealthSystem.OnDeath += HealthDead;
            healthDependencies = GetComponentsInChildren<IInterpolatable>();
        }

        public void Initialize(HealthSystem healthSystem)
        {
            HealthSystem = healthSystem;
            HealthSystem.Owner = this;
        }

        public void TakeDamage(IDamaging damageCauser)
        {
            HealthSystem.TakeDamage(damageCauser);
        }

        private void HealthDead(DamageArgs obj)
        {
            gameObject.SetActive(false);
        }

        private void DamageTaken(DamageArgs args)
        {
            var stat = HealthSystem.Health;
            var factor = Mathf.InverseLerp(stat.MinValue, stat.MaxValue, stat.CurrentValue);

            foreach (var d in healthDependencies)
                d.LerpFactor = factor;
        }
    }
}

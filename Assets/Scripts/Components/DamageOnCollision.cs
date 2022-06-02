using UnityEngine;
using FallingCubes.Abstractions;
using FallingCubes.Stats.Abstract;

namespace FallingCubes.Core
{
    public class DamageOnCollision : MonoBehaviour, IWeapon
    {
        public float DamageAmount => DamageStat.CurrentValue;
        public IStat<float> DamageStat { get; private set; }
        public object Owner { get; set; }

        public void Initialize(IStat<float> damage)
        {
            DamageStat = damage;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.attachedRigidbody == null)
                return;

            if (collision.collider.attachedRigidbody.TryGetComponent<IDamagable>(out var damagable))
            {
                damagable.TakeDamage(this);
            }
        }
    }
}

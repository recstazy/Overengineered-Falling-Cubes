using System;
using System.Collections;
using UnityEngine;

namespace FallingDamage
{
    [RequireComponent(typeof(IWeapon), typeof(Rigidbody))]
    public class Projectile : MonoBehaviour 
    {
        public event Action<Projectile> OnSleep; 

        public IWeapon Weapon => weapon;
        public Rigidbody Body => body;

        private IWeapon weapon;
        private Rigidbody body;
        private IInterpolatable[] damageDependencies;

        private void Awake()
        {
            TryGetComponent(out weapon);
            TryGetComponent(out body);

            damageDependencies = GetComponents<IInterpolatable>();
        }

        private void Start()
        {
            weapon.DamageStat.OnValueChanged += StatChanged;
        }

        private void OnEnable()
        {
            StartCoroutine(WaitForRigidbodySleep());
        }

        private void OnDestroy()
        {
            weapon.DamageStat.OnValueChanged -= StatChanged;
        }

        public void ResetDamageStat()
        {
            weapon.DamageStat.ClearModifiers();
        }

        private IEnumerator WaitForRigidbodySleep()
        {
            yield return new WaitUntil(() => body.IsSleeping());
            OnSleep?.Invoke(this);
        }

        private void StatChanged()
        {
            var stat = weapon.DamageStat;
            var factor = Mathf.InverseLerp(stat.MinValue, stat.MaxValue, stat.CurrentValue);

            foreach (var d in damageDependencies)
                d.LerpFactor = factor;
        }
    }
}

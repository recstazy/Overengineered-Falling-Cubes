using System;
using System.Collections;
using UnityEngine;

namespace FallingDamage
{
    public class Projectile : MonoBehaviour 
    {
        public event Action<Projectile> OnSleep; 

        public IWeapon Weapon => weapon;

        private IWeapon weapon;
        private Rigidbody body;

        private void Awake()
        {
            TryGetComponent(out weapon);
            TryGetComponent(out body);
        }

        private void OnEnable()
        {
            StartCoroutine(WaitForRigidbodySleep());
        }

        private IEnumerator WaitForRigidbodySleep()
        {
            yield return new WaitUntil(() => body.IsSleeping());
            OnSleep?.Invoke(this);
        }
    }
}

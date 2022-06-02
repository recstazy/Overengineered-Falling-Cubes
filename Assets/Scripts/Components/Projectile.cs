using UnityEngine;

namespace FallingDamage
{
    public class Projectile : MonoBehaviour 
    {
        private IWeapon weapon;
        public IWeapon Weapon => weapon;

        private void Awake()
        {
            TryGetComponent(out weapon);
        }
    }
}

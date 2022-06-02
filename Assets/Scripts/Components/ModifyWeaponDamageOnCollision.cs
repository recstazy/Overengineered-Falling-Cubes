using UnityEngine;

namespace FallingDamage
{
    public class ModifyWeaponDamageOnCollision : MonoBehaviour
    {
        [SerializeField]
        private float decreaseValue;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.attachedRigidbody == null)
                return;

            if (collision.collider.attachedRigidbody.TryGetComponent<IWeapon>(out var weapon))
            {
                weapon.DamageStat.AddModifier(new DecreaseFloat(decreaseValue));
            }
        }
    }
}

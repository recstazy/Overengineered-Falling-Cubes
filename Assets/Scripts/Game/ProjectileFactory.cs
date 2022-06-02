using UnityEngine;

namespace FallingDamage
{
    [CreateAssetMenu(menuName = "Game/Projectile Factory", fileName = nameof(ProjectileFactory), order = 131)]
    public class ProjectileFactory : ScriptableObject, IFactory<Projectile>
    {
        [SerializeField]
        private Projectile projectilePrefab;

        [SerializeField]
        private FloatStat projectileBaseDamage;

        public Projectile Create()
        {
            var projectile = Instantiate(projectilePrefab);
            projectile.Weapon.Initialize(new FloatStat(projectileBaseDamage));
            return projectile;
        }
    }
}

using UnityEngine;
using FallingCubes.Abstractions;
using FallingCubes.Stats;

namespace FallingCubes.Core
{
    [CreateAssetMenu(menuName = "Game/Projectile Factory", fileName = nameof(ProjectileFactory), order = 131)]
    public class ProjectileFactory : ScriptableObject, IFactory<Projectile>
    {
        [SerializeField]
        private Projectile[] projectilePrefabs;

        [SerializeField]
        private FloatStat projectileBaseDamage;

        public Projectile Create()
        {
            var index = Random.Range(0, projectilePrefabs.Length);
            var projectile = Instantiate(projectilePrefabs[index]);
            projectile.Weapon.Initialize(new FloatStat(projectileBaseDamage));
            return projectile;
        }
    }
}

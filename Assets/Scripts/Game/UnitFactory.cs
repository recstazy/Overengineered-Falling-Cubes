using UnityEngine;
using FallingCubes.Abstractions;
using FallingCubes.Stats;

namespace FallingCubes.Core
{
    [CreateAssetMenu(menuName = "Game/Unit Factory", fileName = nameof(UnitFactory), order = 131)]
    public class UnitFactory : ScriptableObject, IFactory<Unit>
    {
        [SerializeField]
        private Unit unitPrefab;

        [SerializeField]
        private FloatStat unitHealthConfig;

        [SerializeField]
        private Bounds unitSpawnBounds;

        public Unit Create()
        {
            var position = unitSpawnBounds.RandomPointInside();
            var unit = Instantiate(unitPrefab, position, Quaternion.identity, null);
            var health = new HealthSystem();
            health.Initialize(unitHealthConfig);
            unit.Initialize(health);
            return unit;
        }
    }
}

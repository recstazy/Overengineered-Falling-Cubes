using UnityEngine;

namespace FallingDamage
{
    [CreateAssetMenu(menuName = "Game/GameConfig", fileName = nameof(GameConfig), order = 131)]
    public class GameConfig : ScriptableObject, IGameConfiguration
    {
        [SerializeField]
        private Object unitFactory;

        [SerializeField]
        private Object wallFactory;

        [SerializeField]
        private Object projectileFactory;

        [SerializeField]
        private Bounds worldBounds;

        [SerializeField]
        private int initialUnitsCount;

        [SerializeField]
        private int initialWallsCount;

        [SerializeField]
        private int projectilesSpawnedPerSecond;

        public IFactory<Unit> UnitFactory => unitFactory as IFactory<Unit>;
        public IFactory<Wall> WallFactory => wallFactory as IFactory<Wall>;
        public IFactory<Projectile> ProjectileFactory => projectileFactory as IFactory<Projectile>;
        public Bounds RoomBounds => worldBounds;

        public int InitialUnitsCount => initialUnitsCount;
        public int InitialWallsCount => initialWallsCount;
        public int ProjectilesSpawnedPerSecond => projectilesSpawnedPerSecond;
    }
}

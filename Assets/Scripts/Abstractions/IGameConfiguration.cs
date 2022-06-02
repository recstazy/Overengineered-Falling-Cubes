using UnityEngine;

namespace FallingDamage
{
    public interface IGameConfiguration
    {
        IFactory<Unit> UnitFactory { get; }
        IFactory<Wall> WallFactory { get; }
        IFactory<Projectile> ProjectileFactory { get; }
        Bounds RoomBounds { get; }
        int InitialUnitsCount { get; }
        int InitialWallsCount { get; }
        int ProjectilesSpawnedPerSecond { get; }
    }
}

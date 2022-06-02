using UnityEngine;
using FallingCubes.Abstractions;

namespace FallingCubes.Core
{
    [CreateAssetMenu(menuName = "Game/Wall Factory", fileName = nameof(WallFactory), order = 131)]
    public class WallFactory : ScriptableObject, IFactory<Wall>
    {
        [SerializeField]
        private Wall wallPrefab;

        [SerializeField]
        private Vector2 minWallSize;

        [SerializeField]
        private Vector2 maxWallSize;

        [SerializeField]
        private Bounds wallSpawnBounds;

        public Wall Create()
        {
            var position = wallSpawnBounds.RandomPointInside();
            var wall = Instantiate(wallPrefab, position, Quaternion.identity, null);
            wall.SetSize(new Vector2(Random.Range(minWallSize.x, maxWallSize.x), Random.Range(minWallSize.y, maxWallSize.y)));
            return wall;
        }
    }
}

using UnityEngine;

namespace FallingCubes
{
    public static class MathExtensions
    {
        public static Vector3 RandomPointInside(this Bounds bounds)
        {
            var x = Random.Range(bounds.min.x, bounds.max.x);
            var y = Random.Range(bounds.min.y, bounds.max.y);
            var z = Random.Range(bounds.min.z, bounds.max.z);
            return new Vector3(x, y, z);
        }
    }
}

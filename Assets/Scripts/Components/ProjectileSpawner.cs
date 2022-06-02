using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace FallingCubes
{
    public class ProjectileSpawner : ISpawner
    {
        public int CountPerSecond { get; set; }
        public Bounds SpawnBounds { get; set; }
        public float SpawnForce { get; set; }

        private IPool<Projectile> pool;
        private CancellationToken cancellationToken;
        private CancellationTokenSource cancellationTokenSource;

        public ProjectileSpawner(IPool<Projectile> pool)
        {
            this.pool = pool;
            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;

            foreach (var instance in pool.AllInstances)
            {
                instance.gameObject.SetActive(false);
            }
        }

        public void StartSpawn()
        {
            SpawnLoop();
        }

        public void StopSpawn()
        {
            cancellationTokenSource.Cancel();
        }

        private async void SpawnLoop()
        {
            while (Application.isPlaying && !cancellationToken.IsCancellationRequested)
            {
                var instance = pool.GetAvailable();
                instance.transform.position = SpawnBounds.RandomPointInside();
                instance.gameObject.SetActive(true);
                instance.OnSleep += ProjectileSleep;
                ApplyProjectileForce(instance);
                await Task.Delay(Mathf.RoundToInt(1000f / CountPerSecond));
            }
        }

        private void ProjectileSleep(Projectile instance)
        {
            instance.OnSleep -= ProjectileSleep;
            instance.gameObject.SetActive(false);
            instance.ResetDamageStat();
            pool.ReturnToPool(instance);
        }

        private void ApplyProjectileForce(Projectile instance)
        {
            var randomVector = Random.onUnitSphere;
            // Get lower semisphere
            randomVector.y = -Mathf.Abs(randomVector.y);
            instance.Body.AddRelativeForce(randomVector * SpawnForce, ForceMode.Impulse);
            instance.Body.AddRelativeTorque(randomVector * SpawnForce, ForceMode.Impulse);
        }
    }
}

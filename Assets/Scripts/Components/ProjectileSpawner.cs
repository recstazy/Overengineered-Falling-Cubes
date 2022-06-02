using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace FallingDamage
{
    public class ProjectileSpawner : ISpawner
    {
        public int CountPerSecond { get; set; }
        public Bounds SpawnBounds { get; set; }

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
                instance.OnSleep += ProjectileReachedTarget;
                await Task.Delay(Mathf.RoundToInt(1000f / CountPerSecond));
            }
        }

        private void ProjectileReachedTarget(Projectile instance)
        {
            instance.OnSleep -= ProjectileReachedTarget;
            instance.gameObject.SetActive(false);
            pool.ReturnToPool(instance);
        }
    }
}

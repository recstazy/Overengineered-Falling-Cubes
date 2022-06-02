using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingDamage
{
    public interface ISpawner
    {
        int CountPerSecond { get; set; }
        void StartSpawn();
        void StopSpawn();
    }
}

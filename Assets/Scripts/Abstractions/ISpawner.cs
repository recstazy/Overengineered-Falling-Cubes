using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingCubes.Abstractions
{
    public interface ISpawner
    {
        int CountPerSecond { get; set; }
        void StartSpawn();
        void StopSpawn();
    }
}

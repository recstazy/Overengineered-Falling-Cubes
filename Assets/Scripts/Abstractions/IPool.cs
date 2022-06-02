using System.Collections.Generic;
using UnityEngine;

namespace FallingCubes
{
    public interface IPool<T> where T : Object
    {
        IReadOnlyCollection<T> AllInstances { get; }
        void InitializeWithCount(int initialObjectsCount);
        T GetAvailable();
        void ReturnToPool(T instance);
    }
}

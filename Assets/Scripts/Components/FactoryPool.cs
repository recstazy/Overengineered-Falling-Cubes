using System.Collections.Generic;
using UnityEngine;
using FallingCubes.Abstractions;

namespace FallingCubes.Core
{
    public class FactoryPool<T> : IPool<T> where T : Object
    {
        public IReadOnlyCollection<T> AllInstances => allInstanced.AsReadOnly();

        private IFactory<T> factory;
        private Stack<T> available;
        private List<T> allInstanced;

        public FactoryPool(IFactory<T> factory)
        {
            this.factory = factory;
            allInstanced = new List<T>();
            available = new Stack<T>();
        }

        public void InitializeWithCount(int initialObjectsCount)
        {
            for (int i = 0; i < initialObjectsCount; i++)
            {
                var instance = InstantiateNew();
                ReturnToPool(instance);
            }
        }

        public T GetAvailable()
        {
            if (available.TryPop(out var result))
                return result;

            return InstantiateNew();
        }

        public void ReturnToPool(T instance)
        {
            available.Push(instance);
        }

        private T InstantiateNew()
        {
            var instance = factory.Create();
            allInstanced.Add(instance);
            return instance;
        }
    }
}

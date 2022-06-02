using System;

namespace FallingCubes.Abstractions
{
    public interface IGameEndConditionWatcher : IDisposable
    {
        event Action OnGameEnded;
    }
}

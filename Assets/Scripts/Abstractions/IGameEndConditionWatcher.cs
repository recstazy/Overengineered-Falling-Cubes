using System;

namespace FallingCubes
{
    public interface IGameEndConditionWatcher : IDisposable
    {
        event Action OnGameEnded;
    }
}

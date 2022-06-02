using System;

namespace FallingDamage
{
    public interface IGameEndConditionWatcher : IDisposable
    {
        event Action OnGameEnded;
    }
}

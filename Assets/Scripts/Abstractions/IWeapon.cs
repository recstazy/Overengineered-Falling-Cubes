using FallingCubes.Stats.Abstract;

namespace FallingCubes.Abstractions
{
    public interface IWeapon : IDamaging, IOwnable
    {
        IStat<float> DamageStat { get; }
        void Initialize(IStat<float> damage);
    }
}

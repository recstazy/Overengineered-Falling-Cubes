namespace FallingCubes
{
    public interface IWeapon : IDamaging, IOwnable
    {
        IStat<float> DamageStat { get; }
        void Initialize(IStat<float> damage);
    }
}

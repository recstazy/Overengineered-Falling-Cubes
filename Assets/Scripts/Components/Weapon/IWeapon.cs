namespace FallingDamage
{
    public interface IWeapon : IDamaging, IOwnable
    {
        void Initialize(IStat<float> damage);
    }
}

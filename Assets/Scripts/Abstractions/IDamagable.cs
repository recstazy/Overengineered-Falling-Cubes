namespace FallingCubes.Abstractions
{
    public interface IDamagable : IOwnable
    {
        void TakeDamage(IDamaging damageCauser);
    }
}

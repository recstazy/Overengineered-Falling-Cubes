namespace FallingCubes
{
    public interface IDamagable : IOwnable
    {
        void TakeDamage(IDamaging damageCauser);
    }
}

namespace FallingDamage
{
    public interface IDamagable : IOwnable
    {
        void TakeDamage(IDamaging damageCauser);
    }
}

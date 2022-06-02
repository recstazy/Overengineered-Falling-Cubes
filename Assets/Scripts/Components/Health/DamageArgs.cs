using FallingCubes.Abstractions;

namespace FallingCubes
{
    public class DamageArgs
    {
        public float DamageReceived { get; private set; }
        public IDamagable Victim { get; private set; }
        public IDamaging DamageCauser { get; private set; }

        public DamageArgs(float damageReceived, IDamagable victim, IDamaging damageCauser)
        {
            DamageReceived = damageReceived;
            Victim = victim;
            DamageCauser = damageCauser;
        }
    }
}

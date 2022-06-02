using System;
using System.Collections.Generic;
using System.Linq;
using FallingCubes.Abstractions;

namespace FallingCubes.Core
{
    public class AllUnitsDeadGameEndConditionWatcher : IGameEndConditionWatcher
    {
        public event Action OnGameEnded;
        private List<Unit> units;

        public AllUnitsDeadGameEndConditionWatcher(IEnumerable<Unit> units)
        {
            this.units = units.ToList();

            foreach (var u in units)
            {
                u.HealthSystem.OnDeath += UnitDead;
            }
        }

        public void Dispose()
        {
            if (units != null)
            {
                foreach (var u in units)
                    u.HealthSystem.OnDeath -= UnitDead;

                units = null;
            }
        }

        private void UnitDead(DamageArgs args)
        {
            var unit = args.Victim.Owner as Unit;
            unit.HealthSystem.OnDeath -= UnitDead;
            units.Remove(unit);

            CheckIfGameEnded();
        }

        private void CheckIfGameEnded()
        {
            if (units.Count == 0)
                OnGameEnded?.Invoke();
        }
    }
}

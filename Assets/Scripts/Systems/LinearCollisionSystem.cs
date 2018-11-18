using System.Collections.Generic;
using Assets.Scripts.Components;
using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Events;

namespace Assets.Scripts.Core
{
    public class LinearCollisionSystem : BombCollisionSystem<LinearBombCollisionEvent,LinearDamageSourceComponent>
    {
        public LinearCollisionSystem(Context context) : base(context)
        {
        }

        protected override IList<IEntity> SelectDamagables(LinearDamageSourceComponent damageSource, LinearBombCollisionEvent contextEvent)
        {
            var damagables = base.SelectDamagables(damageSource, contextEvent);
            contextEvent.Entity.GetComponent<HealthComponent>()?.AddDelta(10);
            return damagables;
        }
    }
}
using System.Collections.Generic;
using Assets.Scripts.Components;
using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Events;
using Assets.Scripts.Logger;

namespace Assets.Scripts.Core
{
    public class FakeCollisionSystem : BombCollisionSystem<FakeBombCollisionEvent, FakeDamageSourceComponent>
    {
        public FakeCollisionSystem(Context context) : base(context)
        {
        }


        protected override void ApplyDamage(IEntity damagable, FakeDamageSourceComponent damageSource, FakeBombCollisionEvent collisionEvent)
        {
            if (damagable.GetComponent<HealthComponent>() == null)
                damagable.AddComponent(new HealthComponent(0));
        }

        protected override IList<IEntity> SelectDamagables(FakeDamageSourceComponent damageSource, FakeBombCollisionEvent contextEvent)
        {
            return new List<IEntity> { contextEvent.Entity };
        }
    }
}
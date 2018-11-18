using Assets.Scripts.Components;
using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Events;
using Assets.Scripts.Views;
using System;

namespace Assets.Scripts.Core
{
    public abstract class BombCreateSystem<TDamageSource, TSpawnBombEvent, TBombView, TCollisionEvent> : CreateSystem<TBombView, TSpawnBombEvent, TCollisionEvent>
        where TDamageSource : DamageSourceComponent
        where TSpawnBombEvent : SpawnBombAtPointEvent
        where TBombView : BombView
        where TCollisionEvent : BombCollisionEvent
    {
        protected abstract float DamagePower { get; }
        protected abstract float DamageRange { get; }

        private TDamageSource _damageComponent;

        protected override IEntity CreateEntity(TBombView colliderActionView)
        {
            var e = base.CreateEntity(colliderActionView);
            e.AddComponent(_damageComponent);
            AddAdditionalComponents(e);
            return e;
        }

        protected virtual void AddAdditionalComponents(IEntity entity)
        {
            // при желании можно налепить ещё тучу каких угодно компонентов уже относительно каждой конкретной реализации.
        }

        protected BombCreateSystem(Context context, IResourceProvider resourceProvider) : base(context, resourceProvider)
        {
            _damageComponent = CreateDamageComponent();
        }

        private TDamageSource CreateDamageComponent()
        {
            return (TDamageSource)Activator.CreateInstance(typeof(TDamageSource), DamagePower, DamageRange);
        }
    }
}
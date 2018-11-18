using Assets.Scripts.Components;
using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Events;
using Assets.Scripts.Logger;
using Assets.Scripts.Views;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class PlayerCreateSystem : CreateSystem<PlayerView, SpawnPlayerAtPointEvent, PlayerCollisionEvent>
    {
        public PlayerCreateSystem(Context context, IResourceProvider resourceProvider) : base(context, resourceProvider)
        {
        }

        protected override IEntity CreateEntity(PlayerView colliderActionView)
        {
            var e = base.CreateEntity(colliderActionView);
            var healthComponent = new HealthComponent(Random.Range(20, 50));
            ConditionalLogger.Log($"Create player with health <b> {healthComponent.CurrentHealth} </b>");
            e.AddComponent(healthComponent);
            return e;

        }
    }
}
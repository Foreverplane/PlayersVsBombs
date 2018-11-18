using System;
using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Events;
using Assets.Scripts.Logger;
using Assets.Scripts.Views;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public abstract class CreateSystem<TView, TSpawnEvent, TCollisionAction> : ContextSystem, IEventListenerSystem<TSpawnEvent>
        where TView : ColliderActionView
        where TSpawnEvent : SpawnEvent
        where TCollisionAction : CollisionEvent
    {

        private GameObject _viewResource;

        void IEventListenerSystem<TSpawnEvent>.OnEvent(TSpawnEvent contextEvent)
        {

            var colliderActionView = context.CreateView<TView>(_viewResource);
            ConditionalLogger.Log($"Get point in bounds of ground {contextEvent.SpawnPoint}");
            colliderActionView.transform.position = contextEvent.SpawnPoint;

            var entity = CreateEntity(colliderActionView);
            colliderActionView.SetAction(arg1 => SetOnCollisionAction(arg1, entity));
        }

        protected virtual IEntity CreateEntity(TView colliderActionView)
        {
            return context.CreateEntity(colliderActionView);
        }

        private void SetOnCollisionAction(Collision col, IEntity view)
        {
            var collisionEvent = (TCollisionAction)Activator.CreateInstance(typeof(TCollisionAction), col, view);
            context.FireEvent(collisionEvent);
        }


        protected CreateSystem(Context context, IResourceProvider resourceProvider) : base(context)
        {

            _viewResource = resourceProvider.GetResourceView<TView>().gameObject;
        }
    }
}
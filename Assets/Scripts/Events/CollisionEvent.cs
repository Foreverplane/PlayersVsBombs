using Assets.Scripts.Core.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public abstract class CollisionEvent
    {
        private readonly Collision _collision;
        private readonly IEntity _entity;
        public Collision Collision => _collision;
        public IEntity Entity => _entity;

        protected CollisionEvent(Collision collision, IEntity entity)
        {
            _collision = collision;
            _entity = entity;
        }
    }
}
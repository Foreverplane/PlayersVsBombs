using Assets.Scripts.Core.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public abstract class BombCollisionEvent : CollisionEvent
    {
        public BombCollisionEvent(Collision collision, IEntity entity) : base(collision, entity)
        {
        }
    }
}
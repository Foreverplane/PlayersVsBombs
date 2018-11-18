using Assets.Scripts.Core.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class PlayerCollisionEvent: CollisionEvent
    {
        public PlayerCollisionEvent(Collision collision, IEntity entity) : base(collision, entity)
        {
        }
    }
}
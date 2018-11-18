using Assets.Scripts.Core.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class LinearBombCollisionEvent : BombCollisionEvent
    {
        public LinearBombCollisionEvent(Collision collision, IEntity entity) : base(collision, entity)
        {
        }
    }
}
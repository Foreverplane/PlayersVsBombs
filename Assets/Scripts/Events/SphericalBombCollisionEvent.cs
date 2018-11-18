using Assets.Scripts.Core.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class SphericalBombCollisionEvent : BombCollisionEvent
    {
        public SphericalBombCollisionEvent(Collision collision, IEntity entity) : base(collision, entity)
        {
        }
    }
}
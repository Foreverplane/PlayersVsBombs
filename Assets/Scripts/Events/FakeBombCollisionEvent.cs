using Assets.Scripts.Core.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class FakeBombCollisionEvent : BombCollisionEvent
    {
        public FakeBombCollisionEvent(Collision collision, IEntity entity) : base(collision, entity)
        {
        }
    }
}
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class SpawnLinearBombAtPointEvent : SpawnBombAtPointEvent
    {
        public SpawnLinearBombAtPointEvent(Vector3 point) : base(point)
        {
        }
    }
}
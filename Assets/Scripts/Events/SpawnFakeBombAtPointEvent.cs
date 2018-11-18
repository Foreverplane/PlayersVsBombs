using UnityEngine;

namespace Assets.Scripts.Events
{
    public class SpawnFakeBombAtPointEvent : SpawnBombAtPointEvent
    {
        public SpawnFakeBombAtPointEvent(Vector3 point) : base(point)
        {
        }
    }
}
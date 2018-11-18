using UnityEngine;

namespace Assets.Scripts.Events
{
    public class SpawnPlayerAtPointEvent : SpawnEvent
    {
        public SpawnPlayerAtPointEvent(Vector3 point) : base(point)
        {
        }
    }
}
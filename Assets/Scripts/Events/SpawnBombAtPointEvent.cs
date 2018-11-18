using UnityEngine;

namespace Assets.Scripts.Events
{
    public abstract class SpawnBombAtPointEvent : SpawnEvent
    {
        public SpawnBombAtPointEvent(Vector3 point) : base(point)
        {
        }
    }
}
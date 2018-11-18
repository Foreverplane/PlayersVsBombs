using UnityEngine;

namespace Assets.Scripts.Events
{
    public class SpawnSphericalBombAtPointEvent : SpawnBombAtPointEvent
    {
        public SpawnSphericalBombAtPointEvent(Vector3 point) : base(point)
        {
        }
    }
}
using UnityEngine;

namespace Assets.Scripts.Events
{
    public abstract class SpawnEvent
    {
        private Vector3 _point;

        public Vector3 SpawnPoint => _point;

        public SpawnEvent(Vector3 point)
        {
            this._point = point;
        }
    }
}
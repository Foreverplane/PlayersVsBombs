using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class SphericalBombSpawnOverTimeSystem : BombSpawnOverTimeSystem<SpawnSphericalBombAtPointEvent>
    {
        public SphericalBombSpawnOverTimeSystem(Context context) : base(context)
        {
        }

        protected override int GetRandomSpawnTime()
        {
            return Random.Range(5, 10);
        }
    }
}
using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class LinearBombSpawnOverTimeSystem : BombSpawnOverTimeSystem<SpawnLinearBombAtPointEvent>
    {
        public LinearBombSpawnOverTimeSystem(Context context) : base(context)
        {
        }

        protected override int GetRandomSpawnTime()
        {
            return Random.Range(12, 15);
        }
    }
}
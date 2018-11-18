using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class FakeBombSpawnOverTimeSystem : BombSpawnOverTimeSystem<SpawnFakeBombAtPointEvent>
    {
        public FakeBombSpawnOverTimeSystem(Context context) : base(context)
        {
        }

        protected override int GetRandomSpawnTime()
        {
            return Random.Range(1, 20);
        }
    }
}
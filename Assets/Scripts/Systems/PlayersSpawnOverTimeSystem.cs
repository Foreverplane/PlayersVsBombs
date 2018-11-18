using Assets.Scripts.Events;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Core
{
    public class PlayersSpawnOverTimeSystem : SpawnOverTimeSystem<SpawnPlayerAtPointEvent>
    {

        public PlayersSpawnOverTimeSystem(Context context) : base(context)
        {
        }
        protected override int GetRandomSpawnTime()
        {
            return Random.Range(1, 5);
        }

    }
}
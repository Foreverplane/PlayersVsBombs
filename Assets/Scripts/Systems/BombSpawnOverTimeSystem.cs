using Assets.Scripts.Events;

namespace Assets.Scripts.Core
{
    public abstract class BombSpawnOverTimeSystem<TSpawnEvent> : SpawnOverTimeSystem<TSpawnEvent>
        where TSpawnEvent : SpawnBombAtPointEvent

    {
        protected BombSpawnOverTimeSystem(Context context) : base(context)
        {
        }
    }
}
using Assets.Scripts.Events;

namespace Assets.Scripts.Core
{
    public abstract class BombSpawnOnClickSystem<TSpawnEvent> : OnClickSystem<TSpawnEvent>
        where TSpawnEvent : SpawnBombAtPointEvent

    {
        protected BombSpawnOnClickSystem(Context context) : base(context)
        {
        }
    }
}
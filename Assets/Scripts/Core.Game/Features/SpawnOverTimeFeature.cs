namespace Assets.Scripts.Core
{
    public class SpawnOverTimeFeature : Feature
    {
        public SpawnOverTimeFeature(Context context) : base(context)
        {
            // стреляют ивентами для спавна игроков или бомб в псевдорандомных точках через рандомное время.
            AddSystem(new PlayersSpawnOverTimeSystem(context));
            AddSystem(new SphericalBombSpawnOverTimeSystem(context));
            AddSystem(new LinearBombSpawnOverTimeSystem(context));
            AddSystem(new FakeBombSpawnOverTimeSystem(context));
        }
    }
}
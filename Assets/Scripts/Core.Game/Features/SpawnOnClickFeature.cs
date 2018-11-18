namespace Assets.Scripts.Core
{
    public class SpawnOnClickFeature : Feature
    {
        public SpawnOnClickFeature(Context context) : base(context)
        {
            // стреляют ивентами для спавна бомб при нажатиях на 1,2,3 на клавиатуре и ивентом на спавн игрока по клику левой кнопкой мыши.
            AddSystem(new PlayerSpawnOnClickSystem(context));
            AddSystem(new SphericalBombOnClickSpawnSystem(context));
            AddSystem(new LinearBombOnClickSpawnSystem(context));
            AddSystem(new FakeBombOnClickSpawnSystem(context));
        }
    }
}
namespace Assets.Scripts.Core
{
    public class CreateFeature : Feature
    {
        public CreateFeature(Context context, IResourceProvider resourceProvider) : base(context)
        {
            // создают игроков/бомбы получив ивент. (ивент содержит в себе позицию для спавна)
            AddSystem(new PlayerCreateSystem(context, resourceProvider));
            AddSystem(new SphericalBombCreateSystem(context, resourceProvider));
            AddSystem(new LinearBombCreateSystem(context, resourceProvider));
            AddSystem(new FakeBombCreateSystem(context, resourceProvider));
        }
    }
}
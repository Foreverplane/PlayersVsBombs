namespace Assets.Scripts.Core
{
    public class LevelFeature : Feature
    {
        public LevelFeature(Context context, IResourceProvider resourceProvider) : base(context)
        {
            // просто грузит уровень
            AddSystem(new LevelLoadSystem(context,resourceProvider));  
        }
    }
}
using Assets.Scripts.Events;
using Assets.Scripts.Views;
using UnityEngine;

namespace Assets.Scripts.Core
{
  
    public class LevelLoadSystem : ContextSystem, IEventListenerSystem<StartGameEvent>
    {
        private readonly IResourceProvider _resourceProvider;
        private LevelView _level;

        public LevelLoadSystem(Context context, IResourceProvider resourceProvider) : base(context)
        {
            _resourceProvider = resourceProvider;
        }

        void IEventListenerSystem<StartGameEvent>.OnEvent(StartGameEvent contextEvent)
        {
            var levelGameObject = _resourceProvider.GetResourceView<LevelView>().gameObject;
            _level = context.CreateView<LevelView>(levelGameObject);
            _level.GetViews<View>().ForEach(_=>_.Initialize(context));
        }
    }
}
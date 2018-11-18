

using Assets.Scripts.Events;
using Assets.Scripts.Game.Core;
using Assets.Scripts.Logger;
using UnityEngine;

namespace Assets.Scripts.Core
{
    // Инишалайзит зависимости и прокидывает их в контекст.
    internal static class GameController
    {
        private static Context _context;
        private static IResourceProvider _resourceProvider;       

        static GameController()
        {
            ConditionalLogger.Initialize(new UnityLogger());
            _resourceProvider = Resources.Load(nameof(ViewsLibrary)) as ViewsLibrary;
            _context = new GameContext(_resourceProvider);

        }

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            ConditionalLogger.Log("<color=green><b>Initialize!</b></color>");
            _context.CreateFeatures();
            _context.Initialize();
            _context.FireEvent(new StartGameEvent());

        }

    }
}
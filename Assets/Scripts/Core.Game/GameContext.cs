using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Core;

namespace Assets.Scripts.Game.Core
{
    public class GameContext : Context
    {
        private IResourceProvider _resourceProvider;

        public GameContext(IResourceProvider resourceProvider)
        {
            _resourceProvider = resourceProvider;
           
        }


        // создаёт фичи, что в свою очередь уже заполняют контекст системами.
        public override void CreateFeatures()
        {
#pragma warning disable RECS0026 // Possible unassigned object created by 'new' (фичи нужны просто для группирования систем)
            new LevelFeature(this, _resourceProvider);
            new SpawnOverTimeFeature(this);
            new SpawnOnClickFeature(this);
            new CreateFeature(this, _resourceProvider);
            new DamageFeature(this);
#pragma warning restore RECS0026 // Possible unassigned object created by 'new'
        }
    }
}

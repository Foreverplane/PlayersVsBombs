using Assets.Scripts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Components
{
    public abstract class DamageSourceComponent : IComponent
    {
        public readonly float power;
        public readonly float range;

        
        protected DamageSourceComponent(float power, float range)
        {
            this.power = power;
            this.range = range;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Components;
using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Events;
using Assets.Scripts.Logger;
using Assets.Scripts.ViewComponents;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class SphericalCollisionSystem : BombCollisionSystem<SphericalBombCollisionEvent, SphericalDamageSourceComponent>
    {


        public SphericalCollisionSystem(Context context) : base(context)
        {
        }
      


    }
}
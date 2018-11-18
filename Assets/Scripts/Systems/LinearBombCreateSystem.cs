using Assets.Scripts.Components;
using Assets.Scripts.Events;
using Assets.Scripts.Views;

namespace Assets.Scripts.Core
{
    public class LinearBombCreateSystem : BombCreateSystem<LinearDamageSourceComponent,SpawnLinearBombAtPointEvent,LinearBombView,LinearBombCollisionEvent>
    {
        public LinearBombCreateSystem(Context context, IResourceProvider resourceProvider) : base(context, resourceProvider)
        {
        }

        protected override float DamagePower => 10;
        protected override float DamageRange => 100;
    }
}
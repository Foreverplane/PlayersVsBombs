using Assets.Scripts.Components;
using Assets.Scripts.Events;
using Assets.Scripts.Views;

namespace Assets.Scripts.Core
{
    public class SphericalBombCreateSystem : BombCreateSystem<SphericalDamageSourceComponent,SpawnSphericalBombAtPointEvent,SphericalBombView,SphericalBombCollisionEvent>
    {
        public SphericalBombCreateSystem(Context context, IResourceProvider resourceProvider) : base(context, resourceProvider)
        {
    
        }

        protected override float DamagePower => 100;
        protected override float DamageRange => 50;
    }
}
using Assets.Scripts.Components;
using Assets.Scripts.Events;
using Assets.Scripts.Views;

namespace Assets.Scripts.Core
{
    public class FakeBombCreateSystem : BombCreateSystem<FakeDamageSourceComponent,SpawnFakeBombAtPointEvent,FakeBombView,FakeBombCollisionEvent>
    {
        public FakeBombCreateSystem(Context context, IResourceProvider resourceProvider) : base(context, resourceProvider)
        {
        }

        protected override float DamagePower => 100;
        protected override float DamageRange => 10;
    }
}
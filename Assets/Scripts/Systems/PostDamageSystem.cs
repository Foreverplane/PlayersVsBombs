using Assets.Scripts.Components;
using Assets.Scripts.Events;

namespace Assets.Scripts.Core
{
    public class PostDamageSystem: ContextSystem, IEventListenerSystem<AfterDamageEvent>
    {
        public void OnEvent(AfterDamageEvent contextEvent)
        {
            var entitiesWithHelath = context.GetEntitiesWithComponents(typeof(HealthComponent));
            foreach (var e in entitiesWithHelath)
            {
                var health = e.GetComponent<HealthComponent>();
                if (health.CurrentHealth <= 0)
                {
                    context.RemoveView(e.GetComponent<View>());
                    context.RemoveEntity(e);
                }
                
            }
        }

        public PostDamageSystem(Context context) : base(context)
        {
        }
    }
}
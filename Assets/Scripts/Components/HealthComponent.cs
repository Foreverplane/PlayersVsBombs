using Assets.Scripts.Core.Interfaces;

namespace Assets.Scripts.Components
{
    public class HealthComponent : IComponent
    {
        private readonly float _initialHealth;
        private float _deltaHealth;
        public float CurrentHealth => _initialHealth + _deltaHealth;

        public HealthComponent(float initialHealth)
        {
            _initialHealth = initialHealth;
        }

        public void AddDelta(float delta)
        {
            _deltaHealth += delta;
        }
        
    }
}
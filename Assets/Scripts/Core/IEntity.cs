using System;

namespace Assets.Scripts.Core.Interfaces
{
    public interface IEntity
    {
        T GetComponent<T>() where T : IComponent;
        void AddComponent(IComponent component);
        bool HaveComponents(Type[] types);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Logger;

namespace Assets.Scripts.Core
{
    class Entity : IEntity
    {
        private List<IComponent> _components;

        public Entity()
        {
            _components = new List<IComponent>();
        }

        public Entity(params IComponent[] components)
        {
            _components = components.ToList();

        }

        public T GetComponent<T>() where T : IComponent
        {
            for (var index = 0; index < _components.Count; index++)
            {
                var c = _components[index];
                if (c is T)
                    return (T)c;
            }

            return default(T);
        }

        public void AddComponent(IComponent component)
        {
            _components.Add(component);
        }

        public bool HaveComponents(params Type[] types)
        {

            return _components.Any(_ => types.Contains(_.GetType()));
        }
    }
}

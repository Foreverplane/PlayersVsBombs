using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Logger;
using Assets.Scripts.Systems.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public abstract class Context
    {
        private List<IEntity> _entities;
        private List<ContextSystem> _systems;
        private HashSet<View> _views;

        protected Context()
        {
            _entities = new List<IEntity>();
            _systems = new List<ContextSystem>();
            _views = new HashSet<View>();
            ConditionalLogger.Log($"<b>{GetType().Name}</b> has been created!");
        }

        public void AddSystem(ContextSystem s)
        {
            _systems.Add(s);
        }
        public void AddView(View view)
        {
            _views.Add(view);
        }
        public IEntity CreateEntity(params IComponent[] components)
        {
            var e = new Entity(components);
            _entities.Add(e);
            return e;
        }

        public abstract void CreateFeatures();
        public T CreateView<T>(GameObject viewOnGameObject) where T : View
        {
            var obj = UnityEngine.Object.Instantiate(viewOnGameObject);
            var view = obj.GetComponent<T>();
            view.Initialize(this);
            ConditionalLogger.Log($"{view.GetType().Name} has been instantiated!");
            return view;
        }
        public T GetView<T>() where T : View
        {
            foreach (var view in _views)
            {
                if (view is T)
                    return view as T;
            }
            ConditionalLogger.LogError($"Cant get <color=red><b> {typeof(T).Name}</b></color>");
            return null;
        }
        public void RemoveEntity(IEntity e)
        {
            _entities.Remove(e);
        }
        public void RemoveSystem(ContextSystem s)
        {
            _systems.Remove(s);
        }
        public void RemoveView(View view)
        {
            _views.Remove(view);
            UnityEngine.Object.Destroy(view.gameObject);
        }
        public void FireEvent<T>(T contextEvent)
        {
            ConditionalLogger.Log($"<b>{contextEvent.GetType().Name}</b> fired!");
            for (var index = 0; index < _systems.Count; index++)
            {
                var system = _systems[index];
                var s = system as IEventListenerSystem<T>;
                s?.OnEvent(contextEvent);
            }
        }

        public IEnumerable<IEntity> GetEntitiesWithComponents(params Type[] types)
        {
            return _entities.Where(_ => _.HaveComponents(types)).ToList();
        }
        public void Initialize()
        {
            for (var index = 0; index < _systems.Count; index++)
            {
                var system = _systems[index];
                var s = system as IInitializableSystem; // что-то даже не пригодился.
                s?.Initialize();
            }
        }
    }
}
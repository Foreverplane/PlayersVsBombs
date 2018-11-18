using System;
using Assets.Scripts.Events;
using Assets.Scripts.Extensions;
using Assets.Scripts.Logger;
using Assets.Scripts.Views;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;
// ReSharper disable NotAccessedField.Local

namespace Assets.Scripts.Core
{
    public abstract class SpawnOverTimeSystem<TSpawnEvent> : ContextSystem, IEventListenerSystem<StartGameEvent>
        where TSpawnEvent : SpawnEvent
    {
        private LevelView _levelView;
        #pragma warning disable 0414
        private Tween _spawnTween;

        private SpawnAreaView _spawnAreaView;
        private Bounds _spawnAreaBounds;

        void IEventListenerSystem<StartGameEvent>.OnEvent(StartGameEvent contextEvent)
        {
            _levelView = context.GetView<LevelView>();
            if (_levelView == null)
            {
                ConditionalLogger.LogError("Fatal error because there is no level view!");
                return;
            }

            _spawnAreaView = context.GetView<SpawnAreaView>();
            _spawnAreaBounds = _spawnAreaView.Collider.bounds;
            ConditionalLogger.Log($"Bounds of level {_levelView.gameObject.name} is {_spawnAreaBounds.size}");
            StartSpawn();
        }

        private void StartSpawn()
        {
            _spawnTween = DOVirtual.DelayedCall(GetRandomSpawnTime(), Spawn).OnComplete(StartSpawn);
        }

        protected virtual int GetRandomSpawnTime()
        {
            return Random.Range(1, 5);
        }

        private void Spawn()
        {

            var randomPointInsideBox = GeometryExtensions.RandomPointInBox(_spawnAreaBounds.center, _spawnAreaBounds.size);
            FireSpawnEvent(randomPointInsideBox);

        }

        private void FireSpawnEvent(Vector3 randomPointInsideBox)
        {
            var spawnEvent = GetSpawnEvent(randomPointInsideBox);
            context.FireEvent(spawnEvent);
        }

        protected  virtual TSpawnEvent GetSpawnEvent(Vector3 randomPointInsideBox)
        {
            // активатор, да ещё и с параметрами для конструктора, долгая штука, но как вариант. всегда можно убрать дженерик и заоверрайдить в наследнике создание уже конкретного экземпляра ивента для спавна.
            return (TSpawnEvent)Activator.CreateInstance(typeof(TSpawnEvent), randomPointInsideBox);
             
        }

        protected SpawnOverTimeSystem(Context context) : base(context)
        {
        }
    }
}